using System.Collections.Generic;

namespace HomeCloudWindows
{
    class InMemoryFileBuffer
    {
        public static InMemoryFileBuffer Instance { get; } = new InMemoryFileBuffer();

        public void AddBuffer(string token, string id, string chunk)
        {
            string key = token + id;
            if (! buffer.ContainsKey(key))
            {
                buffer.Add(key, chunk);
            }
            else
            {
                buffer[key] = buffer[key] + chunk;
            }
        }

        public string GetBuffer(string token, string id)
        {
            string key = token + id;
            string element =  buffer[key];
            buffer.Remove(key);
            return element;
        }

        private Dictionary<string, string> buffer;

        private InMemoryFileBuffer()
        {
            buffer = new Dictionary<string, string>();
        }
    }
}
