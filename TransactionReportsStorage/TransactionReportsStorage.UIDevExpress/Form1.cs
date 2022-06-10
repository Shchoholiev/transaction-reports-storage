using System;
using System.Threading.Tasks;
using TransactionReportsStorage.App.Interfaces;
using TransactionReportsStorage.App.Models.DisplayDto;
using TransactionReportsStorage.App.Paging;

namespace TransactionReportsStorage.UIDevExpress
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRecordsService _recordsService;

        private PagedList<RecordDisplayDto> _records;

        public Form1(IRecordsService recordsService)
        {
            this._recordsService = recordsService;
            InitializeComponent();

            new Action(async () => await this.SetPage(1))();
        }

        private async Task SetPage(int pageNumber)
        {
            var pageParameters = new PageParameters();
            pageParameters.PageNumber = pageNumber;
            this._records = await this._recordsService.GetPageAsync(pageParameters);
            this.gridControl1.DataSource = this._records;
            this.gridControl1.Refresh();
            labelControl1.Text = $"{this._records.PageNumber} of {this._records.TotalPages}";
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this._records.HasPreviousPage)
            {
                await this.SetPage(this._records.PageNumber - 1);
            }
        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this._records.HasNextPage)
            {
                await this.SetPage(this._records.PageNumber + 1);
            }
        }
    }
}
