using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateStockAsync(CreateStockRequestDto stock)
        {
            var stockAdd = stock.ToStockFromCreateDto();
            await _context.Stocks.AddAsync(stockAdd);
            await _context.SaveChangesAsync();
            return stockAdd;
        }

        public async Task<Stock?> DeleteStockAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(s => s.Comments).AsQueryable();
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Search))
                    stocks = stocks.Where(s => s.Symbol.Contains(query.Search) || s.CompanyName.Contains(query.Search));
                if (query.SortBy == "symbol")
                    stocks = query.IsSortAscending ? stocks.OrderBy(s => s.Symbol) : stocks.OrderByDescending(s => s.Symbol);
                if (query.SortBy == "companyName")
                    stocks = query.IsSortAscending ? stocks.OrderBy(s => s.CompanyName) : stocks.OrderByDescending(s => s.CompanyName);
            }
            return await stocks.ToListAsync();
        }

        public async Task<Stock?> UpdateStockAsync(int id, UpdateStockRequestDto stock)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.Symbol = stock.Symbol;
            existingStock.CompanyName = stock.CompanyName;
            existingStock.Purchase = stock.Purchase;
            existingStock.LastDiv = stock.LastDiv;
            existingStock.Industry = stock.Industry;
            existingStock.MarketCap = stock.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;
        }

        public async Task<Stock?> GetStockByIdAsync(int id)
        {
            var existingStock = await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            return existingStock;
        }

        public async Task<bool> StockExists(int id)
        {
            return await _context.Stocks.AnyAsync(x => x.Id == id);
        }
    }
}