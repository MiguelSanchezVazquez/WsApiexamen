using BdiExamen.Dtos;
using ApiExamen.StoreProcedures;
using ApiExamen.Model;
using ApiExamen.WebServices;

namespace ApiExamen
{
    public static class ClsExamen
    {
        private static bool _callWebService = true;
        private static WebServiceExamen _webService = new WebServiceExamen();
        private static StoreProcedure _storeProcedure = new StoreProcedure();

        public static void CallWebService(bool callWebService)
        {
            _callWebService = callWebService;
        }

        public static async Task<ExamenResponse> AgregarExamenAsync(ExamenDto examen)
        {
            ExamenResponse response = new ExamenResponse();

            string validData = ValidateData(examen);
            if (!String.IsNullOrEmpty(validData))
            {
                response.Success = false;
                response.Message = validData;

                return response;
            }

            if (_callWebService)
                response = await _webService.AgregarExamenAsync(examen);
            else
                response = _storeProcedure.AgregarExamen(examen);

            return response;
        }

        public static async Task<ExamenResponse> ActualizarExamenAsync(ExamenDto examen)
        {
            ExamenResponse response = new ExamenResponse();

            string validData = ValidateData(examen);
            if (!String.IsNullOrEmpty(validData))
            {
                response.Success = false;
                response.Message = validData;

                return response;
            }

            if (_callWebService)
                response = await _webService.ActualizarExamenAsync(examen);
            else
                response = _storeProcedure.ActualizarExamen(examen);

            return response;
        }

        public static async Task<ExamenResponse> EliminarExamenAsync(int idExamen)
        {
            ExamenResponse response = new ExamenResponse();

            if (idExamen <= 0)
            {
                response.Success = false;
                response.Message = "Id invalido";

                return response;
            }

            if (_callWebService)
                response = await _webService.EliminarExamenAsync(idExamen);
            else
                response = _storeProcedure.EliminarExamen(idExamen);

            return response;
        }

        public static async Task<ExamenResponse> ConsultarExamenAsync(int idExamen)
        {
            ExamenResponse response = new ExamenResponse();

            if (idExamen <= 0)
            {
                response.Success = false;
                response.Message = "Id invalido";

                return response;
            }

            if (_callWebService)
                response = await _webService.ConsultarExamenAsync(idExamen);
            else
                response = _storeProcedure.ConsultarExamen(idExamen);

            return response;
        }

        private static string ValidateData(ExamenDto examen)
        {
            if (examen == null)
                return "Datos invalidos";

            if (examen.idExamen <= 0)
                return "Id invalido";

            if (String.IsNullOrEmpty(examen.Nombre))
                return "El Nombre no puede estar vacio";

            if (String.IsNullOrEmpty(examen.Descripcion))
                return "La Descripcion no puede estar vacia";

            return null;
        }
    }
}
