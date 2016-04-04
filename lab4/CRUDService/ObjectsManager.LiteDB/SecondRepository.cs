using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class SecondRepository : ISecondRepository
    {
        private readonly string _secondConnection = DatabaseConnections.SecondConnection;

        public List<Review> GetAllReviews()
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public List<Review> GetReviewsByMovieId(int movieId)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.Find(x => x.MovieId == movieId);

                return results.Select(x => Map(x)).ToList();
            }
        }

        public List<Review> GetReviewsByAuthor(Person Author)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.Find(x => x.Author == Author);

                return results.Select(x => Map(x)).ToList();
            }
        }

        public List<Person> GetAllPeople()
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<PersonDB>("people");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Review second)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var dbObject = InverseMap(second);


                var repository = db.GetCollection<ReviewDB>("reviews");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public int Add(Person second)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var dbObject = InverseMap(second);


                var repository = db.GetCollection<PersonDB>("people");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Review GetReview(int id)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var result = repository.FindById(id);
                return Map(result);
            }
        }
        
        public Person GetPerson(int id)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<PersonDB>("people");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Person GetPerson(String Name, String Surname)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<PersonDB>("people");
                var result = repository.FindOne(x => x.Name == Name && x.Surname == Surname);
                return Map(result);
            }
        }

        public Review Update(Review second)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var dbObject = InverseMap(second);

                var repository = db.GetCollection<ReviewDB>("reviews");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public Person Update(Person second)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var dbObject = InverseMap(second);

                var repository = db.GetCollection<PersonDB>("people");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool DeleteReview(int id)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                return repository.Delete(id);
            }
        }

        public bool DeletePerson(int id)
        {
            using (var db = new LiteDatabase(this._secondConnection))
            {
                var repository = db.GetCollection<PersonDB>("people");
                return repository.Delete(id);
            }
        }

        private Review Map(ReviewDB dbSecond)
        {
            if (dbSecond == null)
                return null;
            return new Review() {
                Id = dbSecond.Id,
                Content = dbSecond.Content,
                Score = dbSecond.Score,
                Author = dbSecond.Author,
                MovieId = dbSecond.MovieId
            };
        }

        private Person Map(PersonDB dbSecond)
        {
            if (dbSecond == null)
                return null;
            return new Person()
            {
                Id = dbSecond.Id,
                Name = dbSecond.Name,
                Surname = dbSecond.Surname
            };
        }

        private ReviewDB InverseMap(Review second)
        {
            if (second == null)
                return null;
            return new ReviewDB()
            {
                Id = second.Id,
                Content = second.Content,
                Score = second.Score,
                Author = second.Author,
                MovieId = second.MovieId
            };
        }

        private PersonDB InverseMap(Person second)
        {
            if (second == null)
                return null;
            return new PersonDB()
            {
                Id = second.Id,
                Name = second.Name,
                Surname = second.Surname
            };
        }
    }
}
