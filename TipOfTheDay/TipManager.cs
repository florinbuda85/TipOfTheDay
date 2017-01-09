using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string dir = @"D:\Gdrive\Proiecte in desfasurare\09_Randoms\randoms";

            var files = from file in Directory.EnumerateFiles(dir, "*.txt", SearchOption.AllDirectories)
                        select file;

            int fileID = new Random().Next(0, files.Count() - 1);

            return Path.GetFileName(files.ElementAt(fileID)) + ": " +  File.ReadAllText(files.ElementAt(fileID));
        }
    }
}
