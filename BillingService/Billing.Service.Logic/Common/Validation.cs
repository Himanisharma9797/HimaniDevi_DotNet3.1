using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Billing.Service.Logic.Common
{
   public class Validation
    {
        public static void RequiredParameter(string ParmName, object ParmValue)
        {
            string _errMsg = "";
            if (!RequiredParameter(ParmName, ParmValue, ref _errMsg))
                throw new ValidationException(_errMsg);
        }

        public static bool RequiredParameter(string ParmName, object ParmValue, ref string errMsg)
        {
            if (ParmValue == null)
            {
                errMsg = ParmName + " is Required";
                return false;
            }

            System.Type _ParmType = ParmValue.GetType();

            if (_ParmType == typeof(string))
            {
                if (string.IsNullOrEmpty((string)ParmValue))
                {
                    errMsg = ParmName + " is Required";
                    return false;
                }
                else
                    return true;
            }

            return true;
        }
        public static void RequiredIntParameter(string ParmName, object ParmValue)
        {
            string _errMsg = "";
            if (RequiredIntParameter(ParmName, ParmValue, ref _errMsg))
                return;
            else
                throw new ValidationException(_errMsg);
        }

        public static bool RequiredIntParameter(string ParmName, object ParmValue, ref string errMsg)
        {
            System.Type _ParmType = ParmValue.GetType();

            if (_ParmType == typeof(Int32))
            {
                if (Convert.ToInt32(ParmValue) <= 0)
                {
                    errMsg = "Invalid " + ParmName;
                    return false;
                }
                else
                    return true;
            }

            return true;
        }
        public static void RequiredDoubleParameter(string ParmName, object ParmValue)
        {
            string _errMsg = "";
            if (RequiredDoubleParameter(ParmName, ParmValue, ref _errMsg))
                return;
            else
                throw new ValidationException(_errMsg);
        }
       

        public static bool RequiredDoubleParameter(string ParmName, object ParmValue, ref string errMsg)
        {
            System.Type _ParmType = ParmValue.GetType();

            if (_ParmType == typeof(Double))
            {
                if (Convert.ToDouble(ParmValue) <= 0)
                {
                    errMsg = "Invalid " + ParmName;
                    return false;
                }
                else
                    return true;
            }

            return true;

        }
        public static void isValidEmail(string ParmName, object ParmValue)
        {
            string _errMsg = "";
            if (isValidEmail(ParmName, ParmValue, ref _errMsg))
                return;
            else
                throw new ValidationException(_errMsg);
        }

        public static bool isValidEmail(string ParmName, object ParmValue, ref string errMsg)
        {
            System.Type _parmName = ParmValue.GetType();

            if (_parmName == typeof(String))
            {

                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                     @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                     @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(strRegex);
                if (Regex.IsMatch(ParmValue.ToString(), strRegex))
                {
                    return true;
                }
                else
                    errMsg = ParmName + " is Required";
                return false;
            }

            return true;

        }
        public static void isAlphabets(string ParmName, object ParmValue)
        {
            string _errMsg = "";
            if (isAlphabets(ParmName, ParmValue, ref _errMsg))
                return;
            else
                throw new ValidationException(_errMsg);
        }

        public static bool isAlphabets(string ParmName, object ParmValue, ref string errMsg)
        {
            System.Type _parmName = ParmValue.GetType();

            if (_parmName == typeof(String))
            {

                string strRegex = "^[a-zA-Z ]+$";
                Regex re = new Regex(strRegex);
                if (Regex.IsMatch(ParmValue.ToString(), strRegex))
                {
                    return true;
                }
                else
                    errMsg = ParmName + " is InValid";
                return false;
            }

            return true;

        }
    }
}
