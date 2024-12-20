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
            this.textBoxConsole = new TextBox();
            this.menuStrip = new MenuStrip();
            this.fileMenu = new ToolStripMenuItem();
            this.propertiesMenuItem = new ToolStripMenuItem();

            // TextBox settings
            this.textBoxConsole.Dock = DockStyle.Fill;
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.ScrollBars = ScrollBars.Vertical;

            // MenuStrip settings
            this.menuStrip.Items.AddRange(new ToolStripItem[] { this.fileMenu });

            // File menu settings
            this.fileMenu.DropDownItems.AddRange(new ToolStripItem[] { this.propertiesMenuItem });
            this.fileMenu.Text = "File";

            // Properties menu item settings
            this.propertiesMenuItem.Text = "Properties";
            this.propertiesMenuItem.Click += new EventHandler(this.PropertiesMenuItem_Click);

            // MainForm settings
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Text = "Console Application";
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
