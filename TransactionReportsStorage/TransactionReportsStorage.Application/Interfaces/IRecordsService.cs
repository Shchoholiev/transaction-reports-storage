using TransactionReportsStorage.Application.Paging;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.Application.Interfaces
{
    public interface IRecordsService
    {
        Task<PagedList<Record>> GetPageAsync(PageParameters pageParameters, string? cellName, 
                                             DateOnly? startDate, DateOnly? endDate);
    }
}
