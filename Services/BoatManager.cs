using backend_practice.Dto;
using backend_practice.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace backend_practice.Services
{
    public class BoatManager : IBoatService
    {
        private readonly CarDbContext _dbContext;
        public BoatManager(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BoatDto>> GetBoatsByColor(int colorId)
        {
            var result = await _dbContext.Boats
                .Include(x => x.Color)
                .Where(x => x.ColorId == colorId)
                .Select(x => new BoatDto
                {
                    Name = x.BoatName,
                    ColorName = x.Color.ColorName
                }).ToListAsync();

            return result;
        }
    }
}
