using SQLiteNetExtensions.Attributes;

namespace AdventureLog.Data
{
    public class DailyTask : DbObject
    {
        public bool OneComplete { get; set; } = false;
        public bool TwoComplete { get; set; } = false;
        public bool ThreeComplete { get; set; } = false;
        public bool IsComplete { get; set; } = false;

        [ForeignKey(typeof(UserTask))]
        public int UserTaskId { get; set; }
        [OneToOne]
        public UserTask UserTask { get; set; }

        public int TotalGainPoints()
        {
            int total = 0;
            if(OneComplete) total++;
            if(TwoComplete) total+=2;
            if(ThreeComplete) total+=3;
            return total;
        }
    }
}
