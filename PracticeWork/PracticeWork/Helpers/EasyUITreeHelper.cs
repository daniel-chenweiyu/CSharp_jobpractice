using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeWork.Models;

public class EasyUITreeHelper
{
    private MovieDatabase1Entities db = new MovieDatabase1Entities();

    /// <summary>
    /// Gets the root node.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public TreeView GetRootNode()
    {
        if (this.db.TreeView.Any())
        {
            return this.db.TreeView.FirstOrDefault(x => !x.ParentID.HasValue);
        }
        return null;
    }

    /// <summary>
    /// Gets the nodes.
    /// </summary>
    /// <param name="isReadAll">if set to <c>true</c> [is read all].</param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public IQueryable<TreeView> GetNodes(bool isReadAll = false)
    {
        var query = this.db.TreeView.AsQueryable();
        if (!isReadAll)
        {
            return query.Where(x => x.IsWritten == true);
        }
        return query;
    }
}