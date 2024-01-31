using Microsoft.AspNetCore.Mvc.RazorPages;
using Amazon;
using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Newtonsoft.Json.Linq;

namespace CarBookApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration appConfig)
        {
            _logger = logger;
            _configuration = appConfig;
        }
        // add {get; set; } to ensure the variable is accessible in the view
        public string localVAR { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            //ViewData["Secret"] = GetSecret().Result;
            localVAR = "Hello World!";
            Message = _configuration["Message"];
        }

        async Task<string> GetSecret()
        {
            string secretName = "Secrets";
            string region = "us-east-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception e)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
                throw e;
            }

            try
            {
                JObject secretJson = JObject.Parse(response.SecretString);
                string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string appName = Environment.GetEnvironmentVariable("ASPNETCORE_APPLICATIONNAME");
                return secretJson[$"{appName}_{env}_DB"].ToString();
                

            } catch (Exception e)
            {
                throw e;
            }
        }
    }
}
