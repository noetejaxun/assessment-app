using AssessmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessmentApp.Interfaces
{
    public interface IAssessmentQuestionService
    {
        Task<AssessmentQuestionModel> CreateAsync(AssessmentQuestionModel iAssessmentQuestion);
        Task<IEnumerable<AssessmentQuestionModel>> GetAsync();
        Task UpdateAsync(AssessmentQuestionModel iAssessmentQuestion);
        Task DeleteAsync(AssessmentQuestionModel iAssessmentQuestion);
    }
}
