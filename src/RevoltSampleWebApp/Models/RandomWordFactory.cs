using System.Net;
using System.Collections.Generic;

namespace RevoltSampleWebApp.Models
{
    public class RandomWordFactory
    {
        public Stack<string> Words { private set; get; }

        public RandomWordFactory()
        {
            Words = new Stack<string>();
        }
        public void GenerateWords(uint count)
        {
            WebClient client = new WebClient();
            // API Key needs to be updated
            string key = client.DownloadString("https://random-word-api.herokuapp.com/key");
            string rawJSON = client.DownloadString("https://random-word-api.herokuapp.com/word?key=" + key +"&number=" + count.ToString());

            // Clearing JSON file
            rawJSON = rawJSON.Trim('[', ']');
            // Parsing JSON file
            string[] wordsRaw = rawJSON.Split(',');

            Words.Clear();
            foreach (string word in wordsRaw)
            {
                // Removing quotes from individual words
                Words.Push(word.Substring(2, word.Length - 3));
            }

        }
    }
}
