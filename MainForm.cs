using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Model_de_test_3
{ 
    public partial class MainForm : Form
{
    private Facultate Facultate {  get; set; }
    public MainForm()
    {
        Facultate = new Facultate();
        InitializeComponent();
    }

    private void DisplayStudents()
    {
        lvStudents.Items.Clear();
        Facultate.Students.Sort();
        foreach( var student in Facultate.Students)
            {
                ListViewItem lvStudent = new ListViewItem(student.Id.ToString());
                lvStudent.SubItems.Add(student.Name);   
                lvStudent.SubItems.Add(student.Grade.ToString());
                lvStudent.Tag = student;
                lvStudents.Items.Add(lvStudent);
            }

    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        AddEditForm addEditForm = new AddEditForm();
        Students students = new Students();
        addEditForm.Students = students;

        if (addEditForm.ShowDialog() == DialogResult.OK)
        {
            Facultate.Students.Add(students);
            DisplayStudents();

        }

    }

        private void lvStudents_DoubleClick(object sender, EventArgs e)
        {
            AddEditForm form = new AddEditForm();
            if(lvStudents.SelectedItems.Count > 0)
            {
                Students students = lvStudents.SelectedItems[0].Tag as Students;
                form.Students = students;

                if(form.ShowDialog() == DialogResult.OK)
                {
                    DisplayStudents();
                }
            }
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using(FileStream fs = File.Create(saveFileDialog.FileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, Facultate);
                }
            }
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(openFileDialog.FileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Facultate = (Facultate)bf.Deserialize(fs);
                    DisplayStudents();
                }
            }
        }

        private void serializareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Create(saveFileDialog.FileName))
                {
                    XmlSerializer bf = new XmlSerializer(typeof(Facultate));
                    bf.Serialize(fs, Facultate);
                }
            }
        }

        private void deserializareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.OpenRead(openFileDialog.FileName))
                {
                    XmlSerializer bf = new XmlSerializer(typeof(Facultate));
                    Facultate = (Facultate)bf.Deserialize(fs);
                    DisplayStudents();
                }
            }

        }
    } }

