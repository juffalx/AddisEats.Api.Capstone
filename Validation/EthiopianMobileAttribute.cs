using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AddisEats.Api.Validations;

public class EthiopianMobileAttribute : ValidationAttribute
{
    private static  readonly Regex PhoneRegex = new(@"^(?:+251|0)(?:7|9)\d\d{8}$", RegexOptions.Compiled);
}