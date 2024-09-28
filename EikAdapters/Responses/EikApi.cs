namespace Eik.Responses;

internal record EikApi(Approval Approval);

internal record Approval(
	bool IsMedicalNutrition,
	DateTime ValidFrom,
	int messageCode,
	ApprovalStatus ApprovalStatus,
	ReimbursementArticle ReimbursementArticle,
	DailyDose DailyDose
);

internal record ApprovalStatus(
	string V,
	string Dn
);

internal record ReimbursementArticle(
	string V,
	string Dn
);

internal record DailyDose(
	string V,
	string Dn
);