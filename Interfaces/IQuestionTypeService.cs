using AssessmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessmentApp.Interfaces
{
    public interface IQuestionTypeService
    {
        Task<QuestionTypeModel> CreateAsync(QuestionTypeModel iQuestionType);
        Task<IEnumerable<QuestionTypeModel>> GetAsync();
        Task UpdateAsync(QuestionTypeModel iQuestionType);
        Task DeleteAsync(QuestionTypeModel iQuestionType);
    }
}
