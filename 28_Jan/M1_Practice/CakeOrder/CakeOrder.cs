namespace CakeOrderProblem
{
    public class CakeOrder
    {
        private SortedDictionary<string, double> OrderMap;
        public CakeOrder()
        {
            OrderMap = new SortedDictionary<string, double>();
        }

        public void AddOrderDetails(string orderId, double price)
        {
            OrderMap.Add(orderId, price);
        }

        public SortedDictionary<string, double> FindOrdersAboveSpecifiedCost(double cost)
        {
            SortedDictionary<string, double> result = new SortedDictionary<string, double>();
            foreach (var order in OrderMap)
            {
                if (order.Value >= cost)
                {
                    result.Add(order.Key, order.Value);
                }
            }
            return result;
        }
        public  void Print(SortedDictionary<string,double> orders)
        {
            foreach(var order in orders)
            {
                Console.WriteLine($"Order Id : {order.Key}  | Cake Price : {order.Value}");
            }
        }
    }
}