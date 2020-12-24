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
    public class QuestionService : IQuestionService
    {
        private readonly ModelContext _context;

        public QuestionService(ModelContext context)
        {
            _context = context;
        }

        public async Task<QuestionModel> CreateAsync(QuestionModel iQuestion)
        {
            var question = new QuestionModel()
            {
                QuestionId = Guid.NewGuid(),
                Question = iQuestion.Question,
                QuestionTypeId = iQuestion.QuestionTypeId,
                Disabled = iQuestion.Disabled
            };

            var result = await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();

            return new QuestionModel()
            {
                QuestionId = result.Entity.QuestionId,
                Question = result.Entity.Question,
                QuestionTypeId = result.Entity.QuestionTypeId,
                Disabled = result.Entity.Disabled
            };
        }

        public async Task DeleteAsync(QuestionModel iQuestion)
        {
            var entity = _context.Questions
                         .FirstOrDefault(item => item.QuestionId == iQuestion.QuestionId);

            if (entity != null)
            {
                _context.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<QuestionModel>> GetAsync()
        {
            var entities = await _context.Questions.ToListAsync();

            return entities.Select(entity => new QuestionModel()
            {
                QuestionId = entity.QuestionId,
                Question = entity.Question,
                QuestionTypeId = entity.QuestionTypeId,
                Disabled = entity.Disabled
            });
        }

        public async Task UpdateAsync(QuestionModel iQuestion)
        {
            var entity = _context.Questions
                         .FirstOrDefault(item => item.QuestionId == iQuestion.QuestionId);

            if (entity != null)
            {
                entity.QuestionId = iQuestion.QuestionId;
                entity.Question = iQuestion.Question;
                entity.QuestionTypeId = iQuestion.QuestionTypeId;
                entity.Disabled = iQuestion.Disabled;

                await _context.SaveChangesAsync();
            }
        }
    }
}
