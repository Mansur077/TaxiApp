using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargulanTaxiApp
{
    public class Order
    {

        // consturctor with arguments
        public Order(string clientName, string number, string street,
            string house, DateTime startTime, DateTime endTime)
        {
            this.clientName = clientName;
            this.number = number;
            this.street = street;
            this.house = house;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        // mock constructor
        public Order()
        {
        }

        // get client name method
        public string getClientName()
        {
            return this.clientName;
        }

        // get client's number method
        public string getNumber()
        {
            return this.number;
        }

        // get client's street method
        public string getStreet()
        {
            return this.street;
        }

        // get client's house method
        public string getHouse()
        {
            return this.house;
        }

        // get client's time for taxi method
        public DateTime getStartTime()
        {
            return this.startTime;
        }

        // get client's duration
        public DateTime getEndTime()
        {
            return this.endTime;
        }


        // order fields
        private string clientName;
        private string number;
        private string street;
        private string house;
        private DateTime startTime;
        private DateTime endTime;
    }
}
