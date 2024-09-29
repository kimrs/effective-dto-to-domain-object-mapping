using DrugDispenser.Domain.Drug;
using DrugDispenser.Domain.Drugs;

namespace DrugDispenser.Domain.ReimbursementApprovals.Responses;

public record ApprovedForOptiate(
    DateTime ValidFrom,
    Article Reimbursement,
    Dosage DailyDose
) : Response;
