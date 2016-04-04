using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;

namespace SecondsCRUDService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ObjectsService : IObjectsService
    {
        private readonly ISecondRepository _secondsRepository;

        public ObjectsService()
        {
            this._secondsRepository = new SecondRepository();
        }

        /* Reviews */
        public int AddReview(ObjectsManager.Model.Review review)
        {
            return this._secondsRepository.Add(review);
        }

        public ObjectsManager.Model.Review GetReview(int id)
        {
            return this._secondsRepository.GetReview(id);
        }

        public List<ObjectsManager.Model.Review> GetAllReviews()
        {
            return this._secondsRepository.GetAllReviews();
        }

        public List<ObjectsManager.Model.Review> GetReviewsByMovieId(int movieId)
        {
            return this._secondsRepository.GetReviewsByMovieId(movieId);
        }

        public List<ObjectsManager.Model.Review> GetReviewsByAuthor(ObjectsManager.Model.Person Author)
        {
            return this._secondsRepository.GetReviewsByAuthor(Author);
        }

        public ObjectsManager.Model.Review UpdateReview(ObjectsManager.Model.Review review)
        {
            return this._secondsRepository.Update(review);
        }

        public bool DeleteReview(int id)
        {
            return this._secondsRepository.DeleteReview(id);
        }

        /* People */
        public int AddPerson(ObjectsManager.Model.Person person)
        {
            return this._secondsRepository.Add(person);
        }

        public ObjectsManager.Model.Person GetPerson(int id)
        {
            return this._secondsRepository.GetPerson(id);
        }

        public ObjectsManager.Model.Person GetPersonByCredentials(String Name, String Surname)
        {
            return this._secondsRepository.GetPerson(Name, Surname);
        }

        public List<ObjectsManager.Model.Person> GetAllPeople()
        {
            return this._secondsRepository.GetAllPeople();
        }

        public ObjectsManager.Model.Person UpdatePerson(ObjectsManager.Model.Person person)
        {
            return this._secondsRepository.Update(person);
        }

        public bool DeletePerson(int id)
        {
            return this._secondsRepository.DeletePerson(id);
        }
    }
}
