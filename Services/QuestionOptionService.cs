using AssessmentApp.Context;
using AssessmentApp.Interfaces;
using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApp.Services
{
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly ModelContext _context;

        public QuestionOptionService(ModelContext context)
        {
            _context = context;
        }

        public async Task<QuestionOptionModel> CreateAsync(QuestionOptionModel iQuestionOption)
        {
            var questionOption = new QuestionOptionModel()
            {
                QuestionId = iQuestionOption.QuestionId,
                OptionId = iQuestionOption.OptionId,
                IsCorrect = iQuestionOption.IsCorrect,
                Points = iQuestionOption.Points
            };

            var result = await _context.QuestionOptions.AddAsync(questionOption);
            await _context.SaveChangesAsync();

            return new QuestionOptionModel()
            {
                QuestionId = result.Entity.QuestionId,
                OptionId = result.Entity.OptionId,
                IsCorrect = result.Entity.IsCorrect,
                Points = result.Entity.Points
            };
        }

        public async Task DeleteAsync(QuestionOptionModel iQuestionOption)
        {
            var entity = _context.QuestionOptions
                         .FirstOrDefault(item => item.QuestionId == iQuestionOption.QuestionId &&
                                                 item.OptionId == iQuestionOption.QuestionId);

            if (entity != null)
            {
                _context.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<QuestionOptionModel>> GetAsync()
        {
            var entities = await _context.QuestionOptions.ToListAsync();

            return entities.Select(entity => new QuestionOptionModel()
            {
                QuestionId = entity.QuestionId,
                OptionId = entity.OptionId,
                IsCorrect = entity.IsCorrect,
                Points = entity.Points
            });
        }

        public async Task UpdateAsync(QuestionOptionModel iQuestionOption)
        {
            var entity = _context.QuestionOptions
                         .FirstOrDefault(item => item.QuestionId == iQuestionOption.QuestionId &&
                                                 item.OptionId == iQuestionOption.QuestionId);

            if (entity != null)
            {
                entity.QuestionId = iQuestionOption.QuestionId;
                entity.OptionId = iQuestionOption.OptionId;
                entity.IsCorrect = iQuestionOption.IsCorrect;
                entity.Points = iQuestionOption.Points;

                await _context.SaveChangesAsync();
            }
        }
    }
}
