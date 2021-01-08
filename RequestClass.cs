using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureServerState
{
    public class RequestClass
    {
        /// <summary>
        /// 业务类型 ‘1’-新增订单  '0'-撤销订单
        /// </summary>
        public string businessType { get; set; }
        /// <summary>
        /// 客户端用户
        /// </summary>
        public string user { get; set; }
        /// <summary>
        /// 期货代码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 委托方向 "1"-多  "2"-空
        /// </summary>
        public string direction { get; set; }
        /// <summary>
        /// 委托价格
        /// </summary>
        public string entrust_price { get; set; }
        /// <summary>
        /// 委托数量
        /// </summary>
        public string entrust_amount { get; set; }
        /// <summary>
        /// 委托价格类型   ‘0’-限价
        /// </summary>
        public string priceType { get; set; } = "0";

        /// <summary>
        /// 订单状态
        /// </summary>
        public string orderState { get; set; }

        /// <summary>
        /// 客户端自定义编号
        /// </summary>
        public string clordId { get; set; }
        /// <summary>
        /// 委托序号，撤销委托需要填写
        /// </summary>
        public string entrust_no { get; set; }

        /// <summary>
        /// 错误原因
        /// </summary>
        public string error_info { get; set; }

        /// <summary>
        /// 队列名称
        /// </summary>
        public string queue_name { get; set; }

        /// <summary>
        /// 累计成交数量
        /// </summary>
        public string deal_amount { get; set; }

        /// <summary>
        /// 累计成交金额
        /// </summary>
        public string deal_balance { get; set; }

        /// <summary>
        /// 成交均价
        /// </summary>
        public string deal_price { get; set; }

        /// <summary>
        /// 原始价格
        /// </summary>
        public string original_price { get; set; }

        /// <summary>
        /// 委托方向
        /// </summary>
        public string entrust_direction { get; set; }
        /// <summary>
        /// 开平方向
        /// </summary>
        public string futures_direction { get; set; }

        /// <summary>
        /// 单次成交数量
        /// </summary>
        public string onetime_deal_amount { get; set; }

        /// <summary>
        /// 单次成交金额
        /// </summary>
        public string onetime_deal_balance { get; set; }

        public bool IsSelected { get; set; } = false;

        public string addInfo1 { get; set; }
        public string addInfo2 { get; set; }
        public string addInfo3 { get; set; }
        public string addInfo4 { get; set; }
        public string addInfo5 { get; set; }
    }
}
