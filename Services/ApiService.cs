using System.Text;

namespace CopilotIntergrationDemo.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Performs a GET request to the specified URL and returns the response as a string
        /// </summary>
        /// <param name="url">The URL to send the GET request to</param>
        /// <returns>The response content as a string</returns>
        public async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error making GET request to {url}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Performs a POST request to the specified URL with optional content
        /// </summary>
        /// <param name="url">The URL to send the POST request to</param>
        /// <param name="content">Optional JSON content to send in the request body</param>
        /// <returns>The response content as a string</returns>
        public async Task<string> PostAsync(string url, string? content = default)
        {
            try
            {
                HttpContent? httpContent = default;
                if (!string.IsNullOrEmpty(content))
                {
                    httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                }

                var response = await _httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error making POST request to {url}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Performs a PUT request to the specified URL with optional content
        /// </summary>
        /// <param name="url">The URL to send the PUT request to</param>
        /// <param name="content">Optional JSON content to send in the request body</param>
        /// <returns>The response content as a string</returns>
        public async Task<string> PutAsync(string url, string? content = default)
        {
            try
            {
                HttpContent? httpContent = default;
                if (!string.IsNullOrEmpty(content))
                {
                    httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                }

                var response = await _httpClient.PutAsync(url, httpContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error making PUT request to {url}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Performs a DELETE request to the specified URL
        /// </summary>
        /// <param name="url">The URL to send the DELETE request to</param>
        /// <returns>The response content as a string</returns>
        public async Task<string> DeleteAsync(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error making DELETE request to {url}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred: {ex.Message}", ex);
            }
        }
    }
}