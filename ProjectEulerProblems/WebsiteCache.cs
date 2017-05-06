using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEulerProblems
{
    public class WebsiteCache
    {
        private const string CacheFolder = "./Cache";
        private const string WebsiteCacheFile = "./Cache/WebsiteCache.txt";
        private string _guidSplitter;

        private Dictionary<string, string> _urlsWithContents;

        public WebsiteCache()
        {
            _urlsWithContents = new Dictionary<string, string>();
            if (File.Exists(WebsiteCacheFile))
            {
                using (StreamReader reader = new StreamReader(WebsiteCacheFile))
                {
                    _guidSplitter = reader.ReadLine() ?? string.Empty;
                    if (_guidSplitter == string.Empty)
                    {
                        throw new InvalidDataException("Cache needs a GUID on the first line");
                    }
                }
                string text = File.ReadAllText(WebsiteCacheFile);
                string[] splitByGuid = text.Split(new string[] { _guidSplitter }, StringSplitOptions.None);
                for (int i = 1; i < splitByGuid.Length - 2; i += 2)
                {
                    //consecutive pairs are urls with contents
                    _urlsWithContents.Add(splitByGuid[i].TrimStart('\r', '\n'), splitByGuid[i + 1]);
                }
            }
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
            if (!Directory.Exists(CacheFolder))
            {
                Directory.CreateDirectory(CacheFolder);
            }

            if (!File.Exists(WebsiteCacheFile))
            {
                File.Create(WebsiteCacheFile).Close();
                //stick a GUID on the top, can be used as splitter for websites
                _guidSplitter = Guid.NewGuid().ToString();
                File.WriteAllLines(WebsiteCacheFile, new string[] { _guidSplitter });
            }

            if (!_urlsWithContents.ContainsKey(url))
            {
                _urlsWithContents.Add(url, websiteContents);
                File.AppendAllLines(WebsiteCacheFile, new string[]
                {
                    $"{url}{_guidSplitter}{websiteContents}{_guidSplitter}"
                });
            }
        }
    }
}
