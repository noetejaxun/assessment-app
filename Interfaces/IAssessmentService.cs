using AssessmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessmentApp.Interfaces
{
    public interface IAssessmentService
    {
        Task<AssessmentModel> CreateAsync(AssessmentModel IAssessment);
        Task<IEnumerable<AssessmentModel>> GetAsync();
        Task UpdateAsync(AssessmentModel IAssessment);
        Task DeleteAsync(AssessmentModel IAssessment);
    }
}
