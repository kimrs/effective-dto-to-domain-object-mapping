namespace Eik.ReimbursementApprovals.Responses;

internal record Approval(
    bool IsMedicalNutrition,
    DateTime ValidFrom,
    int MessageCode,
    Numerical ApprovalStatus,
    Numerical ReimbursementArticle,
    Dosage DailyDose
);