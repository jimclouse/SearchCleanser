using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static string StripChars(string text)
    {
        // start by trimming leading & trailing whitespace
        text = text.Trim();
        
        // loop through characters and remove diacritics or handle replacements
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        List<char> allowedChars = new List<char> { ' ', '&', '.', '-' };

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory == UnicodeCategory.LetterNumber ||
                unicodeCategory == UnicodeCategory.LowercaseLetter ||
                unicodeCategory == UnicodeCategory.UppercaseLetter ||
               allowedChars.Contains(c)
                )
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}
