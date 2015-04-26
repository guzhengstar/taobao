using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Store
{
    public partial class FrmChooseCommodity : Form
    {

        public delegate void RefreshChooseHandler(commodity commodityEntity) ;//定义刷新选择项委托
        public event RefreshChooseHandler RefreshChooseEvent;

        public FrmChooseCommodity()
        {
            InitializeComponent();
            InitialBuyList();
        }

        public FrmChooseCommodity(DataGridView grid)
            : this()
        {
        }


        /// <summary>
        /// 进货清单初始化
        /// </summary>
        private void InitialBuyList()
        {
            //WhereExpression expression = new WhereExpression(commodity._.Remain > 0);
            //List<commodity> buys = commodity.FindAll(expression, null, null, 0, 10);
            List<commodity> buys = commodity.FindAll("SELECT * from commodity WHERE Remain>0  ");
            datagrid.Rows.Clear();
            int count = buys.Count;

            datagrid.Rows.Add(count);
            for (int i = 0; i < count; i++)
            {
                var buyEntity = buys[i];
                datagrid.Rows[i].SetValues(buyEntity.Name, buyEntity.Type, buyEntity.Color, buyEntity.RealPrice, buyEntity.Amount, buyEntity.Remain
                    , buyEntity.CreateTime);
                datagrid.Rows[i].Tag = buyEntity;
            }
            int width = datagrid.Width / 7;  //datagridview colunms width adjust
            for (int i = 0; i < 7; i++)
            {
                datagrid.Columns[i].Width = width - 4;
            }
        }

        private void btnChooseCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认选择按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseOK_Click(object sender, EventArgs e)
        {
            if (RefreshChooseEvent != null)//判断时间是否订阅了
            {
                RefreshChooseEvent(datagrid.SelectedRows[0].Tag as commodity);//触发回掉事件
            }
            this.Close();
        }
    }
}
