using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using Wassandashboard.Data.Models;

namespace Wassandashboard.Services
{
    public static class FileUploadService
    {
        public static async Task<FileUploadResult> Upload(IBrowserFile file, string folderpath)
        {
            var maxfilesize = 1024 * 1024 * 150;
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpClient = new HttpClient(handler);
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(file.OpenReadStream(maxfilesize)), "file", file.Name);
            content.Add(new StringContent(folderpath), "folder");
            var url = $"https://s3.wassan.org/upload";
            var response = await httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode) return null;
            var data = JsonConvert.DeserializeObject<FileUploadResult>(await response.Content.ReadAsStringAsync());
            data.IsSucceded = true;
            return data;
        }

    }
}
