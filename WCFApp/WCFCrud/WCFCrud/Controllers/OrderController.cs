namespace WCFCrud.Controllers
{
    using BussinessLogic.Managers;
    using Microsoft.AspNet.OData;
    using ModelsDTO;
    using Spring.Context;
    using Spring.Context.Support;
    using System;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="OrderController" />
    /// </summary>
    public class OrderController : ODataController
    {
        /// <summary>
        /// Defines the springManagersFile
        /// </summary>
        private string springManagersFile = ConfigurationManager.AppSettings["springManagersFile"];// ConfigurationManager.AppSettings["springFactoriesFile"];

        /// <summary>
        /// Defines the springManagers
        /// </summary>
        private string springManagers = ConfigurationManager.AppSettings["springManagers"];

        /// <summary>
        /// Defines the _orderManager
        /// </summary>
        private IManager<OrderDTO> _orderManager;

        /// <summary>
        /// Defines the context
        /// </summary>
        protected IApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        public OrderController()
        {
            context = new XmlApplicationContext(this.springManagers, this.springManagersFile);
            _orderManager = (IManager<OrderDTO>)context["OrderManager"];
        }

        /// <summary>
        /// The Get method will retrieve the list of orders
        /// </summary>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [EnableQuery]
        [System.Web.Http.HttpGet]
        public System.Web.Http.IHttpActionResult Get()
        {
            return Ok(_orderManager.GetAll().AsQueryable());
        }

        /// <summary>
        /// The Post method will create a new order 
        /// </summary>
        /// <param name="newOrder">The newOrder<see cref="OrderDTO"/></param>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [System.Web.Mvc.HttpPost]
        public System.Web.Http.IHttpActionResult Post([System.Web.Http.FromBody] OrderDTO newOrder)
        {
            if (newOrder == null)
                return BadRequest();

            return Ok(_orderManager.Save(newOrder));
        }

        /// <summary>
        /// The Put method will be use to update a order
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <param name="updateOrder">The updateOrder<see cref="OrderDTO"/></param>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [System.Web.Mvc.HttpPut]
        public System.Web.Http.IHttpActionResult Put([FromODataUri(Name = "key")] string id, [System.Web.Http.FromBody] OrderDTO updateOrder)
        {
            if (updateOrder == null || id == null)
                return BadRequest();

            return Ok(_orderManager.Update(Convert.ToInt32(id), updateOrder));
        }

        /// <summary>
        /// The Delete method will be use to delete a certain order
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="System.Web.Http.IHttpActionResult"/></returns>
        [System.Web.Mvc.HttpDelete]
        public System.Web.Http.IHttpActionResult Delete([FromODataUri(Name = "key")] string id)
        {
            if (id == null)
                return BadRequest();

            return Ok(_orderManager.Delete(Convert.ToInt32(id)));
        }
    }
}
