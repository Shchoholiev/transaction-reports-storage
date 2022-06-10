using TransactionReportsStorage.App.Models.DTO;
using TransactionReportsStorage.App.Paging;

namespace TransactionReportsStorage.App.Interfaces
{
    public interface IRecordsService
    {
        Task<PagedList<RecordDto>> GetPageAsync(PageParameters pageParameters);

        Task<PagedList<RecordDto>> GetPageAsync(PageParameters pageParameters, string cellName,
                                                DateTime startDate, DateTime endDate);
    }
}
