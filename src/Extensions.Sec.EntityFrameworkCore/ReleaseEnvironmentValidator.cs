using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Validators;

using Gnome.Extensions.FluentValidation;

namespace Gnome.Extensions.Sec;

public class ReleaseEnvironmentValidator<TKey> : AbstractValidator<ReleaseEnvironment<TKey>>
    where TKey : IEquatable<TKey>
{
    public ReleaseEnvironmentValidator()
    {
        this.RuleFor(o => o.Key).NotEmpty().MaximumLength(64).SetValidator(new StringFormatValidator(Caseing.Kebab, new[] { '-' }));
    }
}