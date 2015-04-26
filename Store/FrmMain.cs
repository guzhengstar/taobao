using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.Win.C1Chart;
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
            datetimeRecordStop.Value = datetimeRecordStop.Value.AddDays(1);
        }

        /// <summary>
        /// 进货清单初始化
        /// </summary>
        private void InitialBuyList()
        {
            //WhereExpression expression = new WhereExpression(commodity._.Remain > 0);
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
                newCommodity.Insert();
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

        /// <summary>
        /// 加载库存商品列表窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLoadBuys_Click(object sender, EventArgs e)
        {
            FrmChooseCommodity frmchoose = new FrmChooseCommodity();
            frmchoose.RefreshChooseEvent += frmchoose_RefreshChooseEvent;
            frmchoose.Show(this);
        }

        /// <summary>
        /// 订阅的方法内容
        /// </summary>
        /// <param name="commodityEntity"></param>
        void frmchoose_RefreshChooseEvent(commodity commodityEntity)
        {
            if (commodityEntity != null)
            {
                txtRecordName.Text = commodityEntity.Name + "*" + commodityEntity.Type + "*" + commodityEntity.Color;
                txtRecordCost.Text = commodityEntity.RealPrice.ToString("f");
                txtRecordName.Tag = commodityEntity;
                //commodityEntity.Amount -= 1;
                //commodityEntity.Update();//下单之后库存数量减一
            }
        }

        /// <summary>
        /// 新增订单记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecordAdd_Click(object sender, EventArgs e)
        {
            order orderEntity = new order();
            commodity currentCommodity = txtRecordName.Tag as commodity;
            if (currentCommodity == null)
            {
                MessageBox.Show("请先从库存中选择商品!");
                txtRecordName.Focus();
                return;
            }
            orderEntity.CommodityId = currentCommodity.Id;

            ChangeRecordEntity(orderEntity);

            try
            {
                orderEntity.Insert();
                currentCommodity.Amount -= 1;//库存商品对应减去一件
                currentCommodity.Update();//更新库存记录
                txtRecordName.Tag = null;
                //orderattachment attachment = new orderattachment();
                ////礼品折现
                //attachment.OrderId = orderEntity.Id;
                //attachment.AttachmentTypeId = (int)AttachmentEnum.CashGift;
                //attachment.Money = cashgif;
                //attachment.IsNeed = chkboxRecordGift.Checked ? (sbyte)1 : (sbyte)0;
                //attachment.Insert();
                ////好评折现
                //attachment.AttachmentTypeId = (int)AttachmentEnum.CashBack1;
                //attachment.Money = cashback1;
                //attachment.IsNeed = chkboxRecordCashBack1.Checked ? (sbyte)1 : (sbyte)0;
                //attachment.Insert();
                ////追加折现
                //attachment.AttachmentTypeId = (int)AttachmentEnum.CashBack2;
                //attachment.Money = cashback2;
                //attachment.IsNeed = chkboxRecordCashBack2.Checked ? (sbyte)1 : (sbyte)0;
                //attachment.Insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 给记录实体赋予信息
        /// </summary>
        /// <param name="orderEntity"></param>
        void ChangeRecordEntity(order orderEntity)
        {
            decimal sellingprice = 0;//卖价
            decimal cost = 0;//进价
            decimal cashgif = 0;//礼品折现
            decimal cashback1 = 0;//好评返现
            decimal cashback2 = 0;//追加返现

            if (txtRecordSellingPrice.Text.IsNullOrWhiteSpace() || !decimal.TryParse(txtRecordSellingPrice.Text, out sellingprice))
            {
                MessageBox.Show("下单价格有误!");
                return;
            }
            if (txtRecordCost.Text.IsNullOrWhiteSpace() || !decimal.TryParse(txtRecordCost.Text, out cost))
            {
                MessageBox.Show("商品进价有误!");
                return;
            }
            if (txtRecordGift.Text.IsNullOrWhiteSpace() || !decimal.TryParse(txtRecordGift.Text, out cashgif))
            {
                MessageBox.Show("礼品折现金额有误!");
                return;
            }
            if (txtRecordCashBack1.Text.IsNullOrWhiteSpace() || !decimal.TryParse(txtRecordCashBack1.Text, out cashback1))
            {
                MessageBox.Show("好评返现金额有误!");
                return;
            }
            if (txtRecordCashBack2.Text.IsNullOrWhiteSpace() || !decimal.TryParse(txtRecordCashBack2.Text, out cashback2))
            {
                MessageBox.Show("追加返现金额有误!");
                return;
            }
            decimal realprice = sellingprice - cashgif - cashback1 - cashback2;//实际售价
            decimal profit = realprice - cost;//利润
            orderEntity.RealPrice = realprice;
            orderEntity.SellingPrice = sellingprice;
            orderEntity.Taobao = txtRecordTaobao.Text;
            orderEntity.Truename = txtRecordTruename.Text;
            orderEntity.MobilePhone = txtRecorMobile.Text;
            orderEntity.Profit = profit;
            orderEntity.Cost = cost;
            orderEntity.OrderTime = dateTimeRecord.Value;
            orderEntity.Remark = txtRecordRemark.Text;
            orderEntity.RefreshTime = DateTime.Now;
            //orderEntity.CommodityId = currentCommodity.Id;
            orderEntity.IsCashGift = chkboxRecordGift.Checked ? (sbyte)1 : (sbyte)0;
            orderEntity.IsCashback1 = chkboxRecordCashBack1.Checked ? (sbyte)1 : (sbyte)0;
            orderEntity.IsCashback2 = chkboxRecordCashBack2.Checked ? (sbyte)1 : (sbyte)0;
            orderEntity.CashGift = cashgif;
            orderEntity.Cashback1 = cashback1;
            orderEntity.Cashback2 = cashback2;
        }
        /// <summary>
        /// 修改订单记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecordAlter_Click(object sender, EventArgs e)
        {
            order orderEntity = btnRecordAlter.Tag as order;
            ChangeRecordEntity(orderEntity);
            orderEntity.Update();
        }

        /// <summary>
        /// 删除订单记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecordDelete_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult dialogResult = MessageBox.Show("确认删除该记录?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;
            order orderEntity = btnRecordAlter.Tag as order;
            orderEntity.Delete();
            btnRecordAlter.Tag = null;
        }

        /// <summary>
        /// 点击查询订单记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = datetimeRecordStart.Value;
            DateTime stopdDateTime = datetimeRecordStop.Value;
            if (startDateTime >= stopdDateTime)
            {
                stopdDateTime = startDateTime.AddDays(1);
            }
            string wheresql = "";
            if (chkboxGiftYet.Checked)
            {
                wheresql = " and IsCashGift=0";
            }
            if (chkboxCashback1Yet.Checked)
            {
                wheresql += " and IsCashback1=0";
            }
            if (chkboxCashback2Yet.Checked)
            {
                wheresql += " and IsCashback2=0";
            }
            string sql = string.Format("SELECT * from store.`order` WHERE '{0}' < OrderTime and  OrderTime < '{1}' {2} ", startDateTime.ToString("yyyy-MM-dd"), stopdDateTime.ToString("yyyy-MM-dd"), wheresql);
            List<order> orders = order.FindAll(sql);
            dataGVRecord.Rows.Clear();
            int count = orders.Count;
            btnRecordQuery.Text = "查询(" + count + ")";
            if (count <= 0) return;
            dataGVRecord.Rows.Add(count);
            commodity commodityentity = new commodity();
            for (int i = 0; i < count; i++)
            {

                var orderEntity = orders[i];
                commodityentity = commodity.FindById(orderEntity.CommodityId);
                dataGVRecord.Rows[i].SetValues(orderEntity.Truename, orderEntity.Taobao, commodityentity.Name + "*" + commodityentity.Type + "*" + commodityentity.Color,
                    orderEntity.SellingPrice, orderEntity.RealPrice, orderEntity.Profit, orderEntity.Cost,
                    orderEntity.CashGift + (orderEntity.IsCashGift == 0 ? "(×)" : "(√)"), orderEntity.Cashback1 + (orderEntity.IsCashback1 == 0 ? "(×)" : "(√)"),
                    orderEntity.Cashback2 + (orderEntity.IsCashback2 == 0 ? "(×)" : "(√)"), orderEntity.Remark, orderEntity.OrderTime);
                dataGVRecord.Rows[i].Tag = orderEntity;
            }
            int width = dataGVRecord.Width / 12;  //datagridview colunms width adjust
            for (int i = 0; i < 12; i++)
            {
                dataGVRecord.Columns[i].Width = width - 3;
            }
        }

        /// <summary>
        /// 销售记录单点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            order orderEntity = dataGVRecord.Rows[rowIndex].Tag as order;
            if (orderEntity != null)
            {
                txtRecorMobile.Text = orderEntity.MobilePhone;
                txtRecordCashBack1.Text = orderEntity.Cashback1.ToString("f");
                txtRecordCashBack2.Text = orderEntity.Cashback2.ToString("f");
                txtRecordGift.Text = orderEntity.CashGift.ToString("f");
                txtRecordName.Text = dataGVRecord.Rows[rowIndex].Cells[2].Value.ToString();
                txtRecordCost.Text = orderEntity.Cost.ToString("f");
                txtRecordRemark.Text = orderEntity.Remark;
                txtRecordSellingPrice.Text = orderEntity.SellingPrice.ToString("f");
                txtRecordTaobao.Text = orderEntity.Taobao;
                txtRecordTruename.Text = orderEntity.Truename;
                btnRecordAlter.Tag = orderEntity;
                chkboxRecordGift.Checked = orderEntity.IsCashGift == 0 ? false : true;
                chkboxRecordCashBack1.Checked = orderEntity.IsCashback1 == 0 ? false : true;
                chkboxRecordCashBack2.Checked = orderEntity.IsCashback2 == 0 ? false : true;
                dateTimeRecord.Value = orderEntity.OrderTime;
            }
        }

        /// <summary>
        /// 查询收益曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinaceQuery_Click(object sender, EventArgs e)
        {
            string startmonth = DateTime.Today.AddDays(-DateTime.Today.Day + 1).ToString("yyyy-MM-dd");
            List<order> orders = order.FindAll(string.Format("SELECT * from store.`order` WHERE OrderTime >  '{0}'", startmonth));
            if (orders.Count != 0)  //如果有数据
            {
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[0].X.Clear();
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[0].Y.Clear();
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[1].X.Clear();
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[1].Y.Clear();
                c1Chart1.ChartLabels.LabelsCollection.Clear();
            }

            for (int i = 0; i < orders.Count; i++)
            {
                // 为c1Chart1赋值
                double time = orders[i].OrderTime.Day + orders[i].OrderTime.Hour/24;
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[0].X.Add(time);
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[0].Y.Add(orders[i].Profit);
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[1].X.Add(time);
                c1Chart1.ChartGroups.ChartGroupsCollection[0].ChartData.SeriesList[1].Y.Add(orders[i].Cost);

                c1Chart1.ChartLabels.LabelsCollection.AddNewLabel();
                int labCount = c1Chart1.ChartLabels.LabelsCollection.Count - 1;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethod = AttachMethodEnum.DataCoordinate;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.GroupIndex = 0;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.SeriesIndex = 0;
                c1Chart1.ChartLabels.LabelsCollection[labCount].Offset = 12;
                c1Chart1.ChartLabels.LabelsCollection[labCount].Compass = LabelCompassEnum.Auto;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.X = time;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.Y = Convert.ToDouble(orders[i].Profit);
                c1Chart1.ChartLabels.LabelsCollection[labCount].Visible = true;
                c1Chart1.ChartLabels.LabelsCollection[labCount].Connected = true;
                c1Chart1.ChartLabels.LabelsCollection[labCount].TooltipText = orders[i].OrderTime.ToString("M-d HH:dd") + "\r\n收益" + orders[i].Profit.ToString("F1");
                c1Chart1.ChartLabels.LabelsCollection[labCount].Text = orders[i].Profit.ToString("F1");

                //添加理论功率label
                c1Chart1.ChartLabels.LabelsCollection.AddNewLabel();
                labCount = c1Chart1.ChartLabels.LabelsCollection.Count - 1;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethod = AttachMethodEnum.DataCoordinate;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.GroupIndex = 0;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.SeriesIndex = 1;
                c1Chart1.ChartLabels.LabelsCollection[labCount].Offset = 12;
                c1Chart1.ChartLabels.LabelsCollection[labCount].Compass = LabelCompassEnum.Auto;
                c1Chart1.ChartLabels.LabelsCollection[labCount].TooltipText = orders[i].OrderTime.ToString("M-d HH:dd") + "\r\n成本" + orders[i].Cost.ToString("F1");
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.X = time;
                c1Chart1.ChartLabels.LabelsCollection[labCount].AttachMethodData.Y = Convert.ToDouble(orders[i].Cost);
                c1Chart1.ChartLabels.LabelsCollection[labCount].Visible = true;
                c1Chart1.ChartLabels.LabelsCollection[labCount].Connected = true;
                c1Chart1.ChartLabels.LabelsCollection[labCount].Text = orders[i].Cost.ToString("F1"); 

                //mins = time.Minute + 5; //当前分钟加5
                //hour = time.Hour; //刷新小时

            }
        }


    }
}
