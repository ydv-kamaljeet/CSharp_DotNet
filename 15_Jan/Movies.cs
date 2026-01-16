namespace Jan_15;

public class Movie
{
    public string? Title{get;set;}
    public string? Artist{get;set;}
    public string? Genre{get;set;}
    public int Ratings{get;set;}

    public Movie(string title,string artist,string genre,int rating)
    {
        Title=title;
        Artist=artist;
        Genre=genre;
        Ratings=rating;
    }
}
