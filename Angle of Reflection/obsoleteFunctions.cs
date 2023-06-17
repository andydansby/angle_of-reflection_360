using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angle_of_Reflection360
{
    class obsoleteFunctions
    {
        //obsolete functions
        public int angleReflect77(int incidenceAngle, int surfaceAngle)
        {
            int returnAngle = 0;
            int oppositeAngle = 0;
            //int angle2 = 0;

            if (surfaceAngle < 180)
            {
                oppositeAngle = (180 + surfaceAngle) + 0;
                returnAngle = oppositeAngle - incidenceAngle;
            }
            if (surfaceAngle > 180)
            {
                oppositeAngle = (180 - surfaceAngle) + 360;//good
                returnAngle = oppositeAngle - incidenceAngle;
            }
            return returnAngle;
        }

        public double angleReflect98(int incidenceAngle, int surfaceAngle)
        {
            double angle = surfaceAngle * 2.0 - incidenceAngle;
            double reflection = 0.0;

            if (angle >= -180.0)
            {
                reflection = (angle + 180.0);
            }

            if (angle <= -180.0)
            {
                reflection = (angle + 360) + 180;
            }
            if (angle == 0)
            {
                reflection = 0;
            }
            if (angle == -360.0)
            {
                reflection = 360;
            }
            return Math.Abs(reflection);
        }

        public double angleReflect99(int incidenceAngle, int surfaceAngle)
        {
            double angle = surfaceAngle * 2.0 - incidenceAngle;
            return 180 - angle;
        }

        public double angleReflect77(double incidenceAngle, double surfaceAngle)
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

            //returnAngle = oppositeAngle - incidenceAngle;

            /*if (angleDifference < 180)
            {
                angle2 = Math.Abs(surfaceAngle - incidenceAngle);
                returnAngle = oppositeAngle - angle2;
            }
            if (angleDifference > 180)
            {
                angle2 = Math.Abs(oppositeAngle - incidenceAngle);
                //angle2 = Math.Abs(oppositeAngle - angle2);

                returnAngle = 360 - angle2;
                //returnAngle = angle2 + incidenceAngle;

                //returnAngle = oppositeAngle + (angle2 - 180);
                //returnAngle = angle2 - 360;
            }*/


            //ray incidence  < 180

            angle2 = Math.Abs(surfaceAngle - incidenceAngle);
            if (angle2 < 180)
            {
                angle2 = Math.Abs(surfaceAngle - incidenceAngle);
                returnAngle = oppositeAngle - angle2;
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


            /*if (angleDifference > 180)
            {
                angle2 = Math.Abs(surfaceAngle - incidenceAngle);
                angle2 = Math.Abs(oppositeAngle - angle2);

                returnAngle = 360 - angle2;
                //returnAngle = angle2 + incidenceAngle;

                //returnAngle = oppositeAngle + (angle2 - 180);
                //returnAngle = angle2 - 360;
            }

            if (angleDifference > 180)
            {
                angle2 = Math.Abs(surfaceAngle - incidenceAngle);
                int angle3 = oppositeAngle - angle2;

                returnAngle = 360 + angle3;
                //returnAngle = angle2 + incidenceAngle;

                //returnAngle = oppositeAngle + (angle2 - 180);
                //returnAngle = angle2 - 360;
            }
            
            if (oppositeAngle <= 180)
            {
                angle2 = Math.Abs(surfaceAngle - incidenceAngle);
                returnAngle = oppositeAngle - angle2;
            }
            if (oppositeAngle >= 180)
            {
                angle2 = Math.Abs(oppositeAngle - incidenceAngle);
                returnAngle = surfaceAngle - angle2;
            }
             
             
             */



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

        //https://stackoverflow.com/questions/7645815/as3-angle-of-reflection
        //var reflection:int = (incidence > 0) ? 180 - incidence: -180 - incidence;
        //((angle1 + angle2) / 2 + 90) % 360
        public double angleReflect88(int incidenceAngle, int surfaceAngle)
        {
            double returnAngle = 0;

            //https://stackoverflow.com/questions/9609338/calculating-tangent-from-a-point-on-a-circle
            //returnAngle = ((incidenceAngle + surfaceAngle) / 2 + 90) % 360;
            //returnAngle = (360 - incidenceAngle + (surfaceAngle * 2)) % 360;
            //returnAngle = (360 - surfaceAngle + (incidenceAngle * 2)) % 360;
            //returnAngle = (360 - surfaceAngle + (incidenceAngle)) % 360;
            //returnAngle = (360 - incidenceAngle * 2 + (surfaceAngle)) % 360;
            returnAngle = (360 + incidenceAngle + (surfaceAngle * 2)) % 360;

            return returnAngle;
        }

        //wrong numbers?  OBSOLETE
        public double angleReflect6(int incidenceAngle, int surfaceAngle)
        {
            double angle = (2 * surfaceAngle) - incidenceAngle;
            return Math.Abs(angle);
        }
        //https://forum.processing.org/two/discussion/10649/maths-calculate-reflection-angle.html





    }
}
