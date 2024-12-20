using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExerciseRepository.Business_Entities;
using ExerciseRepository.Data;

namespace ExerciseRepository
{
    public partial class Form1 : Form
    {
        ConsoleForm console;
        Bio bio;

        public Form1()
        {
            InitializeComponent();
        }


        #region For the Master Branch Placeholding
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = @"**Exercise Repository** is a Windows application designed to help users track and manage their workout routine progression.

The project is developed in C# using the .NET Framework 3.5. This repository aims to provide an efficient and meaningful way for users to record and view their exercise data.

While the primary focus is on tracking workout progress, the project is expected to evolve and include additional related features over time.

Please use the development Breach for current devemlopmenting update. 

This about is use as a placeholder as the itnial  Master.";

            MessageBox.Show(text, "Developer Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (console == null)
            {
                console = new ConsoleForm();
                console.FormClosed += new FormClosedEventHandler(ConsoleFormClosed);
                console.FormClosing += new FormClosingEventHandler(ConsoleFormClosing);
                console.Show();
            }
            else
            {
                console.Show(); // Re-show the hidden form
            }

        }

        private void ConsoleFormClosed(object sender, FormClosedEventArgs e)
        {
            console = null;
        }

        private void ConsoleFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            console.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bio = TestData.CreateTestBio();  
        }
    }
}
