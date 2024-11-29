using DrugDispenser.Domain.Retail;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;

public record WithMedicalNutrition(
	PatientId PatientId,
	Name Name) : Request;

public static partial class E
{
	public static Result<WithMedicalNutrition> WithMedicalNutrition(
		this Result<Create> request,
		Name name
	) => request.Then<Create, WithMedicalNutrition>(
		x => new WithMedicalNutrition(
			x.PatientId,
			name));
}