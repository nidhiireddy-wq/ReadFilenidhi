using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ReadFile;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("Function1")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        string filePath = @"C:\Users\Inno\source\repos\sample.txt";

        if (!File.Exists(filePath))
        {
            return new NotFoundObjectResult("File not found!.");
        }

        string fileContent = File.ReadAllText(filePath);

        return new OkObjectResult(fileContent);
    }
}