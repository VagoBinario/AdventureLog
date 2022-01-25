using SQLite;

namespace AdventureLog.Data
{
    public class DbObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
