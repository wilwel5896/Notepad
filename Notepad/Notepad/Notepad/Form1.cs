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
using System.Windows.Documents;

namespace Notepad
{
    public partial class MainNotepadFrm : Form
    {
        public MainNotepadFrm()
        {
            InitializeComponent();
        }

        // Setting Saved to True and Text Change Event

        bool saved = true;

        private void MainRichTextBox_TextChanged(object sender, EventArgs e)
        {
         
            
           
        }

        private void MainRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            saved = false;
        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        string CurrentFile = "";

        // New file
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (saved == false)
            {

                {
                    switch (((MessageBox.Show("Would you like to save your file?.", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))))
                    {
                        case DialogResult.Yes:
                            saveToolStripMenuItem_Click(sender, e);
                            break;
                        case DialogResult.No:
                            MainRichTextBox.Text = "";
                            CurrentFile = "";
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            }
        }

        // Open file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (saved == true)
                {

                    if (DialogResult.OK == openFileDialog.ShowDialog())
                    {
                        CurrentFile = openFileDialog.FileName;
                        if (Path.GetExtension(CurrentFile) == ".txt" || Path.GetExtension(CurrentFile) == ".cs") MainRichTextBox.LoadFile(CurrentFile,
                            RichTextBoxStreamType.PlainText);
                        else MainRichTextBox.LoadFile(CurrentFile);
                        this.Text = Path.GetFileName(CurrentFile) + " - Text Editor";
                    }
                }

                else if (saved == false)
            {
                
                switch (MessageBox.Show("Would you like to save your file?.", "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
                {
                    case DialogResult.Yes:
                    saveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:
                        break;
                }
                
                if (DialogResult.OK == openFileDialog.ShowDialog())
                {
                    if (Path.GetExtension(CurrentFile) == ".txt" || Path.GetExtension(CurrentFile) == ".cs") MainRichTextBox.LoadFile(CurrentFile,
                            RichTextBoxStreamType.PlainText);
                    else MainRichTextBox.LoadFile(CurrentFile);
                    this.Text = Path.GetFileName(CurrentFile) + " - Text Editor";
                }
            }
 
        }
    
        // Printing 
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(MainRichTextBox.Text, new Font("Centuey Gothic", 12, FontStyle.Regular), Brushes.Black, new PointF(130, 130));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PrintDialog().ShowDialog();
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saved == false)
            {

                {
                    switch (((MessageBox.Show("Would you like to save your file?.", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))))
                    {
                        case DialogResult.Yes:
                            saveToolStripMenuItem_Click(sender, e);
                            break;
                        case DialogResult.No:
                            Application.Exit();
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            }
        }

        // Save file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (CurrentFile == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
                //saved = false;
            }
            else MainRichTextBox.SaveFile(CurrentFile, RichTextBoxStreamType.PlainText);
            {
                //saved = true;
            }
            

        }

        // Save as
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void MainNotepadFrm_Load(object sender, EventArgs e)
        {

        }

        // Exit with X
        private void MainNotepadFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved == false)
            {
                {
                    switch (((MessageBox.Show("Would you like to save your file?.", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))))
                    {
                        case DialogResult.Yes:
                            saveToolStripMenuItem_Click(sender, e);
                            break;
                        case DialogResult.No: 
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // EDIT MENU ITEMS

        // Select All
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MainRichTextBox.SelectAll();
           MainRichTextBox.Focus();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Paste();
        }


        // Right Click on MainRichTextBox Menu
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Paste();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
            MainRichTextBox.Focus();
        }

        // FORMAT MENU ITEM LIST SECTION

        // Font
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            

            fontDlg.ShowColor = true;
            fontDlg.ShowEffects = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                MainRichTextBox.Font = fontDlg.Font;
                MainRichTextBox.BackColor = fontDlg.Color;
                
            }
            

        }

        // Text Color
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                MainRichTextBox.ForeColor = colorDialog1.Color;
            }
        }

        // HELP MENU ITEM
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All Rights Reserved by author William Daddy Warbux Wellington", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
