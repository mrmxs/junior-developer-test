using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HTTPServer.Helper
{
    public class FormValidator
    {
        public bool IsValid { get; } = false;
        public Dictionary<string, string> Errors { get; } = new Dictionary<string, string>();
        public Dictionary<string, string> CorrectInput { get; } = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _form;

        public FormValidator(string query)
        {
            _form = HttpUtility.UrlDecode(query)
                .Split('&')
                .Select(param => param.Split('='))
                .ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]);

            if (NameIsValid())
            {
                CorrectInput.Add("name", _form["name"]);
            }
            if (ColorIsValid())
            {
                CorrectInput.Add("color", _form["color"]);
            }
            if (Years18IsValid())
            {
                CorrectInput.Add("years18", _form["years18"]);
            }
            if (DaytimeIsValid())
            {
                CorrectInput.Add("daytime", _form["daytime"]);
            }

            IsValid = Errors.Count == 0;
        }

        private bool NameIsValid()
        {
            if (IsEmpty("name"))
            {
                Errors.Add("name", "Name is empty");
                return false;
            }

            if (!Regex.IsMatch(_form["name"], "^[a-zA-Zа-яА-Я ]+$"))
            {
                Errors.Add("name", "Name is not string");
                return false;
            }

            return true;
        }

        private bool ColorIsValid()
        {
            if (IsEmpty("color"))
            {
                Errors.Add("color", "Color is empty");
                return false;
            }

            return true;
        }

        private bool Years18IsValid()
        {
            if (IsEmpty("years18"))
            {
                Errors.Add("years18", "Years is empty");
                return false;
            }

            return true;
        }

        private bool DaytimeIsValid()
        {
            if (IsEmpty("daytime"))
            {
                Errors.Add("daytime", "Daytime is empty");
                return false;
            }

            if (!(new[] {"Morning", "Evening", "Night"}.Contains(_form["daytime"])))
            {
                Errors.Add("daytime", "Unknown daytime");
                return false;
            }

            return true;
        }

        private bool IsEmpty(string field)
        {
            return !_form.ContainsKey(field) || string.IsNullOrEmpty(_form[field]);
        }
    }
}