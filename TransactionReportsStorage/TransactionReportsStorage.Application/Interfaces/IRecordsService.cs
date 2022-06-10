using TransactionReportsStorage.App.Models.DisplayDto;
using TransactionReportsStorage.App.Paging;

namespace TransactionReportsStorage.App.Interfaces
{
    public interface IRecordsService
    {
        Task<PagedList<RecordDisplayDto>> GetPageAsync(PageParameters pageParameters);

        Task<PagedList<RecordDisplayDto>> GetPageAsync(PageParameters pageParameters, string cellName,
                                                DateTime startDate, DateTime endDate);
    }
}
