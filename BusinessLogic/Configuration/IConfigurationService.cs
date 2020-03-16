namespace BusinessLogic.Configuration
{
    public interface IConfigurationService
    {
        string ConnectionString(string name);
    }
}