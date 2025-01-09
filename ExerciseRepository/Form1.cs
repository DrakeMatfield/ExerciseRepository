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
using ExerciseRepository.Helper_Functions;
using ExerciseRepository.Data_Access;
using System.Xml.Xsl;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace ExerciseRepository
{
    public partial class Form1 : Form
    {
        WorkoutSessionsForm workoutForm;
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
            Business_Logic.xslt = Business_Logic.LoadXsltFromFile("transform.xslt", true);

            //bio = TestData.CreateDrakeBio();

            // Get the bio details as a string
            //string bioDetails = Printsouts.GetBioDetailsAsString(bio);

            if (console == null)
            {
                consoleToolStripMenuItem_Click(this, EventArgs.Empty);
            }

            //console.LogMessage(Printsouts.ProcessHierarchyString(bio.ToString()));

            ////Guid exerciseDayId = bio.profile.Plans
            ////                           .FirstOrDefault()
            ////                           .Routines
            ////                           .FirstOrDefault()
            ////                           .Days
            ////                           .FirstOrDefault(day => day.Name == "Day 3").id;

            ////var workoutSession = Business_Logic.CreateWorkoutSession(bio, exerciseDayId);
            //routinesDataGridView.DataMember = "profile.Plans[0].Routines";
            //routineBindingSource.DataMember = "profile.Plans[0].Routines"; 

            //this.bioBindingSource.DataSource = bio;
            //this.routinesBindingSource.DataSource = bio.profile.Plans[0].Routines;
        }

        private void btnTestSave_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "er files (*.er)|*.er|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = "er";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;

                Business_Logic.SaveBio(filename, bio);
                MessageBox.Show("Bio saved successfully!");
            }
        }

        private void btnOpenBio_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "er Files (.er)|*.er|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = this.openFileDialog1.FileName;
                bio = Business_Logic.OpenBio(filename);
                console.LogMessage(Printsouts.ProcessHierarchyString(bio.ToString()));

                this.bioBindingSource.DataSource = bio;
                this.plansBindingSource.DataSource = bio.profile.Plans[0];
                this.routinesBindingSource.DataSource = bio.profile.Plans[0].Routines;
                this.bioBindingSource.ResetBindings(false);
                Business_Logic.Predefine_ExerciseDays = Business_Logic.GetAllExerciseDays(bio);
                // this.worksessionsBindingSource.DataSource = bio.worksessions;
                // routinesDataGridView.DataMember = "bio.profile.Plans[0].Routines";

            }

        }

        private void btnShowWorkotSessions_Click(object sender, EventArgs e)
        {
            if (workoutForm == null)
            {
                if (bio.worksessions == null)
                {
                    bio.worksessions = new List<WorkoutSession>();
                }
                workoutForm = new WorkoutSessionsForm(bio.worksessions);
                this.workoutForm.FormClosed += new FormClosedEventHandler(workoutForm_FormClosed);
                this.workoutForm.FormClosing += new FormClosingEventHandler(workoutForm_FormClosing);
                this.workoutForm.Deactivate += new EventHandler(workoutForm_Deactivate);
                this.workoutForm.Tag = bio;
                this.workoutForm.Show();
            }
            else
            {
                this.workoutForm.Show();
            }
        }

        void workoutForm_Deactivate(object sender, EventArgs e)
        {
            this.bioBindingSource.ResetBindings(false);

        }

        void workoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            workoutForm.Hide();
        }

        void workoutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.workoutForm = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var z = this.bio.worksessions;
            this.bioBindingSource.ResetBindings(false);
            //this.worksessionsBindingSource.ResetBindings(false);
        }

        private void toXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = "xml";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;

                Business_Logic.ExportToXML(filename, bio);
                MessageBox.Show("Bio saved successfully!");
            }
        }

        private void fromXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "xml Files (.xml)|*.xml|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = this.openFileDialog1.FileName;
                bio = Business_Logic.ImportBioFromXml(filename);
                console.LogMessage(Printsouts.ProcessHierarchyString(bio.ToString()));

                this.bioBindingSource.DataSource = bio;
                this.plansBindingSource.DataSource = bio.profile.Plans[0];
                this.routinesBindingSource.DataSource = bio.profile.Plans[0].Routines;
                this.bioBindingSource.ResetBindings(false);
                Business_Logic.Predefine_ExerciseDays = Business_Logic.GetAllExerciseDays(bio);
                // this.worksessionsBindingSource.DataSource = bio.worksessions;
                // routinesDataGridView.DataMember = "bio.profile.Plans[0].Routines";

            }
        }

        private void btn_xslt_test_Click(object sender, EventArgs e)
        {
            string results;

            if (bio != null)
            {

                // Convert the selected ExerciseDay object to XML
                string xml = BioParser.ConvertBioToXml(bio);

                // Use the XSLT to transform the XML and capture the result as a string
                using (StringReader stringReader = new StringReader(xml))
                using (XmlReader reader = XmlReader.Create(stringReader))
                using (StringWriter writer = new StringWriter())
                {
                    Business_Logic.xslt.Transform(reader, null, writer);
                    results = writer.ToString();
                }

                // Display the transformed result in the console
                console.LogMessage(results);
            }
        }

        private void daysDataGridView_DoubleClick(object sender, EventArgs e)
        {

            // Get the selected item in the GridView, which should be an object of ExerciseDay
            if (daysDataGridView.CurrentRow != null && daysDataGridView.CurrentRow.DataBoundItem is ExerciseDay)
            {
                ExerciseDay eday = (ExerciseDay)daysDataGridView.CurrentRow.DataBoundItem;
                string results = Business_Logic.DisplayExerciseDay(eday);
                // Display the result in a message box
                MessageBox.Show(results);
            }
            else
            {
                MessageBox.Show("Please select a valid ExerciseDay entry.");
            }
        }


    }


}


