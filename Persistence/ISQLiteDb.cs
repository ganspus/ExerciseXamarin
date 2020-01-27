using SQLite;

namespace ExerciseXamarin.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

