using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exam02
{
    class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }



        public void CreateExam()
        {
                #region To Get the type of exam from the user

            int examType;
            while (true)
            {
                Console.Write("Enter The Type of Exam You Want To Create (1 for Practical and 2 for Final): ");
                if (int.TryParse(Console.ReadLine(), out examType) && (examType == 1 || examType == 2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Practical or 2 for Final.");
                }
            }
            #endregion

                #region  To  Get the exam time from the user

            Console.Write("Please Enter The Time Of Exam in Minutes: ");
            int examTimeInMinutes = int.Parse(Console.ReadLine());
            DateTime examTime = DateTime.Now.AddMinutes(examTimeInMinutes);
            #endregion
              
                #region  To Get the number of questions from the user

            Console.Write("Please Enter The Number of Questions You Wanted To Create: ");
            int numQuestions = int.Parse(Console.ReadLine());

            ArrayList questions = new ArrayList();
            for (int i = 0; i < numQuestions; i++)
            {
                
                
                Console.Clear();

                Console.WriteLine($"Question {i + 1}:");
                #endregion

                #region  To Get the question type from the user
                int questionType;
                while (true)
                {
                    Console.Write("Please Choose the Type of Number (1 for True OR False || 2 for MCQ): ");
                    if (int.TryParse(Console.ReadLine(), out questionType) && (questionType == 1 || questionType == 2))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 1 for True/False or 2 for MCQ.");
                    }
                }

                Console.Clear();

                Console.WriteLine($"Question {i + 1}:");
                Console.WriteLine("Please Enter The Body of Question:");
                string body = Console.ReadLine();

                Console.Write("Please Enter The Marks of Question: ");
                int mark = int.Parse(Console.ReadLine());


                #endregion

                #region  To Get answers based on the question type
                ArrayList answers = new ArrayList();
                if (questionType == 1)
                {
                    answers.Add(new Answer { AnswerId = 1, AnswerText = "True" });
                    answers.Add(new Answer { AnswerId = 2, AnswerText = "False" });
                }
                else if (questionType == 2)
                {
                    Console.Write("Please Enter The Number of Answers: ");
                    int numAnswers = int.Parse(Console.ReadLine());

                    for (int j = 0; j < numAnswers; j++)
                    {
                        Console.Clear();

                        Console.WriteLine($"Question {i + 1}:");
                        Console.WriteLine("Please Enter The Body of Question:");
                        Console.WriteLine($"Please Enter Answer {j + 1} Text:");
                        string answerText = Console.ReadLine();
                        answers.Add(new Answer { AnswerId = j + 1, AnswerText = answerText });
                    }
                }
                #endregion

                #region  To  Get the correct answer Number from the user

                int correctAnswerNum;
                while (true)
                {
                    Console.Write("Please Enter The Right Answer of Question: ");
                    if (int.TryParse(Console.ReadLine(), out correctAnswerNum) &&
                        correctAnswerNum >= 1 && correctAnswerNum <= answers.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Please enter a number between 1 and {answers.Count}.");
                    }
                }
                var correctAnswer = (Answer)answers[correctAnswerNum - 1];
                #endregion

                #region  To Create a question based on the question type
                Question question;
                if (questionType == 1)
                {
                    question = new TrueFalseQuestion
                    {
                        Header = $"Question {i + 1}",
                        Body = body,
                        Mark = mark,
                        Answers = answers,
                        CorrectAnswer = correctAnswer
                    };
                }
                else
                {
                    question = new MultipleChoiceQuestion
                    {
                        Header = $"Question {i + 1}",
                        Body = body,
                        Mark = mark,
                        Answers = answers,
                        CorrectAnswer = correctAnswer
                    };
                }

                questions.Add(question);
            }
            #endregion

                #region   Create an exam based on the selected type
            if (examType == 1)
            {
                Exam = new PracticalExam
                {
                    ExamTime = examTime,
                    NumberOfQuestions = numQuestions,
                    Questions = questions
                };
            }
            else
            {
                Exam = new FinalExam
                {
                    ExamTime = examTime,
                    NumberOfQuestions = numQuestions,
                    Questions = questions
                };
            } 
            #endregion

        }

        public void ShowExam()
        {
            Console.Clear();
            Exam.ShowExam();
        }

        public void ShowExamResults()
        {
            int totalMarks = 0;
            int obtainedMarks = 0;

          
            for (int i = 0; i < Exam.Questions.Count; i++)
            {
                var question = (Question)Exam.Questions[i];
                var studentAnswer = question.StudentAnswer;
                var correctAnswer = question.CorrectAnswer.AnswerId;

                totalMarks += question.Mark;
                if (studentAnswer == correctAnswer)
                {
                    obtainedMarks += question.Mark;
                }

                Console.WriteLine($"Q{i + 1}: Your Answer is Number: {studentAnswer}, Correct Answer is Number: {correctAnswer}");
            }

            Console.WriteLine($"Your Exam Grade is {obtainedMarks} from {totalMarks}");
        }

    }

}
        

