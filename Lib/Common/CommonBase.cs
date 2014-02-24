using System;

namespace Lib.Common
{
    public class CommonBase
    {
        // Let's setup standard null values
        public static DateTime NullValueDateTime = DateTime.MinValue;
        public static Guid NullValueGuid = Guid.Empty;
        public static int NullValueInt = int.MinValue;
        public static float NullValueFloat = float.MinValue;
        public static decimal NullValueDecimal = decimal.MinValue;
        public static string NullValueString = null;
    }


    // ValidationError
    // This is just a container for a single validation error. 
    // FieldName should be set to the name of the BAL Object
    // property that failed validation.  The ErrorMessage should
    // contain message that will be sent back to the application.
    // Note that ErrorMessage should not include the field name.
    // Instead it should contain <FieldName> tags, which can then
    // be replaced with the field name by the application.  This
    // addresses the issue of UI's that use a different name for
    // the property.
}