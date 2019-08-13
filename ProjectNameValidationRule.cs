using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;


namespace AppLib.Converters
{
    public class ProjectNameValidationRule : ValidationRule
    {

        public string CanContain { get; set; }

        //public string MustStartWith { get; set; }

        //public string MustEndWith { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (str == null)
            {
                return new ValidationResult(false, "Please enter some text");
            }
            //if (!str.StartsWith(MustStartWith))



            //if (!Regex.IsMatch(str, MustStartWith, RegexOptions.IgnoreCase))
            //{
            //    return new ValidationResult(false, String.Format("Text must start with '{0}'", MustStartWith));

            //}
            //Regex regexObj = new Regex("^[a-z0-9_-]+$(?#case sensitive, matches only lower a-z)", RegexOptions.Multiline);
            try
            {
                if (!Regex.IsMatch(str, CanContain, RegexOptions.IgnoreCase))
                {
                    return new ValidationResult(false, String.Format("Text rules(IgnoreCase) and '{0}'", CanContain));

                }


                //Regex regexObj = new Regex(CanContain, RegexOptions.IgnoreCase);
                //Match matchResults = regexObj.Match(str);
                //while (matchResults.Success)
                //{
                //    for (int i = 1; i < matchResults.Groups.Count; i++)
                //    {
                //        Group groupObj = matchResults.Groups[i];
                //        if (!groupObj.Success)
                //        {
                //            return new ValidationResult(false, String.Format("Text can not contain '{0}'", groupObj));
                //            // matched text: groupObj.Value
                //            // match start: groupObj.Index
                //            // match length: groupObj.Length
                //        }
                //    }
                //    matchResults = matchResults.NextMatch();
                //}

            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
                return new ValidationResult(false, ex.Message.ToString());
            }
            //if (!Regex.IsMatch(str, CanContain, RegexOptions.IgnoreCase))
            //{
            //    return new ValidationResult(false, String.Format("Text can contain '{0}'", CanContain));

            //}

            return new ValidationResult(true, null);

        }
    }
}