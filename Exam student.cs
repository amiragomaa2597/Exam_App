using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sql_project
{
    public partial class Exam_student : Form
    {
        ExamSYSEntities ent = new ExamSYSEntities();
        int? exId;
        List<exam_Questions_choices_Result> exQuestions=new List<exam_Questions_choices_Result>();
        int questionIndex;
        List<RadioButton> questionChoices = new List<RadioButton>();
        int radioIndex = 0;
        public Exam_student()
        {
            InitializeComponent();
            questionChoices.Add(radioButton2);
            questionChoices.Add(radioButton3);
            questionChoices.Add(radioButton4);

        }

        private void Exam_student_Load(object sender, EventArgs e)
        {
            Course crs= new Course();
            crs = (from c in ent.Courses where c.Crs_Name== student_courses.crs_name select c).FirstOrDefault();
            exId = ent.ShowExam(crs.Crs_Id).FirstOrDefault();
            exQuestions= ent.exam_Questions_choices(exId).ToList();
            questionIndex = 0;
            ChangeQuestion();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            questionIndex++;
            HideQuestionInfo();
            ChangeQuestion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            questionIndex--;
            HideQuestionInfo();
            ChangeQuestion();
            
        }
        public void ChangeQuestion()
        {
            radioIndex = 0;
            label1.Text = exQuestions[questionIndex].Q_Title;
            label1.Visible = true;
            radioButton1.Text = exQuestions[questionIndex].choice;
            radioButton1.Visible = true;
            for (int i = 0; i < questionChoices.Count; i++)
            {
                if (exQuestions[questionIndex+1].Q_Id == exQuestions[questionIndex].Q_Id)
                {
                    
                    questionChoices[radioIndex].Text = exQuestions[questionIndex + 1 ].choice;
                    questionChoices[radioIndex].Visible = true;
                    radioIndex++;
                    questionIndex++;
                }
            }
        }
        public void HideQuestionInfo()
        {
            label1.Visible = false;
            radioButton1.Visible=false;
            radioButton2.Visible=false;
            radioButton3.Visible=false;
            radioButton4.Visible=false;
        }
    }
}
