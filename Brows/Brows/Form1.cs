using Awesomium.Windows.Forms;
using Awesomium;
using Awesomium.Windows.Controls;
using Awesomium.Windows;
using Awesomium.Core.Data;
namespace Brows
{
    public partial class Form1 : Form
    {
        string _link_mouse;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            WebBrowser web = new WebBrowser();
            web.Visible = true;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.DocumentCompleted += Web_DocumentCompleted;
            tabControl1.TabPages.Add("Новая вкладка");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i += 1;
        }

        private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != null)
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripTextBox1.Text);
            }
            else
            {
                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
            else
                Application.Exit();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                if (((WebBrowser)tabControl1.SelectedTab.Controls[0]).Document == null) return;

                var elem = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Document.GetElementFromPoint(((WebBrowser)tabControl1.SelectedTab.Controls[0]).PointToClient(MousePosition));
                if (elem == null) return;
                if (string.Compare(elem.TagName, "A", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    _link_mouse = elem.GetAttribute("href");
                }
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Dispose();
            }
            catch (Exception) { }
        }
    }
}