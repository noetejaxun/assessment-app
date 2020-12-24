using AssessmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssessmentApp.Interfaces
{
    public interface IOptionService
    {
        Task<OptionModel> CreateAsync(OptionModel iOption);
        Task<IEnumerable<OptionModel>> GetAsync();
        Task UpdateAsync(OptionModel iOption);
        Task DeleteAsync(OptionModel iOption);
    }
}
