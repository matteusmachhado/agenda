using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Shared.Utils
{
    public static class StringUtil
    {
        public static string ReplaceVariablesTemplate(this string template, IDictionary<string, string> variables) 
        {
            foreach (var variable in variables)
            {
                var key = "{{" + variable.Key + "}}";
                template = template.Replace(key, variable.Value);
            }

            return template;
        }
    }
}
