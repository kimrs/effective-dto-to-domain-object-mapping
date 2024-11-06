using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;

public record WithMedicalNutrition(
	PatientId PatientId,
	string ApprovalType) : Request;

public static partial class E
{
	public static Optional<WithMedicalNutrition> WithMedicalNutrition(
		this Optional<Create> request,
		string applicationType
	) => request.Bind<Create, WithMedicalNutrition>(
		x => new WithMedicalNutrition(
			x.PatientId,
			applicationType));
}