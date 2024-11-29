using DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;
using Functional;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public abstract record Request
{
	public static Result<Create> Create(PatientId patientId)
		=> new Create(patientId);
}