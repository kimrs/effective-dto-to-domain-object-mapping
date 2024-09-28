using DrugDispenser.ReimbursementApprovals.Requests.Strategies;
using Functional;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests;


public static class TilDomeneExtension
{
	private static readonly IStrategy[] Strategies =
	[
		new Strategies.RetailPrescription(),
		new Strategies.DrugPrescription(),
		new OpiatePrescription()
	];

	public static Optional<D.Request> ToDomain(this Request dto)
		=> Strategies.Single(x => x.For(dto)).ToDomain(dto);
}