using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC
{
    public class ResultABC
    {
        private double _result;
        private Guid _userid;
        private int _subThemeID;
        private DateTime _testDate;

        public DateTime TestDate
        {
            get { return _testDate; }
            set { _testDate = value; }
        }

        public double Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public Guid Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public int SubThemeID
        {
            get { return _subThemeID; }
            set { _subThemeID = value; }
        }


    }
}