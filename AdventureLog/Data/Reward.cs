namespace AdventureLog.Data
{
    public class Reward : DbObject
    {
        public string Name { get; set; }
        public int Cost { get; set; } = 1;
        public bool IsRepetable { get; set; }
    }
}
