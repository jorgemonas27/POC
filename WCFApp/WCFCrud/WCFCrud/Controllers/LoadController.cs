using BussinessLogic.Managers;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using ModelsDTO;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Http;


namespace WCFCrud.Controllers
{
    public class LoadController : ODataController
    {
        private string springManagersFile = ConfigurationManager.AppSettings["springManagersFile"]; // ConfigurationManager.AppSettings["springFactoriesFile"];
        private string springManagers = ConfigurationManager.AppSettings["springManagers"];
        private IManager<LoadDTO> _loadManager;
        protected IApplicationContext context;

        public LoadController()
        {
            context = new XmlApplicationContext(this.springManagers, this.springManagersFile);
            _loadManager = (IManager<LoadDTO>)context["LoadManager"];
        }

        [EnableQuery]
        [System.Web.Mvc.HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok(_loadManager.GetLoadDetails().AsQueryable());
        }

        [System.Web.Mvc.HttpDelete]
        public System.Web.Http.IHttpActionResult Delete([FromODataUri(Name = "key")] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            return Ok(_loadManager.Delete(Convert.ToInt32(id)));
        }

        [HttpGet]
        [ODataRoute("Build")]
        public System.Web.Http.IHttpActionResult Build()
        {
            return Ok(_loadManager.Build().AsQueryable());
        }
    }
}
