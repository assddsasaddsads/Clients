using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratornaya20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowClient();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewList.SelectedItems.Count == 1)
            {
                Client client = listViewList.SelectedItems[0].Tag as Client;
                textBoxName.Text = client.Name;
                textBoxPhone.Text = client.Phone;
            }
            else
            {
                textBoxName.Text = "";
                textBoxPhone.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Name = textBoxName.Text;
            client.Phone = textBoxPhone.Text;
            Program.wfcl.Client.Add(client);
            Program.wfcl.SaveChanges();
            ShowClient();
        }
        void ShowClient()
        {
            listViewList.Items.Clear();
            foreach (Client client in Program.wfcl.Client)
            {
                ListViewItem item = new ListViewItem(new string[]
                    {
                        client.Name,
                        client.Phone
                    });
                item.Tag = client;
                listViewList.Items.Add(item);
            }
            listViewList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if(listViewList.SelectedItems.Count ==1)
                {
                    Client client = listViewList.SelectedItems[0].Tag as Client;
                    Program.wfcl.Client.Remove(client);
                    Program.wfcl.SaveChanges();
                    ShowClient();
                }
                textBoxName.Text = "";
                textBoxPhone.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
