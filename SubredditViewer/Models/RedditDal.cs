using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SubredditViewer.Models
{
    public class RedditDal
    {
        public string GetAPIJson(string subreddit)
        {
            string url = $"https://www.reddit.com/r/{subreddit}/.json";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string output = rd.ReadToEnd();
            return output;
        }

        public RedditPost GetPost(string subreddit, int i)
        {
            RedditPost rp;
            string output = GetAPIJson(subreddit);
            JObject json = JObject.Parse(output);
            List<JToken> modelData = json["data"]["children"].ToList();
            rp = JsonConvert.DeserializeObject<RedditPost>(modelData[i]["data"].ToString());
            return rp;
        }

        public List<RedditPost> GetPostList(string subreddit)
        {
            List<RedditPost> rpl = new List<RedditPost>();
            for (int i = 0; i < 10; i++)
            {
                rpl.Add(GetPost(subreddit, i));
            }
            return rpl;
        }
    }
}
