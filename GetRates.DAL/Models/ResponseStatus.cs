using System;
using System.Collections.Generic;
using System.Text;

namespace GetRates.DAL.Models
{
    public class ResponseStatus
    {
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
#nullable enable
        public string? error_message { get; set; }
#nullable disable
        public int elapsed { get; set; }
        public int credit_count { get; set; }
#nullable enable
        public string? notice { get; set; }
#nullable disable
    }
}
