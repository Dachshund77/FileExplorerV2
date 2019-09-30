using FileExplorerHandIn.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FileExplorerHandIn.ViewModel
{
    public class FileExplorerVM
    {
        #region Fields
        private readonly FileNodeFactory fileNodeFactory;
        #endregion

        #region properties

        public ObservableCollection<FileNode> Collection { get; set; }

        public String Path { get; set; }

        public DelegateCommand ExploreFiles { get; set; }

        #endregion

        #region Constructors
        public FileExplorerVM()
        {
            this.Collection = new ObservableCollection<FileNode>();
            this.fileNodeFactory = new FileNodeFactory();
            this.ExploreFiles = new DelegateCommand(this.PopulateList, this.IsValidPath);
            
        }
        #endregion

        #region Methods
        private void PopulateList() //i should consider providing a URI method overload
        {
            //Wipe existing data from the observable
            Collection.Clear();

            //Get the parent directory
            DirectoryInfo parent = new  DirectoryInfo(Path);
            
            //Get the children directories
            DirectoryInfo[] parentsChildren = parent.GetDirectories();

            //For each children invoke factory pattern method call
            foreach (DirectoryInfo dirInfo in parentsChildren)
            {
                //Pass the dir info to the factory
                FileNode nodeInfo = fileNodeFactory.CreateFileNode(dirInfo);

                //Add the node to the Observable
                Collection.Add(nodeInfo);
            }
        }

        /// <summary>
        /// To make this actually work i would need a data trigger, i havent quit review that code yet
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool IsValidPath(object parameter) //not overloaded constructor, need to pass this signature
        {
            if (Directory.Exists(Path))
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
