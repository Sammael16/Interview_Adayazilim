using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ada_PreInterview.Models;
using Ada_PreInterview.Services;

namespace AlphaStellar.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        RequestHandler _requestHander;
        public ValuesController(RequestHandler requestHandler){
            this._requestHander = requestHandler;
        } 

        [HttpGet]
        public ActionResult Get(){
            return Ok("Hello");
        }
        //Post request.
        [HttpPost]
        public ActionResult Post(Input input){
            Answer answer = this._requestHander.ProcessInput(input);
            return Ok(answer);
        }
    }

}
