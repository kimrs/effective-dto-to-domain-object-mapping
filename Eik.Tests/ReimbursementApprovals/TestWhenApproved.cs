using DrugDispenser.Domain;
using DrugDispenser.Domain.Drugs;
using DrugDispenser.Domain.ReimbursementApprovals;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Eik.ReimbursementApprovals;
using FluentAssertions;
using Functional;
using Functional.Operations;

namespace EikAdapters.Tests.ReimbursementApprovals;

public class TestWhenApproved
{
  public Optional<string> D()
  {
    return (Completional<string>)"hello";
  }
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
        var patientId = "12345".ToPatientId();
        var itemNumber = "432".ToItemNumber();
        var prescriberId = "kjsdhfas".ToPrescriberId();

        var result = await Request.Create(patientId)
          .WithDrug(itemNumber)
          .ThatIsNotOpiate()
          // .ThatIsOpiate(prescriberId)
          .BindAsync(x => adapter.Handle(x));
        // _ = result is Completional<Response> {Value: ApprovedForOptiate approvedForOptiate};

        result.Should().BeOfType<Completional<Response>>();
  }
}

internal static class E
{
  internal static PatientId ToPatientId(
    this string patientId
  ) => (PatientId.Create(patientId) as Completional<PatientId>)!.Value;

  internal static ItemNumber ToItemNumber(
    this string itemNumber
  ) => (ItemNumber.Create(itemNumber) as Completional<ItemNumber>)!.Value;
  
  internal static PrescriberId ToPrescriberId(
    this string prescriberId
  ) => (PrescriberId.Create(prescriberId) as Completional<PrescriberId>)!.Value;
}