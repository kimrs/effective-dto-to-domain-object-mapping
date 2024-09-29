using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithMedicalNutritionPrescription
	: IStrategy
{
	public bool For(DrugDispenser.Domain.ReimbursementApprovals.Request domain)
		=> domain is Domain.Requests.WithMedicalNutrition;

	public Optional<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Request domain)
		=> domain is Domain.Requests.WithMedicalNutrition withMedicalNutrition
			? new Request(
				PatientId: withMedicalNutrition.PatientId,
				ApprovalType: withMedicalNutrition.ApprovalType,
				ItemNumber: null,
				PrescriberId: null
			) : new NotSupportedException(domain.GetType().FullName);
}