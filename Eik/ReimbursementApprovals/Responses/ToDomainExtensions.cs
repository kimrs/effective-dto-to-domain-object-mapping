using Eik.ReimbursementApprovals.Responses.Strategies;
using Functional;
using Functional.Operations;

namespace Eik.ReimbursementApprovals.Responses;

public static class ToDomainExtensions
{
	private static readonly IStrategy[] Strategies =
	[
		new ApprovedForMedicalNutrition(),
		new ApprovedForDrug(),
		new ApprovedForOpiate(),
	];

	internal static Result<Domain.Response> ToDomain(
		this Response dto
	) => dto.Validate()
		.Then(x => Strategies.Single(y => y.For(x)).ToDomain(x));
}