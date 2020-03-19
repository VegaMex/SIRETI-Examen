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
                case 0: // Valida registro nuevo de alumno
                    var v10 = ValidateControlNumber(keys[0]);
                    var v20 = ValidateName(keys[1]);
                    var v30 = ValidateName(keys[2]);
                    var v40 = ValidateName(keys[3]);
                    var v50 = ValidateEmail(keys[4]);
                    var v60 = ValidatePassword(keys[5]);
                    var v70 = ValidateBoth(keys[5], keys[6]);

                    if (!v40)
                    {
                        v40 = keys[3].Equals("") ? true : false;
                    }

                    return v10 && v20 && v30 && v40 && v50 && v60 && v70 ? true : false;

                case 1: // Valida Login
                    var v11 = ValidateEmail(keys[0]);
                    var v21 = ValidatePassword(keys[1]);

                    return v11 && v21 ? true : false;

                case 2: // Valida registro nuevo de usuario completo
                    var v12 = ValidateName(keys[0]);
                    var v22 = ValidateName(keys[1]);
                    var v32 = ValidateName(keys[2]);
                    var v42 = ValidateEmail(keys[3]);
                    var v52 = ValidatePassword(keys[4]);
                    var v62 = ValidateBoth(keys[4], keys[5]);

                    if (!v32)
                    {
                        v32 = keys[2].Equals("") ? true : false;
                    }

                    return v12 && v22 && v32 && v42 && v52 && v62 ? true : false;
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
