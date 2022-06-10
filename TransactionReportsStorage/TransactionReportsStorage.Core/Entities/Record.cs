using TransactionReportsStorage.Core.Common;

namespace TransactionReportsStorage.Core.Entities
{
    public class Record : EntityBase
    {
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public User User { get; set; }

        public Cell Cell { get; set; }
    }
}
