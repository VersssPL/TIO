using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.LiteDB.Model
{
    public class ReviewDB
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public ObjectsManager.Model.Person Author { get; set; }
        public int MovieId { get; set; }
    }

    public class PersonDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
