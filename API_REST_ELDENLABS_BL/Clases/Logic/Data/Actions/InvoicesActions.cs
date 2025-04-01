using API_REST_ELDENLABS_BL.Clases.Logic.Data.ORM;
using API_REST_ELDENLABS_BL.Entities.Exceptions;
using API_REST_ELDENLABS_BL.Interfaces.Logic.Data;
using API_REST_ELDENLABS_BL.Models.Controllers.Invoices;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Reflection;

namespace API_REST_ELDENLABS_BL.Clases.Logic.Data.Actions
{
    /// <summary>
    /// Clase que permite realizar diferentes acciones hacia la BD para las facturas.
    /// </summary>
    /// <param name="Actions">Objeto de tipo Actions.</param>
    internal class InvoicesActions(IContextData Actions)
    {
        /// <summary>
        /// Método que permite obtener los detalles de las Facturas.
        /// </summary>
        /// <returns>DataTable.</returns>
        /// <exception cref="ApiRestException">Obtiene una excepción si el PA falla o retorna algún error.</exception>
        internal DataTable GetInvoicesSP()
        {
            try
            {
                DataTable listDataTable;

                using (var connection = new SqlConnection(Actions.Cnx_Bd))
                {
                    connection.Open();
                    listDataTable = DapperORM.ExecuteStoredProcedure(connection, "[dbo].[PA_GET_INVOICES]");

                    return listDataTable;
                }
            }
            catch (Exception ex)
            {
                Actions.Validations = new(MethodBase.GetCurrentMethod()!.Name, ex);
                throw new ApiRestException(Actions.Validations.MessageException);
            }
        }


        /// <summary>
        /// Método que permite obtener los detalles con Parámetros de las Facturas.
        /// </summary>
        /// <param name="Invoices">Objeto de tipo InvoicesWithParamsModel.</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="ApiRestException">Obtiene una excepción si el PA falla o retorna algún error.</exception>
        internal DataTable GetInvoicesByParamsSP(InvoicesWithParamsModel Invoices)
        {
            try
            {
                DataTable listDataTable;

                using (var connection = new SqlConnection(Actions.Cnx_Bd))
                {
                    connection.Open();

                    DynamicParameters parameters = new();

                    parameters.Add("@IdClient", Invoices.IdClient);
                    parameters.Add("@FullNameClient", Invoices.FullNameClient);
                    parameters.Add("@ClientType", Invoices.ClientType);

                    listDataTable = DapperORM.ExecuteStoredProcedure(connection, "[dbo].[PA_GET_INVOICES_BY_PARAMS]", parameters);

                    return listDataTable;
                }
            }
            catch (Exception ex)
            {
                Actions.Validations = new(MethodBase.GetCurrentMethod()!.Name, ex);
                throw new ApiRestException(Actions.Validations.MessageException);
            }
        }
    }
}