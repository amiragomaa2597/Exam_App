using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Exam_student()
        {
            InitializeComponent();
            ent.ShowExam(1);
        }

      
    }
}
