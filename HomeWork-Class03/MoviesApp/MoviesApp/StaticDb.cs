using MoviesApp.Models;

namespace MoviesApp
{
    public static class StaticDb
    {
        
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Year = 1994, Genre = GenreEnum.Action },
            new Movie { Id = 2, Title = "The Godfather", Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", Year = 1972, Genre = GenreEnum.Action },
            new Movie { Id = 3, Title = "The Dark Knight", Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", Year = 2008, Genre = GenreEnum.Action },
            new Movie { Id = 4, Title = "Forrest Gump", Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75.", Year = 1994, Genre = GenreEnum.Comedy },
            new Movie { Id = 5, Title = "Inception", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", Year = 2010, Genre = GenreEnum.Action },
            new Movie { Id = 20, Title = "Toy Story", Description = "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.", Year = 1995, Genre = GenreEnum.Comedy },
        };
    }
}
}
