using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace mp3_rename.BusinessLogic
{
    public class MP3BL
    {
        public List<string> FileNames { get; set; }

        public MP3BL()
        {
            FileNames = new List<string>();
        }

        public void Add(string item)
        {
            if (!FileNames.Contains(item))
                FileNames.Add(item);
        }

        public Tag GetTag(string fileName)
        {
            TagLib.File tagFile = TagLib.File.Create(fileName);
            Tag tag = tagFile.Tag;
            return tag;
        }

        internal void Clear()
        {
            FileNames = new List<string>();
        }
    }
}
