using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ChuckNorrisJokeApp.Models;


namespace ChuckNorrisJokeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {

        private static readonly HttpClient client = new HttpClient();


        [HttpGet("Public")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Public()
        {
            var result = GetJokeFromCategory();
            return Ok(result);
        }

        public static string GetJokeFromCategory()
        {
            Joke joke = new Joke();
            var categories=new List<string>();
            categories.Add("animal");
            categories.Add("career");
            categories.Add("celebrity");
            categories.Add("dev");
            categories.Add("explicit");
            categories.Add("fashion");
            categories.Add("food");
            categories.Add("history");
            categories.Add("money");
            categories.Add("movie");
            categories.Add("music");
            categories.Add("political");
            categories.Add("religion");
            categories.Add("science");
            categories.Add("sport");
            categories.Add("travel");

            var random = new Random();
            int index=random.Next(categories.Count);



            string Url = "https://api.chucknorris.io/jokes/random?category="+categories[index];

            try
            {
                string stringResult = HttpWebRequest("GET", Url);
                joke = JsonConvert.DeserializeObject<Joke>(stringResult);

                return joke.Value;
            }
            catch (Exception)
            {
               
                return null;
            }
        }

        public static string JokeFromSearch(string search)
        {
            JokesResult jokeResult = new JokesResult();
            string Url = "https://api.chucknorris.io/jokes/search?query=" + search;

            try
            {
                string stringResult = HttpWebRequest("GET", Url);
                jokeResult = JsonConvert.DeserializeObject<JokesResult>(stringResult);

                Random randomNumber = new Random(); //Setup, and return random joke from search result list.
                string randomJokeFromList = jokeResult.result[randomNumber.Next(0, jokeResult.result.Count)].Value;
                return randomJokeFromList;
            }
            catch (Exception)
            {
                
                return null;
            }
        }

        public static string HttpWebRequest(string method, string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = method;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string streamResponses = string.Empty;
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);

                    streamResponses = reader.ReadToEnd();
                }

                response.Close();

                return streamResponses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
