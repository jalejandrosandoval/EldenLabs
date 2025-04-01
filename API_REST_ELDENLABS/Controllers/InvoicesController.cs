using API_REST_ELDENLABS.Classes.Config;
using API_REST_ELDENLABS.Classes.Logic.Common;
using API_REST_ELDENLABS_BL.DTOS.Data;
using API_REST_ELDENLABS_BL.DTOS.Invoices;
using API_REST_ELDENLABS_BL.Models.Controllers.Invoices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static API_REST_ELDENLABS_BL.Models.Data.EnumTypesForApi;

namespace API_REST_ELDENLABS.Controllers
{
    /// <summary>
    /// Controlador que permite el manejo de los Tipos de licenciamiento que existen en la BD.
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("")]
    public class InvoicesController : ControllerBase
    {
        /// <summary>
        /// Objeto de Tipo InitConfig.
        /// </summary>
        private readonly InitConfig Init_Config;

        /// <summary>
        /// Constructor del Controlador.
        /// </summary>
        /// <param name="IConfig">Objeto de Tipo IConfiguration.</param>
        public InvoicesController(IConfiguration IConfig)
        {
            Init_Config = new();

            if (IConfig != null)
                Init_Config = new(IConfig);
        }

        /// <summary>
        /// Método que permite obtener un listado de todas las Facturas.
        /// </summary>
        /// <remarks>
        /// Método que permite obtener un listado con todas las Facturas.
        /// 
        /// Ejemplo:
        ///
        ///     GET GetInvoices/
        ///     [
        ///         {
        ///             "ConnectionDeviceID": 1234,
        ///             "Hefesto": "Nombre del Efesto",
        ///             "EventProcessedUtcTime": "Fecha",
        ///             "TimeStamp": "Fecha",
        ///             "Var_Name": "Nombre de la Variable",
        ///             "Value": "Valor",
        ///             "Plugin": "Nombre del Plugin",
        ///             "Request": "Nombre del Request",
        ///             "Var_Name1": "Nombre de la Variable 1",
        ///             "Device": "Nombre del Device"
        ///         }
        ///     ]
        /// 
        /// </remarks>
        /// <returns>Task.</returns>
        /// <response code="200"> OK: Se encontró el Listado de Facturas.</response>
        /// <response code="400"> BadRequest: El Servidor NO puede procesar la petición, por favor verificar la información suministrada.</response>
        /// <response code="404"> Not Found: No se encuentra ninguna Factura Registrada o Activa.</response>
        /// <response code="500"> Internal Server Error: Error NO controlado.</response>
        [HttpGet]
        [Route("GetInvoices/")]
        public async Task<ActionResult> GetInvoices()
        {
            try
            {
                ParamsDataDto ParamsData = new()
                {
                    ActionsName = EnumActions.InvoicesActions,
                    ActionDetails = EnumActionsDetails.GetInvoicesSP
                };

                List<InvoiceDTO> invoicesresult = await Init_Config.dataService.GetObjects<InvoiceDTO>(Init_Config.ConfigurationsDto, ParamsData);

                return Init_Config.Validations.ValidateListObjResult(invoicesresult, "No se encuentra ninguna Factura Registrada o Activa...");
            }
            catch (Exception ex)
            {
                return Init_Config.Validations.CatchError(ex);
            }
        }

        /// <summary>
        /// Método que permite obtener un listado de todas las Facturas.
        /// </summary>
        /// <remarks>
        /// Método que permite obtener un listado con todas las Facturas.
        /// 
        /// Ejemplo:
        ///
        ///     GET GetInvoicesByParamsSP/{Invoices}
        ///     [
        ///         {
        ///             "ConnectionDeviceID": 1234,
        ///             "Hefesto": "Nombre del Efesto",
        ///             "EventProcessedUtcTime": "Fecha",
        ///             "TimeStamp": "Fecha",
        ///             "Var_Name": "Nombre de la Variable",
        ///             "Value": "Valor",
        ///             "Plugin": "Nombre del Plugin",
        ///             "Request": "Nombre del Request",
        ///             "Var_Name1": "Nombre de la Variable 1",
        ///             "Device": "Nombre del Device"
        ///         }
        ///     ]
        /// 
        /// </remarks>
        /// <param name="Invoices">Objeto de tipo InvoicesWithParamsModel.</param>
        /// <returns>Task.</returns>
        /// <response code="200"> OK: Se encontró el Listado de Facturas.</response>
        /// <response code="400"> BadRequest: El Servidor NO puede procesar la petición, por favor verificar la información suministrada.</response>
        /// <response code="404"> Not Found: No se encuentra ninguna Factura Registrada o Activa.</response>
        /// <response code="500"> Internal Server Error: Error NO controlado.</response>
        [HttpPost]
        [Route("GetInvoicesByParamsSP")]
        public async Task<ActionResult> GetInvoicesByParamsSP(InvoicesWithParamsModel Invoices)
        {
            try
            {
                if (ValidationsInControllers.ParamsIsCharsSpecial(Invoices.IdClient!) ||
                    ValidationsInControllers.ParamsIsCharsSpecial(Invoices.FullNameClient!) ||
                    ValidationsInControllers.ParamsIsCharsSpecial(Invoices.ClientType!))
                {
                    Init_Config.Validations.ParamsIsValid();

                    //string JSON = JsonConvert.SerializeObject(Invoices);

                    ParamsDataDto ParamsData = new()
                    {
                        ActionsName = EnumActions.InvoicesActions,
                        ActionDetails = EnumActionsDetails.GetInvoicesByParamsSP,
                        ParamsData = 
                        [
                            new() { ValueParam = Invoices }
                        ]
                    };

                    List<InvoiceWithParamsDTO> invoicesresult = await Init_Config.dataService.GetObjects<InvoiceWithParamsDTO>(Init_Config.ConfigurationsDto, ParamsData);

                    return Init_Config.Validations.ValidateListObjResult(invoicesresult, "No se encuentra ninguna Factura Registrada o Activa...");
                }
                else
                {
                    string Message = "Verifique el identificador del Cliente " + Invoices.IdClient + " o el Nombre Completo del Cliente " + 
                        Invoices.FullNameClient + " o el Tipo de Cliente debido a que no corresponde con un proyecto permitido...";
                    return Init_Config.Validations.ResultBadRequest(Message);
                }
            }
            catch (Exception ex)
            {
                return Init_Config.Validations.CatchError(ex);
            }
        }
    }
}
