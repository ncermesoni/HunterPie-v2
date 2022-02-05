﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace HunterPie.Core.Http
{
    public class PoogieBuilder
    {
        private Poogie poogie = new();

        public PoogieBuilder() { }
        public PoogieBuilder(string[] urls) { poogie.Urls.AddRange(urls); }
        public PoogieBuilder(string url) { poogie.Urls.Add(url); }

        public PoogieBuilder Get(string path)
        {
            poogie.Method = HttpMethod.Get;
            poogie.Path = path;

            return this;
        }

        public PoogieBuilder WithHeader(string key, string value)
        {
            poogie.Headers.Add(key, value);
            
            return this;
        }

        public PoogieBuilder Post(string path)
        {
            poogie.Method = HttpMethod.Post;
            poogie.Path = path;

            return this;
        }

        public PoogieBuilder WithJson<T>(T json)
        {
            string serialized = JsonConvert.SerializeObject(json);
            poogie.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

            return this;
        }

        public PoogieBuilder WithTimeout(TimeSpan timeout)
        {
            poogie.Timeout = timeout;
            return this;
        }

        public Poogie Build()
        {
            return poogie;
        }
    }
}