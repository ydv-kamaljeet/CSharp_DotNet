namespace TechStoreProblem
{
    public class GadgetValidatorUtil
    {
        public bool ValidateGadgetID(string id)
        {
            string part = id.Substring(1);
            if(char.IsUpper(id[0]) && part.All(char.IsDigit))
                return true;
            else
                throw new InvalidGadgetException("Invalid gadget id");
        }
        public bool ValidateWarrantyPeriod(int period)
        {
            if(period >=6 && period <=36)
                return true;
            else
                throw new InvalidGadgetException("Warranty period is not valid");
        }
    }
    public class InvalidGadgetException : Exception
    {
        public InvalidGadgetException(string msg) : base(msg){}
    }
}