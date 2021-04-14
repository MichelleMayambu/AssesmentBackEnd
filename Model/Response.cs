using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentApi.Model
{
    public class Response
    {
        public bool ok { get; set; }
        public string msg { get; set; }
        public dynamic data { get; set; }
    }
    public class DataResponse
    {
        public long ID { get; set; }
        public string PayChannelRef { get; set; }
        public string PaymentMessageTrace { get; set; }
        public string UserID { get; set; }
        public string MeterNumber { get; set; }
        public decimal Amount { get; set; }
        public string ResponseStatus { get; set; }
        public string PaySeqID { get; set; }
        public Guid PaymentTransactionRef { get; set; }

    }
}
