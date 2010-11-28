using Newtonsoft.Json;
using System;

namespace StackOverflow
{
    class Site
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "logo_url")]
        public Uri LogoUrl { get; set; }
        [JsonProperty(PropertyName = "site_url")]
        public Uri SiteUrl { get; set; }
        [JsonProperty(PropertyName = "icon_url")]
        public Uri IconUrl { get; set; }
        [JsonProperty(PropertyName = "api_endpoint")]
        public Uri ApiEndpoint { get; set; }
    }
}

//JSON for http://stackauth.com/1.0/sites
/*
{
  "api_sites": [
    {
      "name": {
        "description": "name of the site",
        "values": "string",
        "optional": false,
        "suggested_buffer_size": 100
      },
      "logo_url": {
        "description": "absolute path to the logo for the site",
        "values": "string",
        "optional": true,
        "suggested_buffer_size": 512
      },
      "api_endpoint": {
        "description": "absolute path to the api endpoint for the site, sans the version string",
        "values": "string",
        "optional": true,
        "suggested_buffer_size": 100
      },
      "site_url": {
        "description": "absolute path to the front page of the site",
        "values": "string",
        "optional": true,
        "suggested_buffer_size": 100
      },
      "description": {
        "description": "description of the site, suitable for display to a user",
        "values": "string",
        "optional": true,
        "suggested_buffer_size": 512
      },
      "icon_url": {
        "description": "absolute path to an icon suitable for representing the site, it is a consumers responsibility to scale",
        "values": "string",
        "optional": true,
        "suggested_buffer_size": 100
      },
      "aliases": [
        {
          "values": "string"
        }
      ],
      "state": {
        "description": "state of this site.",
        "values": "one of normal, closed_beta, open_beta, or linked_meta",
        "optional": false
      },
      "styling": {
        "link_color": {
          "description": "color of links, as a CSS style color value",
          "values": "string",
          "optional": false
        },
        "tag_foreground_color": {
          "description": "foreground color of tags, as a CSS style color value",
          "values": "string",
          "optional": false
        },
        "tag_background_color": {
          "description": "background/fill color of tags, as a CSS style color value",
          "values": "string",
          "optional": false
        }
      }
    }
  ]
}
*/
