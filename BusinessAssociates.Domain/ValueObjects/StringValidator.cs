using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class StringValidator
    {
        private readonly IConfiguration _configuration;

        StringValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Validate(string toValidate, int defaultMaxLength, string defaultRegex, string maxLengthOverride = null, string regexOverride = null)
        {
            ValidateLength(toValidate, defaultMaxLength, maxLengthOverride);
            ValidateAgainstRegex(toValidate, defaultRegex, regexOverride);
        }

        public void ValidateLength(string toValidate, int defaultMaxLength, string maxLengthOverride = null)
        {
            if (defaultMaxLength == 0)
            {
                return;
            }

            int lengthToUse = defaultMaxLength;

            if (maxLengthOverride != null)
            {
                string maxLengthOverrideSetting = _configuration["Validation:" + maxLengthOverride];

                if (maxLengthOverrideSetting != null)
                {
                    if (!int.TryParse(maxLengthOverrideSetting, out var overrideSetting))
                    {
                        lengthToUse = overrideSetting;
                    }
                }
            }

            if (toValidate.Length > lengthToUse)
            {
                throw new Exception("String " + toValidate + "longer than max length of " + lengthToUse);
            }
        }

        public void ValidateAgainstRegex(string toValidate, string defaultRegex, string regexOverride = null)
        {
            if (defaultRegex == null)
            {
                return;
            }

            string regexToUse = defaultRegex;

            if (regexOverride != null)
            {
                string regexOverrideSetting = _configuration["Validation:" + regexOverride];

                if (regexOverrideSetting == null)
                    return;

                regexToUse = regexOverrideSetting;
            }

            Match match = Regex.Match(toValidate, defaultRegex, RegexOptions.IgnoreCase);

            if (!match.Success)
                throw new Exception("String " + toValidate + " does not match regex " + regexToUse);
        }
    }
}