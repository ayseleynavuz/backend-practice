using backend_practice.Dto;
using backend_practice.Entities;

namespace backend_practice.Services
{
    public interface ICarService
    {
        Task AddCar(Car car);
        Task DeleteCar(int carId);
        Task<List<CarDto>> GetCarsByColor(int colorId);
        Task UpdateCarHeadlight(int carId); //farları aç-kapa 

    }
}
