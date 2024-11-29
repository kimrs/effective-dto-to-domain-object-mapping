using System.Text;
using System.Text.Json;
using Eik.ReimbursementApprovals.Requests;
using Eik.ReimbursementApprovals.Responses;
using Functional;
using Request = DrugDispenser.Domain.ReimbursementApprovals.Requests.Request;

namespace Eik.ReimbursementApprovals;

public class Adapter(HttpClient httpClient)
	: Domain.IAdapter
{
	public async Task<Result<Domain.Response>> Handle(Request request)
	{
		var dto = request.ToDto();
		var json = JsonSerializer.Serialize(dto);
		var content = new StringContent(json, Encoding.UTF8, "application/json");
		try
		{
			using var response = await httpClient.PostAsync("https://localhost:5098", content);
			response.EnsureSuccessStatusCode();
			var responseContent = await response.Content.ReadAsStringAsync();
			return JsonSerializer
				.Deserialize<Response>(responseContent)!
				.ToDomain();
		}
		catch (Exception ex)
		{
			return ex;
		}
	}
}