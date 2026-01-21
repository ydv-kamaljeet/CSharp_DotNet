namespace Jan_16;

public class RealEstateListing
{
    public int Id{get;set;}
    public string? Title{get;set;}
    public string? Description{get;set;}
    public int Price{get;set;}
    public string? Location{get;set;}

}

public class RealEstateApp
{
    private List<RealEstateListing> _listing;
    public RealEstateApp()
    {
        _listing = new List<RealEstateListing>();
    }

    public void AddListing(RealEstateListing listing)
    {
        _listing.Add(listing);
    }

    public void RemoveListing(int id)
    {
        
    }
}