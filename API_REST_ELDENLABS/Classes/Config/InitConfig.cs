using API_REST_ELDENLABS.Classes.Logic.Common;
using API_REST_ELDENLABS_BL.DTOS.Config;
using API_REST_ELDENLABS_BL.Repositories.Implements;
using API_REST_ELDENLABS_BL.Services.Implements;

namespace API_REST_ELDENLABS.Classes.Config
{
    /// <summary>
    /// Clase que permite inicializar la configuración Inicial de la aplicación.
    /// </summary>
    internal class InitConfig
    {
        /// <summary>
        /// Servicio de tipo DataService que permite interactuar con ciertos métodos de este.
        /// </summary>
        internal readonly DataService dataService = new(new DataRepository());

        /// <summary>
        /// Servicio de tipo ValoresGlobalesService que permite interactuar con ciertos métodos de este.
        /// </summary>
        private readonly ValoresGlobalesService valoresGlobalesService = new(new ValoresGlobalesRepository());

        /// <summary>
        /// Objeto de tipo ConfigDto.
        /// </summary>
        internal ConfigDto ConfigurationsDto { get; set; } = new();

        /// <summary>
        /// Objeto de tipo ValidationsController.
        /// </summary>
        internal ValidationsInControllers Validations { get; set; } = new();

        /// <summary>
        /// Constructor de la Clase con Parámetros.
        /// </summary>
        /// <param name="IConfig">Objeto de Tipo IConfiguration que permite reconocer ciertas propiedaes del IConfiguration.</param>
        public InitConfig(IConfiguration? IConfig = null)
        {
            if (IConfig != null)
                ConfigurationsDto = valoresGlobalesService.GetConfigutation(IConfig);
        }
    }
}
