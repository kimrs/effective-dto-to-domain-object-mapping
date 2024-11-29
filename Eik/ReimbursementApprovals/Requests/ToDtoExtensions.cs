using Eik.ReimbursementApprovals.Requests.Strategies;
using Functional;

namespace Eik.ReimbursementApprovals.Requests;

public static class ToDtoExtensions
{
	private static readonly IStrategy[] Strategies =
	[
		new WithMedicalNutritionPrescription(),
		new WithDrugPrescription(),
		new WithOpiatePrescription()
	];

	public static Result<Request> ToDto(this DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> Strategies.Single(x => x.For(domain))
			.ToDto(domain);

	public static string ToMachingeReadable(this DrugDispenser.Domain.Drugs.ItemNumber itemNumber)
		=> $"{{{itemNumber}}}";
}

// public class EikItemNumber : ItemNumber, IFormattable
// {
// 	
// }