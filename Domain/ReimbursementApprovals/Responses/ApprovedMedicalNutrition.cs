namespace DrugDispenser.Domain.ReimbursementApprovals.Responses;

public record ApprovedForMedicalNutrition(
    DateTime ValidFrom
) : Response;