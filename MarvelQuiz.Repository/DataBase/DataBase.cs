using System.Data;
using System.Data.SqlClient;

namespace MarvelQuiz.Repository.DataBase
{
    public class DataBase : IDataBase
    {
        private readonly SqlConnection _minhaConexao;
        private SqlCommand SqlCommand { get; set; }

        public DataBase()
        {
            _minhaConexao = new SqlConnection(@"data source=LUCIANO-PC; Integrated Security=SSPI; Initial Catalog=FaculdadeTISelvagem");
            _minhaConexao.Open();
        }

        public void ExecuteProcedure(object procedureName)
        {
            SqlCommand = new SqlCommand(procedureName.ToString(), _minhaConexao)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        public void AddParameter(string name, object valor)
        {
            SqlCommand.Parameters.AddWithValue(name, valor);
        }

        public SqlDataReader ExecuteReader()
        {
            return SqlCommand.ExecuteReader();
        }

        public void ExecuteNonQuery()
        {
            SqlCommand.ExecuteNonQuery();
            Dispose();
        }

        public void Dispose()
        {
            if (_minhaConexao.State == ConnectionState.Open)
                _minhaConexao.Close();
        }
    }
}
