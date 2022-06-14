using System;

namespace 2D_Forest_Attributes
{
    class Shape
    {
        private Double centerX;

        public double CenterX
        {
            get
            {
                return centerX;
            }

            set
            {
                centerX = value;
            }
        }
        
        private Double centerY;

        public double CenterY
        {
            get
            {
                return centerY;
            }

            set
            {
                centerY = value;
            }
        }
        private Double angle;
        public double Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
            }
        }

        private Double distance1;
        public double Distance1
        {
            get
            {
                return distance1;
            }

            set
            {
                distance1 = value;
            }
        }

        private Double distance2;
        public double Distance2
        {
            get
            {
                return distance2;
            }

            set
            {
                distance2 = value;
            }
        }

        private Double distance3;
        public double Distance3
        {
            get
            {
                return distance3;
            }

            set
            {
                distance3 = value;
            }
        }

        private Double distance4;
        public double Distance4
        {
            get
            {
                return distance4;
            }

            set
            {
                distance4 = value;
            }
        }
        private Double distance5;
        public double Distance5
        {
            get
            {
                return distance5;
            }

            set
            {
                distance5 = value;
            }
        }
        private Double distance6;
        public double Distance6
        {
            get
            {
                return distance6;
            }

            set
            {
                distance6 = value;
            }
        }
        private Double distance7;
        public double Distance7
        {
            get
            {
                return distance7;
            }

            set
            {
                distance7 = value;
            }
        }
        private Double distance8;
        public double Distance8
        {
            get
            {
                return distance8;
            }

            set
            {
                distance8 = value;
            }
        }
        private Double dbh;
        public double DBH
        {
            get
            {
                return dbh;
            }
            set
            {
                dbh = value;
            }
        }
        public Shape(double centerX, double centerY, double angle, double distance1, double distance2, double distance3, double distance4, double distance5, double distance6, double distance7, double distance8, double dbh)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.angle = angle;
            this.distance1 = distance1;
            this.distance2 = distance2;
            this.distance3 = distance3;
            this.distance4 = distance4;
            this.distance5 = distance5;
            this.distance6 = distance6;
            this.distance7 = distance7;
            this.distance8 = distance8;
            this.dbh = dbh;
        }
    }
}
