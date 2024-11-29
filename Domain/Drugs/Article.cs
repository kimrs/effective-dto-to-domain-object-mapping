using FluentValidation;
using Functional;

namespace DrugDispenser.Domain.Drugs;

public record Article
{
    public string Nr { get; }
    public string Section { get; }


    public static Article A300S5 = new("300", "§5-14 §3");
    public static Article A350S2 = new("350", "§2-10");
    public static Article A200S5 = new("200", "§5-14 §3");
    public static Article A250S2 = new("250", "§2-10");

    public static Result<Article> Create(string nr, string section)
    {
	    Article article = new(nr, section);
	    return article.Validate();
    }

    private Article(string nr, string section)
    {
        Nr = nr;
        Section = section;
    }

	private Result<Article> Validate()
	{
		var result = new Validator().Validate(this);
		return result.IsValid
			? (Completional<Article>)this
			: result.Errors;
	}

	private class Validator
		: AbstractValidator<Article>
	{
		public Validator()
		{
			RuleFor(x => x.Nr)
				.NotEmpty()
				.Length(3)
				.Matches("^[0-9]*$");

			RuleFor(x => x.Section)
				.NotEmpty();

			RuleFor(x => x.Section)
				.Equal("§5-14 §3")
				.When(x => x.Nr == "300");

			RuleFor(x => x.Section)
				.Equal("§2-10")
				.When(x => x.Nr == "350");
			
			RuleFor(x => x.Section)
				.Equal("§2-10")
				.When(x => x.Nr == "250");
			
			RuleFor(x => x.Section)
				.Equal("§5-14 §3")
				.When(x => x.Nr == "200");
		}
	}
}