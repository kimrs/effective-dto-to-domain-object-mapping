using DrugDispenser.Domain;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using DrugDispenser.Domain.Retail;
using Functional;
using Functional.Operations;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategies;

public class RetailPrescription
	: IStrategy
{
	public bool For(Request r)
		=> r is { RetailPrescription: not null, DrugPrescription: null };

	public Optional<D.Request> ToDomain(Request dto)
		=> dto.Combine(
			x => PatientId.Create(x.PatientId),
			x => Name.Create(x.RetailPrescription!.Name!)
		).Bind<(PatientId patientId, Name name), D.Request>(
			x => D.Request
				.Create(x.patientId)
				.WithMedicalNutrition(x.name)
				.Bind<WithMedicalNutrition, D.Request>(x => x));
}