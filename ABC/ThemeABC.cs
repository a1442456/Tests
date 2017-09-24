using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC
{
    public class ThemeABC
    {
        private int _id;
        private string _theme;

        public ThemeABC(int id, string theme)
        {
            this._id = id;
            this._theme = theme;
        }

        public int Id { get; set; }
        public string ThemeCurrent { get; set; }      
        
               
    }
}