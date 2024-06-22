using System.Text.Json.Serialization;

using FluentValidation;
using FluentValidation.Results;

using Gnome.Sys;

namespace Gnome.Extensions.FluentValidation;

[JsonConverter(typeof(DynamicErrorJsonConverter))]
public class ValidationError : DynamicError
{
    public ValidationError(string? message = null, string? target = null, IInnerError? inner = null)
        : base(message, target, inner)
    {
    }

    public static implicit operator ValidationError(ValidationException ex)
        => ConvertFrom(ex);

    public static implicit operator ValidationError(ValidationResult result)
        => ConvertFrom(result);

    public static implicit operator ValidationError(ValidationFailure result)
        => ConvertFrom(result);

    public static ValidationError ConvertFrom(ValidationFailure result)
    {
        var error = new ValidationError(result.ErrorMessage, result.PropertyName);
        error.Code = result.ErrorCode;
        error.Properties["severity"] = result.Severity;
        return error;
    }

    public static ValidationError ConvertFrom(ValidationResult result)
    {
        var error = new ValidationError(result.ToString());
        var errors = new List<object?>();
        error.Properties["validationErrors"] = errors;
        foreach (var ve in result.Errors)
        {
            var next = new Dictionary<string, object?>();
            next["message"] = ve.ErrorMessage;
            next["propertyName"] = ve.PropertyName;
            next["severity"] = ve.Severity;
            next["code"] = ve.ErrorCode;
            errors.Add(next);
        }

        return error;
    }

    public static ValidationError ConvertFrom(ValidationException ex)
    {
        var list = ex.Errors.ToList();
        if (list.Count == 1)
        {
            var e = list[0];
            var error1 = new ValidationError(e.ErrorMessage, e.PropertyName);
            error1.Code = e.ErrorCode;
            error1.Properties["severity"] = e.Severity;
            return error1;
        }

        var error = new ValidationError(ex.Message);
        var errors = new List<object?>();
        error.Properties["validationErrors"] = errors;
        foreach (var ve in ex.Errors)
        {
            var next = new Dictionary<string, object?>();
            next["message"] = ve.ErrorMessage;
            next["propertyName"] = ve.PropertyName;
            next["severity"] = ve.Severity;
            next["code"] = ve.ErrorCode;
            errors.Add(next);
        }

        return error;
    }
}