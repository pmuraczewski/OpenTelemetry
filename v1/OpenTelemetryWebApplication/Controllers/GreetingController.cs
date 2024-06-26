using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using OpenTelemetry;
using System.Threading;

namespace OpenTelemetryWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly ILogger<GreetingController> _logger;
        private readonly Meter _greetingMeter;
        private readonly Counter<int> _greetingsCounter;
        private readonly Histogram<int> _greetingsRate;
        private readonly ActivitySource _greeterActivitySource;

        public GreetingController(ILogger<GreetingController> logger)
        {
            _logger = logger;

            // Custom metrics for the application
            _greetingMeter = new Meter("OtPrGrYa.Example", "1.0.0");

            // Custom counter
            _greetingsCounter = _greetingMeter.CreateCounter<int>("greetings.count", description: "Counts the number of greetings");

            // Custom histogram
            _greetingsRate = _greetingMeter.CreateHistogram<int>("greetings.rate", description: "rate of greeting quality", unit: "percentage");

            // Custom ActivitySource for the application
            _greeterActivitySource = new ActivitySource("OtPrGrJa.Example");
        }

        [HttpGet("generate-greeting-rate")]
        public string GenerateGreetingRate()
        {
            // Create a new Activity scoped to the method
            using var activity = _greeterActivitySource.StartActivity("GreetingRate");

            // Log a message
            _logger.LogInformation("Generating greeting rate");

            for (int i = 0; i < 20; i++)
            {
                // generate random rate
                var record = Random.Shared.Next(1, 100);
                _greetingsRate.Record(record);
                Thread.Sleep(30000);
            }

            return string.Empty;
        }

        [HttpGet("greeting")]
        public string SendGreeting()
        {
            // Create a new Activity scoped to the method
            using var activity = _greeterActivitySource.StartActivity("GreeterActivity");

            // Log a message
            _logger.LogInformation("Sending greeting");

            // Increment the custom counter
            _greetingsCounter.Add(1);

            // Add a tag to the Activity
            activity?.SetTag("greeting", "Hello World!");

            return "Hello World!";
        }

        [HttpGet]
        public IActionResult Get()
        {
            var infoFromContext = Baggage.Current.GetBaggage("ExampleItem");

            using var source = new ActivitySource("ExampleTracer");

            // A span
            using var activity = source.StartActivity("In Service B GET method");
            activity?.SetTag("InfoServiceBReceived", infoFromContext);
            return Ok();
        }
    }
}
