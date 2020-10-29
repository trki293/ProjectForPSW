﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_wireframe.Validation
{
    public class ValidationForm : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                var s = value as string;

                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid email address.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public partial class ValidationName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;

                Regex regex = new Regex(@"^([A-Z][a-zA-Z]+)$");

                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid name.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
