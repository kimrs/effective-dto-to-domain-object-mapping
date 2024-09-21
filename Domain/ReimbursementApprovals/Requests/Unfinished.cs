namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record Unfinished
{
	public string PatientId { get; }
	public static Unfinished Create(
		string patientId
	) => new(patientId);

	private Unfinished(string patientId)
	{
		PatientId = patientId;
	}
}