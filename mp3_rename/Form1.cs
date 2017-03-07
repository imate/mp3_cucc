using mp3_rename.BusinessLogic;
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

namespace mp3_rename
{
    public partial class Form1 : Form
    {
        private MP3BL BL { get; set; }
        private OpenFileDialog openDialog { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BL = new MP3BL();
            openDialog = new OpenFileDialog();
            openDialog.Title = "Open MP3 File";
            openDialog.Filter = "mp3 files|*.mp3";
            openDialog.Multiselect = true;
            openDialog.InitialDirectory = @"C:\";
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (var item in openDialog.FileNames)
                    {
                        this.BL.Add(item);
                        openDialog.InitialDirectory = item;
                    }
                    RefreshList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            RefreshList();
        }

        private void RefreshList()
        {
            lstFiles.Items.Clear();
            foreach (var item in BL.FileNames)
            {
                lstFiles.Items.Add(item);
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = lstFiles.GetItemText(lstFiles.SelectedItem);
        }
    }
}
