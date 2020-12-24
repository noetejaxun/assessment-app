using AssessmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessmentApp.Interfaces
{
    public interface IQuestionOptionService
    {
        Task<QuestionOptionModel> CreateAsync(QuestionOptionModel iQuestionOption);
        Task<IEnumerable<QuestionOptionModel>> GetAsync();
        Task UpdateAsync(QuestionOptionModel iQuestionOption);
        Task DeleteAsync(QuestionOptionModel iQuestionOption);
    }
}
