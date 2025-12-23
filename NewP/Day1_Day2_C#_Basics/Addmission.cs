using System;
using System.IO.Pipelines;
namespace kamaljeet;

class Addmission
{
 /// <summary>
 /// Member function to check the eligibility of Admission
 /// </summary>
    public void IsEligible()
    {
        #region input
        int phy,che,mth,total=0;
        string result = string.Empty;
        string? input1 = Console.ReadLine();
        string? input2 = Console.ReadLine();
        string? input3 = Console.ReadLine();
        int.TryParse(input1,out phy);
        int.TryParse(input2,out che);
        int.TryParse(input3,out mth);
        #endregion
        #region  checking eligibility
        total = mth+phy+che;
        if(mth >=65 && phy >= 55 && che >= 50 && (total>=180 || (mth + phy) >=140)) result="Eligible";
        else result="Not Eligible";
        #endregion
        Console.WriteLine(result);
    }
}