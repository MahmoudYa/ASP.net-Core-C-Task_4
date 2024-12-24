using REAL_Estate.Resources;

namespace REAL_Estate.Components.Mvc;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class GreaterThanAttribute : ValidationAttribute
{
    public Decimal Minimum { get; }

    public GreaterThanAttribute(Double minimum)
        : base(() => Validation.For("GreaterThan"))
    {
        Minimum = Convert.ToDecimal(minimum);
    }

    public override String FormatErrorMessage(String name)
    {
        return String.Format(ErrorMessageString, name, Minimum);
    }
    public override Boolean IsValid(Object? value)
    {
        try
        {
            return value == null || Minimum < Convert.ToDecimal(value);
        }
        catch
        {
            return false;
        }
    }
}