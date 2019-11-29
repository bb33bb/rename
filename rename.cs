using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rename
{
    public partial class rename : Form
    {
        public rename()
        {
            InitializeComponent();
            comboBox_Rname.Items.Add("替换");
            comboBox_Rname.Items.Add("base64");
            comboBox_Rname.Items.Add("base64-bak");
            comboBox_Rname.SelectedIndex = 0;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            var choice = comboBox_Rname.Text;
            if(choice== "替换")
            {
                var dir = textBox_Dir.Text;
                var txt_1 = textBox_1.Text;
                var txt_2 = textBox_2.Text;
                var files = System.IO.Directory.GetFiles(dir, "*.*");
                for (int i = 0; i < files.Length; i++)
                {
                    var fileName = System.IO.Path.GetFileName(files[i]);
                    var endName = Path.GetDirectoryName(files[i]) + @"\" + fileName.Replace(txt_1, txt_2);
                    File.Move(files[i], endName);
                }
            }
            if(choice == "base64")
            {
                var dir = textBox_Dir.Text;
                var files = System.IO.Directory.GetFiles(dir, "*.*");
                for (int i = 0; i < files.Length; i++)
                {
                    var fileName = System.IO.Path.GetFileName(files[i]);
                    byte[] b = System.Text.Encoding.Default.GetBytes(fileName);
                    var endName = Path.GetDirectoryName(files[i]) + @"\" + Convert.ToBase64String(b);
                    File.Move(files[i], endName);
                }
            }
            if (choice == "base64-bak")
            {
                var dir = textBox_Dir.Text;
                var files = System.IO.Directory.GetFiles(dir, "*.*");
                for (int i = 0; i < files.Length; i++)
                {
                    var fileName = System.IO.Path.GetFileName(files[i]);
                    byte[] b = Convert.FromBase64String(fileName);
                    var endName = Path.GetDirectoryName(files[i]) + @"\" + System.Text.Encoding.Default.GetString(b);
                    File.Move(files[i], endName);
                }
            }

        }
    }
}
