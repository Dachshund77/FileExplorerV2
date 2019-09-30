using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorerHandIn.Model
{
    public class FileNodeFactory
    {
        #region Methods

        public FileNode CreateFileNode(DirectoryInfo directoryInfo)
        {
            //Prepare needed values
            string extension = directoryInfo.Extension;
            FileAttributes attributes = directoryInfo.Attributes;

            // Test for folder
            if (attributes.Equals(FileAttributes.Directory)) //For whatever reason this does not detect everything
            {
                //Create FolderNode
                return new FolderNode(directoryInfo);
            }
            //Test for image file
            else if (IsValidImage(directoryInfo))
            {
                return new ImageNode(directoryInfo);
            }
            else if (extension.Equals(".txt"))
            {
                return new TextNode(directoryInfo);
            }
            else
            {
                return new UnknownNode(directoryInfo);
            }
        }

        private bool IsValidImage(DirectoryInfo directoryInfo)
        {
            String extension = directoryInfo.Extension;
            if (extension.Equals(".jpg") || extension.Equals(".bmp")) //There should be a lot more
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
