using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lib.Common;

namespace Lib.Sample
{
    public class PersonDb : DALBase
    {
        // GetPersonByPersonGuid
        public static PersonDTO GetPersonByPersonGuid(Guid PersonGuid)
        {
            SqlCommand command = GetDbSprocCommand("Person_GetByPersonGuid");
            command.Parameters.Add(CreateParameter("@PersonGuid", PersonGuid));
            return GetSingleDTO<PersonDTO>(ref command);
        }


        // GetPersonByEmail
        public static PersonDTO GetPersonByEmail(string email)
        {
            SqlCommand command = GetDbSprocCommand("Person_GetByEmail");
            command.Parameters.Add(CreateParameter("@Email", email, 100));
            return GetSingleDTO<PersonDTO>(ref command);
        }

        // GetAll
        public static List<PersonDTO> GetAll()
        {
            SqlCommand command = GetDbSprocCommand("Person_GetAll");
            return GetDTOList<PersonDTO>(ref command);
        }

        // SavePerson
        public static void SavePerson(ref PersonDTO person)
        {
            // The sproc will handle both inserts and updates.  We
            // just need to return the appropriate person guid.  If
            // this is a new person then we return the NewPersonGuid.
            // If this is an update we just return the PersonGuid.
            bool isNewRecord = false;
            if (person.PersonGuid.Equals(Common.DTOBase.NullValueGuid))
            {
                isNewRecord = true;
            }

            // Create the command and parameters. When creating parameters
            // we don't need to check for null values. The CreateParameter
            // method will handle that for us and will create null parameters
            // for any DTO members that match the DTOBase.NullValue for
            // that member's data type.
            SqlCommand command = GetDbSprocCommand("Person_Save");
            command.Parameters.Add(CreateParameter("@PersonGuid", person.PersonGuid));
            command.Parameters.Add(CreateParameter("@Password", person.Password, 20));
            command.Parameters.Add(CreateParameter("@Name", person.Name, 100));
            command.Parameters.Add(CreateParameter("@Nickname", person.Nickname, 50));
            command.Parameters.Add(CreateParameter("@PhoneMobile", person.PhoneMobile, 25));
            command.Parameters.Add(CreateParameter("@PhoneHome", person.PhoneHome, 25));
            command.Parameters.Add(CreateParameter("@Email", person.Email, 100));
            command.Parameters.Add(CreateParameter("@ImAddress", person.ImAddress, 50));
            command.Parameters.Add(CreateParameter("@ImType", person.ImType));
            command.Parameters.Add(CreateParameter("@TimeZoneId", person.TimeZoneId));
            command.Parameters.Add(CreateParameter("@LanguageId", person.LanguageId));
            SqlParameter paramIsDuplicateEmail = CreateOutputParameter("@IsDuplicateEmail", SqlDbType.Bit);
            command.Parameters.Add(paramIsDuplicateEmail);
            SqlParameter paramNewPersonGuid = CreateOutputParameter("@NewPersonGuid", SqlDbType.UniqueIdentifier);
            command.Parameters.Add(paramNewPersonGuid);

            // Run the command.
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            // Check for duplicate email.
            if ((bool) paramIsDuplicateEmail.Value)
            {
                throw new Common.Exceptions.DuplicateEmailException();
            }

            // If this is a new record, let's set the Guid so the object
            // will have it.
            if (isNewRecord)
            {
                person.PersonGuid = (Guid) paramNewPersonGuid.Value;
            }
        }
    }
}