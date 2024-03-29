﻿using TransactionReportsStorage.Core.Common;

namespace TransactionReportsStorage.Core.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public List<Record> Records { get; set; }
    }
}
