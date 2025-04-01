﻿namespace API_REST_ELDENLABS_BL.DTOS.Config
{
    /// <summary>
    /// DTO que permite representar como objetos los Parámetros de Configuración.
    /// </summary>
    public class ConfigDto
    {
        /// <summary>
        /// Cadena de Conexión de la BD.
        /// </summary>
        public string CNX_BD { get; set; } = string.Empty;
    }
}