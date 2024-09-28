using System.Text.Json.Nodes;

namespace EikAdapters.Tests;
public class RequestContent
{
    private readonly string _value;
    public static implicit operator RequestContent(string x) => new(x);
    public static implicit operator string(RequestContent x) => x._value;
    public RequestContent this[string s] => JsonNode.Parse(_value)![s]!.ToJsonString();

    private RequestContent(string value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
    }
}
