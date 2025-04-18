using System.Net.Http.Headers;

namespace Integracao.UploadService
{
    public interface IUploadService 
    {
        Task<string> Upload(string id, IFormFileCollection arquivos);
         
    }
    public class UploadService : IUploadService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UploadService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Upload(string id, IFormFileCollection arquivos) 
        {
              using (HttpClient client = _httpClientFactory.CreateClient("Upload")) 
            {
                var multipartContent = new MultipartFormDataContent();
                Console.WriteLine($"Subindo Arquivo {arquivos}");
                foreach (var file in arquivos) {
                    var fileContent = new StreamContent(file.OpenReadStream());

                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                    multipartContent.Add(fileContent, "foto", file.FileName);
                }
                
                var response = await client.PostAsync($"/api/v1/upload/{id}", multipartContent);

                if (response.IsSuccessStatusCode) {
                    return response.ReasonPhrase ?? "Upload de arquvivos feita com Sucesso!";
                }
            }

            return "Nao houve upload de arquivos";
        }
    }
}