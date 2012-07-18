using System;

namespace FretLight
{
    /// <summary>
    ///  This class is intended to be used as a static class. It maintains the state of the 6 by 22 array that represents 
    ///  the LEDs on the guitar neck as well as on the GUI.
    ///  Author: Rodrigo Groppa
    ///  Date Formalized: 07/14/2012
    /// </summary>
    public static class LED
    {
        // This array represents the entire guitar fretboard, 0 is off, 1 is on
        public static byte[,] LArray;

        public const int STR = 6; // X
        public const int FRET = 22; // Y

        /// <summary>
        ///  Zeroes the LED.LArray
        /// </summary>
        public static void Start()
        {
            LArray = new byte[STR, FRET];
            clearArray();
        }

        /// <summary>
        ///  This method takes LArray and translates it into the format that the FretLight is expecting.
        ///  The format is convoluted compared to the simple 6 by 22 array.
        ///  Additionally, it prepares all 3 packets that need to be sent in order to control all the LEDs on the guitar
        /// </summary>
        public static Byte[,] producePacket()
        {
            Byte[,] packet = new Byte[3, 7];

            // These are the header values for each packet
            packet[0, STR] = 0x01;
            packet[1, STR] = 0x02;
            packet[2, STR] = 0x03;


            // x and y iterate over the array
            // byte and packet counters increment the cur values every 8 frets, and 48 frets respectively
            int x, y;
            int curPacket = 0;
            int curByte = 5;
            int byteCounter = 0;
            int packetCounter = 0;

            for (y = 0; y < FRET; y++)
            {
                for (x = 0; x < STR; x++)
                {

                    // LEDs are actually in reverse order, so 128 is the first led, 64 the second and so on
                    if (LArray[x, y] == 1)
                    {
                        packet[curPacket, curByte] += (Byte)Math.Pow(2, 7 - byteCounter);
                    }
                    byteCounter++;

                    // When we hit 8, switch to the next byte in the packet
                    if (byteCounter == 8)
                    {
                        byteCounter = 0;
                        curByte--;
                        packetCounter++;
                    }

                    // When we hit 6, we must move to the next packet
                    if (packetCounter == 6)
                    {
                        packetCounter = 0;
                        curByte = 5;
                        curPacket++;
                    }

                }
            }
            return packet;
        }

        /// <summary>
        ///  Zeroes the LED.LArray
        /// </summary>
        public static void clearArray()
        {
            Array.Clear(LArray, 0, LArray.Length);
        }

        /// <summary>
        ///  Helper method that forces the 2 values given to conform to the ranges of LED.LArray
        /// </summary>
        public static void clampLED(ref int[] point)
        {
            if (point[0] < 0)
                point[0] = 0;
            if (point[0] >= LED.STR)
                point[0] = LED.STR - 1;

            if (point[1] < 0)
                point[1] = 0;
            if (point[1] >= LED.FRET)
                point[1] = LED.FRET - 1;

        }

    } // Class LED
}
