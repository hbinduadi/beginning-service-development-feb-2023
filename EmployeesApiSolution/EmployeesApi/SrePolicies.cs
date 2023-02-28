using Polly;
using Polly.Extensions.Http;

namespace EmployeesApi;

public static class SrePolicies
{
    public static IAsyncPolicy<HttpResponseMessage> GetDefaultRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(5, retryattempt => TimeSpan.FromSeconds(Math.Pow(2, retryattempt)));
    }

    public static IAsyncPolicy<HttpResponseMessage> GetDefaultCircuitBreaker()
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
    }

}
