﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BritehouseMongo.DomainLogic
{
    public class OrdersMod
    {



        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("Row ID")]
        public int RowID { get; set; }

        [BsonElement("Order ID")]
        public string OrderID { get; set; }

        [BsonElement("Order Date")]
        public string OrderDate { get; set; }

        [BsonElement("Ship Date")]
        public string ShipDate { get; set; }

        [BsonElement("Ship Mode")]
        public string ShipMode { get; set; }

        [BsonElement("Customer ID")]
        public string CustomerID { get; set; }

        [BsonElement("Segment")]
        public string Segment { get; set; }

        [BsonElement("Postal Code")]
        public string PostalCode { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("State")]
        public string State { get; set; }

        [BsonElement("Country")]
        public string Country { get; set; }

        [BsonElement("Region")]
        public string Region { get; set; }

        [BsonElement("Market")]
        public string Market { get; set; }

        [BsonElement("Product ID")]
        public string ProductID { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Sub-Category")]
        public string SubCategory { get; set; }

        [BsonElement("Product Name")]
        public string ProductName { get; set; }

        [BsonElement("Sales")]
        public string Sales { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        [BsonElement("Discount")]
        public int Discount { get; set; }

        [BsonElement("Profit")]
        public string Profit { get; set; }

        [BsonElement("Shipping Cost")]
        public double ShippingCost { get; set; }

        [BsonElement("Order Priority")]
        public string OrderPriority { get; set; }



    }
}