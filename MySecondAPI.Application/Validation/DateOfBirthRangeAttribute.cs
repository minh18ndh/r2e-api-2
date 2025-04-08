using System.ComponentModel.DataAnnotations;

public class DateOfBirthRangeAttribute : ValidationAttribute {
    public override bool IsValid(object? value) {
        if (value is DateOnly dob) {
            var minDate = new DateOnly(1910, 1, 1);
            var maxDate = DateOnly.FromDateTime(DateTime.Today);
            return dob >= minDate && dob <= maxDate;
        }

        return false;
    }

    public override string FormatErrorMessage(string name) {
        return $"{name} must be between 1910 and today.";
    }
}