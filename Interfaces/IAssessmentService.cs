using AssessmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessmentApp.Interfaces
{
    public interface IAssessmentService
    {
        Task<AssessmentModel> CreateAsync(AssessmentModel iAssessment);
        Task<IEnumerable<AssessmentModel>> GetAsync();
        Task UpdateAsync(AssessmentModel iAssessment);
        Task DeleteAsync(AssessmentModel iAssessment);
    }
}
