using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;

namespace SecondsCRUDService
{
    [ServiceContract]
    public interface IObjectsService
    {
        /* Reviews */
        [OperationContract]
        int AddReview(Review review);

        [OperationContract]
        Review GetReview(int id);

        [OperationContract]
        List<Review> GetAllReviews();

        [OperationContract]
        List<Review> GetReviewsByMovieId(int movieId);

        [OperationContract]
        List<Review> GetReviewsByAuthor(Person Author);

        [OperationContract]
        Review UpdateReview(Review review);

        [OperationContract]
        bool DeleteReview(int id);

        /* People */
        [OperationContract]
        int AddPerson(Person review);

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        Person GetPersonByCredentials(String Name, String Surname);

        [OperationContract]
        List<Person> GetAllPeople();

        [OperationContract]
        Person UpdatePerson(Person review);

        [OperationContract]
        bool DeletePerson(int id);

    }
}
