using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeWork.Models.ViewModels
{
    public class TreeViewModel
    {
        public TreeView RootNode { get; set; }
        public List<TreeView> TreeNodes { get; set; }
    }
}