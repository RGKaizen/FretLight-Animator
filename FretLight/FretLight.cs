using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Text;

/// <summary>
///  This project allows users to easily commnunicate and manipulate the LEDs found on the Optek FretLight Guitar.
///  The class FretLight handles the Main GUI as well as kicking off the whole shebang.
///  Author: Rodrigo Groppa
///  Date Formalized: 07/14/2012
///  
///  Class fields and methods attached directly to the GUI are given CamelCase
///  Local fields and methods not clearly attached are given lowerUpper case
///  
///  ToDo List:
///  Figure out how to save and load rule list
/// </summary>
namespace FretLight
{
    public partial class FretLight : Form
    {

        private int[] FretsTable = new int[22];
        private const int FrameMax = 10;

        private Boolean _GuitarComm = true;

        /// <summary>
        ///  Intializes the GUI, and sets up the FretsTable constant precise values
        /// </summary>
        public FretLight()
        {
            InitializeComponent();
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
        ///  Calls the Start methods for both the FretCommunicate and the LED classes.
        /// </summary>
        private void FretLight_Load(object sender, EventArgs e)
        {
            FretCommunicate.Start();
            LED.Start();
        }

        /// <summary>
        ///  Clears the LED Array, clears the LEDs on the Guitar, and closes USB Communications
        /// </summary>
        private void FretLight_FormClosed(object sender, EventArgs e)
        {
            LED.clearArray();
            FretCommunicate.SendPacket();
            FretCommunicate.CloseConnection();
        }

        /// <summary>
        ///  When the FretBoard is clicked, this method roggles the appropriate LED[x,y] value.
        ///  It mirrors these changes immediately on the guitar and on the freboard
        /// </summary>
        
        // Constants used in FretBoard_Click and FretBoard_Paint
        private const int FretYOffset = 8;
        private const int FretSize = 20;
        private void FretBoard_Click(object sender, EventArgs e)
        {
            // Current offsets using image, these values are subject to change if the image is changed.
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


            // Toggle value
            // clampedResponse stops OoB values from reaching the array, 
            // instead they are forced into the border values (21, 5, or 0 in all cases).
            int[] clampedResponse = new int[2];
            clampedResponse[0] = stringSelect;
            clampedResponse[1] = fretSelect;
            LED.clampLED(ref clampedResponse);
            if (LED.LArray[clampedResponse[0], clampedResponse[1]] == 1)
                LED.LArray[clampedResponse[0], clampedResponse[1]] = 0;
            else
                LED.LArray[clampedResponse[0], clampedResponse[1]] = 1;

            updateLED();
        }

        /// <summary>
        ///  Paints a red ellipse for each value in LED.LArray set to 1 at the proper location
        /// </summary>
        private void FretBoard_Paint(object sender, PaintEventArgs e)
        {
            int n, l;
            for (n = 0; n < LED.STR; n++)
            {
                for (l = 0; l < LED.FRET; l++)
                {
                    if (LED.LArray[n, l] == 1)
                    {
                        e.Graphics.FillEllipse(Brushes.Red, FretsTable[l], (n * FretSize + FretYOffset), 10, 10);
                    }
                }
            }
        }

        /// <summary>
        ///  This Method updates the LatencyLabel's text so we can see the current value, and sets that value
        ///  to the FrameTimer's Interval value
        /// </summary>
        private void Latency_Scroll(object sender, EventArgs e)
        {
            FrameTimer.Interval = LatencyBar.Value;
            LatencyLabel.Text = "Latency: " + FrameTimer.Interval.ToString();
        }

        /// <summary>
        /// Spawns a GUI that lets the user define a rule, then adds it to the list 
        /// </summary>
        private void addRule(object sender, EventArgs e)
        {
            // This approach technically creates a blank rule in the list, then changes its reference to
            // the rule returned from the RuleBuilderGUI
            using (var ruleForm = new RuleBuilderGUI())
            {
                ruleForm.ShowDialog();
                if (ruleForm.Rule != null)
                {
                    RulesListbox.Items.Add(new object());
                    RulesListbox.Items[RulesListbox.Items.Count - 1] = ruleForm.Rule;
                }
                updateLED();
            }
        }

        /// <summary>
        /// Removes the selected rule from the list
        /// </summary>
        private void removeRule(object sender, EventArgs e)
        {
            if (RulesListbox.SelectedIndex >= 0 && RulesListbox.SelectedIndex < RulesListbox.Items.Count)
            {
                RulesListbox.Items.Remove(RulesListbox.Items[RulesListbox.SelectedIndex]);
            }
        }

        /// <summary>
        /// Encapsulates the code to update the GUI and the Guitar LEDs
        /// </summary>
        private void updateLED()
        {
            FretBoard.Invalidate();

            if(_GuitarComm)
                FretCommunicate.SendPacket();
        }

        /// <summary>
        /// Each Tick causes all the rules to be applied to the GUI and the Guitar
        /// </summary>
        private Boolean _isPlaying = false;
        private int CurrentFrame = 0;
        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            CurrentFrameLabel.Text = "Frame: " + CurrentFrame.ToString();
            foreach (Rule curRule in RulesListbox.Items)
            {
                curRule.Apply(CurrentFrame);
            }
            updateLED();
            CurrentFrame = (CurrentFrame +1)%10;
        }

        /// <summary>
        /// Starts/Stops the animation
        /// </summary>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!_isPlaying)
            {
                FrameTimer.Enabled = true;
                _isPlaying = true;
                PlayButton.Text = "Stop";
            }
            else
            {
                FrameTimer.Enabled = false;
                _isPlaying = false;
                PlayButton.Text = "Play";
            }
            

        }

        /// <summary>
        /// Lets you modify the selected rule
        /// </summary>
        private void RulesListbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.RulesListbox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                Rule selectedRule = (Rule)RulesListbox.Items[index];
                using (var ruleForm = new RuleBuilderGUI(selectedRule))
                {                   
                    ruleForm.ShowDialog();
                    RulesListbox.Items[index] = ruleForm.Rule;
                }
            }

        }

        /// <summary>
        /// Saves rules to a file
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Rule[]));

                // Convert listbox content to array for serialization
                Rule[] ruleArray = new Rule[RulesListbox.Items.Count];
                int counter = 0;
                foreach (Rule n in RulesListbox.Items)
                {
                    ruleArray[counter] = n;
                    counter++;
                }
                

                // this process will open a save file dialog and give the option to choose
                // file location, name, and ext.  then when you press save it will save it
                FileDialog oDialog = new SaveFileDialog();

                oDialog.InitialDirectory = Environment.CurrentDirectory;
                oDialog.DefaultExt = "xml";
                oDialog.FileName = "Rules";
                oDialog.RestoreDirectory = true;

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@oDialog.FileName))
                    {
                        serializer.Serialize(file, ruleArray);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("" + exp);
            }
        }

        /// <summary>
        /// Loads rules from a file
        /// </summary>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Rule[]));

                FileDialog oDialog = new OpenFileDialog();
                oDialog.InitialDirectory = Environment.CurrentDirectory;
                oDialog.DefaultExt = "xml";
                oDialog.FileName = "Rules.xml";
                oDialog.RestoreDirectory = true;

                if (oDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamReader file = new System.IO.StreamReader(@oDialog.FileName))
                    {
                        Rule[] ruleArray = (Rule[])deserializer.Deserialize(file);
                        foreach(Rule n in ruleArray)
                        {
                            RulesListbox.Items.Add(n);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("" + exp);
            }


        }

        /// <summary>
        /// Disables/Enables Guitar communications
        /// </summary>
        private void GuitarCommFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (_GuitarComm)
                _GuitarComm = false;
            else
                _GuitarComm = true;
        }

        /// <summary>
        /// Clears LED Array, Fretboard and guitar
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            LED.clearArray();
            updateLED();
        }


    }
  
}
