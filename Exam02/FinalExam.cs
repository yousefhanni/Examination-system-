using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exam02
{
    class FinalExam : Exam
    {

        public override void ShowExam()
    {
        foreach (var question in Questions)
        {
            var q = (Question)question;
            Console.Clear();
                Console.WriteLine($"Question: {q.Body}");
   
                Console.WriteLine($"Choose One Answer Question :      Mark({q.Mark})");
            
                foreach (var answer in q.Answers)
            {
                var a = (Answer)answer;
                    Console.Write($"{a.AnswerId}.{a.AnswerText}       ");
            }

                Console.WriteLine();
                Console.Write("Your Answer: ");
            q.StudentAnswer = int.Parse(Console.ReadLine());
        }
    }
    }

}
