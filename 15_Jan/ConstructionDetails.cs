namespace Jan_15;

public class EstimateDetails
{
    public float ConstructionArea{get;set;}
    public float SiteArea{get;set;}

    public EstimateDetails(float constArea,float siteArea)
    {
        ConstructionArea=constArea;
        SiteArea=siteArea;
    }
}

public class ConstructionEstimateException : Exception
{
    public override string Message => "Sorry your construction estimation is not approved.";
}