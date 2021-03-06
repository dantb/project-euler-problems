﻿using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEulerProblems
{
    public class WebsiteCache
    {
        private const string CacheFolder = "./Cache";
        private const string WebsiteCacheFile = "./Cache/WebsiteCache.txt";
        private string _guidIdentifier;

        private Dictionary<string, string> _urlsWithContents;

        public WebsiteCache()
        {
            CreateCacheFileWithGuidIdentifier();
            _urlsWithContents = new Dictionary<string, string>();
            //if guid is initialised, we just created the cache - use it. Otherwise read from cache
            _guidIdentifier = string.IsNullOrEmpty(_guidIdentifier) ? ExtractGuidIdentifierFromCache() : _guidIdentifier;
            string text = File.ReadAllText(WebsiteCacheFile);
            ReadCacheIntoMemory(text);
        }

        internal bool TryGetWebsite(string url, out string websiteContents)
        {
            websiteContents = string.Empty;
            if (_urlsWithContents.ContainsKey(url))
            {
                websiteContents = _urlsWithContents[url];
                return true;
            }
            return false;
        }

        internal void SaveWebsiteToCache(string url, string websiteContents)
        {
            if (!_urlsWithContents.ContainsKey(url))
            {
                _urlsWithContents.Add(url, websiteContents);
                File.AppendAllLines(WebsiteCacheFile, new string[]
                {
                    $"{url}{_guidIdentifier}{websiteContents}{_guidIdentifier}"
                });
            }
        }

        private void CreateCacheFileWithGuidIdentifier()
        {
            if (!Directory.Exists(CacheFolder))
            {
                Directory.CreateDirectory(CacheFolder);
            }

            if (!File.Exists(WebsiteCacheFile))
            {
                File.Create(WebsiteCacheFile).Close();
                //stick a GUID on the top, can be used as splitter for websites
                _guidIdentifier = Guid.NewGuid().ToString();
                File.WriteAllLines(WebsiteCacheFile, new string[] { _guidIdentifier });
            }
        }

        private void ReadCacheIntoMemory(string text)
        {
            string[] splitByGuid = text.Split(new string[] { _guidIdentifier }, StringSplitOptions.None);
            for (int i = 1; i < splitByGuid.Length - 2; i += 2)
            {
                //consecutive pairs are urls with contents
                _urlsWithContents.Add(splitByGuid[i].TrimStart('\r', '\n'), splitByGuid[i + 1]);
            }
        }

        private string ExtractGuidIdentifierFromCache()
        {
            string guidIdentifier;
            using (StreamReader reader = new StreamReader(WebsiteCacheFile))
            {
                guidIdentifier = reader.ReadLine() ?? string.Empty;
                if (guidIdentifier == string.Empty)
                {
                    throw new InvalidDataException("Cache needs a GUID on the first line");
                }
            }
            return guidIdentifier;
        }
    }
}
