using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC
{
//this text should be here
    public class AnswerABC
    {
        private int _id;
        private string _answer;
        private bool _isRight;
        private int _questionId;

        public int QuestionId
        {
            get { return _questionId; }
            set { _questionId = value; }
        }


        public bool IsRight
        {
            get { return _isRight; }
            set { _isRight = value; }
        }


        public string AnswerCurrent
        {
            get { return _answer; }
            set { _answer = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}