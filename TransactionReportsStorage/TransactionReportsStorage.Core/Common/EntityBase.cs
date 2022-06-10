using System.ComponentModel.DataAnnotations;

namespace TransactionReportsStorage.Core.Common
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
