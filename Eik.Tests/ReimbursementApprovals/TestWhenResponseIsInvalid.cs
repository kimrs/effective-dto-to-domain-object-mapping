using System.Runtime.CompilerServices;
using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using DrugDispenser.Domain.ReimbursementApprovals.Responses;
using Eik.ReimbursementApprovals;
using FluentAssertions;
using Functional;
using Functional.Operations;

namespace EikAdapters.Tests.ReimbursementApprovals;

public class TestWhenResponseIsInvalid
{
	[Fact]
	public async Task ForMedicalNutrition()
	{
        var httpClient = """
        {
          "EikApi": {
            "Approval": {
              "IsMedicalNutrition": true,
              "MessageCode": 0,
              "ApprovalStatus": {
                "V": "2",
                "Dn": "Approved"
              },
              "ReimbursementArticle": {
                "V": "300",
                "Dn": "§5-14 §3"
              },
              "DailyDose":{
                "V": "12",
                "U": "OMEQ"
              }
            }
          }
        }
        """.AsResponseFromHttpClient();

        var adapter = new Adapter(httpClient);

        var result = await Request.Create("12345".ToPatientId())
           .WithDrug("432".ToItemNumber())
          .BindAsync(x => adapter.Handle(x));

        result.Should().BeOfType<Validational<Response>>();
  }
}