using API_REST_ELDENLABS_BL.Clases.Logic.Data.Actions;
using API_REST_ELDENLABS_BL.DTOS.Config;
using API_REST_ELDENLABS_BL.DTOS.Data;
using API_REST_ELDENLABS_BL.Entities.Exceptions;
using API_REST_ELDENLABS_BL.Models.Data;
using System.Data;
using System.Reflection;
using static API_REST_ELDENLABS_BL.Models.Data.EnumTypesForApi;

namespace API_REST_ELDENLABS_BL.Clases.Logic.Data.Init
{
    /// <summary>
    /// Clase de configuración inicial para acceder a la Base de Datos.
    /// </summary>
    /// <param name="Config">Objeto de tipo ConfigDto.</param>
    internal class InitData(ConfigDto Config)
    {
        /// <summary>
        /// Objeto de tipo ContextDataModel, que permite el manejo de la conexión hacía la BD.
        /// </summary>
        private readonly ContextDataModel ContextData = new(Config);

        /// <summary>
        /// Método genérico que permite recorrer un DataTable y realizar algunas validaciones.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="dataTable">DataTable.</param>
        /// <returns>Lista de Tipo T.</returns>
        private static List<T> TourDataRow<T>(DataTable dataTable)
        {
            try
            {
                List<T> listObjects = [];

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    T itemDataRow = GetItemRow<T>(dataRow);
                    listObjects.Add(itemDataRow);
                }

                return listObjects;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        /// Método genérico que permite recorrer un DataRow y obtener un objeto de Tipo T.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="dataRow">DataRow.</param>
        /// <returns>Objeto de Tipo T.</returns>
        private static T GetItemRow<T>(DataRow dataRow)
        {
            try
            {
                Type type = typeof(T);
                T objectT = Activator.CreateInstance<T>();

                foreach (DataColumn dataColumn in dataRow.Table.Columns)
                {
                    foreach (PropertyInfo propertyInfo in type.GetRuntimeProperties())
                    {
                        if (propertyInfo.Name == dataColumn.ColumnName)
                            propertyInfo.SetValue(objectT, dataRow[dataColumn.ColumnName], null);
                    }
                }

                return objectT;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        /// Método que permite obtener los Métodos de un ensamblado.
        /// </summary>
        /// <param name="Params">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Objeto de tipo MethodInfo.</returns>
        private (MethodInfo Methods, object AssemblyObj) GetMethodsInfoAndAssembly(ParamsDataDto Params)
        {
            MethodInfo? method = null;
            object assembly;

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

            switch (Params.ActionsName)
            {
                case EnumActions.InvoicesActions:
                    assembly = new InvoicesActions(ContextData);
                    break;
                default:
                    throw new InvalidOperationException("Ensamblado no encontrado, por favor verifique el nombre suministrado: " + Params.ActionsName + "...");
            }

            method = assembly.GetType().GetMethod(Params.ActionDetails.ToString(), bindingFlags);

            if (method == null)
                throw new InvalidOperationException("Acción no encontrada, por favor verifique el nombre suministrado: " + Params.ActionDetails + "...");

            return (Methods: method, AssemblyObj: assembly);
        }

        /// <summary>
        /// Método genérico que permite obtener los métodos que tiene el Objeto DataManagerDb con el fin de hacer uso de esto de forma recursiva.
        /// </summary>
        /// <param name="Params">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con un Objeto.</returns>
        /// <exception cref="ApiRestException">Obtiene una excepción personalizada si ocurre un error en el procesamiento de la API.</exception>
        /// <exception cref="InvalidOperationException">Obtiene una excepción genérica.</exception>
        private async Task<object> GetMethodsData(ParamsDataDto Params)
        {
            try
            {
                (MethodInfo method, object assembly) = GetMethodsInfoAndAssembly(Params);

                List<object> listParams = [];

                foreach (ParamsDataModel param in Params.ParamsData)
                    listParams.Add(param.ValueParam);

                object[] parameters = [.. listParams];

                object res = method.Invoke(assembly, parameters)!;

                if (res != null)
                    return await Task.FromResult(res);
                else
                    return await Task.FromResult(new object());
            }
            catch (TargetInvocationException ex) when (ex.InnerException is ApiRestException ex2)
            {
                throw new ApiRestException(ex2.MessageException);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.InnerException?.Message ?? ex.Message);
            }
        }

        /// <summary>
        /// Método genérico que permite obtener una Lista de Objetos de Tipo T y realizar algunas validaciones.
        /// </summary>
        /// <typeparam name="T">Tipo de Dato.</typeparam>
        /// <param name="Params">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con una Lista de Tipo T.</returns>
        public async Task<List<T>> GetObjects<T>(ParamsDataDto Params)
        {
            List<T> listObjects = [];

            if (Params != null)
            {
                object resMethods = await GetMethodsData(Params);

                if (resMethods != null)
                    listObjects = TourDataRow<T>((DataTable)resMethods);
            }

            if (listObjects.Count > 0)
                return await Task.FromResult(listObjects);
            else
                return await Task.FromResult(new List<T>());
        }

        /// <summary>
        /// Método genérico que permite insertar un Objeto de cualquier Tipo T presente dentro ParamsDataDto.Params.
        /// </summary>
        /// <param name="Params">Objeto de tipo ParamsDataDto.</param>
        /// <returns>Task con un Booleano.</returns>
        public async Task<bool> PostObjects(ParamsDataDto Params)
        {
            bool resultObj = false;

            if (Params != null)
            {
                object resMethods = await GetMethodsData(Params);
                string resString = resMethods.ToString()!;

                if (resString != null && resString.Contains("True", StringComparison.OrdinalIgnoreCase))
                    resultObj = true;
            }

            return resultObj;
        }
    }
}