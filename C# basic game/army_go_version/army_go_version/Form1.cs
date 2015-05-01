using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace army_go_version
{
    public partial class Form1 : Form
    {


        /// <summary>
        /// ///////////////////// next idea: insert "turn" into point, to save us moving game instances all the time.
        /// //////////////////// need to implement "ko rule";
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        static int dim = 19;
        static Button[,] buttons = new Button[dim, dim];
        static Game game;
        static string path = @"c:\Users\levav\Desktop\go pictures\";
        private void Form1_Load(object sender, EventArgs e)
        {
            init_graphics();
            game = new Game(dim);
        }
        private void init_graphics()
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.BurlyWood;


            int size = Math.Min(this.Width, this.Height) - 100;
            size /= dim;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = size;
                    buttons[i, j].Height = size;
                    buttons[i, j].Location = new Point(size * i, size * j);
                    buttons[i, j].FlatAppearance.BorderSize = 0;
                    buttons[i, j].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    buttons[i, j].Visible = true;
                    buttons[i, j].BackColor = Color.BurlyWood;
                    buttons[i, j].Tag = new Go_point(i, j);
                    buttons[i, j].Image = init_image(i, j);

                    buttons[i, j].Click += new EventHandler(button_Click);
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        private Image init_image(int x, int y)
        {
            if (x == 0 && y == 0)
                return Image.FromFile(path + @"shape\cor1.png");
            else if (x == dim - 1 && y == 0)
                return Image.FromFile(path + @"shape\cor2.png");
            else if (x == 0 && y == dim - 1)
                return Image.FromFile(path + @"shape\cor3.png");
            else if (x == dim - 1 && y == dim - 1)
                return Image.FromFile(path + @"shape\cor4.png");
            else if (y == 0)
                return Image.FromFile(path + @"shape\top.png");
            else if (y == dim - 1)
                return Image.FromFile(path + @"shape\bot.png");
            else if (x == 0)
                return Image.FromFile(path + @"shape\left.png");
            else if (x == dim - 1)
                return Image.FromFile(path + @"shape\right.png");
            else if (x % 6 == 3 && y % 6 == 3)
                return Image.FromFile(path + @"shape\special.png");
            else
                return Image.FromFile(path + @"shape\mid.png");
        }
        private void remove(Group group)
        {
            foreach (Go_point point in group.group)
            {
                if (game.turn == -1)
                    game.white_score++;
                else
                    game.black_score++;
                int x = point.x;
                int y = point.y;
                game.board[x, y] = 0;
                buttons[x, y].Image = init_image(x, y);
            }
        }
        private void add_stone(Go_point point)
        {
            string size = "17";
            int x = point.x;
            int y = point.y;
            game.board[x, y] = game.turn;
            if (game.turn == 1)
                buttons[x, y].Image = Image.FromFile(path + @"stones/black" + size + ".png");
            else
                buttons[x, y].Image = Image.FromFile(path + @"stones/white" + size + ".png");
        }
        private bool legal_move(Go_point point)
        {
            ///////   this does not alow any ko eating at all!
            foreach (Go_point p in point.find_neighbors())
            {
                if (game.board[p.x, p.y] != -game.turn)
                {
                    return true;
                }
            }
            return false;
        }
        void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Go_point point = (Go_point)button.Tag;            

            if (!legal_move(point))
                MessageBox.Show("no suicides alowed!");
            else if (game.board[point.x, point.y] == 0)
            {
                add_stone(point);                

                foreach (Go_point p in point.find_neighbors())
                    if (game.board[p.x, p.y] == -game.turn)
                    {
                        Group group = new Group(p, game);
                        if (group.isdead())
                            remove(group);
                    }
                game.turn = -game.turn;
            }
            else
            {
                MessageBox.Show("you cant play on other stones!");
            }
        }
        
    }
}
