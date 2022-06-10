namespace TransactionReportsStorage.App.Models.DTO
{
    public class RecordDto : EntityBaseDto
    {
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public UserDto User { get; set; }

        public CellDto Cell { get; set; }
    }
}
