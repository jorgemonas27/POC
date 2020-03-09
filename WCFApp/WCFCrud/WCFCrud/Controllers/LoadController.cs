using BussinessLogic.Managers;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Linq;
using System.Web.Http;


namespace WCFCrud.Controllers
{
    public class LoadController : ODataController
    {
        private LoadManager _manager;

        public LoadController()
        {
            _manager = new LoadManager();
        }

        [EnableQuery]
        [System.Web.Mvc.HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok(_manager.GetData().AsQueryable());
        }

        [System.Web.Mvc.HttpDelete]
        public System.Web.Http.IHttpActionResult Delete([FromODataUri(Name = "key")] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            return Ok(_manager.Delete(Convert.ToInt32(id)));
        }

        [HttpGet]
        [ODataRoute("Build")]
        public System.Web.Http.IHttpActionResult Build()
        {
            return Ok(_manager.Build().AsQueryable());
        }


    }
}
