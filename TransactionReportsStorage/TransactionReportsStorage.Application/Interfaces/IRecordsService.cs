using TransactionReportsStorage.Application.Models.DTO;
using TransactionReportsStorage.Application.Paging;

namespace TransactionReportsStorage.Application.Interfaces
{
    public interface IRecordsService
    {
        Task<PagedList<RecordDto>> GetPageAsync(PageParameters pageParameters, string? cellName, 
                                             DateOnly? startDate, DateOnly? endDate);
    }
}
