namespace AdventureLog.Data
{
    public class Quest : DbObject
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CompletePoints { get; set; }
    }
}
