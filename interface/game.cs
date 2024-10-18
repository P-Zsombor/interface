using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace @interface
{
    public partial class game : Form
    {
        user user;
        PictureBox train;
        Timer cTimer = new Timer();
        Timer tTimer = new Timer();
        Timer sTimer = new Timer();
        Random rand = new Random();
        List<PictureBox> cars = new List<PictureBox>();
        public game(user user)
        {
            this.user = user;
            InitializeComponent();
            Start();
        }
        void Start()
        {
            cTimer.Interval = 25;
            tTimer.Interval = 10;
            cTimer.Start();
            tTimer.Start();
            sTimer.Start();
            cTimer.Tick += cTTick;
            tTimer.Tick += tTTick;
            sTimer.Tick += sTTick;
            text();
            cCar();
            cTrain();
            this.Click += (s, e) => cTrain();

            this.FormClosing += (s, e) => cTimer.Stop();
        }
        void cCar()
        {
            PictureBox car = new PictureBox();
            car.Size = new Size(120, 60);
            car.Location = new Point(-120, 162);
            car.BackColor = Color.OrangeRed;
            this.Controls.Add(car);
            cars.Add(car);
            car.BringToFront();
            pictureBox5.BringToFront();
        }
        void cTrain()
        {
            train = new PictureBox();
            train.Size = new Size(80, 300);
            train.Location = new Point(529, this.Height);
            train.BackColor = Color.DarkSlateBlue;
            this.Controls.Add(train);
            train.BringToFront();
            sTimer.Interval = rand.Next(10000, 30001);
        }
        void cTTick(object s, EventArgs e)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                PictureBox car = cars[i];
                if ((!guna2Button1.Checked || car.Right + 20 <= pictureBox5.Left || car.Right > pictureBox5.Left) && (i > 0 && car.Right + 20 <= cars[i - 1].Left || i == 0))
                {
                    car.Left += 2;
                }
                if (this.Controls.Contains(train) && car.Bounds.IntersectsWith(train.Bounds))
                {
                    cTimer.Stop();
                    tTimer.Stop();
                    MessageBox.Show("You Died");
                    this.Close();
                }
                if (car.Left > this.Width)
                {
                    user.points++;
                    text();
                    this.Controls.Remove(car);
                    cars.Remove(car);
                }
                if (car.Left > 20 && i == cars.Count - 1)
                {
                    cCar();
                }
            }
        }
        void tTTick(object s, EventArgs e)
        {
            if (this.Controls.Contains(train))
            {
                if (train.Bottom > 0)
                {
                    train.Top -= 4;
                }
                else
                {
                    this.Controls.Remove(train);
                }
            }

            if (!guna2Button1.Checked)
            {
                guna2Button1.Text = "Le";
                if (pictureBox5.Height > 17)
                {
                    pictureBox5.Height -= 2;
                }
            }
            else
            {
                guna2Button1.Text = "Fel";
                if (pictureBox5.Bottom < pictureBox1.Bottom)
                {
                    pictureBox5.Height += 2;
                }
            }
        }
        void sTTick(object s, EventArgs e)
        {
            cTrain();
        }
        void text()
        {
            label1.Text = $"User: {user.username}\nPoints: {user.points}";
        }
    }
}
