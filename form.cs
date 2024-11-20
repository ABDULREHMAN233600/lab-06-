using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winforms_visual_lab
{
    public partial class Form1 : Form
    {
      
        private Dictionary<string, List<int>> students = new Dictionary<string, List<int>>()
        {
            {"Alice", new List<int> { 85, 80, 90 }},
            {"Bob", new List<int> { 70, 60, 75 }},
            {"Charlie", new List<int> { 95, 92, 94 }},
            {"Daisy", new List<int> { 35, 60, 58 }}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            InitializeDataGridView();
            InitializeComboBox();
        }

        private void InitializeDataGridView()
        {
           
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Student";
            dataGridView1.Columns[1].Name = "Scores";

           
            foreach (var student in students)
            {
                string scores = string.Join(", ", student.Value);
                dataGridView1.Rows.Add(student.Key, scores);
            }
        }

        private void InitializeComboBox()
        {
         
            comboBox1.Items.Add("Show All Averages");
            comboBox1.Items.Add("Top Performing Student");
            comboBox1.Items.Add("Lowest Performing Student");
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            textBox1.Clear();

        
            string selectedOperation = comboBox1.SelectedItem.ToString();

            switch (selectedOperation)
            {
                case "Show All Averages":
                    ShowAllAverages();
                    break;
                case "Top Performing Student":
                    ShowTopPerformingStudent();
                    break;
                case "Lowest Performing Student":
                    ShowLowestPerformingStudent();
                    break;
            }
        }

        private void ShowAllAverages()
        {
          
            foreach (var student in students)
            {
                double average = student.Value.Average();
                textBox1.AppendText($"{student.Key}: {average:F2}\r\n");
            }
        }

        private void ShowTopPerformingStudent()
        {
           
            var topStudent = students.OrderByDescending(s => s.Value.Average()).First();
            double topAverage = topStudent.Value.Average();
            textBox1.Text = $"Top Performing Student: {topStudent.Key} with average of {topAverage:F2}";
        }

        private void ShowLowestPerformingStudent()
        {
           
            var lowStudent = students.OrderBy(s => s.Value.Average()).First();
            double lowAverage = lowStudent.Value.Average();
            textBox1.Text = $"Lowest Performing Student: {lowStudent.Key} with average of {lowAverage:F2}";
        }
    }
}
