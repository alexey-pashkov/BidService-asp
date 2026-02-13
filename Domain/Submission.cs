using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Submission
    {
        public Guid ApplicationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SubmissionCreator Author { get; set; }
        public Reviewer? Reviewer { get; set; }
        public SubmissionStatus Status { get; set; }

        public Submission(string title, string description, SubmissionCreator author, SubmissionStatus status) 
        {
            Title = title;
            Description = description;
            Author = author;
            Status = status;
        }
    }
}
