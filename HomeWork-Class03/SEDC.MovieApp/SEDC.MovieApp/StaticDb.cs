using SEDC.MovieApp.Models;

namespace SEDC.MovieApp
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>
    {
        new Movie { Id = 1, Title = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Year = 1994, Genre = GenreEnum.Drama },
        new Movie { Id = 2, Title = "Star Wars: A New Hope", Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station.", Year = 1977, Genre = GenreEnum.SciFi },
        new Movie { Id = 3, Title = "The Godfather", Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", Year = 1972, Genre = GenreEnum.Crime },
        new Movie { Id = 4, Title = "The Dark Knight", Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", Year = 2008, Genre = GenreEnum.Action },
        new Movie { Id = 5, Title = "Titanic", Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", Year = 1997, Genre = GenreEnum.Romance },
        new Movie { Id = 6, Title = "Jurassic Park", Description = "A pragmatic paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids after a power failure causes the park's cloned dinosaurs to run loose.", Year = 1993, Genre = GenreEnum.Adventure },
        new Movie { Id = 7, Title = "The Exorcist", Description = "When a teenage girl is possessed by a mysterious entity, her mother seeks the help of two priests to save her daughter.", Year = 1973, Genre = GenreEnum.Horror },
        new Movie { Id = 8, Title = "The Sound of Music", Description = "A woman leaves an Austrian convent to become a governess to the children of a Naval officer widower.", Year = 1965, Genre = GenreEnum.Musical },
        new Movie { Id = 9, Title = "Toy Story", Description = "A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy in a boy's room.", Year = 1995, Genre = GenreEnum.Animation },
        new Movie { Id = 10, Title = "Schindler's List", Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", Year = 1993, Genre = GenreEnum.History }
    };

        public static int MovieId = 10;
    }
}
