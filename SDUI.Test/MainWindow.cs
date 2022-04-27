using SDUI.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDUI.Test
{
    public partial class MainWindow : CleanForm
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            var group1 = new ListViewGroup("Group 1");
            var group2 = new ListViewGroup("Group 2 (collapsible)");
            listView1.Groups.Add(group1);
            listView1.Groups.Add(group2);
            for (int i = 0; i <= 5; i++)
            {
                var title = "Item " + i.ToString();
                var item = new ListViewItem(new[] { i.ToString(), title + " Column 2", title + " Column 3", title + " Column 4" }, group1);
                
                listView1.Items.Add(item);

                var item2 = new ListViewItem(new[] { title });

                if (i == 5)
                {
                    item2.ToolTipText = "Test tooltip";
                    item2.Font = new Font("Arial", 12, FontStyle.Bold);
                    item2.BackColor = Color.Aquamarine;
                    item2.ForeColor = Color.White;
                }

                listView2.Items.Add(item2);
            }

            for (int i = 6; i <= 11; i++)
            {
                string sItem = "Item " + i.ToString();
                listView1.Items.Add(new ListViewItem(new[] { i.ToString(), sItem + " Column 2", sItem + " Column 3", sItem + " Column 4" }, group2));
            }

            listView1.SetGroupInfo(listView1.Handle, 1, NativeMethods.LVGS_COLLAPSIBLE);

            for (int i = 0; i < 3; i++)
            {
                var text = "checkBox5" + i;
                var size = TextRenderer.MeasureText(text, Font);
                //var checkbox = new System.Windows.Forms.CheckBox();
                var checkbox = new SDUI.Controls.CheckBox();
                checkbox.Name = "checkBox5"+i;
                checkbox.Size = new System.Drawing.Size(groupBox3.Width, 24);
                checkbox.Text = text;
                checkbox.Dock = DockStyle.Top;
                groupBox3.Controls.Add(checkbox);
            }
        }

        private void buttonOpenInputDialog_Click(object sender, EventArgs e)
        {
            var dialog = new InputDialog("The input dialog", "This is a input dialog", "Please set the value!");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"The value: {dialog.Value}");
            }
        }

        private void buttonRandomColor_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var r = random.Next(0, 256);
            var g = random.Next(0, 256);
            var b = random.Next(0, 256);

            ColorScheme.BackColor = Color.FromArgb(r, g, b);
            BackColor = ColorScheme.BackColor;
        }

        private void buttonDark_Click(object sender, EventArgs e)
        {
            ColorScheme.BackColor = Color.Black;
            BackColor = ColorScheme.BackColor;
        }

        private void buttonLight_Click(object sender, EventArgs e)
        {
            ColorScheme.BackColor = Color.White;
            BackColor = ColorScheme.BackColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Testing";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text;
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) 
                return;

            MessageBox.Show(textBox1.Text);
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
            }
        }
    }
}