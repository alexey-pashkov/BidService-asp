using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SubmissionCreator : User
    {
        public Submission CreateSubmission(string title, string description)
        {
            return new Submission(title, description, this, SubmissionStatus.Project); 
        }
    }
}
