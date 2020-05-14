namespace DataBase
{
    // Repository
    public interface IDBManager
    {
        void InitDBContext();
        void SaveChanges();
    }
}
