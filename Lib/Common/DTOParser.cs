using System.Data.SqlClient;

namespace Lib.Common
{
    public abstract class DTOParser
    {
        public abstract DTOBase PopulateDTO(SqlDataReader reader);
        public abstract void PopulateOrdinals(SqlDataReader reader);
    }
}