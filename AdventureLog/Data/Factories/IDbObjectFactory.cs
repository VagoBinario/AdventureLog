namespace AdventureLog.Data
{
    public interface IDbObjectFactory<T>
    {
        public T NewInstance();
    }
}
