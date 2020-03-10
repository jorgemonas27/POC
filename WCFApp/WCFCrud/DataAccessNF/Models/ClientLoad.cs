namespace DataAccessNF.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ClientLoad" />
    /// </summary>
    public class ClientLoad
    {
        /// <summary>
        /// Gets or sets the IdLoad
        /// </summary>
        public virtual int IdLoad { get; set; }

        /// <summary>
        /// Gets or sets Trucks for loads
        /// </summary>
        public virtual string TruckLoad { get; set; }

        /// <summary>
        /// Gets or sets the Shipments
        /// </summary>
        public virtual IList<ClientShipment> Shipments { get; set; }

        /// <summary>
        /// Gets or sets the stops for the diferent loads
        /// </summary>
        public virtual string StopsLoad { get; set; }

        /// <summary>
        /// Gets or sets the TotalDistanceLoad
        /// </summary>
        public virtual int TotalDistanceLoad { get; set; }

        /// <summary>
        /// Gets or sets the TotalCostLoad
        /// </summary>
        public virtual int? TotalCostLoad { get; set; }

        /// <summary>
        /// Gets or sets the QuantityShipmentsLoad
        /// </summary>
        public virtual int QuantityShipmentsLoad { get; set; }
    }
}
