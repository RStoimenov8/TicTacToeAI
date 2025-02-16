using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeAI
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }
        Player currentplayer;
        List<Button> buttons;
        Random r = new Random();
        int playerw = 0;
        int AIw = 0;
        public Form1()
        {
            InitializeComponent();
            reset();
        }

        private void PlayerClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentplayer = Player.X;
            button.Text = currentplayer.ToString();
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Cyan;
            buttons.Remove(button);
            Check();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (buttons.Count> 0)
            {
                int index = r.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentplayer = Player.O;
                buttons[index].Text = currentplayer.ToString();
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon;
                buttons.RemoveAt(index);
                Check();
                timer.Stop();
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            reset();
        }
        private void ButtonsLoad()
        {
            buttons = new List<Button> { button1, button2, button3, button6, button5, button4, button9, button7, button8 };
        }
        private void reset()
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                ((Button)X).Enabled = true;
                ((Button)X).Text = "?";
                ((Button)X).BackColor = default(Color);
                }
            }
            ButtonsLoad();
        }
        private void Check()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button9.Text == "X" && button8.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X" ) 
            {
                timer.Stop();
                MessageBox.Show("Играчът Печели!");
                playerw++;
                label1.Text = "Победи играч: " + playerw;
                reset();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button9.Text == "O" && button8.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O" )
            {
                timer.Stop();
                MessageBox.Show("Компютърът Печели!");
                AIw++;
                label2.Text = "Победи Компютър: " + AIw;
                reset();
            }
        }
    }
}
