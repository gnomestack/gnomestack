using System.Reflection;

using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Gnome.Extensions.FluentValidation;

public class StringFormatValidator : PropertyValidator
{
    public StringFormatValidator(Caseing caseing, char[] allowedSpecialCharacters)
        : base(new LazyStringSource((c) =>
            $"The value is not in using {caseing} case or has an invalid character not found in {string.Join(',', allowedSpecialCharacters)}."))
    {
        this.Caseing = caseing;
        this.AllowedSpecialCharacters = allowedSpecialCharacters;
    }

    public StringFormatValidator(string errorMessage)
        : base(errorMessage)
    {
    }

    public char[] AllowedSpecialCharacters { get; set; } = Array.Empty<char>();
    
    public Caseing Caseing { get; set; } = Caseing.Lower;

    protected override bool IsValid(PropertyValidatorContext context)
    {
        if (context.PropertyValue is not string value)
            return false;

        if (string.IsNullOrEmpty(value))
            return true;

        bool isLower = false;
        switch (this.Caseing)
        {
            case Caseing.Kebab:
                isLower = true;
                if (Array.IndexOf(this.AllowedSpecialCharacters, '-') == -1)
                {
                    var copy = new char[this.AllowedSpecialCharacters.Length + 1];
                    Array.Copy(this.AllowedSpecialCharacters, copy, this.AllowedSpecialCharacters.Length);
                    copy[copy.Length - 1] = '-';
                }
                break;
            
            case Caseing.Snake:
                isLower = true;
                if (Array.IndexOf(this.AllowedSpecialCharacters, '_') == -1)
                {
                    var copy = new char[this.AllowedSpecialCharacters.Length + 1];
                    Array.Copy(this.AllowedSpecialCharacters, copy, this.AllowedSpecialCharacters.Length);
                    copy[copy.Length - 1] = '_';
                }

                break;
            case Caseing.Lower:
                isLower = true;
                break;
        }

        foreach (var c in value)
        {
            if (char.IsLetter(c))
            {
                if (isLower && !char.IsLower(c))
                    return false;
                if (!isLower && !char.IsUpper(c))
                    return false;
            }
            else if (char.IsDigit(c))
            {
                continue;
            }
            else if (Array.IndexOf(this.AllowedSpecialCharacters, c) == -1)
            {
                return false;
            }
        }

        return true;
    }
}

public enum Caseing
{
    Lower,
    Upper,
    Kebab,
    Snake,
}