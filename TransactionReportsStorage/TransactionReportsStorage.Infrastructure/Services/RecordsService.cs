using Microsoft.Extensions.Logging;
using TransactionReportsStorage.App.Interfaces;
using TransactionReportsStorage.App.Interfaces.Repositories;
using TransactionReportsStorage.App.Mapping;
using TransactionReportsStorage.App.Models.DisplayDto;
using TransactionReportsStorage.App.Paging;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.Infrastructure.Services
{
    public class RecordsService : IRecordsService
    {
        private readonly IGenericRepository<Record> _recordsRepository;

        private readonly ILogger _logger;

        private readonly Mapper _mapper = new();

        public RecordsService(IGenericRepository<Record> recordsRepository, ILogger<RecordsService> logger)
        {
            this._recordsRepository = recordsRepository;
            this._logger = logger;
        }

        public async Task<PagedList<RecordDisplayDto>> GetPageAsync(PageParameters pageParameters)
        {
            var records = await this._recordsRepository.GetPageAsync(pageParameters, r => r.Cell, r => r.User);
            var dtos = this._mapper.Map(records);

            this._logger.LogInformation($"Returned records page {dtos.PageNumber} from database.");

            return dtos;
        }

        public async Task<PagedList<RecordDisplayDto>> GetPageAsync(PageParameters pageParameters, string cellName, 
                                                             DateTime startDate, DateTime endDate)
        {
            var records = await this._recordsRepository
                                    .GetPageAsync(pageParameters,
                                                  r => r.Cell.Name == cellName
                                                  && r.DateTime >= startDate
                                                  && r.DateTime <= endDate,
                                                  r => r.Cell, r => r.User);
            var dtos = this._mapper.Map(records);

            this._logger.LogInformation($"Returned records page {dtos.PageNumber} with filters from database.");

            return dtos;
        }
    }
}
