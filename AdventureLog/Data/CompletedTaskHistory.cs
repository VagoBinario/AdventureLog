using SQLiteNetExtensions.Attributes;
using System;

namespace AdventureLog.Data
{
    public class CompletedTaskHistory : DbObject
    {
        public DateTime CompletedTime { get; set; }
        public int RemainingPoints { get; set; }

        [ForeignKey(typeof(DailyTask))]
        public int DailyTaskId { get; set; }
        [OneToOne]
        public DailyTask DailyTask { get; set; }
    }
}
