using backend_practice.Dto;
using backend_practice.Entities;

namespace backend_practice.Services
{
    public interface IBusService
    {
        Task<List<BusDto>> GetBusesByColor(int colorId);
        Task DeleteBus(int busId);

    }
}
