namespace RequestService.Policies;

using Polly;
using Polly.Retry;

public class ClientPolicies
{
    public AsyncRetryPolicy<HttpResponseMessage> ImmidateHttpRetryPolicy { get; }

    public ClientPolicies()
    {
        ImmidateHttpRetryPolicy = Policy
            .HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
            .RetryAsync(5);
    }
}