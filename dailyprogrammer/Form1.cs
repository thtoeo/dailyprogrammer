﻿namespace Test
{
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            richTextBox1.Text = Challenge279.Intermediate.Main.Run();
        }
    }
}
