using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerHandIn.Model
{
    public abstract class FileNode //Consider the use of the abstract class 
    {

        #region Properties
        public string Name { get; set; } 
        /*I need to potentially implement INotifyProperty interface,
         * but i might not since im like 10000 meter over the ocean right now
         */
 
        #endregion

        #region Constructors
        public FileNode(DirectoryInfo directoryInfo)
        {
            this.Name = directoryInfo.Name;
        }
        #endregion

    }
}
