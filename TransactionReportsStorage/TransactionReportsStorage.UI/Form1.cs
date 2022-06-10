using TransactionReportsStorage.App.Interfaces;
using TransactionReportsStorage.App.Models.DTO;
using TransactionReportsStorage.App.Paging;

namespace TransactionReportsStorage.UI
{
    public partial class Form1 : Form
    {
        private readonly IRecordsService _recordsService;

        private PagedList<RecordDto> _records;

        public Form1(IRecordsService recordsService)
        {
            this._recordsService = recordsService;
            InitializeComponent();

            new Action(async () => await this.SetPage(1))();
            gridControl1.DataSource = this._records;
        }

        private async Task SetPage(int pageNumber)
        {
            var pageParametes = new PageParameters();
            pageParametes.PageNumber = pageNumber;
            this._records = await this._recordsService.GetPageAsync(pageParametes, null, null, null);
            gridControl1.Refresh();
            //pagingInfo.Content = $"{this._records.PageNumber} of {this._records.TotalPages}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}