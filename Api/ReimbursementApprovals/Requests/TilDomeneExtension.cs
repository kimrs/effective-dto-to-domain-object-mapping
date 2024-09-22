using DrugDispenser.Domain;
using DrugDispenser.Domain.Drug;
using DrugDispenser.Domain.ReimbursementApprovals.Requests;
using DrugDispenser.Domain.Retail;
using Functional;
using Functional.Operations;
using D = DrugDispenser.Domain.ReimbursementApprovals.Requests;

namespace DrugDispenser.ReimbursementApprovals.Requests;


public static class TilDomeneExtension
{
	public static Optional<D.Request> ToDomain(this Request dto)
		=> dto switch
		{
			{ RetailPrescription: not null, DrugPrescription: null } =>  dto
				.Combine(
					x => PatientId.Create(x.PatientId),
					x => Name.Create(x.RetailPrescription!.Name)
				).Bind<(PatientId patientId, Name name), D.Request>(
					x => D.Request
						.Create(x.patientId)
						.WithMedicalNutrition(x.name)
						.Bind<WithMedicalNutrition, D.Request>(x => x)
				),
			{ RetailPrescription: null, DrugPrescription.PrescriberId: not null } => dto
				.Combine(
					x => PatientId.Create(x.PatientId),
					x => ItemNumber.Create(x.DrugPrescription!.ItemNumber),
					x => PrescriberId.Create(x.DrugPrescription!.PrescriberId)
					).Bind<(PatientId patientId, ItemNumber itemNumber, PrescriberId prescriberId), D.Request>(
						x => D.Request
							.Create(x.patientId)
							.WithDrug(x.itemNumber)
							.ThatIsOpiate(x.prescriberId)
							.Bind<ThatIsOpiate, D.Request>(x => x)
					),
			{ RetailPrescription: null, DrugPrescription: not null } => dto
				.Combine(
					x => PatientId.Create(x.PatientId),
					x => ItemNumber.Create(x.DrugPrescription!.ItemNumber)
					).Bind<(PatientId patientId, ItemNumber itemNumber), D.Request>(
						x => D.Request
							.Create(x.patientId)
							.WithDrug(x.itemNumber)
							.Bind<WithDrug, D.Request>(x => x)
					),
			_ => new Exception("Dette fikk vi ikke til")
		};
}