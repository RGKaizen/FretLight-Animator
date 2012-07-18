using System;
using System.Xml.Serialization;

namespace FretLight
{
    /// <summary>
    ///  This Class holds the parent Rule class, as well as any custom rules created
    ///  A rule is an object that manipulates the LED LArray in some way
    ///  I've created a basic template, and all new rules are expected to inherit the parent rule
    ///  as well as override the Apply method
    ///  Author: Rodrigo Groppa
    ///  Date Formalized: 07/14/2012
    /// </summary>
    

    // These lines allow serializiation, new subclasses should also be added as follows
    [XmlInclude(typeof(BasicRule))]
    [XmlInclude(typeof(Conway))]

    public abstract class Rule
    {
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public int[] StartPoint { get; set; } //2
        public int[] EndPoint { get; set; } //2
        public string RuleName { get; set; }
        public string RuleType { get; set; }

        // Is Called by all derived classes
        public Rule()
        {
            StartFrame = 0;
            EndFrame = 0;
            StartPoint = new int[2] { 0, 0 };
            EndPoint = new int[2] { 0, 0 };
            RuleName = "Joker";
        }

        // This method is where the magic should happen
        public virtual Boolean Apply(int CurrentFrame)
        {
            return true;
        }

        public override string ToString()
        {
            return this.RuleName;
        }
    }

    /// <summary>
    ///  The Basic rule attempts to move from the starting point to the ending point
    ///  during the frames that its activate. Its a rough draft for more intersting
    ///  movement patterns like sine waves, zigzags, bouncing and so on.
    /// </summary>
    public class BasicRule : Rule
    {
        int[] newPoint = new int[2];

        public BasicRule()
        {
            RuleType = "Basic";
        }

        // Applies its rule directly to LED.LArray
        // Tries to get start point to reach endpoint by using a temporary newPoint each time
        public override bool Apply(int CurrentFrame)
        {

            if (CurrentFrame == 0)
            {
                newPoint[0] = StartPoint[0];
                newPoint[1] = StartPoint[1];
            }
            else if (CurrentFrame <= EndFrame && CurrentFrame > StartFrame)
            {

                if (EndPoint[0] - newPoint[0] > 0)
                    newPoint[0] = newPoint[0] + 1;
                if (EndPoint[0] - newPoint[0] < 0)
                    newPoint[0] = newPoint[0] - 1;
                else { }


                if (EndPoint[1] - newPoint[1] > 0)
                    newPoint[1] = newPoint[1] + 1;
                if (EndPoint[1] - newPoint[1] < 0)
                    newPoint[1] = newPoint[1] - 1;
                else { }

                LED.clampLED(ref newPoint);
                LED.LArray[newPoint[0], newPoint[1]] = 1;
            }

            return true;
        }
    }

    /// <summary>
    ///  The rule implements Conway's Game of Life ( http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life )
    ///  It applies wraparound behavior for the edges, thereby simulating the game in rectangular Ellipsoid
    /// </summary>
    public class Conway : Rule
    {
        // Buffer Array
        private byte[,] TempArray;

        public Conway()
        {
            RuleType = "Conway";
            TempArray = new byte[LED.STR, LED.FRET];
            Array.Clear(TempArray, 0, TempArray.Length);
        }
        
        // Where the magic happens~!
        public override Boolean Apply(int CurrentFrame)
        {
            int x;
            int y;
            for (x = 0; x < LED.STR; x++)
            {
                for (y = 0; y < LED.FRET; y++)
                {
                    int count = NeighborCount(x, y);

                    if (LED.LArray[x, y] == 1)
                    {
                        if (count <= 1)      // (0-1) neighbors dies
                            this.TempArray[x, y] = 0;
                        else if (count <= 3) // (2-3) neighbors lives
                            this.TempArray[x, y] = 1;
                        else                // (4-8) neighbors dies
                            this.TempArray[x, y] = 0;

                    }
                    else
                    {
                        if (count == 3)      // dead cell with 3 becomes alive
                            this.TempArray[x, y] = 1;
                    }
                }
            }
            Array.Copy(this.TempArray, LED.LArray, LED.STR * LED.FRET);
            return true;
        }

        // Returns the number of neighbors to a given x,y cell. 
        // Wraps around horizontally and vertically
        public int NeighborCount(int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int ad = WrapAround(x + i, 0);
                    int ab = WrapAround(y + j, 1);

                    if (LED.LArray[ad, ab] == 1)
                        count = count + 1;
                }
            }
            // Remove extra count for living cells
            if (LED.LArray[x, y] == 1)
                count = count - 1;
            return count;
        }

        // Wraps either x or y around its length
        public int WrapAround(int val, int type)
        {
            // x
            if (type == 0)
            {
                if (val < 0)
                    return LED.STR - 1;
                else if (val >= LED.STR)
                    return 0;
            }

            // y
            if (type == 1)
            {
                if (val < 0)
                    return LED.FRET - 1;
                else if (val >= LED.FRET)
                    return 0;
            }

            return val;
        }
    }
}
