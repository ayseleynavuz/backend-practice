using backend_practice.Dto;
using backend_practice.Entities;
using backend_practice.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace backend_practice.Services
{
    public class CarManager : ICarService
    {
        private readonly CarDbContext _dbContext;

        public CarManager(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task UpdateCarHeadlight(int carId) 
        {
            var car = await _dbContext.Cars.FindAsync(carId);
            car.activeHeadlight = true;

            await _dbContext.SaveChangesAsync();

        }

        public async Task AddCar(Car car)
        {
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCar(int carId)
        {
            var car = await _dbContext.Cars.FindAsync(carId);

            _dbContext.Cars.Remove(car);

            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<CarDto>> GetCarsByColor(int colorId)
        {
            var result = await _dbContext.Cars
                .Include(x => x.Color)
                .Where(x => x.ColorId == colorId)
                .Select(x => new CarDto
                {
                    Name = x.CarName,
                    ColorName = x.Color.ColorName
                }).ToListAsync();

            return result;
        }

    }
}
