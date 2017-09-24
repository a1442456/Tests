using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC
{
    public class StatisticABC
    {
        private string _userName;
        private int _userID;
        private double result;
        private string _nameofSubTheme;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public double Result
        {
            get { return result; }
            set { result = value; }
        }

        public string NameOfSubTheme
        {
            get { return _nameofSubTheme; }
            set { _nameofSubTheme = value; }
        }


    }
}