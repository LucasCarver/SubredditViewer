using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubredditViewer.Models
{
    public class RedditPost
    {
        public string title { get; set; }
        // IMAGE URL
        public string thumbnail { get; set; }
        public string permalink { get; set; }
    }
}
