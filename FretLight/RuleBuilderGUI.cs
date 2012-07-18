using System;
using System.Drawing;
using System.Windows.Forms;

namespace FretLight
{

    /// <summary>
    ///  This GUI allows the user to define new Rules, which are promptly added to FretLight GUI's RuleList
    ///  Author: Rodrigo Groppa
    ///  Date Formalized: 07/14/2012
    /// </summary>
    public partial class RuleBuilderGUI : Form
    {

        private int[] FretsTable = new int[22];
        private int[] StartPoint = new int[2];
        private int[] EndPoint = new int[2];
        private Boolean _isStart = true;
        private string RuleType;

        // This rule is exposed so that the parent GUI can access it
        public Rule Rule { get; set; }


        /// <summary>
        ///  Intializes the GUI, sets up the FretsTable constant precise values, and creates a new Basic Rule
        /// </summary>
        public RuleBuilderGUI()
        {
            InitializeComponent();
            this.NameBox.Text = "Basic Rule";
            RuleType = "Basic";
            RuleTypeBox.Text = RuleType;
            FretsTable[0] = 8;
            FretsTable[1] = 45;
            FretsTable[2] = 90;
            FretsTable[3] = 145;
            FretsTable[4] = 200;
            FretsTable[5] = 250;
            FretsTable[6] = 300;
            FretsTable[7] = 350;
            FretsTable[8] = 400;
            FretsTable[9] = 448;
            FretsTable[10] = 492;
            FretsTable[11] = 537;
            FretsTable[12] = 576;
            FretsTable[13] = 620;
            FretsTable[14] = 660;
            FretsTable[15] = 695;
            FretsTable[16] = 735;
            FretsTable[17] = 770;
            FretsTable[18] = 805;
            FretsTable[19] = 835;
            FretsTable[20] = 870;
            FretsTable[21] = 900;        
        }

        /// <summary>
        ///  If a rule is selected from the parent GUI Fretlight, then this constructor is called instead to fill in the fields of the rule
        /// </summary>
        public RuleBuilderGUI(Rule selectedRule) : this()
        {
            Rule = selectedRule;

            // Fill boxes
            NameBox.Text = selectedRule.RuleName;
            StartFrameField.Text = selectedRule.StartFrame.ToString();
            EndFrameField.Text = selectedRule.EndFrame.ToString();
            StartPointField.Text = selectedRule.StartPoint[0] + ", " + selectedRule.StartPoint[1];
            EndPointField.Text = selectedRule.EndPoint[0] + ", " + selectedRule.EndPoint[1];
            RuleTypeBox.Text = selectedRule.RuleType;

            // Arrange LED
            this.StartPoint[0] = selectedRule.StartPoint[0];
            this.StartPoint[1] = selectedRule.StartPoint[1];
            this.EndPoint[0] = selectedRule.EndPoint[0];
            this.EndPoint[1] = selectedRule.EndPoint[1];
            this.FretBoard.Invalidate();
            
        }

        private const int FretYOffset = 8;
        private const int FretSize = 20;
        /// <summary>
        ///  Depending on the Mode, it either alternates between selecting the startpoint and the endpoint, or
        ///  it lets the user fill in any value they please
        /// </summary>
        private void FretBoard_Click(object sender, EventArgs e)
        {
            // Image offsets 8,12 (x,y)
            // Box sizes 35, 20 (x,y)
            Point mouse = System.Windows.Forms.Control.MousePosition;
            mouse = FretBoard.PointToClient(mouse);
            int x = mouse.X;
            int y = mouse.Y;

            // If the x pos is within fretSize distance of one of the frets, return that fret, else return
            int fretSelect = -1;
            int fretFind = 0;
            while (fretSelect == -1 && fretFind < LED.FRET)
            {
                if (Math.Abs(FretsTable[fretFind] - x) < FretSize)
                    fretSelect = fretFind;

                fretFind++;
            }
            // Didn't click on a fret, leave method before we hit an array OoB error
            if (fretSelect == -1) return;

            // Simple Y-offset finder
            int stringSelect = (y - FretYOffset) / 20;
            if (RuleType.Equals("Basic")) // 2 points only
            {
                
                if (_isStart == true)
                {
                    StartPoint[0] = stringSelect;
                    StartPoint[1] = fretSelect;
                    LED.clampLED(ref StartPoint);
                    StartPointField.Text = StartPoint[0] + ", " + StartPoint[1];
                    _isStart = false;
                }
                else if (_isStart == false)
                {
                    EndPoint[0] = stringSelect;
                    EndPoint[1] = fretSelect;
                    LED.clampLED(ref EndPoint);
                    EndPointField.Text = EndPoint[0] + ", " + EndPoint[1];
                    _isStart = true;
                }
            }
            else if (RuleType.Equals("Conway")) // Toggle any value
            {
                int[] clampedResponse = new int[2];
                clampedResponse[0] = stringSelect;
                clampedResponse[1] = fretSelect;
                LED.clampLED(ref clampedResponse);
                if (LED.LArray[clampedResponse[0], clampedResponse[1]] == 1)
                    LED.LArray[clampedResponse[0], clampedResponse[1]] = 0;
                else
                    LED.LArray[clampedResponse[0], clampedResponse[1]] = 1;
            }

            this.FretBoard.Invalidate();
        }

        /// <summary>
        ///  Has two modes, one fills in only the starting point and ending point
        ///  The other draws a red circle for any values set in LED.LArray
        /// </summary>
        private void FretBoard_Paint(object sender, PaintEventArgs e)
        {
            if (RuleType.Equals("Basic")) // 2 points only
            {
                if (StartPoint[0] == EndPoint[0] && StartPoint[1] == EndPoint[1])
                    e.Graphics.FillEllipse(Brushes.Purple, FretsTable[ StartPoint[1] ], (StartPoint[0] * 20 + FretYOffset), 10, 10);
                else
                {
                    e.Graphics.FillEllipse(Brushes.Red, FretsTable[ StartPoint[1] ], (StartPoint[0] * 20 + FretYOffset), 10, 10);
                    e.Graphics.FillEllipse(Brushes.Blue, FretsTable[ EndPoint[1] ], (EndPoint[0] * 20 + FretYOffset), 10, 10);
                }
            }
            else if(RuleType.Equals("Conway")) // Paint all
            {
                int n, l;
                for (n = 0; n < LED.STR; n++)
                {
                    for (l = 0; l < LED.FRET; l++)
                    {
                        if (LED.LArray[n, l] == 1)
                        {
                            e.Graphics.FillEllipse(Brushes.Red, FretsTable[l], (n * 20 + FretYOffset), 10, 10);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  Builds the Rule according to the fields set, has default values if the fields are empty or invalid
        /// </summary>
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            int result;

            if (RuleType.Equals("Basic"))
                Rule = new BasicRule();
            else if (RuleType.Equals("Conway"))
                Rule = new Conway();

            if(! int.TryParse(StartFrameField.Text, out result)){
                result = 0;
            }
            Rule.StartFrame = result;

            if (!int.TryParse(EndFrameField.Text, out result))
            {
                result = 0;
            }

            Rule.EndFrame = result;

            Rule.StartPoint[0] = this.StartPoint[0];
            Rule.StartPoint[1] = this.StartPoint[1];

            Rule.EndPoint[0] = this.EndPoint[0];
            Rule.EndPoint[1] = this.EndPoint[1];
            Rule.RuleName = NameBox.Text;
            this.Close();
        }

        /// <summary>
        ///  Sets the Rule Type to the value from the RuleSelectBox
        /// </summary>
        private void RuleTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RuleType = RuleTypeBox.SelectedItem.ToString();
        }

    }
}
