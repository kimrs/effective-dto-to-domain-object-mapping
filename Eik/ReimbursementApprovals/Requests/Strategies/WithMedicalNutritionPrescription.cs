using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Functional;

namespace Eik.ReimbursementApprovals.Requests.Strategies;

public class WithMedicalNutritionPrescription
	: IStrategy
{
	public bool For(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is WithMedicalNutrition;

	public Optional<Request> ToDto(DrugDispenser.Domain.ReimbursementApprovals.Requests.Request domain)
		=> domain is WithMedicalNutrition withMedicalNutrition
			? new Request(
				PatientId: withMedicalNutrition.PatientId,
				Name: withMedicalNutrition.Name.ToString(),
				ItemNumber: null,
				PrescriberId: null
			) : new NotSupportedException(domain.GetType().FullName);
}