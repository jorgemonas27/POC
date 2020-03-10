namespace WCFCrud.Controllers
{
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

    /// <summary>
    /// Defines the <see cref="ShipmentController" />
    /// </summary>
    public class ShipmentController : ODataController
    {
        /// <summary>
        /// Defines the springManagersFile
        /// </summary>
        private string springManagersFile = ConfigurationManager.AppSettings["springManagersFile"];

        /// <summary>
        /// Defines the springManagers
        /// </summary>
        private string springManagers = ConfigurationManager.AppSettings["springManagers"];

        /// <summary>
        /// Defines the _shipmentManager
        /// </summary>
        private IManager<ShipmentDTO> _shipmentManager;

        /// <summary>
        /// Defines the context
        /// </summary>
        protected IApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentController"/> class.
        /// </summary>
        public ShipmentController()
        {
            context = new XmlApplicationContext(this.springManagers, this.springManagersFile);
            _shipmentManager = (IManager<ShipmentDTO>)context["ShipmentsManager"];
        }

        /// <summary>
        /// The Get method will retrieve a list of all the existing shipments
        /// </summary>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [EnableQuery]
        [HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok(_shipmentManager.GetAll().AsQueryable());
        }

        /// <summary>
        /// The Delete method will delete a certain shipment
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [System.Web.Mvc.HttpDelete]
        public System.Web.Http.IHttpActionResult Delete([FromODataUri(Name = "key")] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            return Ok(_shipmentManager.Delete(Convert.ToInt32(id)));
        }

        /// <summary>
        /// The Consolidate method will be retrieve a list of all the orders that were group into a shipment
        /// </summary>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [HttpGet]
        [ODataRoute("Consolidate")]
        public System.Web.Http.IHttpActionResult Consolidate()
        {
            return Ok(_shipmentManager.Consolidate().AsQueryable());
        }
    }
}
