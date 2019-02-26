using System;
namespace Competency.Models
{
    public class Schedule
    {
        public int Activity { get; set; }

        public DateTimeOffset Date { get; set; }

        public int DistanceInMeters { get; set; }

        public long TimeInSeconds { get; set; }
    }
}
