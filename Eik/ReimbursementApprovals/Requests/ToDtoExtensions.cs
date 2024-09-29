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

	public static Optional<Request> ToDto(this DrugDispenser.Domain.ReimbursementApprovals.Request domain)
		=> Strategies.Single(x => x.For(domain)).ToDto(domain);
}