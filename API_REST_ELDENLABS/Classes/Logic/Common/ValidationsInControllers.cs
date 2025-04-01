﻿using API_REST_ELDENLABS.Classes.Tools;
using API_REST_ELDENLABS_BL.Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_ELDENLABS.Classes.Logic.Common
{
    /// <summary>
    /// Clase de Lógica que permite realizar las validaciones de los diferentes objetos de los Controladores.
    /// </summary>
    internal class ValidationsInControllers : ControllerBase
    {
        /// <summary>
        /// Método que permite validar si la respuesta de un un objeto es nulo o vacío.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="ListObj">Lista de tipo Object, que corresponde a los objetos a realizar la validación.</param>
        /// <param name="Message">Objeto de tipo string, que corresponde al Mensaje que se desea Retornar, si llega a ver un posible error.</param>
        /// <returns>ActionResult con una Lista de tipo Object o un Mensaje de Respuesta.</returns>
        internal ActionResult ValidateListObjResult<T>(List<T> ListObj, string Message)
        {
            if (ListObj != null && ListObj.Count > 0)
                return Ok(ListObj);
            else
                return NotFound(Message);
        }

        /// <summary>
        /// Método que permite validar si la respuesta de un objeto es verdadera o falsa.
        /// </summary>
        /// <param name="Obj">Objeto de tipo bool, que al objeto a realizar la validación.</param>
        /// <param name="Message">Objeto de tipo string, que corresponde al Mensaje que se desea Retornar, si llega a ver un posible error.</param>
        /// <returns>ActionResult con un Mensaje de Respuesta.</returns>
        internal ActionResult ValidateObjResult(bool Obj, string Message)
        {
            if (Obj)
                return Ok("@OK");
            else
                return BadRequest(Message);
        }

        /// <summary>
        /// Método que permite validar si la respuesta de un objeto es nulo o vacío, y si es númerico.
        /// </summary>
        /// <param name="Param"></param>
        /// <returns>Booleano que determina si o no un número.</returns>
        internal static bool ParamIsNumericByString(string Param)
        {
            if (!string.IsNullOrEmpty(Param) && Param.IsNumericByString())
                return true;
            else
                return false;
        }

        /// <summary>
        /// Método que permite validar si la respuesta de un objeto es nulo o vacío, y si contiene caracteres especiales.
        /// </summary>
        /// <param name="Param"></param>
        /// <returns>Booleano que determina si contiene caracteres especiales.<returns>
        internal static bool ParamsIsCharsSpecial(string Param)
        {
            if (!string.IsNullOrEmpty(Param) && !Param.ContainsSpecialChars())
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>ActionResult con un Mensaje de Respuesta.</returns>
        internal ActionResult ParamsIsValid()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
                return Ok();
        }

        /// <summary>
        /// Método que permite mostrar un mensaje de error.
        /// </summary>
        /// <param name="Message">Objeto de tipo string, que corresponde al Mensaje que se desea Retornar, si llega a ver un posible error.</param>
        /// <returns>ActionResult con un Mensaje de Respuesta.</returns>
        internal ActionResult ResultBadRequest(string Message)
        {
            return BadRequest(Message);
        }

        /// <summary>
        /// Método que permite capturar un error y retornar un mensaje de error.
        /// </summary>
        /// <param name="Ex">Objeto de tipo Exception, que corresponde a la Exepción lanzada.</param>
        /// <returns>ActionResult con un Mensaje de Error.</returns>
        internal ActionResult CatchError(Exception Ex)
        {
            if (Ex is ApiRestException ex2)
                return BadRequest(ex2.MessageException.DescriptionException);
            else
                return BadRequest(Ex.Message);
        }
    }
}
