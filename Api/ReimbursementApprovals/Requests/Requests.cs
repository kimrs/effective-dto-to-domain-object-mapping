namespace DrugDispenser.ReimbursementApprovals.Requests;

public record Code(string? CodingSystem, string? Id);
public record IdNumber(string? Number, string? Type);
public record Request(IdNumber? IdNumber, Code? Code);
	