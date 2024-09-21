
namespace DrugDispenser.Domain.ReimbursementApprovals.Requests;

public record ForOpiate(
	string PatientId,
	string ItemNumber,
	string PrescriberId
) : Request;

public static partial class E
{
	public static ForOpiate ForOpiate(
		this WithPrescription request,
		string prescriberId
	) => new ForOpiate(
		request.PatientId,
		request.ItemNumber,
		prescriberId
	);
}