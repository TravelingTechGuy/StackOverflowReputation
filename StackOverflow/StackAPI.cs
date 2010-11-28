using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace StackOverflow
{
    class StackAPI
    {
        private const string authUrl = "http://stackauth.com/1.0";
        private const string flairUrl = "http://stackexchange.com/users/flair";
        private const string apiKey = "X_ZnExTP50ebPk2OntQxjQ";
        
        private Uri combinedReputationUrl;
        private SortedDictionary<string, User> users;
        private SortedDictionary<string, Site> sites;
        
        public Uri CombinedReputationUrl { get { return combinedReputationUrl; } }

        public SortedDictionary<string, User> Users
        {
            get { return users; }
        }

        public SortedDictionary<string, Site> Sites
        {
            get { return sites; }
        }

        public StackAPI()
        {
            sites = new SortedDictionary<string, Site>();
            GetSites();
            users = new SortedDictionary<string, User>();
        }

        private void GetSites()
        {
            if (sites.Count > 0)
            {
                sites.Clear();
            }
            string url = string.Format("{0}/sites", authUrl);
            try
            {
                JObject json = JObject.Parse(GetJsonString(url));
                List<JToken> results = json["api_sites"].ToList();
                foreach (JToken result in results)
                {
                    Site site = JsonConvert.DeserializeObject<Site>(result.ToString());
                    sites.Add(site.Name, site);
                }
            }
            catch
            {
                sites.Clear();
            }
        }

        public bool GetUsers(string site, string userId)
        {
            if (users.Count > 0)
            {
                users.Clear();
            }
            string url = string.Format("{0}/1.0/users/{1}", sites[site].ApiEndpoint.OriginalString, userId);
            try
            {
                JObject json = JObject.Parse(GetJsonString(url));
                string associatedId = (string) json["users"][0]["association_id"];
                combinedReputationUrl = new Uri(string.Format("{0}/{1}.png", flairUrl, associatedId.Replace("-", "")));
                return GetAssociatedSites(associatedId);
            }
            catch
            {
                users.Clear();
                return false;
            }
        }

        private bool GetAssociatedSites(string associatedId)
        {
            string url = string.Format("{0}/users/{1}/associated", authUrl, associatedId);
            try {
                JObject json = JObject.Parse(GetJsonString(url));
                List<JToken> results = json["associated_users"].ToList();
                foreach (JToken result in results)
                {
                    User user = JsonConvert.DeserializeObject<User>(result.ToString());
                    user.FlairUrl = new Uri(string.Format("{0}/users/flair/{1}.png", (string) result["on_site"]["site_url"], user.UserID));
                    users.Add((string) result["on_site"]["name"], user);
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetJsonString(string url)
        {
            try
            {
                url += (apiKey != string.Empty) ? "?key=" + apiKey : "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string reply = reader.ReadToEnd();
                        return reply;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
