using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Piastcode.Plugin.Interfaces;

namespace Toci.Piastcode.Plugin.Implementations
{
    public class ProjectItem : IProjectItem
    {
        private string _projectPath; //sln
        private string _filePath;
        private string _content;

        public ProjectItem(string projectPath,string filePath,string content)
        {
            _projectPath = projectPath;
            _filePath = filePath;
            _content = content;
        }

       public string ProjectPath
        {
            get
            {
                return _projectPath;
            }
            set
            {
                _projectPath = value;
            }
        }
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
            }
        }
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
    }
}
