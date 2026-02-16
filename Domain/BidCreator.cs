using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BidCreator : User
    {
        public Bid CreateBid(string title, string description)
        {
            return new Bid(title, description, this, BidStatus.Project); 
        }
    }
}
