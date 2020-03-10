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
    /// Defines the <see cref="LoadController" />
    /// </summary>
    public class LoadController : ODataController
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
        /// Defines the _loadManager
        /// </summary>
        private IManager<LoadDTO> _loadManager;

        /// <summary>
        /// Defines the context
        /// </summary>
        protected IApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadController"/> class.
        /// </summary>
        public LoadController()
        {
            context = new XmlApplicationContext(this.springManagers, this.springManagersFile);
            _loadManager = (IManager<LoadDTO>)context["LoadManager"];
        }

        /// <summary>
        /// The Get method that allows to retrieve a list of loads
        /// </summary>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [EnableQuery]
        [System.Web.Mvc.HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok(_loadManager.GetAll().AsQueryable());
        }

        /// <summary>
        /// The Delete method that allows to delete a load
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

            return Ok(_loadManager.Delete(Convert.ToInt32(id)));
        }

        /// <summary>
        /// The Build method that will group shipments under some criteria and will retrieve the result list of loads that were build
        /// </summary>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [HttpGet]
        [ODataRoute("Build")]
        public System.Web.Http.IHttpActionResult Build()
        {
            return Ok(_loadManager.Build().AsQueryable());
        }
    }
}
