using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace OCR.SampleClient
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        static void Main(string[] args)
        {
            string apiKey;

            do
            {
                Console.Write("Please enter OCR API key:");
                apiKey = Console.ReadLine();
            } while (string.IsNullOrEmpty(apiKey));

            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["server"]);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ApiKey", apiKey);
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            ConsoleKeyInfo key;
            do
            {
                await Execute();
                Console.Write("Run again?");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Escape);
        }

        private static async Task Execute()
        {
            try
            {
                Console.WriteLine("Process...");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var result = await RecognizeImageAsync(
                    "1.jpg"
                   ,"2.jpg"
                );
                sw.Stop();
                Console.WriteLine("Result: " + result);

                TimeSpan ts = sw.Elapsed;
                string elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
                Console.WriteLine("Done.\nRunTime " + elapsedTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task<string> RecognizeImageAsync(params string[] paths)
        {
            var content = new MultipartFormDataContent();
            foreach (var path in paths)
            {
                var fileName = Path.GetFileName(path);
                content.Add(new ByteArrayContent(File.ReadAllBytes(path)), fileName, fileName);
            }
            HttpResponseMessage response = await Client.PostAsync("api/ocr/recognize", content);

            var result = response.Content != null ? await response.Content.ReadAsStringAsync() : null;
            if (response.IsSuccessStatusCode)
            {
                var o = JsonConvert.DeserializeObject(result);
                result = JsonConvert.SerializeObject(o, Formatting.Indented);
                return result;
            }
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Error: " + result);
            }
            response.EnsureSuccessStatusCode();
            return null;
        }
    }
}
