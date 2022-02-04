using SQLite;

namespace AdventureLog.Data
{
    public class DbObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public object GetPropertyValue(string properyName)
            => GetType().GetProperty(properyName).GetValue(this, null);
    }
}
