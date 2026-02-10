namespace OnBoarding
{
    public class Employee
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string Email{get;set;}
        public double Salary{get;set;}



        public Employee(int id , string name , string email, double salary)
        {
            if (salary <= 0)
                this.Salary=30000;
            else
                this.Salary = salary;

            if (!email.Contains("@"))
                this.Email="unknown@company.com";
            else
                this.Email=email;
            
            this.Name = name;
            this.Id=id;
        }

    }
}