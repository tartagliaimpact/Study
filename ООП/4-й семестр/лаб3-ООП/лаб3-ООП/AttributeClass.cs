using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace лаб3_ООП
{
    //-----------------------------------------------------------------
    //Атрибут валидации индекса
    //-----------------------------------------------------------------

    class IndexAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if (value != null)
            {

                string idx = value.ToString();
                if (Regex.Match(idx, @"^22\d\d\d\d$").Success || Regex.Match(idx, @"^1\d\d\d\d$").Success)
                    return true;
                else
                    ErrorMessage = "Некорректно введён индекс!";
            }
            return false;
        }


    }
}
