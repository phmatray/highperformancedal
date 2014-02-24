using System.Collections.Generic;

namespace Lib.Common
{
    public abstract class BALBase
    {
        //
        // ValidationErrors
        //
        private List<ValidationError> _validationErrors;

        public List<ValidationError> ValidationErrors
        {
            get
            {
                if (_validationErrors == null)
                {
                    _validationErrors = new List<ValidationError>();
                }
                return _validationErrors;
            }
            set { _validationErrors = value; }
        }


        //
        // Validate
        // This method should be contained in the validation
        // of each concrete business object class.  The validation
        // region should contain contain all of the validation
        // functions for the class and an implementation of
        // Validate that calls all of them. Each validation
        // function is responsible for adding it's own ValidationError
        // to the ValidationErrors list if the method fails.
        //
        public abstract List<ValidationError> Validate();
    }
}