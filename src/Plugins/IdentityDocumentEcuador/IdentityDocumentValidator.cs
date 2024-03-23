﻿namespace Plugin.IdentityDocument.Ecuador;

/// <summary>
/// Represents a validator for Ecuadorian identity documents.
/// </summary>
/// <remarks>
/// Link to the algorithm: <see href="https://www.skypack.dev/view/udv-ec"/>
/// </remarks>
public class IdentityDocumentValidator : IIdentityDocumentValidator
{
    public Result IsValid(string document)
    {
        if (string.IsNullOrWhiteSpace(document))
            return Result.Invalid(Messages.DocumentIsEmpty);

        if (document.Length != 10)
            return Result.Invalid(string.Format(Messages.DocumentMaxCharacters, 10));

        if(IsNotNumeric(document))
            return Result.Invalid(Messages.DocumentMustBeNumeric);

        if(HasInvalidRegionDigit(document))
            return Result.Invalid(Messages.DocumentIsInvalid);

        int verificationDigit = int.Parse(document[^1].ToString());
        int total = 0;
        bool isOddPosition = false;
        // The verification digit is not considered.
        int len = document.Length - 1;
        for (int i = 0; i < len; i++)
        {
            isOddPosition = !isOddPosition;
            int coefficient = isOddPosition ? 2 : 1;
            int digit = (document[i] - '0') * coefficient;
            int result = digit > 9 ? digit - 9 : digit;
            total += result;
        }

        bool isValidDocument = 
            (total % 10 == 0 && verificationDigit == 0) || 
            (10 - (total % 10) == verificationDigit);

        return isValidDocument ? 
            Result.Success() : 
            Result.Invalid(Messages.DocumentIsInvalid);
    }

    private static bool IsNotNumeric(string document)
        => document.Where(c => c is < '0' or > '9').Any();

    private static bool HasInvalidRegionDigit(string document)
        => !HasValidRegionDigit(document);

    private static bool HasValidRegionDigit(string document)
    {
        // The digit of the region is obtained, which are the first two digits.
        int regionDigit = int.Parse(document[..2]);

        // It is validated if the region digit exists in Ecuador, which is divided into 24 regions.
        // 30 is assigned for Ecuadorians abroad.
        return regionDigit is (>= 1 and <= 24) or 30;
    }
}
