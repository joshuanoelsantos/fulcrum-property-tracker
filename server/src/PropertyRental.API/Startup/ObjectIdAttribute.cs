using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace PropertyRental.API
{
    public class ObjectIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return IsValidObjectId(value.ToString());
        }

        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? string.Format("The {0} field is invalid.", name);
        }

        private static bool IsValidObjectId(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return ObjectId.TryParse(str, out ObjectId placeholderObjectId);
        }
    }
}