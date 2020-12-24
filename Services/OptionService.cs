using AssessmentApp.Interfaces;
using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApp.Context
{
    public class OptionService : IOptionService
    {
        private readonly ModelContext _context;

        public OptionService(ModelContext context)
        {
            _context = context;
        }

        public async Task<OptionModel> CreateAsync(OptionModel iOption)
        {
            var option = new OptionModel()
            {
                OptionId = Guid.NewGuid(),
                Description = iOption.Description,
                Answer = iOption.Answer,
                Disabled = iOption.Disabled
            };

            var result = await _context.Options.AddAsync(option);
            await _context.SaveChangesAsync();

            return new OptionModel()
            {
                OptionId = result.Entity.OptionId,
                Description = result.Entity.Description,
                Answer = result.Entity.Answer,
                Disabled = result.Entity.Disabled
            };
        }

        public async Task DeleteAsync(OptionModel iOption)
        {
            var entity = _context.Options
                         .FirstOrDefault(item => item.OptionId == iOption.OptionId);

            if (entity != null)
            {
                _context.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OptionModel>> GetAsync()
        {
            var entities = await _context.Options.ToListAsync();

            return entities.Select(entity => new OptionModel()
            {
                OptionId = entity.OptionId,
                Description = entity.Description,
                Answer = entity.Answer,
                Disabled = entity.Disabled
            });
        }

        public async Task UpdateAsync(OptionModel iOption)
        {
            var entity = _context.Options
                         .FirstOrDefault(item => item.OptionId == iOption.OptionId);

            if (entity != null)
            {
                entity.OptionId = iOption.OptionId;
                entity.Description = iOption.Description;
                entity.Answer = iOption.Answer;
                entity.Disabled = iOption.Disabled;

                await _context.SaveChangesAsync();
            }
        }
    }
}
