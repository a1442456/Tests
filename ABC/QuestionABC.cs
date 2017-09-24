using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC
{
    public class QuestionABC
    {
        private int _id;
        private string _question;
        private int _subThemeId;
        private List<AnswerABC> _answers = new List<AnswerABC>();

        public QuestionABC()
        { }

        public QuestionABC(int id, string question, int subThemeId)
        {
            AnswerDAL aDAL = new AnswerDAL();
            this._id = id;
            this._question = question;
            this._subThemeId = subThemeId;
            this._answers = aDAL.GetAllAnswersByQuestion(question);
        }


        public int SubThemeId
        {
            get { return _subThemeId; }
            set { _subThemeId = value; }
        }


        public string QuestionCurrent
        {
            get { return _question; }
            set { _question = value; }
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public List<AnswerABC> ListAnswers
        {
            get { return _answers; }
            set { _answers = value; }
        }

    }
}