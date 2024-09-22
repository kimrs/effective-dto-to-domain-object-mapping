namespace DrugDispenser.ReimbursementApprovals.Requests;

public record DrugPrescription(string? ItemNumber, string? PrescriberId);

public record RetailPrescription(string? Name);

public record Request(
	string PatientId,
	RetailPrescription? RetailPrescription,
	DrugPrescription? DrugPrescription
);

/*
 * If RetailPrescription is not null, we are dealing with 
 *
 */