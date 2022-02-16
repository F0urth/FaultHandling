namespace RequestService.Policies;

using Polly;
using Polly.Retry;

public class ClientPolicy
{
    public AsyncRetryPolicy<HttpResponseMessage> ImmidateHttpRetryPolicy { get; }

    public ClientPolicy()
    {
        ImmidateHttpRetryPolicy = Policy
            .HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
            .RetryAsync(5);
    }
}