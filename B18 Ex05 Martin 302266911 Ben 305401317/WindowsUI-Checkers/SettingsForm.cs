﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Checkers_Logic;

namespace WindowsUI_Checkers
{
    public partial class SettingsForm : Form
    {
        private Board.eBoardSize m_BoardSize = Board.eBoardSize.Small;

        public SettingsForm()
        {
            this.DialogResult = DialogResult.No;
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPlayer2.Enabled)
            {
                textBoxPlayer2.Enabled = true;
            }
        }

        public int BoardSize
        {
            get { return (int)m_BoardSize; }
        }

        public bool IsComputer
        {
            get { return checkBoxPlayer2.Enabled; }
        }

        private void radioButtonSmallBoard_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = Board.eBoardSize.Small;
        }

        private void radioButtonMediumBoard_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = Board.eBoardSize.Medium;
        }

        private void radioButtonLargeBoard_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = Board.eBoardSize.Large;
        }

        public string PlayerOneName
        {
            get
            {
                return string.Format("{0}:", textBoxPlayer1.Text);
            }
        }
   
        public string PlayerTwoName
        {
            get
            {
                string player2Name = textBoxPlayer2.Text;

                if(this.IsComputer)
                {
                    player2Name = textBoxPlayer2.Text.Substring(1, textBoxPlayer2.Text.Length - 2);
                }
                return string.Format("{0}:", player2Name);
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (textBoxPlayer1.Text.Length > 10)
            {
                textBoxPlayer1.Text = textBoxPlayer1.Text.Substring(0, 9);
            }

            if (textBoxPlayer2.Text.Length > 10)
            {
                textBoxPlayer2.Text = textBoxPlayer2.Text.Substring(0, 9);
            }

            if (textBoxPlayer1.Text == string.Empty || textBoxPlayer2.Text == string.Empty)
            {
                MessageBox.Show("Please fill all the fields", "Checkers Game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
