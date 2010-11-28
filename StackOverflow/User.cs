using Newtonsoft.Json;
using System;

namespace StackOverflow
{
    class User
    {
        [JsonProperty(PropertyName = "user_id")]
        public string UserID { get; set; }
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
        public int Reputation { get; set; }
        public Uri FlairUrl { get; set; }
    }
}


//JSON for http://api.stackoverflow.com/1.0/users/19856/?type=jsontext
/*
{
  "total": 1,
  "page": 1,
  "pagesize": 30,
  "users": [
    {
      "user_id": 19856,
      "user_type": "registered",
      "creation_date": 1221974975,
      "display_name": "Traveling Tech Guy",
      "reputation": 4118,
      "email_hash": "68ff0d07c7890fec6cd74d3ddff72b65",
      "age": 36,
      "last_access_date": 1290837948,
      "website_url": "http://www.travelingtechguy.com",
      "location": "California",
      "about_me": "<p>I'm a traveling consultant, currently self-employed.<br>For the last 15 years I managed and developed web applications, mostly in the .Net space, but recently in other web technologies as well.</p>\r\n<p>I offer several services, including project management, web applications  development, integrations with existing systems and problem resolution.</p>\r\n<p>Find out more about me at <a href=\"http://www.travelingtechguy.com\" rel=\"nofollow\">my site</a>, <a href=\"http://www.guyvider.com\" rel=\"nofollow\">my blog</a>, or <a href=\"http://www.linkedin.com/in/gvider\" rel=\"nofollow\">my Linkedin profile</a></p>",
      "question_count": 25,
      "answer_count": 241,
      "view_count": 280,
      "up_vote_count": 101,
      "down_vote_count": 5,
      "accept_rate": 100,
      "association_id": "a4bcd7a4-52ad-4f02-8f17-d8c349e81936",
      "user_questions_url": "/users/19856/questions",
      "user_answers_url": "/users/19856/answers",
      "user_favorites_url": "/users/19856/favorites",
      "user_tags_url": "/users/19856/tags",
      "user_badges_url": "/users/19856/badges",
      "user_timeline_url": "/users/19856/timeline",
      "user_mentioned_url": "/users/19856/mentioned",
      "user_comments_url": "/users/19856/comments",
      "user_reputation_url": "/users/19856/reputation",
      "badge_counts": {
        "gold": 0,
        "silver": 6,
        "bronze": 18
      }
    }
  ]
}
*/