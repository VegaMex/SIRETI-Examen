using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Backend.Security
{
    public class ValidatorService
    {
        public static bool AllRegister(string[] keys, int order)
        {
            switch (order)
            {
                case 0: // Valida Registro nuevo
                    var v10 = ValidateControlNumber(keys[0]);
                    var v20 = ValidateName(keys[1]);
                    var v30 = ValidateName(keys[2]);
                    var v40 = ValidateName(keys[3]);
                    var v50 = ValidateEmail(keys[4]);
                    var v60 = ValidatePassword(keys[5]);
                    var v70 = ValidateBoth(keys[5], keys[6]);

                    return v10 && v20 && v30 && v40 && v50 && v60 && v70 ? true : false;

                case 1:
                    var v11 = ValidateEmail(keys[0]);
                    var v21 = ValidatePassword(keys[1]);

                    return v11 && v21 ? true : false;
            }
            return false;
        }

        public static bool ValidateName(string name)
        {
            var regex = new Regex(@"^[ÁÉÍÓÚÑA-Z][a-záéíóúñ]+(\s+[ÁÉÍÓÚÑA-Z]?[a-záéíóúñ]+)*$");
            return regex.IsMatch(name);
        }

        public static bool ValidateEmail(string email)
        {
            var regex = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}", RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool ValidateControlNumber(string control)
        {
            var regex = new Regex(@"[AaBbCcDdEeGgIiMmSsTt][0-9]{2}(120)[0-9]{3}$");
            return regex.IsMatch(control);
        }

        public static bool ValidatePassword(string password)
        {
            var regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*]{8,}$");
            return regex.IsMatch(password);
        }

        public static bool ValidateBoth(string pass1, string pass2)
        {
            return pass1.Equals(pass2);
        }

    }
}
