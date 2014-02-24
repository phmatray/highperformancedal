using System;
using Lib.Common;

namespace Lib.Sample
{
    internal static class DTOParserFactory
    {
        // GetParser
        internal static DTOParser GetParser(System.Type DTOType)
        {
            switch (DTOType.Name)
            {
                case "PersonDTO":
                    return new DTOParser_Person();
                    break;
                    //////case "PostDTO":
                    //////    return new DTOParser_Post();
                    //////    break;
                    //////case "SiteProfileDTO":
                    //////    return new DTOParser_SiteProfile();
                    //////    break;
            }
            // if we reach this point then we failed to find a matching type. Throw
            // an exception.
            throw new Exception("Unknown Type");
        }
    }
}