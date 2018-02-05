using System.Data.SqlClient;

namespace MarvelQuiz.Repository.DataBase
{
    public interface IDataBase
    {
        void ExecuteProcedure(object procedureName);
        void AddParameter(string name, object valor);
        SqlDataReader ExecuteReader();
        void ExecuteNonQuery();
    }
}
