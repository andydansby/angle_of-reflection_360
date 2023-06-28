using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Angle_of_Reflection
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        //works best from -180 to +180
        public double angleReflect1(int incidenceAngle, int surfaceAngle)
        {//https://observablehq.com/@harrystevens/geometric-anglereflect
            double angle = surfaceAngle * 2.0 - incidenceAngle;
            return angle >= 360.0 ? angle - 360.0 : angle < 0.0 ? angle + 360.0 : angle;
        }

        //works best from -180 to +180
        public double angleReflect2(int incidenceAngle, int surfaceAngle)
        {//long version of angleReflect1
            double a = surfaceAngle * 2.0 - incidenceAngle;
            if (a < 0.0)
            {
                return a + 360.0;
            }
            if (a >= 360.0)
            {
                return a - 360.0;
            }
            else
            {
                return a;
            }

        }

        //wrong numbers?  OBSOLETE?
        public double angleReflect3(int incidenceAngle, int surfaceAngle)
        {
            return (surfaceAngle - incidenceAngle) + surfaceAngle;
        }

        //wrong numbers?  OBSOLETE?
        public double angleReflect4(int incidenceAngle, int surfaceAngle)
        {
            return surfaceAngle - (incidenceAngle - surfaceAngle);
        }

        //wrong numbers?  OBSOLETE?
        public double angleReflect5(int incidenceAngle, int surfaceAngle)
        {
            double angle = surfaceAngle - (incidenceAngle * 2);
            return angle;
        }

        //good
        public double angleReflect360(double incidenceAngle, double surfaceAngle)
        {
            double returnAngle = 0;
            double oppositeAngle = 0;
            double angle2 = 0;
            double angleDifference = 0;

            angleDifference = Math.Abs(incidenceAngle - surfaceAngle);

            //first calculate opposite angle
            if (surfaceAngle < 180)
            {
                oppositeAngle = (180 + surfaceAngle) + 0;
            }
            if (surfaceAngle > 180)
            {
                oppositeAngle = (surfaceAngle - 180) + 360;//good
            }
            if (oppositeAngle >= 360)
            {
                oppositeAngle -= 360;
            }
            //opposite angle calculated
            //good

            if (surfaceAngle > 180)
            {//swap surface and opposite angles
                double temp = surfaceAngle;
                surfaceAngle = oppositeAngle;
                oppositeAngle = temp;
            }



            angle2 = Math.Abs(surfaceAngle - incidenceAngle);
            if (angle2 <= 180)
            {
                angle2 = Math.Abs(surfaceAngle - incidenceAngle);


                //returnAngle = oppositeAngle - angle2;
                //returnAngle = 9999;

                angle2 = (180 - incidenceAngle) + (oppositeAngle + surfaceAngle);

                returnAngle = angle2 % 360.0;

                if (returnAngle < 0)
                    returnAngle += 360;

            }



            if (angle2 > 180)
            {
                angle2 = Math.Abs(surfaceAngle - incidenceAngle);
                //returnAngle = angle2;

                
                //angle2 = (360 - incidenceAngle) - (oppositeAngle);// starts fail at 20,230
                angle2 = (360 - incidenceAngle) + (oppositeAngle + surfaceAngle);
                //returnAngle = (360 - incidenceAngle) + (oppositeAngle);
                //returnAngle = (360 - incidenceAngle);

                //returnAngle = Math.DivRem(returnAngle, 360);//should be the same as fmod

                //double temp;
                returnAngle = angle2 % 360.0;

                if (returnAngle < 0)
                    returnAngle += 360;

            }



            if (incidenceAngle == surfaceAngle)
            {
                returnAngle = surfaceAngle;
            }
            if (incidenceAngle == oppositeAngle)
            {
                returnAngle = oppositeAngle;
            }


            return returnAngle;
        }

        public double angleReflect360_2(double incidenceAngle, double surfaceAngle)
        {
            double normal = 90;
            double outgoing = 0;
            double difference = 0;

            //find normal angle is always 90 + surface angle
            normal = surfaceAngle + 90.0;

            if (normal > 360)
            {//if you exceed to angle over 360
                normal -= 360;
            }
            //normal is OK


            //outgoing = 
            outgoing = 2 * normal - 180 - incidenceAngle;
            if (outgoing > 360)
            {//if you exceed to angle over 360
                outgoing -= 360;
            }
            if (outgoing < 0)
            {//if you exceed to angle over 360
                outgoing += 360;
            }

            // return normal;
            //return difference;
            return outgoing;
        }


        public double angleReflect360_3(double incidenceAngle, double surfaceAngle)
        {
            double surfaceNormal = 90;
            double reflectionAngle = 0;
            double difference = 0;
            double oppositeAngle = 0;

            //first calculate opposite angle
            if (surfaceAngle < 180)
            {
                oppositeAngle = (180 + surfaceAngle) + 0;
            }
            if (surfaceAngle > 180)
            {
                oppositeAngle = (surfaceAngle - 180) + 360;//good
            }
            if (oppositeAngle >= 360)
            {
                oppositeAngle -= 360;
            }

            //find normal angle is always 90 + surface angle
            surfaceNormal = surfaceAngle + 90.0;
            if (surfaceNormal > 360)
            {//if you exceed to angle over 360
                surfaceNormal -= 360;
            }
            //normal is good

            difference = surfaceNormal - incidenceAngle;
            //difference = Math.Abs ((180.0 + incidenceAngle) - normal);
            /*if (difference > 360)
            {//if you exceed to angle over 360
                difference -= 360;
            }*/

            reflectionAngle = surfaceNormal + difference;

            if (reflectionAngle >= 360)
            {//if you exceed to angle over 360
                reflectionAngle -= 360;
            }
            if (reflectionAngle < 0)
            {//if you exceed to angle over 360
                reflectionAngle += 360;
            }

            if (incidenceAngle == surfaceAngle)
            {
                reflectionAngle = surfaceAngle;
            }
            if (incidenceAngle == oppositeAngle)
            {
                reflectionAngle = oppositeAngle;
            }

            return reflectionAngle;
        }




        //attempt tp work in Radians
        public double angleReflect8(int incidenceAngle, int surfaceAngle)
        {
            double incidenceRAD = incidenceAngle * Math.PI / 180;
            double surfaceRAD = surfaceAngle * Math.PI / 180;

            double a = surfaceRAD * 2.0 - incidenceRAD;
            double b = 0;

            if (a < 0.0)
            {
                b = a + Math.PI;
            }
            if (a > 0.0)
            {
                b = a - Math.PI;
            }



            if (b > 0)
            {
                //b = b * (180 / Math.PI);
            }


            //test surface @ 270 = 6.28
            if (b < 0)
            {
                //b = 999;
                //b = incidenceRAD - b % 360;
                //b =  b % 360;
                //b = (Math.PI - b) % 360;
                b = b + 3.14;
            }


            if (b > 6.28)
            {
                b = b % 3.14;
            }


            b = b * (180 / Math.PI);

            return b;
        }

        public int oppositeAngleCalc1(int surfaceAngle)
        {
            int returnAngle = 0;
            if (surfaceAngle < 180)
            {
                returnAngle = (180 + surfaceAngle) + 0;
            }
            if (surfaceAngle > 180)
            {
                //returnAngle = (180 - surfaceAngle) + 360;//no quite good
                returnAngle = (surfaceAngle - 180) + 360;//good
            }

            if (returnAngle >= 360)
            {
                returnAngle -= 360;
            }

            return returnAngle;
        }

        public int surfaceNormal(int surfaceAngle)
        {
            int returnNormal = 0;
            if (surfaceAngle <= 360)
            {
                returnNormal = surfaceAngle + 90;
            }
            if (returnNormal >= 360)
            {
                returnNormal -= 360;
            }
            return returnNormal;
        }

        public int incidenceDegrees(int incidenceAngle, int surfaceAngle)
        {//working on
            int surfaceNormal = 0;
            int returnAngle = 0;
            int incidenceDiff = 0;

            //first calculate surface normal
            if (surfaceAngle <= 360)
            {
                surfaceNormal = surfaceAngle + 90;
            }
            //Surface Normal is now 90 degrees from Surface Angle
            if (surfaceNormal >= 360)
            {
                surfaceNormal -= 360;
                //keep in range
            }
            
            incidenceDiff = incidenceAngle - surfaceAngle;

            //if a positive value
            if (incidenceDiff > 0)
            {
                returnAngle = 180 - incidenceDiff;
            }

            //if a negative value
            /*if (incidenceDiff < 0)
            {
                //temp
                returnAngle = 360 - incidenceDiff;
            }*/


            //if the same value, bounce back, edge case
            if (incidenceDiff == 0 || incidenceDiff == 180)
            {
                returnAngle = incidenceAngle;
            }


            return returnAngle;
        }

        /// <summary>
        /// 0 to +360
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {//ray incidence
            numericUpDown1.Value = (int)trackBar1.Value;

            int incidence = trackBar1.Value;
            int surface = trackBar2.Value;

            double answer = angleReflect360(incidence, surface);
            //double answer8 = angleReflect8(incidence, surface);
            double answer7RAD = Math.PI * answer / 180.0;
            double answer8 = angleReflect360_3(incidence, surface);

            double OppAngle = oppositeAngleCalc1(surface);
            double SurfNorm = surfaceNormal(surface);
            int incidenceDifference = incidenceDegrees(incidence, surface);
            double answerOppAngle = oppositeAngleCalc1 ((int)answer);

            oppositeTxt.Text = OppAngle.ToString();
            surfaceTxt.Text = SurfNorm.ToString();
            Answer7Text.Text = answer.ToString();
            Answer7RADText.Text = answer7RAD.ToString();
            Answer8Text.Text = answer8.ToString();

            answerOpposite.Text = answerOppAngle.ToString();

            double toRadians = Math.PI * trackBar1.Value / 180.0;
            ray_radian_textbox.Text = toRadians.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;

            int incidence = trackBar1.Value;
            int surface = trackBar2.Value;

            double answer = angleReflect360(incidence, surface);//double answer8 = angleReflect8(incidence, surface);            
            double answer7RAD = Math.PI * answer / 180.0;
            double answer8 = angleReflect360_3(incidence, surface);
            double OppAngle = oppositeAngleCalc1(surface);
            double SurfNorm = surfaceNormal(surface);
            int incidenceDifference = incidenceDegrees(incidence, surface);
            double answerOppAngle = oppositeAngleCalc1((int)answer);            

            oppositeTxt.Text = OppAngle.ToString();
            surfaceTxt.Text = SurfNorm.ToString();
            Answer7Text.Text = answer.ToString();
            Answer7RADText.Text = answer7RAD.ToString();

            Answer8Text.Text = answer8.ToString();
            answerOpposite.Text = answerOppAngle.ToString();

            double toRadians = Math.PI * (double)numericUpDown1.Value / 180.0;
            ray_radian_textbox.Text = toRadians.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //surface angle
            numericUpDown2.Value = (int)trackBar2.Value;

            int incidence = trackBar1.Value;
            int surface = trackBar2.Value;

            double answer = angleReflect360(incidence, surface);//double answer8 = angleReflect8(incidence, surface);
            double answer7RAD = Math.PI * answer / 180.0;
            double answer8 = angleReflect360_3(incidence, surface);
            double OppAngle = oppositeAngleCalc1(surface);
            double SurfNorm = surfaceNormal(surface);
            int incidenceDifference = incidenceDegrees(incidence, surface);
            double answerOppAngle = oppositeAngleCalc1((int)answer);

            oppositeTxt.Text = OppAngle.ToString();
            surfaceTxt.Text = SurfNorm.ToString();
            Answer7Text.Text = answer.ToString();
            Answer7RADText.Text = answer7RAD.ToString();
            Answer8Text.Text = answer8.ToString();

            answerOpposite.Text = answerOppAngle.ToString();

            //surface_radian_textbox.Text = answer7RAD.ToString();
            double toRadians = Math.PI * trackBar2.Value / 180.0;
            surface_radian_textbox.Text = toRadians.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2.Value = (int)numericUpDown2.Value;

            int incidence = trackBar1.Value;
            int surface = trackBar2.Value;

            double answer = angleReflect360(incidence, surface);//double answer8 = angleReflect8(incidence, surface);
            double answer7RAD = Math.PI * answer / 180.0;

            double answer8 = angleReflect360_3(incidence, surface);

            double OppAngle = oppositeAngleCalc1(surface);
            double SurfNorm = surfaceNormal(surface);
            int incidenceDifference = incidenceDegrees(incidence, surface);
            double answerOppAngle = oppositeAngleCalc1((int)answer);            

            oppositeTxt.Text = OppAngle.ToString();
            surfaceTxt.Text = SurfNorm.ToString();
            Answer7Text.Text = answer.ToString();
            Answer7RADText.Text = answer7RAD.ToString();
            Answer8Text.Text = answer8.ToString();

            answerOpposite.Text = answerOppAngle.ToString();

            double toRadians = Math.PI * (double)numericUpDown2.Value / 180.0;
            surface_radian_textbox.Text = toRadians.ToString();
        }



/// <summary>
/// -180 to +180
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            numericUpDown3.Value = (int)trackBar3.Value;
            int incidence = trackBar3.Value;
            int surface = trackBar4.Value;

            double answer1 = angleReflect1(incidence, surface);
            double answer2 = angleReflect2(incidence, surface);
            double answer3 = angleReflect3(incidence, surface);
            double answer4 = angleReflect4(incidence, surface);
            double answer5 = angleReflect5(incidence, surface);

            answer180_1.Text = answer1.ToString();
            answer180_2.Text = answer2.ToString();
            answer180_3.Text = answer3.ToString();
            answer180_4.Text = answer4.ToString();
            answer180_5.Text = answer5.ToString();
            
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            trackBar3.Value = (int)numericUpDown3.Value;
            int incidence = trackBar3.Value;
            int surface = trackBar4.Value;

            double answer1 = angleReflect1(incidence, surface);
            double answer2 = angleReflect2(incidence, surface);
            double answer3 = angleReflect3(incidence, surface);
            double answer4 = angleReflect4(incidence, surface);
            double answer5 = angleReflect5(incidence, surface);
            double OppAngle = oppositeAngleCalc1(surface);

            answer180_1.Text = answer1.ToString();
            answer180_2.Text = answer2.ToString();
            answer180_3.Text = answer3.ToString();
            answer180_4.Text = answer4.ToString();
            answer180_5.Text = answer5.ToString();
            oppositeTxt.Text = OppAngle.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            numericUpDown4.Value = (int)trackBar4.Value;

            int incidence = trackBar3.Value;
            int surface = trackBar4.Value;

            double answer1 = angleReflect1(incidence, surface);
            double answer2 = angleReflect2(incidence, surface);
            double answer3 = angleReflect3(incidence, surface);
            double answer4 = angleReflect4(incidence, surface);
            double answer5 = angleReflect5(incidence, surface);

            answer180_1.Text = answer1.ToString();
            answer180_2.Text = answer2.ToString();
            answer180_3.Text = answer3.ToString();
            answer180_4.Text = answer4.ToString();
            answer180_5.Text = answer5.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            trackBar4.Value = (int)numericUpDown4.Value;
            int incidence = trackBar3.Value;
            int surface = trackBar4.Value;

            double answer1 = angleReflect1(incidence, surface);
            double answer2 = angleReflect2(incidence, surface);
            double answer3 = angleReflect3(incidence, surface);
            double answer4 = angleReflect4(incidence, surface);
            double answer5 = angleReflect5(incidence, surface);

            answer180_1.Text = answer1.ToString();
            answer180_2.Text = answer2.ToString();
            answer180_3.Text = answer3.ToString();
            answer180_4.Text = answer4.ToString();
            answer180_5.Text = answer5.ToString();
        }

        private void ray_radian_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void surface_radian_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        public static double ConvertAngle_360(double angle)
        {
            if (angle >= 0)
            {
                return angle;
            }
            else
            {
                return angle + 360;
            }
        }

        public static double ConvertAngle_180(double angle)
        {
            if (angle > 180)
            {
                return angle - 360;
            }
            else
            {
                return angle;
            }
        }

        private void degreeConversion_ValueChanged(object sender, EventArgs e)
        {//0 to 360
            double toRadians = Math.PI * (double)degreeConversion.Value / 180.0;
            radianConversion.Value = (decimal)toRadians;

            //need to work on
            int temp = (int)degreeConversion.Value;
            double temp2 = (double)ConvertAngle_180(temp);
            convertto180.Text = temp2.ToString();
        }

        private void radianConversion_ValueChanged(object sender, EventArgs e)
        {//0 to PI
            double temp = (double)radianConversion.Value;

            if (temp < (0))
            {
                temp = 0;
            }
            if (temp > ((double)Math.PI)*2)
            {
                temp = Math.PI*2;
            }

            double toRadians = (double)radianConversion.Value * 180.0 / Math.PI;

            if (toRadians > 360)
            {
                toRadians = 360.0;
            }



            degreeConversion.Value = (decimal)toRadians;
        }

//---------------------------------------------
        private void degreeConversion2_ValueChanged(object sender, EventArgs e)
        {//-180 to 180
            double toRadians = Math.PI * (double)degreeConversion2.Value / 180.0;
            radianConversion2.Value = (decimal)toRadians;

            int temp = (int)degreeConversion2.Value;
            double temp2 = (double)ConvertAngle_360(temp);
            convertto360.Text = temp2.ToString();
        }
//---------------------------------------------
        private void radianConversion2_ValueChanged(object sender, EventArgs e)
        {//-PI to PI
            double temp = (double)radianConversion2.Value;

            if (temp < ((double)-Math.PI))
            {
                temp = -Math.PI;
            }
            if (temp > ((double)Math.PI))
            {
                temp = Math.PI;
            }

            /*if (radianConversion2.Value < -179)
            {
                radianConversion2.Value = -179;
            }
            if (radianConversion2.Value > 179)
            {
                radianConversion2.Value = 179;
            }
             
            double toRadians = (double)radianConversion2.Value * 180.0 / Math.PI;
             
             */


            double toRadians = (double)temp * 180.0 / Math.PI;
            degreeConversion2.Value = (decimal)toRadians;
        }
//---------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
