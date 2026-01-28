using System.Reflection;

namespace GOAIRProblem
{
    public class EntryUtility
    {
        public bool ValidateEmployeeId(string empId)
        {
            bool flag = false;
            if (empId.Length != 10)
                flag = false;
            else
            {
                string tag = empId.Substring(0, 5);
                string id = empId.Substring(6);
                if (tag.Equals("GOAIR") && empId[5] == '/' && id.All(char.IsDigit))
                {
                    flag = true;
                }
            }
            if (!flag)
                throw new InvalidEntryException("No entry alllowed due to Invalid Employee Id");
            else 
                return flag;
        }

        public bool ValidateDuration(int duration)
        {
            if(duration >= 1 && duration <= 5)
                return true;
            else
                throw new InvalidEntryException("No Entry allowed due to Invalid duration");
        }
    }


    public class InvalidEntryException : Exception
    {
        public InvalidEntryException(string msg) : base(msg){}
        
    }
}