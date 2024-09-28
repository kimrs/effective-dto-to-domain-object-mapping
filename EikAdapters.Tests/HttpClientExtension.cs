using Moq;
using Moq.Protected;

namespace EikAdapters.Tests;

public static class HttpClientExtension
{
    public static HttpClient AsResponseFromHttpClient(
        this string responsStreng
    )
    {
        var respons = new HttpResponseMessage();
        respons.Content = new StringContent(responsStreng);

        return respons.AsResponseFromHttpClient();
    }

    private static HttpClient AsResponseFromHttpClient(
        this HttpResponseMessage respons
    )
    {
        var httpMessageHandler = new Mock<HttpMessageHandler>();
        httpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Returns((HttpRequestMessage _, CancellationToken _) => Task.FromResult(respons));
        var httpClient = new HttpClient(httpMessageHandler.Object);
        httpClient.BaseAddress = new Uri("https://test");

        return httpClient;
    }
	
}