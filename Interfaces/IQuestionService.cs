using AssessmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessmentApp.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionModel> CreateAsync(QuestionModel iQuestion);
        Task<IEnumerable<QuestionModel>> GetAsync();
        Task UpdateAsync(QuestionModel iQuestion);
        Task DeleteAsync(QuestionModel iQuestion);
    }
}
