using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace Exam02
{
    abstract class Question
    {

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public ArrayList Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
        public int StudentAnswer { get; set;}

    }
}
