using HangFire.Platform.Common.Data;
using System.Linq;
using System;

namespace HangFireCronEmail.Models
{
    public class EmailDays
    {
        public int firstDayEmail { get; set; }
        public int secondDayEmail { get; set; }
    }
}