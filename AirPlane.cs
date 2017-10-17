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
            if (increment * 2 > MaxAltitudeAuto) AutoPilotOn = false;
                return Altitude = increment * 2;
           
        }
      public void Switch()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter parameter: ");
                Console.WriteLine("If you want to lift the plane, press 'C'");
                Console.WriteLine("If you want to enable forsage, press 'F'");
                Console.WriteLine("If you want to enable autopilot, press 'A'");
                Console.WriteLine();
                string commandName = Console.ReadLine();

                switch (commandName)
                {
                    case "A":
                        Console.WriteLine("Enable, press '1'\nSwitch off, press '0'.");
                        int autopilot = Int32.Parse(Console.ReadLine());

                        if (autopilot == 1 && Altitude > MinAltitudeAuto || autopilot == 1 && Altitude < MaxAltitudeAuto)  
                        { AutoPilotOn = true; }

                        if (autopilot == 1 && Altitude < MinAltitudeAuto || autopilot == 1 && Altitude > MaxAltitudeAuto)
                        { Console.WriteLine("Sorry can not enable autopilot");AutoPilotOn = false; }

                        if(autopilot == 0){ AutoPilotOn = false; }
                        
                        Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                        break;

                    case "C":
                        Console.WriteLine("Enter altitude settings: ");
                        int height = Int32.Parse(Console.ReadLine());

                        Altitude = height;

                        if (Altitude < MinAltitudeAuto || Altitude > MaxAltitudeAuto  ) AutoPilotOn = false;
                        Console.WriteLine("Altitude = {0}, Autopilot = {1}",Altitude, AutoPilotOn);
                        break;

                    case "F":
                        Forsage(Altitude);
                        if (Altitude < MinAltitudeAuto || Altitude > MaxAltitudeAuto) AutoPilotOn = false;
                        Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                        break;
                }

            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
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

