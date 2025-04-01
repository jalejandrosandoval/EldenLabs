using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace API_REST_ELDENLABS_BL.Clases.Logic.Data.ORM
{
    /// <summary>
    /// Clase de Dapper ORM para el manejo de la BD.
    /// </summary>
    internal class DapperORM
    {
        /// <summary>
        /// Método para ejecutar procedimientos almacenados y retornar un DataTable.
        /// </summary>
        /// <param name="connection">Objeto de tipo SqlConnection.</param>
        /// <param name="storedProcedureName">Nombre dle Procedimiento Almacenado.</param>
        /// <param name="parameters">Parámetros a enviar.</param>
        /// <returns></returns>
        public static DataTable ExecuteStoredProcedure(SqlConnection connection, string storedProcedureName, DynamicParameters parameters = null)
        {
            using (var command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var paramName in parameters.ParameterNames)
                    {
                        command.Parameters.Add(new SqlParameter(paramName, parameters.Get<object>(paramName)));
                    }
                }

                using (var adapter = new SqlDataAdapter(command))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}
