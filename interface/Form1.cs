using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace @interface
{
    public partial class Form1 : Form
    {
        dbHandler db;
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            db = new dbHandler();
            guna2TextBox2.PasswordChar = '*';
            guna2Button1.Click += Login;
            guna2Button2.Click += Register;
        }
        void Login(object s, EventArgs e)
        {
            db.read();
            foreach (user item in user.users)
            {
                if (guna2TextBox1.Text == item.username && guna2TextBox2.Text == item.password)
                {
                    game game = new game(item);
                    game.Show();
                    this.Hide();
                    game.FormClosing += (s2, e2) =>
                    {
                        this.Show();
                        db.update(item);
                    };
                    break;
                }
            }
        }
        void Register(object s, EventArgs e)
        {
            if (guna2TextBox1.TextLength > 0 && guna2TextBox2.TextLength > 0)
            {
                user user = new user();
                user.username = guna2TextBox1.Text;
                user.password = guna2TextBox2.Text;
                db.insert(user);
            }
        }
    }
}
