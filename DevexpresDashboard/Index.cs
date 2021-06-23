using Dapper;
using DevexpresDashboard.Helpers;
using DevexpresDashboard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DevexpresDashboard
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            string sql = "SELECT OBJECT_NAME(ips.object_id) AS TableName,i.name AS IndexName,ips.index_id AS IndexID,index_type_desc AS IndexType,avg_fragmentation_in_percent AS Fragmantation,avg_page_space_used_in_percent,page_count AS UsedSpace FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, 'SAMPLED') ips INNER JOIN sys.indexes i ON(ips.object_id = i.object_id) AND (ips.index_id = i.index_id) ORDER BY avg_fragmentation_in_percent DESC; ";

            IEnumerable<IndexInfo> indexInfos;
            using (var connection = CustomDBFactory.GetConnection())
            {
                //DynamicParameters dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add("@TableName", "asdasd");
                indexInfos = connection.Query<IndexInfo>(sql);
            }
            dataGridView1.DataSource = indexInfos;

        }

        public object CheckBoxColumn1 { get; private set; }

        public void button_rebuild_Click(object sender, EventArgs e)
        {
            string sql = "USE [nSoft.Document]GO ALTER INDEX[IX4] ON[dbo].[SaleInvoice] REBUILD PARTITION = ALL WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70)GO";

            IEnumerable<IndexInfo> indexInfos;
            using (var connection = CustomDBFactory.GetConnection())
            {
                //DynamicParameters dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add("@TableName", "asdasd");
                indexInfos = connection.Query<IndexInfo>(sql);
            }
         
        }

        private void RebuildEt_Click(object sender, EventArgs e)
        {
            string sql = "USE [nSoft.Document]GO ALTER INDEX[IX4] ON[dbo].[SaleInvoice] REBUILD PARTITION = ALL WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, ONLINE = ON, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70)GO";
            IEnumerable<IndexInfo> indexInfos;
            using (var connection = CustomDBFactory.GetConnection())
            {
                //DynamicParameters dynamicParameters = new DynamicParameters();
                //dynamicParameters.Add("@TableName", "asdasd");
                indexInfos = connection.Query<IndexInfo>(sql);
            }

        }
    }
}
