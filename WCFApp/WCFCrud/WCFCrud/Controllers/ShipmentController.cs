using BussinessLogic.Managers;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using ModelsDTO;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;

namespace WCFCrud.Controllers
{
    public class ShipmentController : ODataController
    {
        private string springManagersFile = ConfigurationManager.AppSettings["springManagersFile"]; // ConfigurationManager.AppSettings["springFactoriesFile"];
        private string springManagers = ConfigurationManager.AppSettings["springManagers"];
        private IManager<ShipmentDTO> _shipmentManager;
        protected IApplicationContext context;

        public ShipmentController()
        {
            context = new XmlApplicationContext(this.springManagers, this.springManagersFile);
            _shipmentManager = (IManager<ShipmentDTO>)context["ShipmentsManager"];
        }

        [EnableQuery]
        [HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {   
            return Ok((_shipmentManager.GetDetails()));
        }

        [System.Web.Mvc.HttpDelete]
        public System.Web.Http.IHttpActionResult Delete([FromODataUri(Name = "key")] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            return Ok(_shipmentManager.Delete(Convert.ToInt32(id)));
        }

        [HttpGet]
        [ODataRoute("Consolidate")]
        public System.Web.Http.IHttpActionResult Consolidate()
        {
            return Ok(_shipmentManager.Consolidate().AsQueryable());
        }
    }
}