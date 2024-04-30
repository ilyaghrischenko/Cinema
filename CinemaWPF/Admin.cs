using System.IO;
using System.Text.Json;

namespace CinemaWPF
{
    public class Admin(string login, string password)
    {
        public string Login { get; set; } = login;
        public string Password { get; set; } = password;
        private string FilePath { get; } = "admin.json";

        public async Task<bool> Check()
        {
            Admin? admin = await JsonSerializer.DeserializeAsync<Admin>(File.OpenRead(FilePath));
            if (admin == null) return false;
            if (ToString() == admin.ToString()) return true;
            return false;
        }
        public override string ToString()
        {
            return $"Login: {Login}, Password: {Password}";
        }
    }
}
