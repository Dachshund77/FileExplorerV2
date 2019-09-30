using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerHandIn.Model
{
    public class FolderNode : FileNode
    {

        #region Constructors
        public FolderNode(DirectoryInfo directoryInfo) 
            :base(directoryInfo)
       
        {

        }
        #endregion
    }
}
