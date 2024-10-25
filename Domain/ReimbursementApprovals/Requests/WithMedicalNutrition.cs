using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record WithMedicalNutrition(
	PatientId PatientId,
	string ApprovalType) : Request;

public static partial class E
{
	public static Optional<WithMedicalNutrition> WithMedicalNutrition(
		this Optional<Unfinished> request,
		string applicationType
	) => request.Bind<Unfinished, WithMedicalNutrition>(
		x => new WithMedicalNutrition(
			x.PatientId,
			applicationType));
}