namespace ECommerceDiscount
{
    public abstract class DiscountPolicy
    {
        public abstract double GetFinalAmount(double amount);
    }

    public class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            double discount = 0;
            if(amount >=5000)
                discount = amount*0.1;
            else
                discount = amount*0.05;
            return amount - discount;
        }
    }

    public class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            double discount = 0;
            if(amount>=2000)
                discount = 300;
            
            return amount - discount;
        }
    }

}