using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Utilities
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // constraint implemented on database
            return true;
        }
    }
}
