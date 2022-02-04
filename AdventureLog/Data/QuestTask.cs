using SQLiteNetExtensions.Attributes;

namespace AdventureLog.Data
{
    public class QuestTask : DbObject
    {
        public string Name { get; set; }
        public int PointsReward { get; set; } = 1;
        public bool IsCompleted { get; set; }

        [ForeignKey(typeof(Quest))]
        public int QuestId { get; set; }
        [OneToOne]
        public UserTask Quest { get; set; }

    }
}
