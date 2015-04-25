using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewLife.Log;
using XCode;

namespace Store
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitialBuyList();
        }

        /// <summary>
        /// 进货清单初始化
        /// </summary>
        private void InitialBuyList()
        {
            WhereExpression expression = new WhereExpression(commodity._.Remain > 0);
            //List<commodity> buys = commodity.FindAll(expression, null, null, 0, 10);
            List<commodity> buys = commodity.FindAll("SELECT * from commodity WHERE Remain>0 ");
            dataGVBuy.Rows.Clear();
            int count = buys.Count;

            dataGVBuy.Rows.Add(count);
            for (int i = 0; i < count; i++)
            {
                var buyEntity = buys[i];
                dataGVBuy.Rows[i].SetValues(buyEntity.Name, buyEntity.Type, buyEntity.Color, buyEntity.RealPrice, buyEntity.Amount, buyEntity.Remain
                    , buyEntity.CreateTime);
                dataGVBuy.Rows[i].Tag = buyEntity;
            }
            int width = dataGVBuy.Width / 7;  //datagridview colunms width adjust
            for (int i = 0; i < 7; i++)
            {
                dataGVBuy.Columns[i].Width = width - 4;
            }
        }

        /// <summary>
        /// 修改进货商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuyAlter_Click(object sender, EventArgs e)
        {
            commodity buyentity = btnBuyAlter.Tag as commodity;
            if (buyentity == null) return;
            decimal realprice = 0;
            short amount = Convert.ToInt16(numUDBuyAmount.Value);
            if (txtBuyRealPrice.Text.IsNullOrWhiteSpace() || !decimal.TryParse(txtBuyRealPrice.Text, out realprice))
            {
                MessageBox.Show("单价有误!");
                return;
            }
            buyentity.Name = txtBuyName.Text;
            buyentity.Type = txtBuyType.Text;
            buyentity.RealPrice = realprice;
            buyentity.Amount = amount;
            buyentity.Remain = Convert.ToInt16(txtBuyRemain.Text);//剩余数量
            buyentity.Color = txtBuyColor.Text;
            buyentity.CreateTime = dateTimeBuy.Value;
            try
            {
                int aa = buyentity.Update();
                InitialBuyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                XTrace.WriteException(ex);
            }
            lblBuyRemain.Visible = txtBuyRemain.Visible = false;
        }

        /// <summary>
        /// 新增进货商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuyAdd_Click(object sender, EventArgs e)
        {
            commodity newCommodity = new commodity();
            decimal realprice = 0;
            short amount = Convert.ToInt16(numUDBuyAmount.Value);
            if (txtBuyRealPrice.Text.IsNullOrWhiteSpace() || !decimal.TryParse(txtBuyRealPrice.Text, out realprice))
            {
                MessageBox.Show("单价有误!");
                return;
            }
            newCommodity.Name = txtBuyName.Text;
            newCommodity.Type = txtBuyType.Text;
            newCommodity.RealPrice = realprice;
            newCommodity.Amount = amount;
            newCommodity.Remain = amount;//剩余数量
            newCommodity.Color = txtBuyColor.Text;
            newCommodity.CreateTime = dateTimeBuy.Value;
            try
            {
                int aa = newCommodity.Insert();
                InitialBuyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                XTrace.WriteException(ex);
            }

        }
        /// <summary>
        /// 删除进货商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuyDelete_Click(object sender, EventArgs e)
        {
            commodity buyentity = btnBuyAlter.Tag as commodity;
            if (buyentity != null)
            {
                buyentity.Delete();
                InitialBuyList();
                lblBuyRemain.Visible = txtBuyRemain.Visible = false;
            }
        }
        /// <summary>
        /// 点击进货单元格获取进货信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGVBuy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            commodity buyEntity = dataGVBuy.Rows[rowIndex].Tag as commodity;
            if (buyEntity != null)
            {
                txtBuyName.Text = buyEntity.Name;
                txtBuyColor.Text = buyEntity.Color;
                txtBuyRealPrice.Text = buyEntity.RealPrice.ToString("f");
                txtBuyType.Text = buyEntity.Type;
                txtBuyRemain.Text = buyEntity.Remain.ToString();
                numUDBuyAmount.Value = buyEntity.Amount;
                dateTimeBuy.Value = buyEntity.CreateTime;
                btnBuyAlter.Tag = buyEntity;//将实体放入修改按钮tag中,如果是修改可以直接拿过去用了
                lblBuyRemain.Visible = txtBuyRemain.Visible = true;
            }
        }


    }
}
