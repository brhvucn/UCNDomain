using System;
using System.Collections.Generic;
using System.Text;
using UCN.Domain.Common;
using EnsureThat;
using System.Text.RegularExpressions;

namespace UCN.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; set; }
        /// <summary>
        /// Hiding the public constructor and forcing all to use the constructor method. The constructor method then calls the private constructor
        /// </summary>
        /// <param name="emailAddress"></param>
        private Email(string emailAddress)
        {
            this.Value = emailAddress;
        }
        public static Email Create(string emailAddress)
        {
            Ensure.That(emailAddress, nameof(emailAddress)).IsNotNullOrWhiteSpace();            
            Ensure.That(emailAddress, nameof(emailAddress)).Matches(new Regex(@".+@.+\..+"));
            return new Email(emailAddress);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
