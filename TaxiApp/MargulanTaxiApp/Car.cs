using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargulanTaxiApp
{
    public class Car
    {

        // constructor with arguments
        public Car(string carName, DateTime startTime, DateTime endTime)
        {
            this.carName = carName;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        // mock constructor
        public Car()
        {

        }



        // get car name method
        public string getCarName()
        {
            return this.carName;
        }

        // get car start time method
        public DateTime getStartTime()
        {
            return this.startTime;
        }

        // get car end time
        public DateTime getEndTime()
        {
            return this.endTime;
        }

        // set car start time
        public void setStartTime(DateTime time)
        {
            this.startTime = time;
        }

        // car fields
        private string carName;
        private DateTime startTime;
        private DateTime endTime;
    }
}
