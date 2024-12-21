using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExerciseRepository
{
    public class ConsoleForm : Form
    {
        private TextBox textBoxConsole;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem propertiesMenuItem;

        public ConsoleForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.BackColor = System.Drawing.Color.Black;
            this.textBoxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxConsole.ForeColor = System.Drawing.Color.Green;
            this.textBoxConsole.Location = new System.Drawing.Point(0, 24);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(284, 237);
            this.textBoxConsole.TabIndex = 0;
            this.textBoxConsole.AcceptsTab = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // propertiesMenuItem
            // 
            this.propertiesMenuItem.Name = "propertiesMenuItem";
            this.propertiesMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesMenuItem.Text = "Properties";
            this.propertiesMenuItem.Click += new System.EventHandler(this.PropertiesMenuItem_Click);
            // 
            // ConsoleForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ConsoleForm";
            this.Text = "Console Application";
            this.Load += new System.EventHandler(this.ConsoleForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PropertiesMenuItem_Click(object sender, EventArgs e)
        {
            // Open properties form
            PropertiesForm propertiesForm = new PropertiesForm(this);
            propertiesForm.ShowDialog();
        }

        public void LogMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(LogMessage), message);
            }
            else
            {
                textBoxConsole.AppendText(message + Environment.NewLine);
            }
        }

        public void SetConsoleColors(Color backgroundColor, Color textColor)
        {
            if (backgroundColor != Color.Empty)
            {
                this.textBoxConsole.BackColor = backgroundColor;
            }
            if (textColor != Color.Empty)
            {
                this.textBoxConsole.ForeColor = textColor;
            }
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {

        }
    }

    //public class PropertiesForm : Form
    //{
    //    private ConsoleForm mainForm;
    //    private Button buttonApply;
    //    private ColorDialog colorDialogBackground;
    //    private ColorDialog colorDialogText;

    //    public PropertiesForm(ConsoleForm form)
    //    {
    //        this.mainForm = form;
    //        InitializeComponent();
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.buttonApply = new Button();
    //        this.colorDialogBackground = new ColorDialog();
    //        this.colorDialogText = new ColorDialog();

    //        // Button settings
    //        this.buttonApply.Text = "Change Colors";
    //        this.buttonApply.Click += new EventHandler(this.ButtonApply_Click);
    //        this.buttonApply.Dock = DockStyle.Top;

    //        // PropertiesForm settings
    //        this.Controls.Add(this.buttonApply);
    //        this.Text = "Properties";
    //    }

    //    private void ButtonApply_Click(object sender, EventArgs e)
    //    {
    //        if (colorDialogBackground.ShowDialog() == DialogResult.OK)
    //        {
    //            Color backgroundColor = colorDialogBackground.Color;

    //            if (colorDialogText.ShowDialog() == DialogResult.OK)
    //            {
    //                Color textColor = colorDialogText.Color;
    //                mainForm.SetConsoleColors(backgroundColor, textColor);
    //            }
    //        }
    //    }
    //}


    public class PropertiesForm : Form
    {
        private ConsoleForm mainForm;
        private Button buttonSetBackgroundColor;
        private Button buttonSetForegroundColor;
        private ColorDialog colorDialog;

        public PropertiesForm(ConsoleForm form)
        {
            this.mainForm = form;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.buttonSetBackgroundColor = new Button();
            this.buttonSetForegroundColor = new Button();
            this.colorDialog = new ColorDialog();

            // Button settings for setting background color
            this.buttonSetBackgroundColor.Text = "Set Background Color";
            this.buttonSetBackgroundColor.Click += new EventHandler(this.ButtonSetBackgroundColor_Click);
            this.buttonSetBackgroundColor.Dock = DockStyle.Top;

            // Button settings for setting foreground color
            this.buttonSetForegroundColor.Text = "Set Foreground Color";
            this.buttonSetForegroundColor.Click += new EventHandler(this.ButtonSetForegroundColor_Click);
            this.buttonSetForegroundColor.Dock = DockStyle.Top;

            // PropertiesForm settings
            this.Controls.Add(this.buttonSetBackgroundColor);
            this.Controls.Add(this.buttonSetForegroundColor);
            this.Text = "Properties";
        }

        private void ButtonSetBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color backgroundColor = colorDialog.Color;
                mainForm.SetConsoleColors(backgroundColor, Color.Empty); // Pass the current foreground color
            }
        }

        private void ButtonSetForegroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color textColor = colorDialog.Color;
                mainForm.SetConsoleColors(Color.Empty, textColor); // Pass the current background color
            }
        }
    }



}
