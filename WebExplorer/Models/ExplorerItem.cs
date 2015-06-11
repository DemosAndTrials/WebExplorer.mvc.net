using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExplorer.Models
{
    public class ExplorerItem
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private bool _isFile;
        public bool IsFile
        {
            get { return _isFile; }
            set { _isFile = value; }
        }
    }
}