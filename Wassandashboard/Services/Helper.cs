using Microsoft.AspNetCore.Components.Forms;

namespace Wassandashboard.Services
{
    public static class Helper
    {
        public static string ToLabelCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }


        public static async Task<(bool IsValid, string? ErrorMessage, string? FilePath)> ValidateAndUploadFileAsync(
        IBrowserFile file,
        int fileTypeKey,
        string fileContext, // New parameter for context-specific messages    
        string uploadFolder)
        {
            if (file == null)
                return (false, $"{fileContext} is required", null);

            var allowedFileTypes = GetAllowedFileTypes(fileTypeKey);
            var fileType = file.ContentType.ToLower();

            if (!allowedFileTypes.Contains(fileType))
                return (false, $"Invalid file type for {fileContext}", null);

            var response = await FileUploadService.Upload(file, uploadFolder);
            if (!response.IsSucceded)
                return (false, $"Failed to upload {fileContext}", null);

            return (true, null, response.Path);
        }


        // Dictionary to store allowed file types by key
        private static readonly Dictionary<int, string[]> FileTypes = new()
        {
            {
                1, new[] // Key 1 for images
                {
                    "image/jpeg", "image/png", "image/gif",
                    "image/bmp", "image/tiff", "image/webp", "image/jpg"
                }
            },
            {
                2, new[] // Key 2 for documents
                {
                    "application/pdf",
                    "application/msword",
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    "application/vnd.ms-excel",
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                }
            }
        };

        // Method to get allowed file types by key
        public static string[] GetAllowedFileTypes(int key)
        {
            return FileTypes.TryGetValue(key, out var types) ? types : Array.Empty<string>();
        }

    }
}
