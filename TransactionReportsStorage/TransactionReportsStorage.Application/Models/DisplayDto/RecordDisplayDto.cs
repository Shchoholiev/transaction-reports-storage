using TransactionReportsStorage.App.Models.DTO;

namespace TransactionReportsStorage.App.Models.DisplayDto
{
    public class RecordDisplayDto
    {
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; }

        public string CellName { get; set; }
    }
}
