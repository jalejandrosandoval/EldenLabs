using API_REST_ELDENLABS_BL.DTOS.Config;
using API_REST_ELDENLABS_BL.Repositories.Interfaces;
using API_REST_ELDENLABS_BL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace API_REST_ELDENLABS_BL.Services.Implements
{
    /// <summary>
    /// Clase de Tipo Repository que implementa o hereda de la clase IValoresGlobalesService varias propiedades y/o métodos. 
    /// </summary>
    /// <param name="GenericRepository">Párametro de tipo IApiLicenseRepository.</param>
    public class ValoresGlobalesService(IValoresGlobalesRepository GenericRepository) : IValoresGlobalesService
    {
        /// <summary>
        /// Método que permite obtener todos los valores de configuración a partir de ciertos parámetros.
        /// </summary>
        /// <param name="configuration">Objeto de Tipo IConfiguration que permite reconocer ciertas propiedaes del IConfiguration.</param>
        /// <returns>Objeto de tipo ConfigDto.</returns>
        public ConfigDto GetConfigutation(IConfiguration configuration)
        {
            return GenericRepository.GetConfigutation(configuration);
        }
    }
}
