﻿using API_REST_ELDENLABS_BL.Models.Data;
using static API_REST_ELDENLABS_BL.Models.Data.EnumTypesForApi;

namespace API_REST_ELDENLABS_BL.DTOS.Data
{
    /// <summary>
    /// DTO que permite representar como objetos los Parámetros para realizar consultas e interacciones con la BD.
    /// </summary>
    public class ParamsDataDto
    {
        /// <summary>
        /// Nombre de la Clase de Acciones a Ejecutar.
        /// </summary>
        public EnumActions ActionsName { get; set; }

        /// <summary>
        /// Nombre de la Acción específica a Ejecutar.
        /// </summary>
        public EnumActionsDetails ActionDetails { get; set; }

        /// <summary>
        /// Lista de Parámetros.
        /// </summary>
        public List<ParamsDataModel> ParamsData { get; set; } = [];
    }
}
