public class MyCalculator
{
    public int Addition(int a, int b)
    {
        return a+b;
    }

    public int Subtraction(int a, int b)
    {
        return a-b;
    }

    public double Division(int a, int b)
    {
        if(a==0 || b==0) throw new DivideByZeroException();
        double res = a/b;
        return res;
    }

    public int Mulitplication(int a, int b)
    {
        return a*b;
    }

    public int Remainder(int a, int b)
    {
        return a%b;
    }

    public double Percentage(int a, int b)
    {
        return a*(b/100);
    }

}