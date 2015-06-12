using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExplorer.Helpers;

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
            this._rootUrl = HttpContext.Current.Request.Url.Scheme 
                            + System.Uri.SchemeDelimiter 
                            + HttpContext.Current.Request.Url.Host
                            //+ (HttpContext.Current.Request.Url.IsDefaultPort ? "" : ":" + HttpContext.Current.Request.Url.Port)  // for localhost use
                            + URLROOT;
            Items = new List<ExplorerItem>();

            if (!Directory.Exists(this._rootPath))
                Directory.CreateDirectory(this._rootPath);

            GetAllFiles();
        }

        /// <summary>
        /// Get all files in root directory
        /// </summary>
        private void GetAllFiles()
        {

            // get all files
            var files = Directory.GetFiles(this._rootPath);
            foreach (var file in files)
            {
                FileInfo f = new FileInfo(file);
              
                ExplorerItem item = new ExplorerItem();
                item.Name = f.Name;
                item.Path = file;
                item.Url = _rootUrl + f.Name;
                item.Size = Utils.BytesToString(f.Length);
                item.ModifiedDate = f.LastWriteTime.ToString("dd/MM/yyyy HH:mm");
                item.IsFile = true;
                Items.Add(item);
            }
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="path">file path</param>
        public bool Delete(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception)
            {
                return false;
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