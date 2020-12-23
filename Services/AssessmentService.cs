using AssessmentApp.Context;
using AssessmentApp.Interfaces;
using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApp.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly DemoContext _context;

        public AssessmentService(DemoContext context)
        {
            _context = context;
        }

        public async Task<AssessmentModel> CreateAsync(AssessmentModel IAssessment)
        {
            var assessment = new AssessmentModel()
            {
                AssessmentId = Guid.NewGuid(),
                Description = IAssessment.Description,
                StartDate = IAssessment.StartDate,
                DueDate = IAssessment.DueDate,
                Disabled = IAssessment.Disabled,
                TotalPoints = IAssessment.TotalPoints
            };

            var result = await _context.Assessments.AddAsync(assessment);
            await _context.SaveChangesAsync();

            return new AssessmentModel()
            {
                AssessmentId = result.Entity.AssessmentId,
                Description = result.Entity.Description,
                StartDate = result.Entity.StartDate,
                DueDate = result.Entity.DueDate,
                Disabled = result.Entity.Disabled,
                TotalPoints = result.Entity.TotalPoints
            };
        }

        public async Task DeleteAsync(AssessmentModel IAssessment)
        {
            var entity = _context.Assessments.FirstOrDefault(item => item.AssessmentId == IAssessment.AssessmentId);

            if (entity != null)
            {
                _context.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AssessmentModel>> GetAsync()
        {
            var entities = await _context.Assessments.ToListAsync();

            return entities.Select(entity => new AssessmentModel()
            {
                AssessmentId = entity.AssessmentId,
                Description = entity.Description,
                StartDate = entity.StartDate,
                DueDate = entity.DueDate,
                Disabled = entity.Disabled,
                TotalPoints = entity.TotalPoints
            });
        }

        public async Task UpdateAsync(AssessmentModel IAssessment)
        {
            var entity = _context.Assessments.FirstOrDefault(item => item.AssessmentId == IAssessment.AssessmentId);

            if (entity != null)
            {
                entity.AssessmentId = IAssessment.AssessmentId;
                entity.Description = IAssessment.Description;
                entity.StartDate = IAssessment.StartDate;
                entity.DueDate = IAssessment.DueDate;
                entity.Disabled = IAssessment.Disabled;
                entity.TotalPoints = IAssessment.TotalPoints;

                await _context.SaveChangesAsync();
            }
        }
    }
}
