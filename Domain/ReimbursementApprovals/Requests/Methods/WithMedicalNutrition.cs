﻿using DrugDispenser.Domain.Retail;
using Functional;
using Functional.Operations;

namespace DrugDispenser.Domain.ReimbursementApprovals.Requests.Methods;

public record WithMedicalNutrition(
	PatientId PatientId,
	Name Name) : Request;

public static partial class E
{
	public static Optional<WithMedicalNutrition> WithMedicalNutrition(
		this Optional<Create> request,
		Name name
	) => request.Bind<Create, WithMedicalNutrition>(
		x => new WithMedicalNutrition(
			x.PatientId,
			name));
}