using System.Collections.Generic;
using System.Linq;
namespace CollectionProblems
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //---------------------- 1. ECOMMERCE CART CONSOLIDATE
            // Dictionary<string,int> dict = new Dictionary<string, int>(Consolidate(new List<(string,int)>{("A101",2),("B102",3),("A101",4),("C103",-12)}));

            //---------------------- 2. SCAN EMPLOYEES ON GATE
            //PrintList(ScanEmployee(new List<int>{10,20,10,30,20,40}));

            //---------------------- 3. GAMER's LEADERBOARD
            //GenerateLeaderboard(new List<(string,int)>{("A",2),("B",4),("C",4),("D",12)}, 3);

            //---------------------- 4. PROCESS METRO PASSANGER 
            // var q = new Queue<(TimeSpan entryTime, string ticketType)>(
            // new[]
            // {
            //     (TimeSpan.Parse("07:45"), "Regular"),
            //     (TimeSpan.Parse("08:15"), "Regular"),
            //     (TimeSpan.Parse("08:30"), "VIP"),
            //     (TimeSpan.Parse("09:10"), "Regular"),
            //     (TimeSpan.Parse("10:00"), "Regular"),
            //     (TimeSpan.Parse("10:30"), "Regular"),
            //     (TimeSpan.Parse("09:45"), "Invalid")
            // });

            // Console.WriteLine($"Total valid tickets : {ProcessPassanger(q)}");

            //---------------------- 5. TYPE - UNDO
            //ProcessRequests(new string[]{"TYPE Hello","TYPE World","UNDO","TYPE CSharp"});

            //---------------------- 6. MERGE TWO SORTED LIST
            //MergeTwoSortedList(new List<int> {1,3,5,7}, new List<int>{2,4,6});

            //---------------------- 7. CALCULATE TOTAL SPEND
            //ComputeTotalSpend(new List<(string,decimal)>{("Food",-200),("Fuel",-500),("Food",-50),("Salary",1000)});

            //---------------------- 8. DETECT DUPLICATE STRINGS
            //DetectDuplicate(new List<string>{"S1","S2","S1","S3","S2","S2"});

            //---------------------- 9. ALLOCATE LOWEST SEAT
            //AllocateSeat(10, new List<int>{2,3,4,7,9},4);

            //--------------------- 10. LOG ANALYZER
            // string error = Analyze(new List<string>{"E02","E01","E02","E01","E03"});
            // Console.WriteLine(error);
        }

        //1. ECOMMERCE CART CONSOLIDATION
        public static Dictionary<string,int> Consolidate(List<(string,int)> scans)
        {
            Dictionary<string,int> result = new Dictionary<string, int>();

            foreach(var item in scans)
            {
                if(item.Item2>0){
                    if (!result.ContainsKey(item.Item1))
                    {
                        result[item.Item1] = 0;
                        
                    }
                    result[item.Item1]+=item.Item2;
                }
            }
            return result;
        }

        
        //2. SCAN EMPLOYEES ON GATE
        public static List<int> ScanEmployee(List<int> employees)
        {
            HashSet<int> uniqueEmployeees = new HashSet<int>(employees);
            List<int> result = new List<int>(uniqueEmployeees);
            return result;
        }

        //3. GAMER's LEADERBOARD
        public static List<(string name, int score)> GenerateLeaderboard(List<(string name, int score)> players, int k)
        {
            //1st approach
            var topK1 = players
                    .OrderByDescending(x => x.score)
                    .ThenBy(x => x.name)
                    .Take(k)
                    .ToList();


            //2nd Approach
            players.Sort((a, b) =>
            {
                int scoreCompare = b.score.CompareTo(a.score);
                return scoreCompare != 0
                    ? scoreCompare
                    : a.name.CompareTo(b.name);
            });

            // Handle edge case
            k = Math.Min(k, players.Count);
            var topK2 = players.GetRange(0, k);

            Console.WriteLine("Top K Players:");
            foreach (var p in topK2)
            {
                Console.WriteLine($"{p.name} - {p.score}");
            }

            return topK1;
            
        }

        //4. PROCESS METRO PASSANGER
        public static int ProcessPassanger(Queue<(TimeSpan entryTime, string ticketType)> q)
        {
            int count=0;
            TimeSpan start = new TimeSpan(8,0,0);
            TimeSpan end  = new TimeSpan(10,0,0);
            foreach(var ticket in q)
            {
                if(ticket.entryTime >= start && ticket.entryTime <= end && String.Equals(ticket.ticketType,"Regular", StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
            return count;
        }

        //5. TYPE - UNDO
        public static void ProcessRequests(string[] request)
        {
            Stack<string> stk = new Stack<string>();
            foreach( var ops in request)
            {
                string[] strs = ops.Split(' ');
                if (strs.Length == 2)
                {
                    stk.Push(strs[1]);
                }
                else
                {
                    if(stk.Count>0)
                        stk.Pop();
                }

            }
            string str="";
            while(stk.Count() > 0)
            {
                str+=stk.Pop() + " ";
            }

            var reversed = string.Join(" ", str.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse()); 
            Console.WriteLine(reversed);
        }


        // 6. MERGE TWO SORTED LIST
        public static List<int> MergeTwoSortedList(List<int> list1, List<int> list2)
        {
            list1.AddRange(list2);
            list1.Sort();
            return list1;
        }

        // 7. CALCULATE TOTAL SPEND
        public static Dictionary<string,decimal> ComputeTotalSpend(List<(string category, decimal amount)> txns)
        {
            Dictionary<string,decimal> dict = new Dictionary<string, decimal>();
            foreach(var spend in txns)
            {
                if(spend.amount < 0 )
                {
                    if (!dict.ContainsKey(spend.category))
                    {
                        dict[spend.category] = 0;
                    }
                    dict[spend.category] += Math.Abs(spend.amount);
                }
            }
            return dict;
        }


        //8. DETECT DUPLICATE STRINGS
        public static List<string> DetectDuplicate(List<string> serials)
        {
            List<string> result = new List<string>();
            HashSet<string> hs = new HashSet<string>();
            foreach(var serial in serials)
            {
                if (hs.Contains(serial) && !result.Contains(serial))
                {
                    result.Add(serial);
                }
                else
                {
                    hs.Add(serial);
                }
            }
            return result;
        }

        //9. MOVIE TICKET BOOKING
        public static List<int> AllocateSeat(int n, List<int> alreadyBooked, int requestCount)
        {
            List<int> result = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                if (!alreadyBooked.Contains(i) && requestCount> 0)
                {
                    result.Add(i);
                    requestCount--;
                }
            }
            while (requestCount > 0)
            {
                result.Add(-1);
                requestCount--;
            }

            foreach(var it in result)
            {
                Console.WriteLine(it);
            }
            return result;
            
        }

        //10. LOG ANALYZER
        public static string Analyze(List<string> codes)
        {
            var dict = codes.GroupBy(s => s)
                    .ToDictionary(s => s.Key, s => s.Count());
        
            int max = dict.Values.Max();
        
            return dict.Where(s => s.Value == max)
                   .OrderBy(s => s.Key)
                   .First()
                   .Key;
        }


        //--------------- Print----------------
        public static void Print(Dictionary<string,int> dict)
        {
            foreach(var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
        public static void PrintList(List<int> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}