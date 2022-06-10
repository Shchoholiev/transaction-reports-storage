using TransactionReportsStorage.Application.Interfaces;
using TransactionReportsStorage.Application.Interfaces.Repositories;
using TransactionReportsStorage.Application.Mapping;
using TransactionReportsStorage.Application.Models.DTO;
using TransactionReportsStorage.Application.Paging;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.Infrastructure.Services
{
    public class RecordsService : IRecordsService
    {
        private readonly IGenericRepository<Record> _recordsRepository;

        private readonly Mapper _mapper = new();

        public RecordsService(IGenericRepository<Record> recordsRepository)
        {
            this._recordsRepository = recordsRepository;
        }

        public async Task<PagedList<RecordDto>> GetPageAsync(PageParameters pageParameters, string? cellName, 
                                                             DateOnly? startDate, DateOnly? endDate)
        {
            var records = await this._recordsRepository
                                    .GetPageAsync(pageParameters,
                                                  r => r.Cell.Name == cellName
                                                  && DateOnly.FromDateTime(r.DateTime) >= startDate
                                                  && DateOnly.FromDateTime(r.DateTime) <= endDate,
                                                  r => r.Cell, r => r.User);
            var dtos = this._mapper.Map(records);

            return dtos;
        }
    }
}
