using DrugDispenser.ReimbursementApprovals.Requests.Strategy;
using Functional;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests;


public static class TilDomeneExtension
{
	private static readonly IStrategy[] Strategies =
	[
		new Strategy.RetailPrescription(),
		new Strategy.DrugPrescription(),
		new Strategy.OpiatePrescription()
	];

	public static Optional<D.Request> ToDomain(this Request dto)
		=> Strategies.Single(x => x.StrategyFor(dto)).ToDomain(dto);
}