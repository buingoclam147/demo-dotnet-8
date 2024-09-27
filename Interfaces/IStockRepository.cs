using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject search);
        Task<Stock?> GetStockByIdAsync(int id);
        Task<Stock> CreateStockAsync(CreateStockRequestDto stock);
        Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto stock);
        Task<Stock?> DeleteStockAsync(int id);

        Task<bool> StockExists(int id);

    }
}