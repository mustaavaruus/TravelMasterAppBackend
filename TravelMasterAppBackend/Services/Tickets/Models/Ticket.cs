﻿using DbDataReaderMapper;

namespace TravelMasterAppBackend.Services.Tickets.Models
{
    public class Ticket
    {
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("begin_dt")]
        public DateTime BeginDt { get; set; }

        [DbColumn("end_dt")]
        public DateTime EndDt { get; set; }

        [DbColumn("price")]
        public int Price { get; set; }

        [DbColumn("from_id")]
        public int FromId { get; set; }

        [DbColumn("to_id")]
        public int ToId { get; set; }

        [DbColumn("luggage_price")]
        public int LuggagePrice { get; set; }

        [DbColumn("transfer_count")]
        public int TransferCount { get; set; }
    }
}
