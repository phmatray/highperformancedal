using System.Collections.Generic;
using Lib.Common;

namespace Lib.Sample
{
    public class Person : BALBase
    {
        //
        // Data
        // This property exists for all BAL objects, and it is
        // set to the DTO type for this entity.  This is the
        // mechanism that we use to implement "has a" inheritance
        // instead of "is a" inheritance.
        //
        public PersonDTO Data { get; set; }


        //
        // Person - default constructor
        //
        public Person()
        {
            this.Data = new PersonDTO();
        }

        //
        // Person - takes a DTO
        //
        public Person(PersonDTO dto)
        {
            this.Data = dto;
        }


        #region "Validation"

        //
        // Validate
        // Required for BALBase implementation
        //
        public override List<ValidationError> Validate()
        {
            // Call all validation functions
            Val_Name();
            Val_Email();
            Val_Password();
            Val_TimeZone();
            Val_City();
            Val_State();
            Val_ZipCode();
            Val_ImType();

            return this.ValidationErrors;
        }


        // Validation Methods:
        // There are only 2 requirements on validation methods.
        //  - They must handle adding a Validation Error to the
        //    ValidationErrors list if they find an error.
        //  - You must manually add a call to all validation methods
        //    to the Validate() function.
        //  When creating a new ValidationError object, remember
        //  that the first parameter is the exact name of the field
        //  that has the bad value, and the error message should
        //  not contain the field name, but instead the <FieldName>
        //  tag, which will be replaced by the UI or consuming app.

        //
        // Val_Name
        //
        public bool Val_Name()
        {
            // Name required
            if (this.Data.Name == DTOBase.NullValueString)
            {
                this.ValidationErrors.Add(new ValidationError("Person.Name", "<FieldName> is required"));
                return false;
            }
            else
            {
                return true;
            }
        }

        //
        // Val_Email
        //
        public bool Val_Email()
        {
            // Email required
            if (this.Data.Email == DTOBase.NullValueString)
            {
                this.ValidationErrors.Add(new ValidationError("Person.Email", "<FieldName> is required"));
                return false;
            }
                // Email is valid email
            else if (!ValidationRules.IsValidEmail(this.Data.Email))
            {
                this.ValidationErrors.Add(new ValidationError("Person.Email",
                                                              "<FieldName> must be a valid email address"));
                return false;
            }
                // Email is not already in use.
            else
            {
                Person checkPerson = PersonRepository.GetPersonByEmail(this.Data.Email);
                if ((checkPerson != null) && (!checkPerson.Data.PersonGuid.Equals(this.Data.PersonGuid)))
                {
                    this.ValidationErrors.Add(new ValidationError("Person.Email", "That <FieldName> is already in use"));
                    return false;
                }
            }
            // If we reached this point then the email passed validation
            return true;
        }

        //
        // Val_Password
        //
        public bool Val_Password()
        {
            // Password required
            if (string.IsNullOrEmpty(this.Data.Password))
            {
                this.ValidationErrors.Add(new ValidationError("Person.Password", "<FieldName> is required"));
                return false;
            }
                // Password is valid password
            else if (!ValidationRules.IsValidPassword(this.Data.Password))
            {
                this.ValidationErrors.Add(new ValidationError("Person.Password",
                                                              "<FieldName> must be at least 6 characters"));
                return false;
            }
            else
            {
                return true;
            }
        }

        // TimeZone required
        public bool Val_TimeZone()
        {
            //  TimeZone required
            if (this.Data.TimeZoneId == CommonBase.NullValueInt)
            {
                this.ValidationErrors.Add(new ValidationError("Person.TimeZoneId", "<FieldName> is required"));
                return false;
            }
            else
            {
                return true;
            }
        }

        // Val_City
        public bool Val_City()
        {
            // City required
            if (string.IsNullOrEmpty(this.Data.City))
            {
                this.ValidationErrors.Add(new ValidationError("Person.City", "<FieldName> is required"));
                return false;
            }
                // Valid City business rule
            else if (!ValidationRules.IsValidCity(this.Data.City))
            {
                this.ValidationErrors.Add(new ValidationError("Person.City", "<FieldName> must be a valid city"));
                return false;
            }
            else
            {
                return true;
            }
        }

        // Val_State
        public bool Val_State()
        {
            //  State required
            if (string.IsNullOrEmpty(this.Data.State))
            {
                this.ValidationErrors.Add(new ValidationError("Person.State", "<FieldName> is required"));
                return false;
            }
                // Valid StateCode business rule
            else if (!ValidationRules.IsValidStateCode(this.Data.State))
            {
                this.ValidationErrors.Add(new ValidationError("Person.State", "<FieldName> must be a valid state"));
                return false;
            }
            else
            {
                return true;
            }
        }

        // Val_ZipCode
        public bool Val_ZipCode()
        {
            // ZipCode Required
            if (this.Data.ZipCode == CommonBase.NullValueInt)
            {
                this.ValidationErrors.Add(new ValidationError("Person.ZipCode", "<FieldName> is required"));
                return false;
            }
                // Valid ZipCode business rule
            else if (!ValidationRules.IsValidZipCode(this.Data.ZipCode))
            {
                this.ValidationErrors.Add(new ValidationError("Person.ZipCode", "A valid <FieldName> is required."));
                return false;
            }
            else
            {
                return true;
            }
        }

        // ValImType
        public bool Val_ImType()
        {
            //  If ImAddress exists, ImType is required
            if (!string.IsNullOrEmpty(this.Data.ImAddress) && (!ValidationRules.IsValidImTypeId(this.Data.ImType)))
            {
                this.ValidationErrors.Add(new ValidationError("Person.ImType",
                                                              "<FieldName> is required for the IM Address"));
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}