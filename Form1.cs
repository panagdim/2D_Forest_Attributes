using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace 2D_Forest_Attributes
{
    public partial class Form1 : Form
    {
        // Using 8 radii/tree
        const int degrees45 = 45;
        const int degrees90 = 90;
        const int degrees135 = 135;
        const int degrees180 = 180;
        const int degrees225 = 225;
        const int degrees270 = 270;
        const int degrees315 = 315;
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Shape> shapes = ReadShapesFromFile();
                counter = 0;

                Series coordinates = CreateCustomSeries("coordinates", SeriesChartType.Point);
                Series crown = CreateCustomSeries("crown", SeriesChartType.Point);

                foreach (var s in shapes)
                {
                    // Call in all the methods for execution
                    addValueToListBox(listBox1, s.CenterX, Color.Blue);
                    addValueToListBox(listBox2, s.CenterY, Color.Blue);

                    addValueToListBox(listBox3, s.Angle, Color.Cyan);
                    addValueToListBox(listBox4, s.Distance1, Color.Red);
                    addValueToListBox(listBox5, s.Distance2, Color.Red);
                    addValueToListBox(listBox6, s.Distance3, Color.Red);
                    addValueToListBox(listBox7, s.Distance4, Color.Red);
                    addValueToListBox(listBox8, s.Distance5, Color.Red);
                    addValueToListBox(listBox9, s.Distance6, Color.Red);
                    addValueToListBox(listBox10, s.Distance7, Color.Red);
                    addValueToListBox(listBox11, s.Distance8, Color.Red);
                    addValueToListBox(listBox12, s.DBH, Color.Black);
                 
                    DrawCoordinates(coordinates, s);
                    DrawCrown(crown, s);                    
                    
                    Series delineate = CreateCustomSeries("delineate" + counter.ToString(), SeriesChartType.Line);
                    counter++;
                    DrawDelineates(delineate, s);

                    EstimateBA(s, listBox13,Color.BlueViolet);
                }
                CreateChart();
            }
            catch (InvalidDataException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (FileLoadException)
            {
                MessageBox.Show("File excpetion caught, please check your fileName");
            }
        }
	
        // Estimate the BA for each tree in [m^2]
        private void EstimateBA(Shape s, ListBox p, Color p1)
        {
            double convert = (s.DBH / 100);
            p.Items.Add((System.Math.Round((Math.PI / 4 * Math.Pow(convert, 2)),3))); 
            p.ForeColor = p1;
        }

        // Objects which are repeating is always good to put in methods
        private void addValueToListBox(ListBox ls, Double val, Color cl)  {
            ls.Items.Add(val);
            ls.ForeColor = cl; 
        }

        // Crown point connections using lines
        private void DrawDelineates(Series series, Shape s) { 

            // Connect the first point with the second  
            series.Points.AddXY(TreePositionX(s.Angle, s.Distance1, s.CenterX), TreePositionY(s.Angle, s.Distance1, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees45, s.Distance2, s.CenterX), Every45Y(s.Angle, degrees45, s.Distance2, s.CenterY));

            // Connect the Second point with the third 
            series.Points.AddXY(Every45X(s.Angle, degrees45, s.Distance2, s.CenterX), Every45Y(s.Angle, degrees45, s.Distance2, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees90, s.Distance3, s.CenterX), Every45Y(s.Angle, degrees90, s.Distance3, s.CenterY));

            // ...
            series.Points.AddXY(Every45X(s.Angle, degrees90, s.Distance3, s.CenterX), Every45Y(s.Angle, degrees90, s.Distance3, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees135, s.Distance4, s.CenterX), Every45Y(s.Angle, degrees135, s.Distance4, s.CenterY));

            // ...
            series.Points.AddXY(Every45X(s.Angle, degrees135, s.Distance4, s.CenterX), Every45Y(s.Angle, degrees135, s.Distance4, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees180, s.Distance5, s.CenterX), Every45Y(s.Angle, degrees180, s.Distance5, s.CenterY));

            // ...
            series.Points.AddXY(Every45X(s.Angle, degrees180, s.Distance5, s.CenterX), Every45Y(s.Angle, degrees180, s.Distance5, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees225, s.Distance6, s.CenterX), Every45Y(s.Angle, degrees225, s.Distance6, s.CenterY));

            // ...
            series.Points.AddXY(Every45X(s.Angle, degrees225, s.Distance6, s.CenterX), Every45Y(s.Angle, degrees225, s.Distance6, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees270, s.Distance7, s.CenterX), Every45Y(s.Angle, degrees270, s.Distance7, s.CenterY));
            
            // ...
            series.Points.AddXY(Every45X(s.Angle, degrees270, s.Distance7, s.CenterX), Every45Y(s.Angle, degrees270, s.Distance7, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees315, s.Distance8, s.CenterX), Every45Y(s.Angle, degrees315, s.Distance8, s.CenterY));

            // ...
            series.Points.AddXY(Every45X(s.Angle, degrees315, s.Distance8, s.CenterX), Every45Y(s.Angle, degrees315, s.Distance8, s.CenterY));
            series.Points.AddXY(TreePositionX(s.Angle, s.Distance1, s.CenterX), TreePositionY(s.Angle, s.Distance1, s.CenterY));
                
            series.ChartType = SeriesChartType.Line; }
        
	// Crown points
        private void DrawCrown(Series series, Shape s)
        {
            series.Points.AddXY(TreePositionX(s.Angle, s.Distance1, s.CenterX), TreePositionY(s.Angle, s.Distance1, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees45, s.Distance2, s.CenterX), Every45Y(s.Angle, degrees45, s.Distance2, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees90, s.Distance3, s.CenterX), Every45Y(s.Angle, degrees90, s.Distance3, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees135, s.Distance4, s.CenterX), Every45Y(s.Angle, degrees135, s.Distance4, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees180, s.Distance5, s.CenterX), Every45Y(s.Angle, degrees180, s.Distance5, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees225, s.Distance6, s.CenterX), Every45Y(s.Angle, degrees225, s.Distance6, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees270, s.Distance7, s.CenterX), Every45Y(s.Angle, degrees270, s.Distance7, s.CenterY));
            series.Points.AddXY(Every45X(s.Angle, degrees315, s.Distance8, s.CenterX), Every45Y(s.Angle, degrees315, s.Distance8, s.CenterY));
            series.Color = Color.Red;         
        }

        // Center tree positions
        private void DrawCoordinates(Series series, Shape s)
        {
            series.Points.AddXY(s.CenterX, s.CenterY);
            series.MarkerSize = 5;
            series.Color = Color.Blue;
            series.SmartLabelStyle.Enabled = true;
        }

        // Create series object in order each shape using its own series
        private Series CreateCustomSeries(String name, SeriesChartType chartType)
        {
            Series s = new Series();
            s.ChartArea = "ChartArea1";
            s.ChartType = chartType;
            s.Legend = "Legend1";
            s.Name = name;
            chart1.Series.Add(s);
            return s;
        }

        private static List<Shape> ReadShapesFromFile()
        {
            List<Shape> shapes = new List<Shape>();
            using (StreamReader sr = File.OpenText("TreePositionsTestCrown.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string qwe = line;
                    string[] ew = qwe.Split('\t');
                    double center_x = Convert.ToDouble(ew[0]);
                    double center_y = Convert.ToDouble(ew[1]);
                    double angle = double.Parse(ew[2]);
                    double distance1 = double.Parse(ew[3]);
                    double distance2 = double.Parse(ew[4]);
                    double distance3 = double.Parse(ew[5]);
                    double distance4 = double.Parse(ew[6]);
                    double distance5 = double.Parse(ew[7]);
                    double distance6 = double.Parse(ew[8]);
                    double distance7 = double.Parse(ew[9]);
                    double distance8 = double.Parse(ew[10]);
                    double dbh = double.Parse(ew[11]);

                    Shape s = new Shape(center_x, center_y, angle, distance1, distance2, distance3, distance4, distance5, distance6, distance7, distance8, dbh);
                    shapes.Add(s);                   
                }
            }
            return shapes;
        }

        private void CreateChart()
        {
            // Grid On/Off
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            CreateAxesAndLabels();
            // Set Line Width 
            chart1.Series[2].BorderWidth = 1;
            chart1.Series[2].Color = Color.Green;
            // Create Legend and Assign Custom Names
            CreateLegend();
            // Create a ToolTip 
            CreateToolTip();
            // Set Chart Title and modify it
            createChartTitle();
        }

        private void createChartTitle()
        {
            chart1.Titles.Add("Tree Positions");
            chart1.Titles[0].Alignment = ContentAlignment.MiddleCenter;
            chart1.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles[0].ForeColor = Color.DarkCyan;
        }

        private void CreateToolTip()
        {
            chart1.Series[0].ToolTip = "X,Y: #VALX{G}, #VALY{G}";
            chart1.Series[2].ToolTip = "X,Y: #VALX{G}, #VALY{G}";
        }

        private void CreateLegend()
        {
            chart1.Series[0].IsVisibleInLegend = true;
            chart1.Series[0].LegendText = "Stem Coordinates";

            chart1.Series[1].IsVisibleInLegend = true;
            chart1.Series[1].LegendText = "Crown Points";

            chart1.Series[2].IsVisibleInLegend = true;
            chart1.Series[2].LegendText = "Crown Delineation";
        }

        private void CreateAxesAndLabels()
        {
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "X";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Center; // Chart X axis Text Alignment
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.Cyan;

            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Y";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Center; // Chart Y axis Text Alignment
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.Cyan;
            chart1.ChartAreas["ChartArea1"].AxisY.TextOrientation = TextOrientation.Horizontal;
        }

        // Create the methods for tree positioning based on trigonometry
        public double TreePositionX(double angle, double distance, Double b)
        {
            double x = (Math.Sin(ConvertDegToRadians(angle)) * distance) + b;
            return x;
        }
	
        public double TreePositionY(double angle, double distance, Double b)
        {
            double y = (Math.Cos(ConvertDegToRadians(angle)) * distance) + b;
            return y;
        }

        public double Every45X(double angle, int angleVer, double distance, double x)
        {
            double standardAngleX = (Math.Sin(ConvertDegToRadians(angle + angleVer)) * distance) + x;
            return standardAngleX;
        }
	
        public double Every45Y(double angle, int angleVer, double distance, double y)
        {
            double standardAngleY = (Math.Cos(ConvertDegToRadians(angle + angleVer)) * distance) + y;
            return standardAngleY;
        }

        // Convert from Deg. to Radians
        private double ConvertDegToRadians(double angle)
        {
            return 2 * Math.PI * angle / 360;
        }
               
        private void button3_Click(object sender, EventArgs e)
        {
            // Clear textbox items
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            listBox10.Items.Clear();
            listBox11.Items.Clear();
            listBox12.Items.Clear();
            listBox13.Items.Clear();           
            // Clear all series from the graph            
            chart1.Series.Clear();
            chart1.Titles.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.chart1.SaveImage("F:\\Visual Studio\\Tree Positions-Crown Projections\\Version3\\Tree Positions-Crown_8Radii_Tree\\bin\\Debug\\ChartImage.png", ChartImageFormat.Png);
                MessageBox.Show("File saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("An error has occured" + ex);
            }            
        }
    }
 }  
     
