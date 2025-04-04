﻿using API_REST_ELDENLABS_BL.DTOS.Config;
using API_REST_ELDENLABS_BL.DTOS.Data;

namespace API_REST_ELDENLABS_BL.Repositories.Interfaces
{
    /// <summary>
    /// Interface de tipo Repository que implementa varias propiedades y/o métodos que permite realizar múltiples funciones.
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Método genérico que permite obtener una Lista de Objetos de Tipo T y realizar algunas validaciones.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="Config">Objeto de tipo ConfigDto.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con una Lista de tipo T.</returns>
        public Task<List<T>> GetObjects<T>(ConfigDto Config, ParamsDataDto ParamsData);

        /// <summary>
        /// Método genérico que permite insertar uno o varios objetos en la BD.
        /// </summary>
        /// <param name="Config">Objeto de tipo ConfigDto.</param>
        /// <param name="ParamsData">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con un Booleano.</returns>
        public Task<bool> PostObjects(ConfigDto Config, ParamsDataDto ParamsData);
    }
}
