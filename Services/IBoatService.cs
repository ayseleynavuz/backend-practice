using backend_practice.Dto;

namespace backend_practice.Services
{
    public interface IBoatService
    {
        Task<List<BoatDto>> GetBoatsByColor(int colorId);
    }
}
