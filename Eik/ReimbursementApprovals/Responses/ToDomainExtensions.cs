using Eik.ReimbursementApprovals.Responses.Strategies;
using Functional;

namespace Eik.ReimbursementApprovals.Responses;

public static class ToDomainExtensions
{
	private static readonly IStrategy[] Strategies =
	[
		new ApprovedForMedicalNutrition(),
		new ApprovedForDrug(),
		new ApprovedForOpiate(),
	];

	internal static Optional<Domain.Response> ToDomain(
		this Response dto
	) => Strategies.Single(x => x.For(dto)).ToDomain(dto);

	internal static Optional<DateTime> ToDomain(
		this DateTime dto
	) => dto;
}