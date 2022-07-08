using System;
using System.Windows.Forms;
using RDR2;
using RDR2.UI;
using RDR2.Native;
using RDR2.Math;
using System.Drawing;
using System.Text;
using System.Collections.Generic;


namespace RDRModTest
{
    public class Class1 : Script
    {
        bool enabled = true;
        bool use12h;
        string suffix = null;
        int timeHour = 00;
        int timeMinute = 00;
        RDR2.UI.ContainerElement timeContainer;
        RDR2.UI.TextElement timeText;
        String timeString;
        string debug_wrapW;
        string debug_scale;
        int pointX;
        int distanceFromRSide = 68; //default 68 for 12h clock. Use 43 for 24h
        public Class1()
        {
            KeyDown += OnKeyDown;
            Tick += OnTick;
            
            Interval = 1;



            //*****VARIABLES*****
            use12h = true;
            if (!use12h) distanceFromRSide = 43; //24h
            pointX = (int)RDR2.UI.Screen.Width - distanceFromRSide;


            timeText = new TextElement("00:00", new Point(0, 0), 0.24f, Color.WhiteSmoke, RDR2.UI.Alignment.Right, true, true);
            timeContainer = new RDR2.UI.ContainerElement(new Point(pointX, 2), new Size(distanceFromRSide, 20), Color.Transparent); //Size(w,h) 68 - 43
            timeContainer.Items.Add(timeText);
            timeText.Centered = true;
        }



        private void OnTick(object sender, EventArgs e)
        {
           //if (enabled)
          ///  {
                if(RDR2.UI.Hud.IsRadarVisible)
                {
                    timeHour = RDR2.World.CurrentDayTime.Hours;
                    timeMinute = RDR2.World.CurrentDayTime.Minutes;

                    if (use12h)
                    {


                        if (RDR2.World.CurrentDayTime.Hours > 12) // PM
                        {
                            timeHour -= 12;
                            suffix = " PM";
                        }
                        else suffix = " AM";
                    }

                    timeString = String.Format("{0:D2}:{1:D2}{2}", timeHour, timeMinute, suffix);

                //timeContainer.Items.Add(timeText);
                //timeText.Centered = true;

               timeText.Caption = timeString;
               

              
                timeContainer.Draw();
                }

          
               
            // }
            


                //HORSE SPEEDOMETER TEST
/*
            try
            {
                Vector3 mm = RDR2.Game.Player.Character.CurrentMount.Velocity;
                int vel = ((int)(mm.LengthSquared()));
                TextElement hmm = new TextElement(vel.ToString(), new Point(0, 0), 0.24f, Color.WhiteSmoke, RDR2.UI.Alignment.Right, true, true); ;

                hmm.Draw();
                
    
                
            }
            catch(Exception ex)
            {

            }
            */

               

            /*
            timeHour = RDR2.World.CurrentDayTime.Hours;
            timeMinute = RDR2.World.CurrentDayTime.Minutes;

            if (use12h)
            {
                

                if (RDR2.World.CurrentDayTime.Hours > 12) // PM
                {
                    timeHour -= 12;
                    suffix = " PM";
                }
                else suffix = " AM";
            }
           
            timeString = String.Format("{0:D2}:{1:D2}{2}", timeHour, timeMinute, suffix);

            //timeContainer.Items.Add(timeText);
            //timeText.Centered = true;
            timeText.Caption = timeString;
            timeContainer.Draw();

            */





            // timeText = new TextElement(timeString, new Point(0, 0), 0.24f, Color.White, RDR2.UI.Alignment.Right, true, true);
            // timeContainer = new RDR2.UI.ContainerElement(new Point(pointX, 0), new Size(distanceFromRSide, 20), Color.Red); //Size(w,h) 68 - 43
            //RectangleF a = new RectangleF(0, 0, 100, 200);
            //timeText.ScaledDraw(a.Size);
            // debug_wrapW = timeText.WrapWidth.ToString();
            //timeText.Alignment = Alignment.Right;
            // timeText.ScaledDraw(new SizeF(100 , 100));
            //  debug_scale = timeText.Scale.ToString();

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {

               // enabled = !enabled;

               
                if(enabled) Tick -= OnTick;
                else Tick += OnTick;
                enabled = !enabled;


                //debug code
                //RDR2.UI.Screen.ShowSubtitle(String.Format("Scaled Width: {0}, Width: {1}, Height: {2}, timeText_WrapWidth: {3}, timeText_scale: {4}", RDR2.UI.Screen.ScaledWidth, RDR2.UI.Screen.Width, RDR2.UI.Screen.Height, debug_wrapW, debug_scale));



            }
        }
    }
}
