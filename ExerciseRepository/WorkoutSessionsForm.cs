using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExerciseRepository.Business_Entities;

namespace ExerciseRepository
{
    public partial class WorkoutSessionsForm : Form
    {
        private List<WorkoutSession> workoutSessions;


        public WorkoutSessionsForm(List<WorkoutSession> workoutSessions)
        {
            InitializeComponent();

            if (workoutSessions == null)
            {
                throw new ArgumentNullException("workoutSessions", "A null worksession was passed.");
            }

            this.workoutSessions = workoutSessions;
        }


        private void WorkoutSessionsForm_Load(object sender, EventArgs e)
        {
            if (workoutSessions != null)
            {



                // Bind the BindingSource to the workoutSessions list
                this.worksessionsBindingSource.DataSource = workoutSessions;

                // Bind the DataGridView to the BindingSource
                this.worksessionsDataGridView.DataSource = this.worksessionsBindingSource;

                // Set up event handlers for adding, editing, and deleting
                //this.bindingNavigatorAddNewItem.Click += new EventHandler(AddNewWorkoutSession);
                //this.bindingNavigatorDeleteItem.Click += new EventHandler(DeleteWorkoutSession);
                //this.worksessionsDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(EditWorkoutSession);

            }


        }

        // Event handler for adding a new WorkoutSession
        private void AddNewWorkoutSession(object sender, EventArgs e)
        {
            //var newSession = new WorkoutSession
            //{
            //    id = Guid.NewGuid(),
            //    // Initialize other properties as needed
            //};
            //workoutSessions.Add(newSession);
            //this.worksessionsBindingSource.ResetBindings(false);
           
        }

        // Event handler for deleting a WorkoutSession
        private void DeleteWorkoutSession(object sender, EventArgs e)
        {
            if (worksessionsBindingSource.Current != null)
            {
                workoutSessions.Remove((WorkoutSession)worksessionsBindingSource.Current);
                worksessionsBindingSource.ResetBindings(false);
            }
        }

        // Event handler for editing a WorkoutSession
        private void EditWorkoutSession(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.RowIndex < worksessionsBindingSource.Count)
            //{
            //    var session = (WorkoutSession)worksessionsBindingSource[e.RowIndex];
            //    // Open a dialog or form to edit the session details
            //    var editForm = new EditWorkoutSessionForm(session);
            //    if (editForm.ShowDialog() == DialogResult.OK)
            //    {
            //        worksessionsBindingSource.ResetBindings(false);
            //    }
            //}
        }

        private void worksessionsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.worksessionsBindingSource.Current != null)
            {
                var selectedSession = (WorkoutSession)worksessionsBindingSource.Current;
                if (selectedSession.EDay != null)
                {
                    exercisesBindingSource.DataSource = selectedSession.EDay.Exercises;

                }
            }
            else
            {
                exercisesBindingSource.DataSource = null;
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //int x = this.workoutSessions.Count;
            this.worksessionsBindingSource.EndEdit();
            this.worksessionsBindingSource.ResetBindings(false);
        }

        private void exercisesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.exercisesBindingSource.Current != null)
            {
                var selectedExercise = (Exercise)this.exercisesBindingSource.Current;
                this.setsBindingSource.DataSource = selectedExercise.Sets;
                if (selectedExercise.Sets != null)
                {
                    this.setsBindingSource.DataSource = selectedExercise.Sets;
                }
                else
                {
                    selectedExercise.Sets = new List<Set>();
                    this.setsBindingSource.DataSource = selectedExercise.Sets;
                }
            }
            else
            {
                this.setsBindingSource.DataSource = null;
            }
        }

        private void worksessionsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            using (var predefinedSessionsForm = new PredefinedSessionsForm(Business_Logic.Predefine_ExerciseDays))
            {
                if (predefinedSessionsForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedSessionId = predefinedSessionsForm.SelectedSessionId;
                    var newSession = Business_Logic.CreateWorkoutSession((Bio)this.Tag, selectedSessionId);
                    e.NewObject = newSession;
                }
                else
                {
                    var newSession = new WorkoutSession
                    {
                        id = Guid.NewGuid(),
                        // Initialize other properties as needed
                    };

                    //// Set the new item to be added to the BindingSource
                    e.NewObject = newSession;
                }
            }

        }

      

      



    }


    public class PredefinedSessionsForm : Form
    {
        private List<ExerciseDay> predefinedSessions;
        private Guid selectedSessionId;
        private FlowLayoutPanel radioPanel;
        private Button submitButton;

        public Guid SelectedSessionId
        {
            get { return selectedSessionId; }
        }

        public PredefinedSessionsForm(List<ExerciseDay> predefinedSessions)
        {
            this.predefinedSessions = predefinedSessions;

            InitializeComponent();
            GenerateRadioButtons();
        }

        private void InitializeComponent()
        {
            this.Text = "Select a Workout Session";
            this.Size = new System.Drawing.Size(300, 200);

            this.radioPanel = new FlowLayoutPanel
            {
                //Dock = DockStyle.Fill,
                AutoScroll = true
            };

            this.submitButton = new Button
            {
                Text = "Submit",
                Dock = DockStyle.Bottom
                //Anchor = AnchorStyles.Bottom
            };
            this.submitButton.Click += new EventHandler(SubmitButton_Click);

            this.Controls.Add(radioPanel);
            this.Controls.Add(submitButton);
        }

        private void GenerateRadioButtons()
        {
            foreach (var session in predefinedSessions)
            {
                var radioButton = new RadioButton
                {
                    Text = session.Name,
                    Tag = session.id,
                    AutoSize = true
                };
                this.radioPanel.Controls.Add(radioButton);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = null;

            foreach (Control control in this.radioPanel.Controls)
            {
                if (control is RadioButton && ((RadioButton)control).Checked)
                {
                    selectedRadioButton = (RadioButton)control;
                    break;
                }
            }

            if (selectedRadioButton != null)
            {
                this.selectedSessionId = (Guid)selectedRadioButton.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a session.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }





    //public partial class EditWorkoutSessionForm : Form
    //{
    //    private WorkoutSession session;

    //    public EditWorkoutSessionForm(WorkoutSession session)
    //    {
    //        InitializeComponent();
    //        this.session = session;

    //        // Bind session properties to form controls, e.g.:
    //        // this.textBoxName.Text = session.Name;
    //    }

    //    private void btnSave_Click(object sender, EventArgs e)
    //    {
    //        // Update session properties from form controls, e.g.:
    //        // session.Name = this.textBoxName.Text;

    //        this.DialogResult = DialogResult.OK;
    //        this.Close();
    //    }
    //}
}
