using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TestWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private static HashSet<string> ValuesCollection = new HashSet<string> { "message 1", "hi", "happy monday!" };

        [Route("api/values")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<string> Get()
        {
            return ValuesCollection;
        }

        [Route("api/values")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public void Post([FromBody]StringModel message)
        {
            ValuesCollection.Add(message.Message);
        }

        [Route("api/values")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public void Put([FromBody]UpdateModel model)
        {
            if (ValuesCollection.Remove(model.OldMessage))
            {
                ValuesCollection.Add(model.NewMessage);
            }
            else
            {
                throw new ArgumentNullException(model.OldMessage);
            }
        }

        [Route("api/values/{message}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpDelete]
        public void Delete(string message)
        {
            ValuesCollection.Remove(message);
        }
    }

    public class UpdateModel
    {
        public string OldMessage { get; set; }
        public string NewMessage { get; set; }
    }

    public class StringModel
    {
        public string Message { get; set; }
    }
}
