namespace CopilotIntergrationDemo.Services
{
    public interface IApiService
    {
        Task<string> GetAsync(string url);
        Task<string> PostAsync(string url, string content = null);
        Task<string> PutAsync(string url, string content = null);
        Task<string> DeleteAsync(string url);
    }
}