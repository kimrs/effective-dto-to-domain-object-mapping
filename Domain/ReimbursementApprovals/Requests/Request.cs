namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record Request
{
	public static Unfinished Create(string patientId)
		=> Unfinished.Create(patientId);
}