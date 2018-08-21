using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Assent_Quiz
{
    public interface IDownloadAndOpenFile
    {
        void Open_File(string URL, string mimeType); 
    }
}
