using System;
using System.Collections.Generic;
using Rosenbach.Services.DataBase;

namespace Rosenbach.Models
{
    public class Rating : DataBaseObject
    {
        [LiteDB.BsonId]
        public int Id { get; set; }

        public double Rating1 { get; set; }
        public double Rating2 { get; set; }
        public double Rating3 { get; set; }
        public double Rating4 { get; set; }
        public double Rating5 { get; set; }
        public DateTime dateTime { get; set; }
   
    }

    public class RatingDataBase : BaseImplementation<Rating>
    {
        public RatingDataBase() : base()
        {

        }

        public IEnumerable<Rating> Search(int id)
        {
            return base.Find(x => x.Id == id);
        }
    }
}
