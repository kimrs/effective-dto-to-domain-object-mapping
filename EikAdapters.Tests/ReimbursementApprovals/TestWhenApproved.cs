using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using DrugDispenser.Domain.ReimbursementApprovals.Responses;
using Eik.ReimbursementApprovals;
using Functional.Operations;

namespace EikAdapters.Tests.ReimbursementApprovals;

public class TestWhenApproved
{
	[Fact]
	public async Task ForOpiate()
	{
        var httpClient = """
        {
          "EikApi": {
            "Approval": {
              "IsMedicalNutrition": false,
              "ValidFrom": "2023-10-30T00:00:00.000Z",
              "MessageCode": 0,
              "ApprovalStatus": {
                "V": "2",
                "Dn": "Approved"
              },
              "ReimbursementArticle": {
                "V": "300",
                "Dn": "§5-14 §3"
              }
              "DailyDose":{
                "V": "12",
                "U": "OMEQ"
              },
            }
          }
        }
        """.AsResponseFromHttpClient();

        var adapter = new Adapter(httpClient);

        var result = await Request.Create("12345")
          .WithMedicalNutrition("App")
          // .WithDrug("432")
          // .ThatIsOpiate("452")
          .BindAsync(x => adapter.Handle(x));
        
  }

	[Fact]
	public void ForDrug()
	{
        var httpClient = """
        {
        "eikApi": {
            "sokeresultat": {
              "vedtak": [
                {
                  "erNaeringsmiddel": false,
                  "gyldigFraDato": "2023-10-30T00:00:00.000Z",
                  "meldingskode": 0,
                  "refusjonskode": [
                  {
                    "v": "J45",
                    "s": "7435",
                    "dn": "Astma"
                  }
                  ],
                  "refusjonshjemmel": [{"v":"300", "dn":"§5-14 §3"}],
                  "vedtakStatus": {
                    "v": "2",
                    "dn": "Innvilget"
                  },
                  "dogndose":{
                    "v": "12",
                    "u": "OMEQ"
                  },
                  "fastlegeInformasjon": "Russiske dukker er selvopptatte"
                }
              ]
            }
          }
        }
        """.AsResponseFromHttpClient();

        var adapter = new Adapter(httpClient);
  }

	[Fact]
	public void ForMedicalNutrition()
	{
        var httpClient = """
        {
        "eikApi": {
            "sokeresultat": {
              "vedtak": [
                {
                  "erNaeringsmiddel": false,
                  "gyldigFraDato": "2023-10-30T00:00:00.000Z",
                  "meldingskode": 0,
                  "refusjonskode": [
                  {
                    "v": "J45",
                    "s": "7435",
                    "dn": "Astma"
                  }
                  ],
                  "refusjonshjemmel": [{"v":"300", "dn":"§5-14 §3"}],
                  "vedtakStatus": {
                    "v": "2",
                    "dn": "Innvilget"
                  },
                  "dogndose":{
                    "v": "12",
                    "u": "OMEQ"
                  },
                  "fastlegeInformasjon": "Russiske dukker er selvopptatte"
                }
              ]
            }
          }
        }
        """.AsResponseFromHttpClient();

        var adapter = new Adapter(httpClient);
  }
}