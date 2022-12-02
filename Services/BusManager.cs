using backend_practice.Dto;
using backend_practice.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace backend_practice.Services
{
    public class BusManager : IBusService
    {
        private readonly CarDbContext _dbContext;
        public BusManager(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteBus(int busId)
        {
            var bus = await _dbContext.Buses.FindAsync(busId);

            _dbContext.Buses.Remove(bus);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<BusDto>> GetBusesByColor(int colorId)
        {
            var result = await _dbContext.Buses
                .Include(x => x.Color)
                .Where(x => x.ColorId == colorId)
                .Select(x => new BusDto
                {
                    Name = x.BusName,
                    ColorName = x.Color.ColorName
                }).ToListAsync();

            return result;
        }
    }
}
