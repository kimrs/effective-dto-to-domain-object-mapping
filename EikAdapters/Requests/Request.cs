namespace Eik.Requests;

public record Request(
	string PatientId,
	string? ApprovalType,
	string? ItemNumber,
	string? PrescriberId
);