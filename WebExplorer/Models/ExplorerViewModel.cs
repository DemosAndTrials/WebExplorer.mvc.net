using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebExplorer.Models
{
    public class ExplorerViewModel
    {
        // const fields
        private const string PATHROOT = "CatalogOutput\\Products\\";

        // fields
        private string _rootPath { get; set; }
        public List<ExplorerItem> Items { get; set; }


        public ExplorerViewModel()
        {
            this._rootPath = HttpContext.Current.Server.MapPath("~/") + PATHROOT;
            Items = new List<ExplorerItem>();

            if (!Directory.Exists(this._rootPath))
                Directory.CreateDirectory(this._rootPath);

            GetAllFiles();
        }

        private void GetAllFiles()
        {

            // get all files

            var files = Directory.GetFiles(this._rootPath);
            foreach (var file in files)
            {
                ExplorerItem item = new ExplorerItem();
                item.Name = Path.GetFileName(file);
                item.Path = file;
                item.IsFile = true;
                Items.Add(item);
            }
        }
    }
}