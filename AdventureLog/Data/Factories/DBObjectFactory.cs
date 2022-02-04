namespace AdventureLog.Data.Factories
{
    public static class DBObjectFactory<T> where T : DbObject, new ()
    {
        public static T Instance() => new();
    }
}
