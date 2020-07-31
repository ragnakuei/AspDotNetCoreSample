namespace SharedLibrary.Dto
{
    public class ApiConfig
    {
        public CorsSettings Cors { get; set; }
    }

    public class CorsSettings
    {
        public string[] Origins { get; set; }
    }
}
