using SQLiteNetExtensions.Attributes;

namespace AdventureLog.Data
{
    public class UserTask : DbObject
    {
        public string Name { get; set; } 
        public string LevelOne { get; set; }
        public string LevelTwo { get; set; }
        public string LevelThree { get; set; }  

    }
}
