using AssessmentApp.Context;
using AssessmentApp.Interfaces;
using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentApp.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly ModelContext _context;

        public QuestionTypeService(ModelContext context)
        {
            _context = context;
        }

        public async Task<QuestionTypeModel> CreateAsync(QuestionTypeModel iQuestionType)
        {
            var questionType = new QuestionTypeModel()
            {
                QuestionTypeId = Guid.NewGuid(),
                Description = iQuestionType.Description,
                Disabled = iQuestionType.Disabled
            };

            var result = await _context.QuestionTypes.AddAsync(questionType);
            await _context.SaveChangesAsync();

            return new QuestionTypeModel()
            {
                QuestionTypeId = result.Entity.QuestionTypeId,
                Description = result.Entity.Description,
                Disabled = result.Entity.Disabled
            };
        }

        public async Task DeleteAsync(QuestionTypeModel iQuestionType)
        {
            var entity = _context.QuestionTypes
                         .FirstOrDefault(item => item.QuestionTypeId == iQuestionType.QuestionTypeId);

            if (entity != null)
            {
                _context.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<QuestionTypeModel>> GetAsync()
        {
            var entities = await _context.QuestionTypes.ToListAsync();

            return entities.Select(entity => new QuestionTypeModel()
            {
                QuestionTypeId = entity.QuestionTypeId,
                Description = entity.Description,
                Disabled = entity.Disabled
            });
        }

        public async Task UpdateAsync(QuestionTypeModel iQuestionType)
        {
            var entity = _context.QuestionTypes
                         .FirstOrDefault(item => item.QuestionTypeId == iQuestionType.QuestionTypeId);

            if (entity != null)
            {
                entity.QuestionTypeId = iQuestionType.QuestionTypeId;
                entity.Description = iQuestionType.Description;
                entity.Disabled = iQuestionType.Disabled;

                await _context.SaveChangesAsync();
            }
        }
    }
}
