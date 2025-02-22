using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Integracao.UploadService
{
    public class UploadService 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UploadService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Upload(string id, List<IFormFile> arquivos)
        {
            using (var HttpClient client = _httpClientFactory.CreateClient("Upload")) 
            {
                var response = await client.PostAsync($"/api/v1/upload/{id}", arquivos);

                if (response.IsSuccessStatusCode) {
                    var result = await response.Content.ReadAsStringAsync();
                }
            }

            return "Nao houve upload de arquivos";
        }
    }
}