﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TipOfTheDay
{
    class TipManager
    {
        private TipManager ()
        {

        }

        private static TipManager _instance = null;
        
        public static TipManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new TipManager();
            }
            return _instance;
        }
         
        public string getRandomTip()
        {
            var files = from file in Directory.EnumerateFiles(Properties.Settings.Default.sourceFolder, "*.txt", SearchOption.AllDirectories)
                        select file;

            int fileID = new Random().Next(0, files.Count() - 1);

            return Path.GetFileName(files.ElementAt(fileID)) + ": " +  File.ReadAllText(files.ElementAt(fileID));
        }
    }
}
