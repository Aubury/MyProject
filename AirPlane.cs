using System;

namespace MyProject
{
    class AirPlane
    {

        public int Capacity { get; private set; }
        public bool AutoPilotOn { get; set; }

        /// <summary>
        /// Fuel consuption. kg/km
        /// </summary>
        public float Consuption { get; private set; }

        public int Altitude { get; private set; }


        public static decimal TicketPrice { get; set; }
        public static int MinAltitudeAuto { get; set; }
        public static int MaxAltitudeAuto { get; set; }

        private int _altitudeIncrement;
        static AirPlane()
        {
            MinAltitudeAuto=2000;
            MaxAltitudeAuto = 10000;
        }
        public AirPlane(int capacity, float consuption, int altitudeIncrement)
        {
            Altitude = 0;
            AutoPilotOn = false;
            Capacity = capacity;
            Consuption = consuption;
            _altitudeIncrement = altitudeIncrement;
        }

        public int Climb(int increment)
        {
            if (!AutoPilotOn) return Altitude += increment;

            if (Altitude + increment < MaxAltitudeAuto)
            {
                return Altitude += increment;
            }

            return Altitude = MaxAltitudeAuto;
        }

        public int Down(int increment)
        {
            if (AutoPilotOn)
            {
                if (Altitude - increment > MinAltitudeAuto)
                {
                    return Altitude -= increment;
                }
                if (Altitude < MinAltitudeAuto) return Altitude;
                //return Altitude = MinAltitudeAuto;
            }

            if (Altitude - increment < 0) return Altitude = 0;
            return Altitude -= increment;
        }
        public int Forsage(int increment)
        {
            if (increment * 2 < MaxAltitudeAuto) return Altitude = increment * 2;
            else return Altitude = MaxAltitudeAuto;
        }
      //static void Switch(string s)
      //  {
      //      switch(s)
      //      {
      //          case "A":
      //              Climb(int increment);break;
      //      }

      //  }
        //public int Forsage(int increment)
        //{
        //    if(increment*2 < MaxAltitudeAuto) return Altitude=increment * 2;
        //    if (increment * 2 > MaxAltitudeAuto) return Altitude = MaxAltitudeAuto;
        //} 
        public void SetAltitude(int targetAlitude)
        {
            int speed = 100;

            do
              {
                Climb(speed);
                if (Altitude > MinAltitudeAuto) AutoPilotOn = true;
                if (AutoPilotOn == true) Altitude = MaxAltitudeAuto;
                Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
              }
            while (Altitude <= targetAlitude);

           do
               {
                  Down(speed);
                  if (Altitude < MinAltitudeAuto) AutoPilotOn = false;
                  Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                   }
            while (Altitude>0);

               }
             }
       
       }

