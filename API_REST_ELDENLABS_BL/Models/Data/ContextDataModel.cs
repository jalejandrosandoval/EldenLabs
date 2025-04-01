using API_REST_ELDENLABS_BL.DTOS.Config;
using API_REST_ELDENLABS_BL.Entities.Data;
using API_REST_ELDENLABS_BL.Interfaces.Logic.Data;

namespace API_REST_ELDENLABS_BL.Models.Data
{
    /// <summary>
    /// Modelo que permite maperar los objectos para las Acciones hacia la BD, el cuál hereda propiedades de IActions.
    /// </summary>
    /// <param name="Config">Objeto de tipo ConfigDto.</param>
    public class ContextDataModel(ConfigDto Config) : IContextData
    {
        /// <summary>
        /// Cadena de conexión de la Base de Datos.
        /// </summary>
        public string Cnx_Bd { get; set; } = Config.CNX_BD;

        /// <summary>
        /// TimeOut de conexión de la Base de Datos.
        /// </summary>
        public int TimeOut { get; set; } = 300;

        /// <summary>
        /// Objeto de tipo ValidationsInDataManager.
        /// </summary>
        public ContextDataValidations Validations { get; set; } = new();
    }
}