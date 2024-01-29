namespace Exam02
{
    internal class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public static implicit operator int(Answer? v)
        {
            throw new NotImplementedException();
        }
    }
}