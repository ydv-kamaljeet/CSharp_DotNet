namespace Meeting
{

    public class CreditRiskProcessor
    {
        public bool validateCustomerDetails(int age, String employmentType, double monthlyIncome, double dues, int creditScore, int defaults)
        {
            if(age<21 || age > 65)
            {
                throw new InvalidCreditDataException("Invalid Age");
            }
            if(employmentType != "Salaried" && employmentType != "Self-Employed")
            {
                throw new InvalidCreditDataException("Invalid employment type");
            }
            if (monthlyIncome < 20000)
            {
                throw new InvalidCreditDataException("Invalid monthly income");
            }
            if(dues < 0)
            {
                throw new InvalidCreditDataException("Invalid credit dues");
            }
            if(creditScore <300 || creditScore > 900)
            {
                throw new InvalidCreditDataException("Invalid credit score");
            }
            if (defaults < 0)
            {
                throw new InvalidCreditDataException("Invalid default count");
            }
            //If everything is fine
            return true;
        }
        public int calculateCreditLimit(double monthlyIncome, double dues, int creditScore, int defaults)
        {
            
            double debtRatio = dues / (monthlyIncome * 12);

            if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            {
                return 300000;
            }
            
            if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
            {
                return 50000;
            }
            
            return 150000;
        }
    }

    public class InvalidCreditDataException : Exception
    {
        public InvalidCreditDataException(string message) : base(message) { }
    }
}