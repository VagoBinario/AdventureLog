using Microsoft.Maui.Essentials;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace AdventureLog.Data
{
    public class Repository
    {
        private readonly SQLiteConnection _database;

        private void SeedData()
        {
            if (!_database.Table<UserTask>().Any())
            {
                List<UserTask> userTasks = new()
                {
                    new UserTask() { Name = "Leer", LevelOne = "Un capitulo", LevelTwo = "3 capitulos", LevelThree = "5 Capitulos" },
                    new UserTask() { Name = "Ejercicio", LevelOne = "Una series", LevelTwo = "3 series", LevelThree = "5 series" },
                    new UserTask() { Name = "Programar", LevelOne = "Una funcion", LevelTwo = "3 funciones", LevelThree = "5 funciones" },
                };
                userTasks.ForEach(x => _database.Insert(x));
            }
            if (!_database.Table<Reward>().Any())
            {
                List<Reward> rewards = new()
                {
                    new Reward() { Name="Juego 30 minutos", IsRepetable=true},
                    new Reward() { Name="Fifi", IsRepetable=true},
                    new Reward() { Name="Capitulo 30 minutos", IsRepetable=true},
                };
                rewards.ForEach(x => _database.Insert(x));
            }
        }

        public Repository()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "AdventureLog.db3");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<UserTask>();
            _database.CreateTable<Reward>();
            _database.CreateTable<DailyTask>();
            _database.CreateTable<CompletedTaskHistory>();
            SeedData();
        }

        public List<UserTask> GetAllUserTasks() => _database.Table<UserTask>().ToList(); 
        public List<Reward> GetAllRewards() => _database.Table<Reward>().ToList();
        public List<DailyTask> GetAllActiveDailyTasks(bool includeChilds = false)
        {
            Expression<Func<DailyTask, bool>> filter = x => !x.IsComplete;
            return includeChilds ? _database.GetAllWithChildren(filter) : _database.Table<DailyTask>().Where(filter).ToList();
        }
        public IEnumerable<CompletedTaskHistory> GetCompletedTaskHistories(bool includeChilds = false)
        {
            return includeChilds? _database.GetAllWithChildren<CompletedTaskHistory>() : _database.Table<CompletedTaskHistory>();
        }

        public DailyTask GetRandomTask(IEnumerable<int> ignoreTasksIds = null)
        {
            if (ignoreTasksIds == null) ignoreTasksIds = Enumerable.Empty<int>();
            TableQuery<DailyTask> dailyTasks = _database.Table<DailyTask>().Where(x => !x.IsComplete && !ignoreTasksIds.Contains(x.UserTaskId));
            if (dailyTasks.Any())
            {
                int randomTask = new Random().Next(dailyTasks.Count());
                DailyTask dailyTask = dailyTasks.ElementAt(randomTask);
                UserTask userTask = _database.GetWithChildren<UserTask>(dailyTask.UserTaskId);
                dailyTask.UserTask = userTask;
                return dailyTask;
            }
            else
            {
                TableQuery<UserTask> userTasks = _database.Table<UserTask>().Where(x => !ignoreTasksIds.Contains(x.Id));
                if (!userTasks.Any()) return null;
                int randomTask = new Random().Next(userTasks.Count());
                UserTask userTask = userTasks.ElementAt(randomTask);
                DailyTask dailyTask = new() { UserTaskId = userTask.Id, UserTask = userTask };
                Create(dailyTask);
                return dailyTask;
            }
        }
        public List<DailyTask> GetRandomTasks(int maxNumber = 3)
        {
            List<DailyTask> dailyTasks = new();
            for(int i = 0; i < maxNumber; i++)
            {
                var task = GetRandomTask(dailyTasks.Select(x => x.UserTaskId));
                if(task != null) dailyTasks.Add(task);
            }
            return dailyTasks;
        }

        public int Create<T>(T entity) where T : DbObject
        {
            return _database.Insert(entity);
        }

        public int Update<T>(T entity) where T : DbObject
        {
            return _database.Update(entity);
        }

        public int Delete<T>(T entity) where T : DbObject
        {
            return _database.Delete(entity);
        }
    }
}
