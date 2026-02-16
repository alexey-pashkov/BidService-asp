using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bid
    {
        public Guid BidId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BidCreator Author { get; set; }
        public Reviewer? Reviewer { get; set; }
        public BidStatus Status { get; set; }
        public Category Category { get; set; }

        public Bid(string title, string description, BidCreator author, BidStatus status) 
        {
            Title = title;
            Description = description;
            Author = author;
            Status = status;
        }
    }
}
