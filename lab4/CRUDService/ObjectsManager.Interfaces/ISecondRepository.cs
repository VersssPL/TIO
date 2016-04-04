using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Model;

namespace ObjectsManager.Interfaces
{
    public interface ISecondRepository
    {
        List<Review> GetAllReviews();
        List<Review> GetReviewsByMovieId(int movieId);
        List<Review> GetReviewsByAuthor(Person Author);
        List<Person> GetAllPeople();
        int Add(Review second);
        int Add(Person second);
        Review GetReview(int id);
        Person GetPerson(int id);
        Person GetPerson(String Name, String Surname);
        Review Update(Review second);
        Person Update(Person second);
        bool DeleteReview(int id);
        bool DeletePerson(int id);
    }
}
