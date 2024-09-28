using Functional;

namespace Eik.Requests.Strategies;

public class WithMedicalNutritionPrescription
	: IStrategy
{
	public bool For(Domain.Request domain)
		=> domain is Domain.WithMedicalNutrition;

	public Optional<Request> ToDto(Domain.Request domain)
		=> domain is Domain.WithMedicalNutrition withMedicalNutrition
			? new Request(
				PatientId: withMedicalNutrition.PatientId,
				ApprovalType: withMedicalNutrition.ApprovalType,
				ItemNumber: null,
				PrescriberId: null
			) : new NotSupportedException(domain.GetType().FullName);
}