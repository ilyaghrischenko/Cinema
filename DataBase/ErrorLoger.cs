using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataBase
{
    public static class ErrorLoger
    {
        public static async Task LogErrorAsync(string filePath, Exception exception)
        {
            var errorInfo = new
            {
                TimePoint = DateTime.Now,
                ErrorMessage = exception.Message,
                StackTrace = exception.StackTrace
            };

            await File.AppendAllTextAsync(filePath, JsonSerializer.Serialize(errorInfo));
        }
    }
}
