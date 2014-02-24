using System.Data.SqlClient;
using Lib.Common;

namespace Lib.Sample
{
    internal class DTOParser_Person : DTOParser
    {
        private int Ord_PersonGuid;
        private int Ord_PersonId;
        private int Ord_UtcCreated;
        private int Ord_UtcModified;
        private int Ord_Password;
        private int Ord_Name;
        private int Ord_Nickname;
        private int Ord_PhoneMobile;
        private int Ord_PhoneHome;
        private int Ord_Email;
        private int Ord_ImAddress;
        private int Ord_ImType;
        private int Ord_TimeZoneId;
        private int Ord_LanguageId;
        private int Ord_City;
        private int Ord_State;
        private int Ord_ZipCode;


        public override void PopulateOrdinals(SqlDataReader reader)
        {
            Ord_PersonGuid = reader.GetOrdinal("person_guid");
            Ord_PersonId = reader.GetOrdinal("person_id");
            Ord_UtcCreated = reader.GetOrdinal("utc_created");
            Ord_UtcModified = reader.GetOrdinal("utc_modified");
            Ord_Password = reader.GetOrdinal("password");
            Ord_Name = reader.GetOrdinal("name");
            Ord_Nickname = reader.GetOrdinal("nickname");
            Ord_PhoneMobile = reader.GetOrdinal("phone_mobile");
            Ord_PhoneHome = reader.GetOrdinal("phone_home");
            Ord_Email = reader.GetOrdinal("email");
            Ord_ImAddress = reader.GetOrdinal("im_address");
            Ord_ImType = reader.GetOrdinal("im_type");
            Ord_TimeZoneId = reader.GetOrdinal("time_zone_id");
            Ord_LanguageId = reader.GetOrdinal("language_id");
            Ord_City = reader.GetOrdinal("city");
            Ord_State = reader.GetOrdinal("state_code");
            Ord_ZipCode = reader.GetOrdinal("zip_code");
        }





        public override DTOBase PopulateDTO(SqlDataReader reader)
        {
            // We assume the reader has data and is already on the row 
            // that contains the data we need. We don't need to call read.
            // As a general rule, assume that every field must be null
            // checked. If a field is null then the nullvalue for that
            // field has already been set by the DTO constructor, we
            // don't have to change it.

            PersonDTO person = new PersonDTO();

            // PersonGuid
            if (!reader.IsDBNull(Ord_PersonGuid))
            {
                person.PersonGuid = reader.GetGuid(Ord_PersonGuid);
            }
            // PersonId
            if (!reader.IsDBNull(Ord_PersonId))
            {
                person.PersonId = reader.GetInt32(Ord_PersonId);
            }
            // UtcCreated
            if (!reader.IsDBNull(Ord_UtcCreated))
            {
                person.UtcCreated = reader.GetDateTime(Ord_UtcCreated);
            }
            // UtcModified
            if (!reader.IsDBNull(Ord_UtcModified))
            {
                person.UtcModified = reader.GetDateTime(Ord_UtcModified);
            }
            // Password
            if (!reader.IsDBNull(Ord_Password))
            {
                person.Password = reader.GetString(Ord_Password);
            }
            // Name
            if (!reader.IsDBNull(Ord_Name))
            {
                person.Name = reader.GetString(Ord_Name);
            }
            // Nickname
            if (!reader.IsDBNull(Ord_Nickname))
            {
                person.Nickname = reader.GetString(Ord_Nickname);
            }
            // PhoneMobile
            if (!reader.IsDBNull(Ord_PhoneMobile))
            {
                person.PhoneMobile = reader.GetString(Ord_PhoneMobile);
            }
            // PhoneHome
            if (!reader.IsDBNull(Ord_PhoneHome))
            {
                person.PhoneHome = reader.GetString(Ord_PhoneHome);
            }
            // Email
            if (!reader.IsDBNull(Ord_Email))
            {
                person.Email = reader.GetString(Ord_Email);
            }
            // ImAddress
            if (!reader.IsDBNull(Ord_ImAddress))
            {
                person.ImAddress = reader.GetString(Ord_ImAddress);
            }
            // ImType
            if (!reader.IsDBNull(Ord_ImType))
            {
                person.ImType = reader.GetInt32(Ord_ImType);
            }
            // TimeZoneId
            if (!reader.IsDBNull(Ord_TimeZoneId))
            {
                person.TimeZoneId = reader.GetInt32(Ord_TimeZoneId);
            }
            // LanguageId
            if (!reader.IsDBNull(Ord_LanguageId))
            {
                person.LanguageId = reader.GetInt32(Ord_LanguageId);
            }
            // City
            if (!reader.IsDBNull(Ord_City))
            {
                person.City = reader.GetString(Ord_City);
            }
            // State
            if (!reader.IsDBNull(Ord_State))
            {
                person.State = reader.GetString(Ord_State);
            }
            // ZipCode
            if (!reader.IsDBNull(Ord_ZipCode))
            {
                person.ZipCode = reader.GetInt32(Ord_ZipCode);
            }
            // IsNew
            person.IsNew = false;

            return person;
        }

    }
}
