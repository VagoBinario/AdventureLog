namespace AdventureLog.Data.Factories
{
    public class UserTaskFactory : IDbObjectFactory<UserTask>
    {
        public UserTask NewInstance() => new();
    }
}
