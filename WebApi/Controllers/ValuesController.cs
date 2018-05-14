using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebApi.Services;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using WebApi.Classes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : ControllerBase /* For api that not serving html etc. its better to user controllerBase*/
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        /*can also :
         * HttpGet("{id?}") - will go to this route even if id not specified (id will be the default value 0
         * HttpGet("{id=123}") - will go to this route even if id not specified (id will be 123)
         * HttpGet("{id:int}") - will avoid this route if id is not int
         */
         [Produces("application/xml")] // will return response as xml
        public string[] Get(int id)
        {
            return new string[] { "value1", "value2" };
        }
        // GET with Query params

        [HttpGet("hen")]// GET api/values/hen?name=<val>
        public string Get([FromQuery]string name)
        {
            /*
             demonstrate sending http request from server: @see https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
             */

            //POST REQUEST EXAMPLE 
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Set("Content-Type", "application/json");
                var email = new Email()
                {
                    subject = "HI",
                    from = "jhon-doe",
                    to = new string[] { "hen10102@gmail.com" },
                    html = "some text"
                };
                var json = JsonConvert.SerializeObject(email);

                string responseBody = webClient.UploadString("https://hen-mailer.herokuapp.com/mail", json);
                Console.WriteLine(responseBody);
            }
            catch (WebException webEx)
            {
                Trace.TraceError("Failed to GetLatestDelta(...), HttpStatus: "
                    + $"{((HttpWebResponse)webEx.Response).StatusCode}. "
                    + $"cloudAccessToken: ");
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Failed to GetLatestDelta(...). {ex.Message}\n{ex.StackTrace}");
            }

            return "hen";
        }
        //POST api/values
        [HttpPost]
        public string Post([FromBody]Email email)//getting posted json object by binding
        {
            JsonConvert.ToString(email);
            Console.WriteLine();
            return "ok";
        }

        /*
          === Data Annotation === 
          - helps validate incoming requests.
          - can also be in use inside classes and their props
          for exmaple:
          [MinLength(3)] - the prop have to be at least 3 length size]
          if the prop is not valid - [ModelState.IsValid] = false
         */
        //POST api/values/hen
        [HttpPost("hen/{val}")]
        //[Produces("application/json")]
        public IActionResult Post([FromBody]Message message)//getting posted json object by binding
        {
            if (!ModelState.IsValid)
            {
                //how to return response
                return BadRequest(ModelState);
            }
            return Ok(message);
            
        }

        public class Message
        {
            [MinLength(3)]
            public string msg { get; set; }
        }
    


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
