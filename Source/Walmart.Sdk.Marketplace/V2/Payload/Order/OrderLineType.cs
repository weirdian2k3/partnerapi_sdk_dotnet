/*
Copyright (c) 2018-present, Walmart Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

//  ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 4.4.0.7
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Walmart.Sdk.Marketplace.V2.Payload.Order
{
    using System;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Collections.Generic;
    using Walmart.Sdk.Base.Primitive;

    [XmlTypeAttribute(Namespace = "http://walmart.com/mp/orders", TypeName = "chargesType")]
    [XmlRootAttribute("charges", Namespace = "http://walmart.com/mp/orders", IsNullable = false)]
    public class ChargesList : BasePayload, IEnumerable<ChargeType>
    {
        [XmlElement("charge")]
        public List<ChargeType> Charges { get; set; }

        public ChargesList()
        {
            Charges = new List<ChargeType>();
        }

        public ChargeType this[int index]
        {
            get { return Charges[index]; }
            set { Charges[index] = value; }
        }

        public IEnumerator<ChargeType> GetEnumerator()
        {
            return Charges.GetEnumerator();
        }

        public void Add(ChargeType item)
        {
            Charges.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    [XmlTypeAttribute(Namespace = "http://walmart.com/mp/orders", TypeName = "orderLineStatusesType")]
    [XmlRootAttribute("orderLineStatuses", Namespace = "http://walmart.com/mp/orders", IsNullable = false)]
    public class OrderLineStatuses : BasePayload, IEnumerable<OrderLineStatusType>
    {
        [XmlElement("orderLineStatus")]
        public List<OrderLineStatusType> LineStatuses { get; set; }

        public OrderLineStatuses()
        {
            LineStatuses = new List<OrderLineStatusType>();
        }

        public OrderLineStatusType this[int index]
        {
            get { return LineStatuses[index]; }
            set { LineStatuses[index] = value; }
        }

        public IEnumerator<OrderLineStatusType> GetEnumerator()
        {
            return LineStatuses.GetEnumerator();
        }

        public void Add(OrderLineStatusType item)
        {
            LineStatuses.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// Start of Orderline info and
    /// statuses Line status
    /// will have Price, status and refund sections
    /// Refund section will be
    /// populated only if we have refund history
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "4.4.0.7")]
    [Serializable]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(Namespace="http://walmart.com/mp/orders", TypeName="orderLineType")]
    [XmlRootAttribute("orderLine", Namespace = "http://walmart.com/mp/orders", IsNullable = false)]
    public class OrderLineType : BasePayload
    {
        [XmlElement("lineNumber")]
        public string LineNumber { get; set; }
        [XmlElement("item")]
        public ItemType Item { get; set; }

        [XmlElement("charges", IsNullable=false)]
        public ChargesList Charges { get; set; }

        [XmlElement("orderLineQuantity")]
        public QuantityType OrderLineQuantity { get; set; }
        [XmlElement("statusDate")]
        public System.DateTime StatusDate { get; set; }
        [XmlElement("orderLineStatuses")]
        public OrderLineStatuses OrderLineStatuses { get; set; }
        [XmlElement("refund")]
        public RefundType Refund { get; set; }
    
        /// <summary>
        /// OrderLineType class constructor
        /// </summary>
        public OrderLineType()
        {
            Refund = new RefundType();
            OrderLineStatuses = new OrderLineStatuses();
            OrderLineQuantity = new QuantityType();
            Charges = new ChargesList();
            Item = new ItemType();
        }
    }
}