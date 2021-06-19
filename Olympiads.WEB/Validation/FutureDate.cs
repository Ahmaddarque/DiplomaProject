using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Validation
{
    public class FutureDate : ValidationAttribute
    {
        private readonly int days;

        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime >= DateTime.Today.AddDays(days);
            }
            else
            {
                throw new ArgumentException("Should be a DateTime value");
            }
        }

        public FutureDate(int days)
        {
            this.days = days;
        }

        public FutureDate()
        {

        }
    }
}