using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace point
{


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class point_f
    {
        // переменные
        public double F;
        public double I;
        public double V;
        public double gear;//передача на другой елемент

        
       //
    }
    public partial class MainWindow : Window
    {
        
        Stack<double> point_x = new Stack<double>();
        Stack<double> point_y = new Stack<double>();
        double round_x;
        double round_y;

        public MainWindow()
        {
            
            InitializeComponent();


           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            canvas1.Children.Clear();
            Grid(Convert.ToInt16(grid_label.Text));
            Sheet2d(0,300 , canvas1.ActualWidth, 300, Convert.ToInt16(Sheet_point.Text));

            round(canvas1.ActualWidth / 2, 100);
            Timer_1();
            time = 0;
        }

        void Sheet2d(double x1, double y1, double x2, double y2, int count)
        {
            Line sheet = new Line();
            sheet.Stroke = Brushes.Black;
            sheet.X1 = x1;
            sheet.X2 = x2;
            sheet.Y1 = y1;
            sheet.Y2 = y2;
            sheet.StrokeThickness = 5;
            canvas1.Children.Add(sheet);

          
            for (int i = 0; i < x2; i++)
            {


                if (i % count == 0)
                {
                    Ellipse point = new Ellipse();
                    point.Stroke = Brushes.Green;
                    point.Width = 4;
                    point.Height = 4;
                    point.Margin = new Thickness(i, y2 + 5, 0, 0);
                    canvas1.Children.Add(point);
                    point_x.Push(i);
                    point_y.Push(y2);
                }
            }
        }

        void Grid(double count)
        {
         double n=canvas1.ActualWidth;
         double height = canvas1.ActualHeight;
         double width = canvas1.ActualWidth;
        for (int i = 0; i < n; i++)
        {
             if (i%count==0)
             {

              Line line = new Line();
              line.Stroke = Brushes.LightBlue;
              line.X1 = i;      line.Y1 = 0;
              line.X2 = i;      line.Y2 = height;
              line.StrokeThickness = 0.5;
              canvas1.Children.Add(line);
            }
        }
         n = canvas1.ActualHeight;
        for (int i = 0; i < n; i++)
        {
             if (i % count == 0)
             {

              Line line = new Line();
              line.Stroke = Brushes.LightBlue;
              line.X1 = 0;      line.Y1 = i;
              line.X2 = width;  line.Y2 = i;
              line.StrokeThickness = 0.5;
              canvas1.Children.Add(line);
             }
        }
        }

        void round(double x, double y)
        {
            Ellipse Round = new Ellipse();
            Round.Stroke = Brushes.Black;
            Round.StrokeThickness = 5;
            Round.Width  = 30;
            Round.Height = 30;
            Round.Margin = new Thickness(x, y, 0, 0);
            canvas1.Children.Add(Round);
            round_x = x;
            round_y = y;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            canvas1.Children.Clear();
            Grid(Convert.ToInt16(grid_label.Text));
            Sheet2d(0, 300, canvas1.ActualWidth, 300, Convert.ToInt16(Sheet_point.Text));

            round(canvas1.ActualWidth / 2, 100);

        }
   
        void Timer_1()
        {
            System.Windows.Threading.DispatcherTimer Timer1 = new System.Windows.Threading.DispatcherTimer();
            
            Timer1.Tick += new EventHandler(Timer_tick);
            Timer1.Interval = new TimeSpan(0,0,0);
            Timer1.Start();

            lbl2.Content = Convert.ToInt16(timer_slide.Value);

        }
        
        private void Timer_tick(object sender, EventArgs e) {
            Timer_1();
            start(0, 10, 0, Convert.ToInt16(timer_slide.Value));
            lbl2.Content = Convert.ToInt16(timer_slide.Value);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
           // lbl2.Content = Convert.ToInt16(timer_slide.Value);
         
            //Timer1.Start();
        }
        int time = 0;
        int qwer = 0;
        void start(double V_round, double F_round, double I_round, int step) {
 
            if (qwer >= step) {
                qwer = 0;
                time++;
                canvas1.Children.Clear();
                Grid(Convert.ToInt16(grid_label.Text));
                Sheet2d(0, 300, canvas1.ActualWidth, 300, Convert.ToInt16(Sheet_point.Text));
                lbl1.Content = time;
               
                V_round = V_round + F_round * time / 1000;
                Ellipse Round = new Ellipse();
                Round.Stroke = Brushes.Black;
                Round.StrokeThickness = 5;
                Round.Width = 30;
                Round.Height = 30;
                round_y = round_y + V_round;
                Round.Margin = new Thickness(round_x, round_y, 0, 0);
                canvas1.Children.Add(Round);
            }
            else if(qwer>1200){ qwer = 0; }
            else { qwer++; }
        }
    }
}
