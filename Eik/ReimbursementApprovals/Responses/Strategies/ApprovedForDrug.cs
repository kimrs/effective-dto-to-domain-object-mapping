﻿using DrugDispenser.Domain;
using Functional;
using Functional.Operations;
using Drugs = DrugDispenser.Domain.Drugs;

namespace Eik.ReimbursementApprovals.Responses.Strategies;

internal class ApprovedForDrug
    : IStrategy
{
    public bool For(Response dto)
        => dto is {EikApi.Approval: {IsMedicalNutrition: false, DailyDose: null}};

    public Result<Domain.Response> ToDomain(Response dto)
        => ToDomain(dto.EikApi.Approval);

    private Result<Domain.Response> ToDomain(Approval dto)
        => dto.Combine(
            x => ApprovalDate.Create(x.ValidFrom!.Value),
            x => Drugs.Article.Create(x.ReimbursementArticle.V, x.ReimbursementArticle.Dn)
        ).Then<(ApprovalDate validFrom, Drugs.Article article), Domain.Response>(
            x => new Domain.Responses.ApprovedForDrug(x.validFrom, x.article)
        );
}