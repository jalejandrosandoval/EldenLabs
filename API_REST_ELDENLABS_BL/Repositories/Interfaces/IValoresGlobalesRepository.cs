using API_REST_ELDENLABS_BL.DTOS.Config;
using Microsoft.Extensions.Configuration;

namespace API_REST_ELDENLABS_BL.Repositories.Interfaces
{
    /// <summary>
    /// Interface de tipo Repository que implementa varias propiedades y/o métodos que permite realizar múltiples funciones.
    /// </summary>
    public interface IValoresGlobalesRepository
    {
        /// <summary>
        /// Método que permite obtener todos los valores de configuración a partir de ciertos parámetros.
        /// </summary>
        /// <param name="configuration">Objeto de Tipo IConfiguration que permite reconocer ciertas propiedaes del IConfiguration.</param>
        /// <returns>Objeto de tipo ConfigDto.</returns>
        public ConfigDto GetConfigutation(IConfiguration configuration);
    }
}
