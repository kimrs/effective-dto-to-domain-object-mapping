namespace EikAdapters.Tests;

public class MockHttpMessageHandler : HttpMessageHandler
{
    public RequestContent? RequestContent { get; private set; }
    public int AntallKall { get; private set; } = 0;
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        AntallKall++;
        RequestContent = await request.Content!.ReadAsStringAsync(cancellationToken);
        return new HttpResponseMessage();
    }
}