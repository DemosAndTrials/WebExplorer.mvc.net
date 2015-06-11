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
        private const string URLROOT = "/CatalogOutput/Products/";


        // fields
        private string _rootPath { get; set; }
        private string _rootUrl { get; set; }
        public List<ExplorerItem> Items { get; set; }


        public ExplorerViewModel()
        {
            this._rootPath = HttpContext.Current.Server.MapPath("~/") + PATHROOT;
            this._rootUrl = HttpContext.Current.Request.Url.Scheme + System.Uri.SchemeDelimiter + HttpContext.Current.Request.Url.Host
                //+ (HttpContext.Current.Request.Url.IsDefaultPort ? "" : ":" + HttpContext.Current.Request.Url.Port)  // for localhost use
                          + URLROOT;
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
                string name = Path.GetFileName(file);
                ExplorerItem item = new ExplorerItem();
                item.Name = name;
                item.Path = file;
                item.Url = _rootUrl + name;
                item.IsFile = true;
                Items.Add(item);
            }
        }

        public static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;

            string newUrl = serverUrl;
            Uri originalUri = System.Web.HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        } 
    }
}