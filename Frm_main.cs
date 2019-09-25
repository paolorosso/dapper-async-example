using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace DapperAsync
{
    public partial class Frm_main : Form
    {
        public Frm_main()
        {
            InitializeComponent();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {

        }

        private void Frm_main_Shown(object sender, EventArgs e)
        {
            loadData();
        }


        private async void loadData()
        {
            progressBar1.Visible = true;

            try
            {
                List<Model.Data> data = null;

                data = await loadDataAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            label1.Text = "Complete";
            progressBar1.Visible = false;

        }

        private async Task<List<Model.Data>> loadDataAsync()
        {
            await Task.Delay(4000);

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(LOAD.ConnDb))
            {
                var res = await db.QueryAsync<Model.Data>("SELECT * FROM Table");

                return res.ToList();
            }
        }

    }
}
