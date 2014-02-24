using System;
using Lib.Common;

namespace Lib.Sample
{
    public class PersonDTO : DTOBase
    {
        public Guid PersonGuid { get; set; }
        public int PersonId { get; set; }
        public DateTime UtcCreated { get; set; }
        public DateTime UtcModified { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string PhoneMobile { get; set; }
        public string PhoneHome { get; set; }
        public string Email { get; set; }
        public string ImAddress { get; set; }
        public int ImType { get; set; }
        public int TimeZoneId { get; set; }
        public int LanguageId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        // Constructor
        // No parameters and all types are intialized to their
        // null values as defined in CommonBase.
        public PersonDTO()
        {
            PersonGuid = NullValueGuid;
            PersonId = NullValueInt;
            UtcCreated = NullValueDateTime;
            UtcModified = NullValueDateTime;
            Name = NullValueString;
            Nickname = NullValueString;
            PhoneMobile = NullValueString;
            PhoneHome = NullValueString;
            Email = NullValueString;
            ImAddress = NullValueString;
            ImType = NullValueInt;
            TimeZoneId = NullValueInt;
            LanguageId = NullValueInt;
            City = NullValueString;
            State = NullValueString;
            ZipCode = NullValueInt;
            IsNew = true;
        }
    }
}