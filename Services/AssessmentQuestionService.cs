using AssessmentApp.Context;
using AssessmentApp.Interfaces;
using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApp.Services
{
    public class AssessmentQuestionService : IAssessmentQuestionService
    {

        private readonly ModelContext _context;

        public AssessmentQuestionService(ModelContext context)
        {
            _context = context;
        }

        public async Task<AssessmentQuestionModel> CreateAsync(AssessmentQuestionModel iAssessmentQuestion)
        {
            var assessmentQuestion = new AssessmentQuestionModel()
            {
                AssessmentId = iAssessmentQuestion.AssessmentId,
                QuestionId = iAssessmentQuestion.QuestionId,
                Points = iAssessmentQuestion.Points
            };

            var result = await _context.AssessmentQuestions.AddAsync(assessmentQuestion);
            await _context.SaveChangesAsync();

            return new AssessmentQuestionModel()
            {
                AssessmentId = result.Entity.AssessmentId,
                QuestionId = result.Entity.QuestionId,
                Points = result.Entity.Points
            };
        }

        public async Task DeleteAsync(AssessmentQuestionModel iAssessmentQuestion)
        {
            var entity = _context.AssessmentQuestions
                         .FirstOrDefault(item => item.AssessmentId == iAssessmentQuestion.AssessmentId && 
                                                 item.QuestionId == iAssessmentQuestion.QuestionId);

            if (entity != null)
            {
                _context.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AssessmentQuestionModel>> GetAsync()
        {
            var entities = await _context.AssessmentQuestions.ToListAsync();

            return entities.Select(entity => new AssessmentQuestionModel()
            {
                AssessmentId = entity.AssessmentId,
                QuestionId = entity.QuestionId,
                Points = entity.Points
            });
        }

        public async Task UpdateAsync(AssessmentQuestionModel iAssessmentQuestion)
        {
            var entity = _context.AssessmentQuestions
                         .FirstOrDefault(item => item.AssessmentId == iAssessmentQuestion.AssessmentId &&
                                                 item.QuestionId == iAssessmentQuestion.QuestionId);

            if (entity != null)
            {
                entity.AssessmentId = iAssessmentQuestion.AssessmentId;
                entity.QuestionId = iAssessmentQuestion.QuestionId;
                entity.Points = iAssessmentQuestion.Points;

                await _context.SaveChangesAsync();
            }
        }
    }
}
