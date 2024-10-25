namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record Unfinished
{
	public PatientId PatientId { get; }
	public static Unfinished Create(
		PatientId patientId
	) => new(patientId);

	private Unfinished(PatientId patientId)
	{
		PatientId = patientId;
	}
}