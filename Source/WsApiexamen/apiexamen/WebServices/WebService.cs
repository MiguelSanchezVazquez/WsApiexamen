using ApiExamen.Model;
using BdiExamen.Dtos;
using System.Net.Http.Json;

namespace ApiExamen.WebServices
{
    public class WebServiceExamen
    {
        public async Task<ExamenResponse> AgregarExamenAsync(ExamenDto examen)
        {
            HttpClient httpClient = new HttpClient();
            ExamenResponse exaResponse = new ExamenResponse();

            try
            {
                string url = "https://localhost:7178/Examen/AgregarExamen";

                // Send the POST request with the JSON body automatically serialized
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, examen);

                // 4. Handle and deserialize the response
                if (response.IsSuccessStatusCode)
                {
                    ReturnDataModel? result = await response.Content.ReadFromJsonAsync<ReturnDataModel>();

                    exaResponse.Message = result.Message;
                }
                else
                {
                    exaResponse.Success = false;
                    exaResponse.Message = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                exaResponse.Success = false;
                exaResponse.Message = ex.Message;
            }

            return exaResponse;
        }

        public async Task<ExamenResponse> ActualizarExamenAsync(ExamenDto examen)
        {
            HttpClient httpClient = new HttpClient();
            ExamenResponse exaResponse = new ExamenResponse();

            try
            {
                string url = "https://localhost:7178/Examen/ActualizarExamen";

                // Send the POST request with the JSON body automatically serialized
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, examen);

                // 4. Handle and deserialize the response
                if (response.IsSuccessStatusCode)
                {
                    ReturnDataModel? result = await response.Content.ReadFromJsonAsync<ReturnDataModel>();

                    exaResponse.Message = result.Message;
                }
                else
                {
                    exaResponse.Success = false;
                    exaResponse.Message = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Handle or log your exception here
                exaResponse.Success = false;
                exaResponse.Message = ex.Message;
            }

            return exaResponse;
        }

        public async Task<ExamenResponse> EliminarExamenAsync(int idExamen)
        {
            HttpClient httpClient = new HttpClient();
            ExamenResponse exaResponse = new ExamenResponse();

            try
            {
                string url = $"https://localhost:7178/Examen/EliminarExamen?examenId={idExamen}";

                // Send the POST request with the JSON body automatically serialized
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, idExamen);

                // 4. Handle and deserialize the response
                if (response.IsSuccessStatusCode)
                {
                    ReturnDataModel? result = await response.Content.ReadFromJsonAsync<ReturnDataModel>();

                    exaResponse.Message = result.Message;
                }
                else
                {
                    exaResponse.Success = false;
                    exaResponse.Message = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Handle or log your exception here
                exaResponse.Success = false;
                exaResponse.Message = ex.Message;
            }

            return exaResponse;
        }

        public async Task<ExamenResponse> ConsultarExamenAsync(int idExamen)
        {
            HttpClient httpClient = new HttpClient();
            ExamenResponse exaResponse = new ExamenResponse();

            try
            {
                string url = $"https://localhost:7178/Examen/ConsultarExamen?examenId={idExamen}";

                // Send the POST request with the JSON body automatically serialized
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, idExamen);

                // 4. Handle and deserialize the response
                if (response.IsSuccessStatusCode)
                {
                    ReturnExamenDataModel? result = await response.Content.ReadFromJsonAsync<ReturnExamenDataModel>();

                    exaResponse.Examen = result.Examen;
                }
                else
                {
                    exaResponse.Success = false;
                    exaResponse.Message = $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Handle or log your exception here
                exaResponse.Success = false;
                exaResponse.Message = ex.Message;
            }

            return exaResponse;
        }
    }
}
