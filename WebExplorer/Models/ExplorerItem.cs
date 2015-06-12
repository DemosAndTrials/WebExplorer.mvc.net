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

        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private string _modifiedDate;
        public string ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

        private bool _isFile;
        public bool IsFile
        {
            get { return _isFile; }
            set { _isFile = value; }
        }
    }
}