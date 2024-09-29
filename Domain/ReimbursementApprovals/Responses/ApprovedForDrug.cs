using DrugDispenser.Domain.Drugs;

namespace DrugDispenser.Domain.ReimbursementApprovals.Responses;

public record ApprovedForDrug(
    DateTime ValidFrom,
    Article Reimbursement
) : Response;