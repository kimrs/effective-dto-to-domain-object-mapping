using DrugDispenser.ReimbursementApprovals.Requests.Strategies;
using Functional;

namespace DrugDispenser.ReimbursementApprovals.Requests;


public static class TilDomeneExtension
{
	private static readonly IStrategy[] Strategies =
	[
		new Strategies.RetailPrescription(),
		new Strategies.DrugPrescription(),
		new OpiatePrescription()
	];

	public static Result<Domain.ReimbursementApprovals.Requests.Request> ToDomain(this Request dto)
		=> Strategies.Single(x => x.For(dto)).ToDomain(dto);
}