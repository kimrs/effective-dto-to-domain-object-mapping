namespace Eik.ReimbursementApprovals.Requests;

public record Request(
	string PatientId,
	string? Name,
	string? ItemNumber,
	string? PrescriberId
);