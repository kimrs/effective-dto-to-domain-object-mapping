using DrugDispenser.Domain;
using DrugDispenser.Domain.Drug;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using Functional;
using Functional.Operations;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests.Strategies;

public class DrugPrescription
	: IStrategy
{
	public bool For(Request r)
		=> r is { RetailPrescription: null, DrugPrescription.PrescriberId: null };

	public Optional<Domain.ReimbursementApprovals.Request> ToDomain(Request dto)
		=> dto
			.Combine(
				x => PatientId.Create(x.PatientId),
				x => ItemNumber.Create(x.DrugPrescription!.ItemNumber)
			).Bind<(PatientId patientId, ItemNumber itemNumber), Domain.ReimbursementApprovals.Request>(
				x => Domain.ReimbursementApprovals.Request
					.Create(x.patientId)
					.WithDrug(x.itemNumber)
					.Bind<WithDrug, Domain.ReimbursementApprovals.Request>(x => x));
}