using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC
{
    public class SubThemeABC
    {
        private int _id;
        private string _subtheme;
        private int _themeId;

        public SubThemeABC(int id, string subTheme, int themeId)
        {
            this._id = id;
            this._subtheme = subTheme;
            this._themeId = themeId;
        }        

        public string subTheme
        {
            get { return _subtheme; }
            set { _subtheme = value; }
        }        

        public int MyProperty
        {
            get { return _id; }
            set { _id = value; }
        }     

        public int ThemeId
        {
            get { return _themeId; }
            set { _themeId = value; }
        }
        
        

         
    }
}