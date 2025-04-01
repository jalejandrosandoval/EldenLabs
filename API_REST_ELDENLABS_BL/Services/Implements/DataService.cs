using API_REST_ELDENLABS_BL.DTOS.Config;
using API_REST_ELDENLABS_BL.DTOS.Data;
using API_REST_ELDENLABS_BL.Repositories.Interfaces;
using API_REST_ELDENLABS_BL.Services.Interfaces;

namespace API_REST_ELDENLABS_BL.Services.Implements
{
    /// <summary>
    /// Clase de Tipo Repository que implementa o hereda de la clase IDataService varias propiedades y/o métodos. 
    /// </summary>
    /// <param name="GenericRepository">Párametro de tipo IDataRepository.</param>
    public class DataService(IDataRepository GenericRepository) : IDataService
    {
        /// <summary>
        /// Método genérico que permite obtener una Lista de Objetos de Tipo T y realizar algunas validaciones.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="Config">Objeto de tipo ConfigDto.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con una Lista de Tipo T.</returns>
        public async Task<List<T>> GetObjects<T>(ConfigDto Config, ParamsDataDto ParamsData)
        {
            return await GenericRepository.GetObjects<T>(Config, ParamsData);
        }

        /// <summary>
        /// Método genérico que permite insertar uno o varios objetos en la BD.
        /// </summary>
        /// <param name="Config">Objeto de tipo ConfigDto.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con un Booleano.</returns>
        public async Task<bool> PostObjects(ConfigDto Config, ParamsDataDto ParamsData)
        {
            return await GenericRepository.PostObjects(Config, ParamsData);
        }
    }
}
