
using Eik.Requests.Strategies;
using Functional;

namespace Eik.Requests;

public static class ToDtoExtensions
{
	private static readonly IStrategy[] Strategies =
	[
		new WithMedicalNutritionPrescription(),
		new WithDrugPrescription(),
		new WithOpiatePrescription()
	];

	public static Optional<Request> ToDto(this Domain.Request domain)
		=> Strategies.Single(x => x.For(domain)).ToDto(domain);
}