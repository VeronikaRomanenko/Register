using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class RegistryTree : Form
    {
        public RegistryTree()
        {
            InitializeComponent();
            TreeNode node1 = new TreeNode(Registry.ClassesRoot.Name);
            addSubKeys(Registry.CurrentUser, node1);
            treeView1.Nodes.Add(node1);
            TreeNode node2 = new TreeNode(Registry.CurrentConfig.Name);
            addSubKeys(Registry.CurrentUser, node2);
            treeView1.Nodes.Add(node2);
            TreeNode node3 = new TreeNode(Registry.CurrentUser.Name);
            addSubKeys(Registry.CurrentUser, node3);
            treeView1.Nodes.Add(node3);
            TreeNode node4 = new TreeNode(Registry.LocalMachine.Name);
            addSubKeys(Registry.CurrentUser, node4);
            treeView1.Nodes.Add(node4);
            TreeNode node5 = new TreeNode(Registry.Users.Name);
            addSubKeys(Registry.CurrentUser, node5);
            treeView1.Nodes.Add(node5);
        }

        private void addSubKeys(RegistryKey reg, TreeNode node)
        {
            foreach (string item in reg.GetSubKeyNames())
            {
                TreeNode n = new TreeNode(item);
                try
                {
                    RegistryKey reg1 = reg.OpenSubKey(item);
                    addSubKeys(reg1, n);
                }
                catch { }
                node.Nodes.Add(n);
            }
        }
    }
}