using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exam02
{
 // Abstract class(Exam) i will put it Common  attributes
    abstract class Exam
    {
        public DateTime ExamTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public ArrayList Questions { get; set; }
        public abstract void ShowExam();

      
    }
}
