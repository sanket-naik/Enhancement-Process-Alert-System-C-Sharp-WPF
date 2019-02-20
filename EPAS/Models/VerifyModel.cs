using EPAS.Models;  
using EPAS.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EPAS.Services
{
    /// <summary>
    /// Merge Similer Task and Display in Tree View
    /// </summary>
    public class VerifyModel
    {
        bool flag=false;
        private VerifyView _page;

        List<Jobs> Enhancementlist;
        /// <summary>
        /// Takes param from Verify model
        /// </summary>
        /// <param name="enhancement"></param>
        public VerifyModel(List<Jobs> enhancement)
        {
            this.Enhancementlist = enhancement;
            _page = new VerifyView(Enhancementlist);
        }
        
        /// <summary>
        /// Display's task in tree view
        /// </summary>
        /// <returns></returns>
        public bool Show()
        {
            if (Enhancementlist.Count != 0)
            {
                for (int k = 1; k <= Enhancementlist[0].week; k++)
                {
                    int count = 1;
                    TreeViewItem ParentItem = new TreeViewItem();
                    ParentItem.Header = "Week " + k;
                    _page.TreeData.Items.Add(ParentItem);

                    for (int i = 0; i < Enhancementlist.Count; i++)
                    {
                        if (k == Enhancementlist[i].week)
                        {
                            Jobs j = Enhancementlist[i];
                            TreeViewItem treeItem = new TreeViewItem();
                            treeItem.Header = "Task: " + count;
                            ParentItem.Items.Add(treeItem);

                            treeItem.Items.Add(new TreeViewItem() { Header = "Date: " + j.day });
                            treeItem.Items.Add(new TreeViewItem() { Header = "Done By: " + j.target.ToUpper() });
                            treeItem.Items.Add(new TreeViewItem() { Header = "Assignee: " + j.responsibility });
                            treeItem.Items.Add(new TreeViewItem() { Header = "Approval: " + j.approval });
                            treeItem.Items.Add(new TreeViewItem() { Header = "Task: " });
                            treeItem.Items.Add(new TreeViewItem() { Header = j.task });
                            count++;
                        }
                    }
                }
                _page.Show();

                flag = true;
            }
            return flag;
        }
    }
}

