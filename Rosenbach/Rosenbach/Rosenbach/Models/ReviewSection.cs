using System;
using System.Collections.Generic;
using System.Text;
using Rosenbach.Services.DataBase;

namespace Rosenbach.Models
{
 
    public class ReviewSection : DataBaseObject
    {
        [LiteDB.BsonId]
        public int Id { get; set; }
        public string TendenzMinimum { get; set; }
        public string TendenzMiddle { get; set; }
        public string TendenzMaximum { get; set; }
        public string Question { get; set; }
    }

    public class ReviewSectionDataBase : BaseImplementation<ReviewSection>
    {
        public ReviewSectionDataBase() : base()
        {

        }

        public IEnumerable<ReviewSection> Search(int id)
        {
            return base.Find(x => x.Id == id);
        }
    }
}
