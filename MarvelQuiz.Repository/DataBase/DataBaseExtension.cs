using System.Data.SqlClient;

namespace MarvelQuiz.Repository.DataBase
{
    public static class DataBaseExtension
    {
        public static T ReadAttr<T>(this SqlDataReader reader, string nomeColuna)
        {
            var index = reader.GetOrdinal(nomeColuna);
            return (T)reader.GetValue(index);
        }
    }
}
