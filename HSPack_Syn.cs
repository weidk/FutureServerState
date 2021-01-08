using CTPsysinfo;
using hundsun.mcapi;
using hundsun.t2sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FutureServerState
{
    #region 输入输出参数

    //——————————登录参数———————————
    public class Login_Input_O32
    {
        //输入参数
        public string in_operator_no;
        public string in_password;
        public string in_mac_address;
        public string in_station_add;
        public string in_ip_address;
        public string authorization_id;
        public string app_id;
        public string authorize_code;
        public string port_id;
    }

    public class Login_Output_O32
    {
        //输出参数
        public string out_error_no;
        public string out_error_info;

        public string out_user_token;
    }

    //——————————34001 资产账户查询参数——————————————
    public class AssetInfo_Input
    {
        public string user_token;
        public string account_code;
        public string asset_no;
        public string combi_no;
    }

    public class AssetInfo_Output
    {
        //账户编号
        //资产单元编号
        //T+0可用资金
        //T+1可用资金
        public string out_error_no;
        public string out_error_info;
        public string account_code;
        public string asset_no;
        public double enable_balance_t0;
        public double enable_balance_t1;

    }


    //——————————————委托确认参数———————————————
    public class SendOrder_Input_O32
    {
        //输入参数
        public string in_user_token; //用户口令
        public string in_batch_no; //委托批号
        public string in_account_code; //账户编号
        public string in_asset_no; //资产编号
        public string in_combi_no; //组合编号
        public string in_stockholder_id; //股东代码
        public string in_report_seat; //申报席位
        public string in_market_no; //交易市场
        public string in_stock_code; //证券代码
        public string in_entrust_direction; //委托方向
        public string in_price_type; //委托价格类型
        public string in_entrust_amount; //委托数量
        public string in_entrust_price; //委托价格
        public string in_invest_way; //投资类型
        public string in_payoff_direction; //平仓方向
        public string in_out_extsystem_id;


    }
    public class SendOrder_Output_O32
    {
        //输出参数
        public string out_error_no;
        public string out_error_info;
        public string out_entrust_no;
        public string out_batch_no;
        public string out_extsystem_id;
        public string out_entrust_fail_code; //委托失败代码
        public string out_fail_cause; //  失败原因
        public string out_risk_serial_no; //风控判断流水号

    }

    //————————————30001 账户查询参数————————————
    public class Fundqry_in
    {
        public string in_user_token;
        public string in_account_code;
    }

    public class Fundqry_out
    {
        public string out_error_no;
        public string out_error_info;
        public string out_account_code;
        public string out_account_name;
        public string out_account_type;
    }



    //————————————32001 委托查询参数——————————————
    public class SendedOrder_Input_O32
    {
        public string in_user_token;	//用户口令
        public string in_batch_no;	//委托批号
        public string in_entrust_no;	//委托编号
        public string in_account_code;	//账户编号
        public string in_asset_no;	//资产单元编号
        public string in_combi_no;	//组合编号
        public string in_stockholder_id;//股东代码
        public string in_market_no;	//交易市场
        public string in_stock_code;//证券代码
        public string in_entrust_direction;	//委托方向
        public string in_entrust_state_list;	//委托状态
        public string in_extsystem_id;//第三方系统自定义号
        public string in_third_reff;//第三方系统自定义说明
        public string in_position_str;	//定位串
        public string in_request_num;//请求数

    }


    public class SendedOrder_Output_O32
    {
        public string out_error_no;
        public string out_error_info;
        public string out_entrust_date;//委托日期
        public string out_entrust_time;//委托时间
        public string out_operator_no;//操作员编号
        public string out_batch_no;//委托批号
        public string out_entrust_no;//委托编号
        public string out_report_no;//申报编号
        public string out_extsystem_id;//第三方系统自定义号
        public string out_third_reff;//第三方系统自定义说明
        public string out_account_code;//账户编号
        public string out_asset_no;//资产单元编号
        public string out_combi_no;//组合编号
        public string out_stockholder_id;//股东代码
        public string out_report_seat;//申报席位
        public string out_market_no;//交易市场
        public string out_stock_code;//证券代码
        public string out_entrust_direction;//	委托方向
        public string out_price_type;//委托价格类型
        public string out_entrust_price;//	委托价格
        public string out_entrust_amount;//	委托数量
        public string out_pre_buy_frozen_balance;//	预买冻结金额
        public string out_pre_sell_balance;//	预卖金额
        public string out_confirm_no;//	委托确认号
        public string out_entrust_state;//C1	委托状态
        public string out_first_deal_time;//	N6	首次成交时间
        public string out_deal_amount;//N16	成交数量
        public string out_deal_balance;//N16.2	成交金额
        public string out_deal_price;//N11.4	成交均价
        public string out_deal_times;//N6	分笔成交次数
        public string out_withdraw_amount;//	N16	撤单数量
        public string out_withdraw_cause;//C256	撤单原因
        public string out_position_str;//C32	定位串

    }



    //————————————91101 委托撤单参数——————————————

    public class SendWtd_Input_O32
    {
        public string in_user_token;//C512	令牌号	Y
        public string in_entrust_no;//	N8	委托序号	Y
    }

    public class SendWtd_Output_O32
    {
        public string out_error_no;
        public string out_error_info;
        public string out_entrust_no;//N8	委托序号
        public string out_market_no;//C3	交易市场
        public string out_stock_code;//C16	证券代码
        public string out_success_flag;//C1	撤单成功标志
        public string out_fail_cause;//C256	失败原因
    }


    //————————————33001 证券成交查询参数——————————————
    public class DealQry_Input
    {
        public string in_user_token;//C512	令牌号
        public string in_account_code;//C32	账户编号
        public string in_asset_no;//C16	资产单元编号
        public string in_combi_no;//C8	组合编号
        public string in_entrust_no;//N8	委托编号
        public string in_deal_no;//C64	;成交编号
        public string in_stockholder_id;//C20	股东代码
        public string in_market_no;//C3	交易市场
        public string in_stock_code;//C16	证券代码
        public string in_entrust_direction;//C3	委托方向
        public string in_extsystem_id;//N8	第三方系统自定义号
        public string in_third_reff;//C256	第三方系统自定义说明
        public string in_position_str;//C32	定位串
        public string in_request_num;	//N8	请求数

    }

    public class DealQry_Output
    {
        public string out_error_no;
        public string out_error_info;
        public string out_deal_date;//N8	成交日期
        public string out_deal_no;//C64	成交编号
        public string out_entrust_no;//	N8	委托编号
        public string out_extsystem_id;//	N8	第三方系统自定义号
        public string out_third_reff;//	C256	第三方系统自定义说明
        public string out_account_code;//	C32	账户编号
        public string out_asset_no;//C16	资产单元编号
        public string out_combi_no;//C8	组合编号
        public string out_instance_no;//	C128	交易实例编号
        public string out_stockholder_id;//	C20	股东代码
        public string out_market_no;//C3	交易市场
        public string out_stock_code;//C16	证券代码
        public string out_entrust_direction;//C3	委托方向
        public string out_deal_amount;//	N16	成交数量
        public string out_deal_price;//N11.4	成交价格
        public string out_deal_balance;//	N16.2	成交金额
        public string out_total_fee;//	N16.2	总费用
        public string out_deal_time;//N6	成交时间
        public string out_position_str;//	C32	定位串

    }


    //——————————————91004 期货委托 —————————————————

    public class FutureEntrust_Input
    {
        public string in_user_token;//C512	令牌号
        public string in_batch_no;//N8	委托批号
        public string in_account_code;//	C32	账户编号
        public string in_asset_no;//C16	资产单元编码
        public string in_combi_no;//C8	组合编号
        public string in_stockholder_id;//	C20	股东代码
        public string in_market_no;//	C3	交易市场
        public string in_stock_code;//C16	证券代码
        public string in_entrust_direction;//C3	委托方向
        public string in_futures_direction;//C1	开平方向
        public string in_price_type;//C1	委托价格类型
        public string in_entrust_price;//	N11.4	委托价格
        public string in_entrust_amount;//N16.2	委托数量
        public string in_limit_deal_amount;//	N12	最小成交量
        public string in_extsystem_id;//N8	第三方系统自定义号
        public string in_third_reff;//C256	第三方系统自定义说明

    }

    public class FutureEntrust_Output
    {
        public string out_error_no;
        public string out_error_info;
        public string out_batch_no;//	N8	委托批号
        public string out_entrust_no;//	N8	委托编号
        public string out_extsystem_id;//	N8	第三方系统自定义号
        public string out_entrust_fail_code; //委托失败代码
        public string out_fail_cause; //  失败原因
        public string out_risk_serial_no; //风控判断流水号
    }

    //——————————————91005 期货委托撤单————————————————

    public class FutureentrustWithdraw_Input
    {
        public string in_user_token;//	C512	令牌号
        public string in_entrust_no;//	N8	委托序号
        public string account_code;//	账户编号
        public string combi_no;//	组合编号
    }

    public class FutureentrustWithdraw_Output
    {
        public string out_error_no;
        public string out_error_info;
        public string out_entrust_no;//	N8	委托序号
        public string out_market_no;//	C3	交易市场
        public string out_stock_code;//	C16	证券代码
        public string out_success_flag;//C1	撤单成功标志
        public string out_fail_cause;//C256	失败原因

    }


    //——————————————31003 期货持仓查询————————————————
    public class FuturepositionQry_Input
    {
        public string in_user_token;//C512	令牌号
        public string in_account_code;//C32	账户编号
        public string in_asset_no;//C16	资产单元编号
        public string in_combi_no;//C8	组合编号
        public string in_market_no;//	C3	交易市场
        public string in_stock_code;//C16	证券代码
        public string in_stockholder_id;//	C20	股东代码
        public string in_hold_seat;//C6	持仓席位
        public string in_invest_type;//C1	投资类型
        public string in_position_flag;//C1	多空标志

    }

    public class FuturepositionQry_Output
    {
        public string out_error_no { get; set; }
        public string out_error_info { get; set; }
        public string out_account_code { get; set; }//C32	账户编号
        public string out_asset_no { get; set; }//C16	资产单元编号
        public string out_combi_no { get; set; }//C8	组合编号
        public string out_market_no { get; set; }//C3	交易市场
        public string out_stock_code { get; set; }//C16	证券代码
        public string out_stockholder_id { get; set; }//	C20	股东代码
        public string out_hold_seat { get; set; }//	C6	持仓席位
        public string out_position_flag { get; set; }//	C1	多空标志
        public string out_invest_type { get; set; }//C1	投资类型
        public string out_current_amount { get; set; }//	N16	当前数量
        public string out_enable_amount { get; set; }//N16	可用数量
        public string out_begin_cost { get; set; }//	N16.2	期初成本
        public string out_current_cost { get; set; }//N16.2	当前成本
        public string out_current_cost_price { get; set; }//	N9.3	当前成本价
        public string out_pre_buy_amount { get; set; }//	N16	开仓挂单数量
        public string out_pre_sell_amount { get; set; }//N16	平仓挂单数量
        public string out_pre_buy_balance { get; set; }//N16.2	开仓挂单金额
        public string out_pre_sell_balance { get; set; }//	N16.2	平仓挂单金额
        public string out_buy_amount { get; set; }//N16	当日开仓数量
        public string out_sell_amount { get; set; }//N16	当日平仓数量
        public string out_buy_balance { get; set; }//N16.2	当日开仓金额
        public string out_sell_balance { get; set; }//N16.2	当日平仓金额
        public string out_buy_fee { get; set; }//	N16.2	当日开仓费用
        public string out_sell_fee { get; set; }//N16.2	当日平仓费用

        public string out_accumulate_profit { get; set; }//N16.2	实现盈亏

    }


    //———————————————32003 期货委托查询————————————————
    public class FutureentrustQry_Input
    {
        public string in_user_token;//	C512	用户口令
        public string in_batch_no;//N8	委托批号
        public string in_entrust_no;//	N8	委托编号
        public string in_account_code;//	C32	账户编号
        public string in_asset_no;//C16	资产单元编号
        public string in_combi_no;//C8	组合编号
        public string in_stockholder_id;//C20	股东代码
        public string in_market_no;//C3	交易市场
        public string in_stock_code;//	C16	证券代码
        public string in_entrust_direction;//C3	委托方向
        public string in_futures_direction;//C1	开平方向
        public string in_entrust_state_list;//C256	委托状态
        public string in_extsystem_id;//N8	第三方系统自定义号
        public string in_third_reff;//	C256	第三方系统自定义说明
        public string in_position_str;//	C32	定位串
        public string in_request_num;//	N8	请求数

    }


    public class FutureentrustQry_Output
    {
        public string out_error_no { get; set; }
        public string out_error_info { get; set; }
        public string out_entrust_date { get; set; }//	N8	委托日期
        public string out_entrust_time { get; set; }//N6	委托时间
        public string out_operator_no { get; set; }//	C16	操作员编号
        public string out_batch_no { get; set; }//N8	委托批号
        public string out_entrust_no { get; set; }//	N8	委托编号
        public string out_report_no { get; set; }//	C64	申报编号
        public string out_extsystem_id { get; set; }//	N8	第三方系统自定义号
        public string out_third_reff { get; set; }//C256	第三方系统自定义说明
        public string out_account_code { get; set; }//	C32	账户编号
        public string out_asset_no { get; set; }//	C16	资产单元编号
        public string out_combi_no { get; set; }//C8	组合编号
        public string out_stockholder_id { get; set; }//	C20	股东代码
        public string out_report_seat { get; set; }//	C6	申报席位
        public string out_market_no { get; set; }//C3	交易市场
        public string out_stock_code { get; set; }//	C16	证券代码
        public string out_entrust_direction { get; set; }//C3	委托方向
        public string out_futures_direction { get; set; }//C1	开平方向
        public string out_price_type { get; set; }//C1	委托价格类型
        public string out_entrust_price { get; set; }//	N11.4	委托价格
        public string out_entrust_amount { get; set; }//N16.2	委托数量
        public string out_pre_buy_frozen_balance { get; set; }//	N16.2	预买冻结金额
        public string out_pre_sell_balance { get; set; }//	N16.2	预卖金额
        public string out_confirm_no { get; set; }//C32	委托确认号
        public string out_entrust_state { get; set; }//C1	委托状态
        public string out_first_deal_time { get; set; }//N6	首次成交时间
        public string out_deal_amount { get; set; }//N16	成交数量
        public string out_deal_balance { get; set; }//N16.2	成交金额
        public string out_deal_price { get; set; }//N11.4	成交均价
        public string out_deal_times { get; set; }//N6	分笔成交次数
        public string out_withdraw_amount { get; set; }//	N16	撤单数量
        public string out_withdraw_cause { get; set; }//	C256	撤单原因
        public string out_position_str { get; set; }//	C32	定位串

    }


    //————————————————33003 期货成交查询 ————————————————
    public class FuturedealQry_Input
    {
        public string in_user_token;//	C512	令牌号
        public string in_account_code;//C32	账户编号
        public string in_asset_no;//C16	资产单元编号
        public string in_combi_no;//	C8	组合编号
        public string in_entrust_no;//N8	委托编号
        public string in_deal_no;//C64	成交编号
        public string in_stockholder_id;//	C20	股东代码
        public string in_market_no;//	C3	交易市场
        public string in_stock_code;//	C16	证券代码
        public string in_entrust_direction;//	C3	委托方向
        public string in_futures_direction;//C1	开平方向
        public string in_extsystem_id;//N8	第三方系统自定义号
        public string in_third_reff;//C256	第三方系统自定义说明
        public string in_position_str;//C32	定位串
        public string in_request_num;//	N8	请求数

    }

    public class FuturedealQry_Output
    {
        public string out_error_no;
        public string out_error_info;
        public string out_deal_date;//	N8	成交日期
        public string out_deal_no;//C64	成交编号
        public string out_entrust_no;//	N8	委托编号
        public string out_extsystem_id;//	N8	第三方系统自定义号
        public string out_third_reff;//	C256	第三方系统自定义说明
        public string out_account_code;//C32	账户编号
        public string out_asset_no;//C16	资产单元编号
        public string out_combi_no;//	C8	组合编号
        public string out_instance_no;//C128	交易实例编号
        public string out_stockholder_id;//	C20	股东代码
        public string out_market_no;//C3	交易市场
        public string out_stock_code;//C16	证券代码
        public string out_entrust_direction;//	C3	委托方向
        public string out_futures_direction;//	C1	开平方向
        public string out_deal_amount;//N16	成交数量
        public string out_deal_price;//N11.4	成交价格
        public string out_deal_balance;//	N16.2	成交金额
        public string out_total_fee;//	N16.2	总费用
        public string out_deal_time;//	N6	成交时间
        public string out_position_str;//	C32	定位串

    }

    //————————————————34003 期货保证金查询 ————————————————
    public class FuturedepositQry_Input
    {
        public string in_user_token;//	C512	令牌号
        public string in_account_code;//	C32	账户编号
        public string in_asset_no;//	C16	资产单元编号
        public string in_combi_no;//	C8	组合编号


    }

    public class FuturedepositQry_Output
    {
        public string out_error_no;
        public string out_error_info;
        public string out_account_code;//C32	账户编号
        public string out_asset_no;//C16	资产单元编号
        public string out_occupy_deposit_balance;//N16.2	占用保证金
        public string out_enable_deposit_balance;//N16.2	可用保证金

    }

    //————————————————31001  现货持仓查询  ————————————————

    public class positionQry_Input
    {
        public string in_user_token;//	C512	令牌号
        public string in_account_code;//	C32	账户编号
        public string in_asset_no;//C16	资产单元编号
        public string in_combi_no;//C8	组合编号
        public string in_market_no;//C3	交易市场
        public string in_stock_code;//C16	证券代码
        public string in_stockholder_id;//	C20	股东代码
        public string in_hold_seat;//C6	持仓席位
    }

    public class positionQry_Output
    {
        public string out_error_no;
        public string out_error_info;
        public string out_account_code;//C32	账户编号
        public string out_asset_no;//C16	资产单元编号
        public string out_combi_no;//C8	组合编号
        public string out_market_no;//	C3	交易市场
        public string out_stock_code;//C16	证券代码
        public string out_stockholder_id;//C20	股东代码
        public string out_hold_seat;//C6	持仓席位
        public string out_invest_type;//C1	投资类型
        public string out_current_amount;//N16	当前数量
        public string out_enable_amount;//	N16	可用数量
        public string out_begin_cost;//N16.2	期初成本
        public string out_current_cost;//N16.2	当前成本
        public string out_pre_buy_amount;//N16	买挂单数量
        public string out_pre_sell_amount;//N16	卖挂单数量
        public string out_pre_buy_balance;//N16.2	买挂单金额
        public string out_pre_sell_balance;//	N16.2	卖挂单金额
        public string out_buy_amount;//	N16	当日买入数量
        public string out_sell_amount;//	N16	当日卖出数量
        public string out_buy_balance;//	N16.2	当日买入金额
        public string out_sell_balance;//	N16.2	当日卖出金额
        public string out_buy_fee;//N16.2	当日买费用
        public string out_sell_fee;//N16.2	当日卖费用

    }

    //——————————————91008 基金委托 —————————————————

    public class FundEntrust_Input
    {
        public string in_user_token;//C512	令牌号
        public string in_batch_no;//N8	委托批号
        public string in_account_code;//	C32	账户编号
        public string in_asset_no;//C16	资产单元编码
        public string in_combi_no;//C8	组合编号
        public string in_stockholder_id;//	C20	股东代码
        public string in_market_no;//	C3	交易市场
        public string in_stock_code;//C16	证券代码
        public string in_entrust_direction;//C3	委托方向
        public string in_entrust_price;//	N11.4	委托价格
        public string in_entrust_balance;//	N11.4	委托金额，LOF申购必填，其他业务该字段无效
        public string in_purchase_way;//	申赎方式
        public string in_entrust_amount;//N16.2	委托数量
        public string in_limit_deal_amount;//	N12	最小成交量
        public string in_extsystem_id;//N8	第三方系统自定义号
        public string in_third_reff;//C256	第三方系统自定义说明

    }

    public class FundEntrust_Output
    {
        public string out_error_no;
        public string out_error_info;
        public string out_batch_no;//	N8	委托批号
        public string out_entrust_no;//	N8	委托编号
        public string out_extsystem_id;//	N8	第三方系统自定义号
        public string out_entrust_fail_code; //委托失败代码
        public string out_fail_cause; //  失败原因
        public string out_risk_serial_no; //风控判断流水号
    }


    #endregion


    public class HSPack_Syn
    {

        #region 定义变量 

        public bool Connected;
        public NetInfo objNetInfo;
        public CT2Configinterface config = null;
        public CT2Connection conn = null;
        //public string operator_no; //操作员号
        //public string password; //操作员密码
        public string mac_address; //mac地址
        //public string station_add; //登录站点
        //public string ip_address; //登录IP
        public callbacktest callback = null;




        #endregion


        #region 接口初始化

        public HSPack_Syn()
        {
            Connected = false;
            objNetInfo = new NetInfo();
            GetMac(true);
        }


        public string GetMac(bool RefreshMAC)
        {
            if (RefreshMAC)
            {
                objNetInfo.Refresh();
                mac_address = objNetInfo.MAC;
            }
            return mac_address;
        }

        public class NetInfo
        {
            public ManagementClass objManClass;
            public string m_MAC;
            public string m_HostName;
            public IPAddress[] m_IPList;
            public NetInfo()
            {
                Refresh();
            }
            public void Refresh()
            {
                m_HostName = Dns.GetHostName();
                m_IPList = Dns.GetHostAddresses(m_HostName);
                m_MAC = GetMAC();
            }
            public string HostName
            {
                get
                {
                    return Dns.GetHostName();
                }
            }
            public IPAddress[] IPList
            {
                get
                {
                    return Dns.GetHostAddresses(Dns.GetHostName());

                }
            }
            public string MAC
            {
                get
                {
                    return m_MAC;
                }
            }
            public string GetMAC()
            {
                string strMAC = null;

                objManClass = new ManagementClass("Win32_NetworkAdapterConfiguration");

                ManagementObjectCollection objManObjCol = objManClass.GetInstances();
                foreach (ManagementObject objManObj in objManObjCol)
                {
                    if (objManObj["IPEnabled"].ToString() == "True")
                        strMAC = objManObj["MacAddress"].ToString().Replace(":", "");
                }

                return strMAC;
            }
        }

        #endregion


        #region 连接 和 断开连接
        public bool InitT2()
        {
            if (conn == null)
            {
                config = new CT2Configinterface();
                config.Load("t2sdk.ini");
                conn = new CT2Connection(config);
                callback = new callbacktest();
                conn.Create(callback);

                int iret = conn.Connect(4000);
                //MessageBox.Show(conn.GetErrorMsg(iret));

                if (iret != 0)
                {
                    CloseT2();
                    return false;
                }
            }

            return true;
        }

        //断开连接
        public void CloseT2()
        {
            config.Dispose();
            conn.Dispose();
            config = null;
            conn = null;
        }



        #endregion


        #region 功能号10001：登录
        public Login_Output_O32 Fun10001_Login(Login_Input_O32 objLogin_Input)
        {
            //打包请求报文

            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("operator_no", strType, 255, 4);
            packer.AddField("password", strType, 255, 4);
            packer.AddField("mac_address", strType, 255, 4);
            packer.AddField("op_station", strType, 255, 4);
            packer.AddField("ip_address", strType, 255, 4);
            packer.AddField("authorization_id", strType, 255, 4);

            packer.AddStr(objLogin_Input.in_operator_no);
            packer.AddStr(objLogin_Input.in_password);
            packer.AddStr(objLogin_Input.in_mac_address);
            packer.AddStr(objLogin_Input.in_station_add);
            packer.AddStr(objLogin_Input.in_ip_address);
            packer.AddStr(objLogin_Input.authorization_id);
            packer.EndPack();

            //功能号，业务包
            int iRet = conn.SendBiz(10001, packer, 0, 0, 1);
            Login_Output_O32 objLogin_Output = new Login_Output_O32();
            string a = conn.GetErrorMsg(iRet);
            if (iRet < 0)
            {
                objLogin_Output.out_error_no = iRet.ToString();
                objLogin_Output.out_error_info = conn.GetErrorMsg(iRet);
                //MessageBox.Show("登录失败——" + "错误号：" + objLogin_Output.out_error_no + "错误信息：" + objLogin_Output.out_error_info);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {

                    if (unpacker.GetDatasetCount() > 1)//业务数据接收成功，获取数据
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        objLogin_Output.out_error_no = "0";
                        objLogin_Output.out_error_info = "";
                        objLogin_Output.out_user_token = unpacker.GetStr("user_token");//获得用户token
                                                                                       //MessageBox.Show("登录成功！");
                    }
                    else
                    {
                        objLogin_Output.out_error_no = unpacker.GetStr("ErrorCode");
                        objLogin_Output.out_error_info = unpacker.GetStr("ErrorMsg");
                        //MessageBox.Show("登录失败——" + "错误号：" + objLogin_Output.out_error_no + "错误信息：" + objLogin_Output.out_error_info);
                    }

                }
                else if (iRet < 0)
                {
                    objLogin_Output.out_error_no = iRet.ToString();
                    objLogin_Output.out_error_info = conn.GetErrorMsg(iRet);
                    //MessageBox.Show(objLogin_Output.out_error_info);
                }
                else if (iRet == 2)
                {
                    objLogin_Output.out_error_no = iRet.ToString();
                    objLogin_Output.out_error_info = "解包失败";
                }
            }
            return objLogin_Output;
        }


        public Login_Output_O32 Fun10001_Login_S(Login_Input_O32 objLogin_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("operator_no", strType, 255, 4);
            packer.AddField("password", strType, 255, 4);
            packer.AddField("mac_address", strType, 255, 4);
            packer.AddField("op_station", strType, 255, 4);
            packer.AddField("ip_address", strType, 255, 4);
            packer.AddField("authorization_id", strType, 255, 4);
            packer.AddField("app_id", strType, 255, 4);
            packer.AddField("authorize_code", strType, 255, 4);
            packer.AddField("port_id", strType, 255, 4);

            packer.AddStr(objLogin_Input.in_operator_no);
            packer.AddStr(objLogin_Input.in_password);
            packer.AddStr(objLogin_Input.in_mac_address);
            packer.AddStr(objLogin_Input.in_station_add);
            packer.AddStr(objLogin_Input.in_ip_address);
            //packer.AddStr("020407E911B10BA4C6A7F66357B8C797");
            packer.AddStr(objLogin_Input.authorization_id);
            //packer.AddStr("HUNDSUN_UFX_1.0");
            packer.AddStr(objLogin_Input.app_id);
            //packer.AddStr("VWJVngCu6XYBB53r");
            packer.AddStr(objLogin_Input.authorize_code);
            //packer.AddStr("65535");
            packer.AddStr(objLogin_Input.port_id);

            int ReturnCode = 1;
            packer.NewDataset("1", ReturnCode);
            packer.AddField("counter_id", strType, 255, 0);
            packer.AddField("terminal_no", strType, 1024, 0);
            //packer.AddField("data_scale", strType, 1024, 0);
            packer.AddField("service_errcode", strType, 8, 0);
            packer.AddStr("1");
            //char[] pSystemInfo = new char[500];
            //int nlen = 500;
            //CTP_GetSystemInfo(ref pSystemInfo, ref nlen);

            byte[] buffer = new byte[512];
            int nLen = 0;
            int res = GetTerminalno.CTPGetSystemInfo(buffer, ref nLen);

            byte[] buffer1 = new byte[nLen];
            Array.Copy(buffer, 0, buffer1, 0, nLen);
            string terminal_no = Convert.ToBase64String(buffer1);

            packer.AddStr(terminal_no);
            //packer.AddStr("1024");
            packer.AddStr("0");
            //packer.AddStr("3");
            //packer.AddStr("222");
            //packer.AddStr("555");
            //packer.AddStr("0");

            packer.EndPack();

            //功能号，业务包
            int iRet = conn.SendBiz(10001, packer, 0, 0, 1);
            Login_Output_O32 objLogin_Output = new Login_Output_O32();
            string a = conn.GetErrorMsg(iRet);
            if (iRet < 0)
            {
                objLogin_Output.out_error_no = iRet.ToString();
                objLogin_Output.out_error_info = conn.GetErrorMsg(iRet);
                //MessageBox.Show("登录失败——" + "错误号：" + objLogin_Output.out_error_no + "错误信息：" + objLogin_Output.out_error_info);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {
                    if (unpacker.GetDatasetCount() > 1)//业务数据接收成功，获取数据
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        objLogin_Output.out_error_no = "0";
                        objLogin_Output.out_error_info = "";
                        objLogin_Output.out_user_token = unpacker.GetStr("user_token");//获得用户token
                        //MessageBox.Show("登录成功！");
                    }
                    else
                    {
                        objLogin_Output.out_error_no = unpacker.GetStr("ErrorCode");
                        objLogin_Output.out_error_info = unpacker.GetStr("ErrorMsg");
                        objLogin_Output.out_user_token = unpacker.GetStr("user_token");//获得用户token
                        //MessageBox.Show("登录失败——" + "错误号：" + objLogin_Output.out_error_no + "错误信息：" + objLogin_Output.out_error_info);
                    }
                }
                else if (iRet < 0)
                {
                    objLogin_Output.out_error_no = iRet.ToString();
                    objLogin_Output.out_error_info = conn.GetErrorMsg(iRet);
                }
                else if (iRet == 2)
                {
                    objLogin_Output.out_error_no = iRet.ToString();
                    objLogin_Output.out_error_info = "解包失败";
                }
            }

            return objLogin_Output;
        }


        #endregion

        #region 心跳功能
        public void Fun10000_heartBeat(string user_token)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddStr(user_token);
            packer.EndPack();

            //功能号，业务包
            int iRet = conn.SendBiz(10000, packer, 0, 0, 1);
            string a = conn.GetErrorMsg(iRet);
            if (iRet < 0)
            {
                //MessageBox.Show("心跳失败" + conn.GetErrorMsg(iRet));
            }
        }

        #endregion


        #region 34001 资产查询
        public AssetInfo_Output Fun34001_Assetqry(AssetInfo_Input objAssetInfo_Input)
        {
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("combi_no", strType, 255, 4);


            packer.AddStr(objAssetInfo_Input.user_token);
            packer.AddStr(objAssetInfo_Input.account_code);
            packer.AddStr(objAssetInfo_Input.asset_no);
            packer.AddStr(objAssetInfo_Input.combi_no);
            packer.EndPack();


            int iRet = conn.SendBiz(34001, packer, 0, 0, 1);
            AssetInfo_Output objAssetInfo_Out = new AssetInfo_Output();
            if (iRet < 0)
            {
                //MessageBox.Show("资金查询失败:" + conn.GetErrorMsg(iRet));
                objAssetInfo_Out = null;
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {
                    if (unpacker.GetDatasetCount() > 1)//业务数据接收成功，获取数据
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        while (unpacker.IsEOF() != 1)
                        {
                            objAssetInfo_Out.account_code = unpacker.GetStr("account_code");
                            objAssetInfo_Out.asset_no = unpacker.GetStr("asset_no");
                            objAssetInfo_Out.enable_balance_t0 = unpacker.GetDouble("enable_balance_t0");
                            objAssetInfo_Out.enable_balance_t1 = unpacker.GetDouble("enable_balance_t1");

                            unpacker.Next();
                        }
                    }
                    else
                    {
                        //MessageBox.Show("资金查询失败：" + conn.GetErrorMsg(iRet));
                        objAssetInfo_Out = null;
                    }

                }
                else if (iRet < 0)
                {
                    objAssetInfo_Out = null;
                    //MessageBox.Show("资金查询失败——" + "错误信息：" + conn.GetErrorMsg(iRet));
                }
                else if (iRet == 2)
                {
                    objAssetInfo_Out = null;
                    //MessageBox.Show(error);
                }
            }
            return objAssetInfo_Out;


        }
        #endregion


        #region 30001账户查询

        public Fundqry_out Fun30001_Fundqry(Fundqry_in objFundqry_in)
        {
            //打包请求报文

            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);

            packer.AddStr(objFundqry_in.in_user_token);
            packer.AddStr(objFundqry_in.in_account_code);
            packer.EndPack();

            //功能号，业务包
            int iRet = conn.SendBiz(30001, packer, 0, 0, 1);
            Fundqry_out objFundqry_out = new Fundqry_out();

            if (iRet < 0)
            {
                //MessageBox.Show("查询错误：" + conn.GetErrorMsg(iRet));
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);

                if (iRet == 0 || iRet == 1)
                {
                    if (unpacker.GetDatasetCount() > 1)//业务数据接收成功，获取数据
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        while (unpacker.IsEOF() != 1)
                        {
                            objFundqry_out.out_account_code = unpacker.GetStr("account_code");
                            objFundqry_out.out_account_name = unpacker.GetStr("account_name");
                            objFundqry_out.out_account_type = unpacker.GetStr("account_type");

                            unpacker.Next();
                        }

                    }
                    else
                    {
                        objFundqry_out.out_error_no = unpacker.GetStr("ErrorCode");
                        objFundqry_out.out_error_info = unpacker.GetStr("ErrorMsg");
                    }

                }
                else if (iRet < 0)
                {
                    //MessageBox.Show(error);
                }
                else if (iRet == 2)
                {
                    //MessageBox.Show(error);
                }
            }

            return objFundqry_out;

        }
        #endregion


        #region 91001 普通买卖委托
        public SendOrder_Output_O32 Fun91001_SendOrder_Syn(SendOrder_Input_O32 objSendOrder_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("market_no", strType, 255, 4);
            packer.AddField("stock_code", strType, 255, 4);
            packer.AddField("entrust_direction", strType, 255, 4);
            packer.AddField("price_type", strType, 255, 4);
            packer.AddField("entrust_amount", strType, 255, 4);
            packer.AddField("entrust_price", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("batch_no", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("report_seat", strType, 255, 4);
            packer.AddField("combi_no", strType, 255, 4);
            packer.AddField("extsystem_id", strType, 255, 4);




            packer.AddStr(objSendOrder_Input.in_user_token);
            packer.AddStr(objSendOrder_Input.in_account_code);
            packer.AddStr(objSendOrder_Input.in_market_no);
            packer.AddStr(objSendOrder_Input.in_stock_code);
            packer.AddStr(objSendOrder_Input.in_entrust_direction);
            packer.AddStr(objSendOrder_Input.in_price_type);
            packer.AddStr(objSendOrder_Input.in_entrust_amount);
            packer.AddStr(objSendOrder_Input.in_entrust_price);
            packer.AddStr(objSendOrder_Input.in_asset_no);
            packer.AddStr(objSendOrder_Input.in_batch_no);
            packer.AddStr(objSendOrder_Input.in_stockholder_id);
            packer.AddStr(objSendOrder_Input.in_report_seat);
            packer.AddStr(objSendOrder_Input.in_combi_no);
            packer.AddStr(objSendOrder_Input.in_out_extsystem_id);

            packer.EndPack();


            int iRet = conn.SendBiz(91001, packer, 0, 0, 1);

            //string a = conn.GetErrorMsg(iRet);

            SendOrder_Output_O32 objSendOrder_Output = new SendOrder_Output_O32();

            if (iRet < 0)
            {
                objSendOrder_Output.out_error_no = iRet.ToString();
                objSendOrder_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                string b = conn.GetErrorMsg(iRet);
                if (iRet == 0 || iRet == 1)
                {
                    objSendOrder_Output.out_error_no = "";
                    objSendOrder_Output.out_error_info = "";

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        while (unpacker.IsEOF() != 1)
                        {
                            objSendOrder_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                            objSendOrder_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objSendOrder_Output.out_batch_no = unpacker.GetStr("batch_no");
                            objSendOrder_Output.out_entrust_fail_code = unpacker.GetStr("entrust_fail_code");
                            objSendOrder_Output.out_fail_cause = unpacker.GetStr("fail_cause");
                            objSendOrder_Output.out_risk_serial_no = unpacker.GetStr("risk_serial_no");

                            unpacker.Next();
                        }
                    }
                    else
                    {
                        objSendOrder_Output.out_error_no = unpacker.GetStr("ErrorCode");
                        objSendOrder_Output.out_error_info = unpacker.GetStr("ErrorMsg");
                    }


                }
                else if (iRet < 0)
                {
                    objSendOrder_Output.out_error_no = iRet.ToString();
                    objSendOrder_Output.out_error_info = conn.GetErrorMsg(iRet);
                }
                else if (iRet == 2)
                {
                    objSendOrder_Output.out_error_no = iRet.ToString();
                    objSendOrder_Output.out_error_info = "解包失败";
                }
            }

            return objSendOrder_Output;
        }
        #endregion


        #region 91004 期货委托

        public FutureEntrust_Output Fun91004_FutrueEntrust(FutureEntrust_Input objFutrueEntrust_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("market_no", strType, 255, 4);
            packer.AddField("stock_code", strType, 255, 4);
            packer.AddField("entrust_direction", strType, 255, 4);
            packer.AddField("futures_direction", strType, 255, 4);
            packer.AddField("price_type", strType, 255, 4);
            packer.AddField("entrust_price", strType, 255, 4);
            packer.AddField("entrust_amount", strType, 255, 4);
            packer.AddField("extsystem_id", strType, 255, 4);


            packer.AddStr(objFutrueEntrust_Input.in_user_token);
            packer.AddStr(objFutrueEntrust_Input.in_account_code);
            packer.AddStr(objFutrueEntrust_Input.in_asset_no);
            packer.AddStr(objFutrueEntrust_Input.in_stockholder_id);
            packer.AddStr(objFutrueEntrust_Input.in_market_no);
            packer.AddStr(objFutrueEntrust_Input.in_stock_code);
            packer.AddStr(objFutrueEntrust_Input.in_entrust_direction);
            packer.AddStr(objFutrueEntrust_Input.in_futures_direction);
            packer.AddStr(objFutrueEntrust_Input.in_price_type);
            packer.AddStr(objFutrueEntrust_Input.in_entrust_price);
            packer.AddStr(objFutrueEntrust_Input.in_entrust_amount);
            packer.AddStr(objFutrueEntrust_Input.in_extsystem_id);

            packer.EndPack();

            int iRet = conn.SendBiz(91004, packer, 0, 0, 1);

            FutureEntrust_Output objFutrueEntrust_Output = new FutureEntrust_Output();

            if (iRet < 0)
            {
                objFutrueEntrust_Output.out_error_no = iRet.ToString();
                objFutrueEntrust_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                string b = conn.GetErrorMsg(iRet);
                if (iRet == 0 || iRet == 1)
                {
                    objFutrueEntrust_Output.out_error_no = "";
                    objFutrueEntrust_Output.out_error_info = "";

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        while (unpacker.IsEOF() != 1)
                        {
                            objFutrueEntrust_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                            objFutrueEntrust_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objFutrueEntrust_Output.out_batch_no = unpacker.GetStr("batch_no");
                            objFutrueEntrust_Output.out_entrust_fail_code = unpacker.GetStr("entrust_fail_code");
                            objFutrueEntrust_Output.out_fail_cause = unpacker.GetStr("fail_cause");
                            objFutrueEntrust_Output.out_risk_serial_no = unpacker.GetStr("risk_serial_no");

                            unpacker.Next();
                        }
                    }
                    else
                    {
                        objFutrueEntrust_Output.out_error_no = unpacker.GetStr("ErrorCode");
                        objFutrueEntrust_Output.out_error_info = unpacker.GetStr("ErrorMsg");
                    }


                }
                else if (iRet < 0)
                {
                    objFutrueEntrust_Output.out_error_no = iRet.ToString();
                    objFutrueEntrust_Output.out_error_info = conn.GetErrorMsg(iRet);
                }
                else if (iRet == 2)
                {
                    objFutrueEntrust_Output.out_error_no = iRet.ToString();
                    objFutrueEntrust_Output.out_error_info = "解包失败";
                }
            }

            return objFutrueEntrust_Output;
        }
        #endregion


        #region 32001 证券委托查询
        public List<SendedOrder_Output_O32> Fun32001_SendedOrder(SendedOrder_Input_O32 objSendedOrder_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("extsystem_id", strType, 255, 4);
            packer.AddField("entrust_no", strType, 255, 4);
            packer.AddField("batch_no", strType, 255, 4);
            packer.AddField("position_str", strType, 255, 4);


            packer.AddStr(objSendedOrder_Input.in_user_token);
            packer.AddStr(objSendedOrder_Input.in_asset_no);
            packer.AddStr(objSendedOrder_Input.in_extsystem_id);
            packer.AddStr(objSendedOrder_Input.in_entrust_no);
            packer.AddStr(objSendedOrder_Input.in_batch_no);
            packer.AddStr(objSendedOrder_Input.in_position_str);

            packer.EndPack();


            //功能号，业务包
            int iRet = conn.SendBiz(32001, packer, 0, 0, 1);

            List<SendedOrder_Output_O32> list_objSendedOrder_Output = new List<SendedOrder_Output_O32>();
            if (iRet < 0)
            {
                SendedOrder_Output_O32 objSendedOrder_Output = new SendedOrder_Output_O32();
                objSendedOrder_Output.out_error_no = iRet.ToString();
                objSendedOrder_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        while (unpacker.IsEOF() != 1)
                        {
                            SendedOrder_Output_O32 objSendedOrder_Output = new SendedOrder_Output_O32();
                            objSendedOrder_Output.out_batch_no = unpacker.GetStr("batch_no");
                            objSendedOrder_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objSendedOrder_Output.out_entrust_date = unpacker.GetStr("entrust_date");
                            objSendedOrder_Output.out_entrust_time = unpacker.GetStr("entrust_time");
                            objSendedOrder_Output.out_operator_no = unpacker.GetStr("operator_no");
                            objSendedOrder_Output.out_report_no = unpacker.GetStr("report_no");
                            objSendedOrder_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                            objSendedOrder_Output.out_third_reff = unpacker.GetStr("third_reff");
                            objSendedOrder_Output.out_account_code = unpacker.GetStr("account_code");
                            objSendedOrder_Output.out_asset_no = unpacker.GetStr("asset_no");
                            objSendedOrder_Output.out_combi_no = unpacker.GetStr("combi_no");
                            objSendedOrder_Output.out_stockholder_id = unpacker.GetStr("stockholder_id");
                            objSendedOrder_Output.out_report_seat = unpacker.GetStr("report_seat");
                            objSendedOrder_Output.out_market_no = unpacker.GetStr("market_no");
                            objSendedOrder_Output.out_stock_code = unpacker.GetStr("stock_code");
                            objSendedOrder_Output.out_entrust_direction = unpacker.GetStr("entrust_direction");
                            objSendedOrder_Output.out_price_type = unpacker.GetStr("price_type");
                            objSendedOrder_Output.out_entrust_price = unpacker.GetStr("entrust_price");
                            objSendedOrder_Output.out_entrust_amount = unpacker.GetStr("entrust_amount");
                            objSendedOrder_Output.out_pre_buy_frozen_balance = unpacker.GetStr("pre_buy_frozen_balance");
                            objSendedOrder_Output.out_pre_sell_balance = unpacker.GetStr("pre_sell_balance");
                            objSendedOrder_Output.out_confirm_no = unpacker.GetStr("confirm_no");
                            objSendedOrder_Output.out_entrust_state = unpacker.GetStr("entrust_state");
                            objSendedOrder_Output.out_first_deal_time = unpacker.GetStr("first_deal_time");
                            objSendedOrder_Output.out_deal_amount = unpacker.GetStr("deal_amount");
                            objSendedOrder_Output.out_deal_balance = unpacker.GetStr("deal_balance");
                            objSendedOrder_Output.out_deal_price = unpacker.GetStr("deal_price");
                            objSendedOrder_Output.out_deal_times = unpacker.GetStr("deal_times");
                            objSendedOrder_Output.out_withdraw_amount = unpacker.GetStr("withdraw_amount");
                            objSendedOrder_Output.out_withdraw_cause = unpacker.GetStr("withdraw_cause");
                            objSendedOrder_Output.out_position_str = unpacker.GetStr("position_str");

                            list_objSendedOrder_Output.Add(objSendedOrder_Output);
                            unpacker.Next();
                        }
                    }
                    else
                    {
                        SendedOrder_Output_O32 objSendedOrder_Output = new SendedOrder_Output_O32();
                        objSendedOrder_Output.out_error_no = iRet.ToString();
                        objSendedOrder_Output.out_error_info = conn.GetErrorMsg(iRet);
                    }

                }

            }

            return list_objSendedOrder_Output;
        }

        #endregion


        #region 91101 委托撤单
        public SendWtd_Output_O32 Fun91101_SendWtd_Syn(SendWtd_Input_O32 objSendWtd_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("entrust_no", strType, 255, 4);

            packer.AddStr(objSendWtd_Input.in_user_token);
            packer.AddStr(objSendWtd_Input.in_entrust_no);
            packer.EndPack();

            int iRet = conn.SendBiz(91101, packer, 0, 0, 1);

            SendWtd_Output_O32 objSendWtd_Output_O32 = new SendWtd_Output_O32();

            if (iRet < 0)
            {
                objSendWtd_Output_O32.out_error_no = iRet.ToString();
                objSendWtd_Output_O32.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                string b = conn.GetErrorMsg(iRet);
                if (iRet == 0 || iRet == 1)
                {
                    objSendWtd_Output_O32.out_error_no = "";
                    objSendWtd_Output_O32.out_error_info = "";

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        objSendWtd_Output_O32.out_error_no = "0";
                        objSendWtd_Output_O32.out_error_info = "";

                        while (unpacker.IsEOF() != 1)
                        {
                            objSendWtd_Output_O32.out_entrust_no = unpacker.GetStr("entrust_no");
                            objSendWtd_Output_O32.out_market_no = unpacker.GetStr("market_no");
                            objSendWtd_Output_O32.out_stock_code = unpacker.GetStr("stock_code");
                            objSendWtd_Output_O32.out_success_flag = unpacker.GetStr("success_flag");
                            objSendWtd_Output_O32.out_fail_cause = unpacker.GetStr("fail_cause");

                            unpacker.Next();
                        }
                    }
                    else
                    {
                        objSendWtd_Output_O32.out_error_no = unpacker.GetStr("ErrorCode");
                        objSendWtd_Output_O32.out_error_info = unpacker.GetStr("ErrorMsg");
                    }





                }
                else if (iRet < 0)
                {
                    objSendWtd_Output_O32.out_error_no = iRet.ToString();
                    objSendWtd_Output_O32.out_error_info = conn.GetErrorMsg(iRet);
                }
                else if (iRet == 2)
                {
                    objSendWtd_Output_O32.out_error_no = iRet.ToString();
                    objSendWtd_Output_O32.out_error_info = "解包失败";
                }
            }

            return objSendWtd_Output_O32;

        }
        #endregion


        #region 91105 期货委托撤单
        public FutureentrustWithdraw_Output Fun91105_FutrueentrustWithdraw(FutureentrustWithdraw_Input objFutrueentrustWithdraw_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("entrust_no", strType, 255, 4);

            packer.AddStr(objFutrueentrustWithdraw_Input.in_user_token);
            packer.AddStr(objFutrueentrustWithdraw_Input.in_entrust_no);
            packer.EndPack();

            int iRet = conn.SendBiz(91105, packer, 0, 0, 1);

            FutureentrustWithdraw_Output objFutrueentrustWithdraw_Output = new FutureentrustWithdraw_Output();

            if (iRet < 0)
            {
                objFutrueentrustWithdraw_Output.out_error_no = iRet.ToString();
                objFutrueentrustWithdraw_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                string b = conn.GetErrorMsg(iRet);
                if (iRet == 0 || iRet == 1)
                {
                    objFutrueentrustWithdraw_Output.out_error_no = "";
                    objFutrueentrustWithdraw_Output.out_error_info = "";

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        objFutrueentrustWithdraw_Output.out_error_no = "0";
                        objFutrueentrustWithdraw_Output.out_error_info = "";

                        while (unpacker.IsEOF() != 1)
                        {
                            objFutrueentrustWithdraw_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objFutrueentrustWithdraw_Output.out_market_no = unpacker.GetStr("market_no");
                            objFutrueentrustWithdraw_Output.out_stock_code = unpacker.GetStr("stock_code");
                            objFutrueentrustWithdraw_Output.out_success_flag = unpacker.GetStr("success_flag");
                            objFutrueentrustWithdraw_Output.out_fail_cause = unpacker.GetStr("fail_cause");

                            unpacker.Next();
                        }
                    }
                    else
                    {
                        objFutrueentrustWithdraw_Output.out_error_no = unpacker.GetStr("ErrorCode");
                        objFutrueentrustWithdraw_Output.out_error_info = unpacker.GetStr("ErrorMsg");
                    }


                }
                else if (iRet < 0)
                {
                    objFutrueentrustWithdraw_Output.out_error_no = iRet.ToString();
                    objFutrueentrustWithdraw_Output.out_error_info = conn.GetErrorMsg(iRet);
                }
                else if (iRet == 2)
                {
                    objFutrueentrustWithdraw_Output.out_error_no = iRet.ToString();
                    objFutrueentrustWithdraw_Output.out_error_info = "解包失败";
                }
            }

            return objFutrueentrustWithdraw_Output;
        }

        public FutureentrustWithdraw_Output Fun91119_FutrueentrustWithdraw(FutureentrustWithdraw_Input objFutrueentrustWithdraw_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("entrust_no", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("combi_no", strType, 255, 4);

            packer.AddStr(objFutrueentrustWithdraw_Input.in_user_token);
            packer.AddStr(objFutrueentrustWithdraw_Input.in_entrust_no);
            packer.AddStr(objFutrueentrustWithdraw_Input.account_code);
            packer.AddStr(objFutrueentrustWithdraw_Input.combi_no);
            packer.EndPack();

            int iRet = conn.SendBiz(91119, packer, 0, 0, 1);

            FutureentrustWithdraw_Output objFutrueentrustWithdraw_Output = new FutureentrustWithdraw_Output();

            if (iRet < 0)
            {
                objFutrueentrustWithdraw_Output.out_error_no = iRet.ToString();
                objFutrueentrustWithdraw_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                string b = conn.GetErrorMsg(iRet);
                if (iRet == 0 || iRet == 1)
                {
                    objFutrueentrustWithdraw_Output.out_error_no = "";
                    objFutrueentrustWithdraw_Output.out_error_info = "";

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        objFutrueentrustWithdraw_Output.out_error_no = "0";
                        objFutrueentrustWithdraw_Output.out_error_info = "";

                        while (unpacker.IsEOF() != 1)
                        {
                            objFutrueentrustWithdraw_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objFutrueentrustWithdraw_Output.out_market_no = unpacker.GetStr("market_no");
                            objFutrueentrustWithdraw_Output.out_stock_code = unpacker.GetStr("stock_code");
                            objFutrueentrustWithdraw_Output.out_success_flag = unpacker.GetStr("success_flag");
                            objFutrueentrustWithdraw_Output.out_fail_cause = unpacker.GetStr("fail_cause");

                            unpacker.Next();
                        }
                    }
                    else
                    {
                        objFutrueentrustWithdraw_Output.out_error_no = unpacker.GetStr("ErrorCode");
                        objFutrueentrustWithdraw_Output.out_error_info = unpacker.GetStr("ErrorMsg");
                    }


                }
                else if (iRet < 0)
                {
                    objFutrueentrustWithdraw_Output.out_error_no = iRet.ToString();
                    objFutrueentrustWithdraw_Output.out_error_info = conn.GetErrorMsg(iRet);
                }
                else if (iRet == 2)
                {
                    objFutrueentrustWithdraw_Output.out_error_no = iRet.ToString();
                    objFutrueentrustWithdraw_Output.out_error_info = "解包失败";
                }
            }

            return objFutrueentrustWithdraw_Output;
        }

        #endregion

        #region 33001 成交查询
        public List<DealQry_Output> Fun33001_DealQry(DealQry_Input objDealQry_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("position_str", strType, 255, 4);

            packer.AddStr(objDealQry_Input.in_user_token);
            packer.AddStr(objDealQry_Input.in_asset_no);
            packer.AddStr(objDealQry_Input.in_account_code);
            packer.AddStr(objDealQry_Input.in_stockholder_id);
            packer.AddStr(objDealQry_Input.in_position_str);

            packer.EndPack();

            int iRet = conn.SendBiz(33001, packer, 0, 0, 1);

            List<DealQry_Output> list_DealQry_Output = new List<DealQry_Output>();
            if (iRet < 0)
            {
                DealQry_Output objDealQry_Output = new DealQry_Output();
                objDealQry_Output.out_error_no = iRet.ToString();
                objDealQry_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);



                        while (unpacker.IsEOF() != 1)
                        {
                            DealQry_Output objDealQry_Output = new DealQry_Output();
                            objDealQry_Output.out_deal_date = unpacker.GetStr("deal_date");
                            objDealQry_Output.out_deal_no = unpacker.GetStr("deal_no");
                            objDealQry_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objDealQry_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                            objDealQry_Output.out_third_reff = unpacker.GetStr("third_reff");
                            objDealQry_Output.out_account_code = unpacker.GetStr("account_code");
                            objDealQry_Output.out_asset_no = unpacker.GetStr("asset_no");
                            objDealQry_Output.out_combi_no = unpacker.GetStr("combi_no");
                            objDealQry_Output.out_instance_no = unpacker.GetStr("instance_no");
                            objDealQry_Output.out_stockholder_id = unpacker.GetStr("stockholder_id");
                            objDealQry_Output.out_market_no = unpacker.GetStr("market_no");
                            objDealQry_Output.out_stock_code = unpacker.GetStr("stock_code");
                            objDealQry_Output.out_entrust_direction = unpacker.GetStr("entrust_direction");
                            objDealQry_Output.out_deal_amount = unpacker.GetStr("deal_amount");
                            objDealQry_Output.out_deal_price = unpacker.GetStr("deal_price");
                            objDealQry_Output.out_deal_balance = unpacker.GetStr("deal_balance");
                            objDealQry_Output.out_total_fee = unpacker.GetStr("total_fee");
                            objDealQry_Output.out_deal_time = unpacker.GetStr("deal_time");
                            objDealQry_Output.out_position_str = unpacker.GetStr("position_str");

                            list_DealQry_Output.Add(objDealQry_Output);
                            unpacker.Next();
                        }
                    }
                    else
                    {
                        DealQry_Output objDealQry_Output = new DealQry_Output();
                        objDealQry_Output.out_error_no = iRet.ToString();
                        objDealQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                    }

                }

            }

            return list_DealQry_Output;

        }
        #endregion


        #region 31001 现货持仓查询

        public List<positionQry_Output> Fun31001_positionQry(positionQry_Input objpositionQry_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("market_no", strType, 255, 4);
            packer.AddField("combi_no", strType, 255, 4);
            packer.AddField("stock_code", strType, 255, 4);
            packer.AddField("hold_seat", strType, 255, 4);


            packer.AddStr(objpositionQry_Input.in_user_token);
            packer.AddStr(objpositionQry_Input.in_asset_no);
            packer.AddStr(objpositionQry_Input.in_account_code);
            packer.AddStr(objpositionQry_Input.in_stockholder_id);
            packer.AddStr(objpositionQry_Input.in_market_no);
            packer.AddStr(objpositionQry_Input.in_combi_no);
            packer.AddStr(objpositionQry_Input.in_stock_code);
            packer.AddStr(objpositionQry_Input.in_hold_seat);

            packer.EndPack();

            int iRet = conn.SendBiz(31001, packer, 0, 0, 1);
            List<positionQry_Output> list_objpositionQry_Output = new List<positionQry_Output>();

            if (iRet < 0)
            {
                positionQry_Output objpositionQry_Output = new positionQry_Output();
                objpositionQry_Output.out_error_no = iRet.ToString();
                objpositionQry_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        while (unpacker.IsEOF() != 1)
                        {
                            positionQry_Output objpositionQry_Output = new positionQry_Output();
                            objpositionQry_Output.out_account_code = unpacker.GetStr("account_code");
                            objpositionQry_Output.out_asset_no = unpacker.GetStr("asset_no");
                            objpositionQry_Output.out_combi_no = unpacker.GetStr("combi_no");
                            objpositionQry_Output.out_market_no = unpacker.GetStr("market_no");
                            objpositionQry_Output.out_stock_code = unpacker.GetStr("stock_code");
                            objpositionQry_Output.out_stockholder_id = unpacker.GetStr("stockholder_id");
                            objpositionQry_Output.out_hold_seat = unpacker.GetStr("hold_seat");
                            objpositionQry_Output.out_invest_type = unpacker.GetStr("invest_type");
                            objpositionQry_Output.out_current_amount = unpacker.GetStr("current_amount");
                            objpositionQry_Output.out_enable_amount = unpacker.GetStr("enable_amount");
                            objpositionQry_Output.out_begin_cost = unpacker.GetStr("begin_cost");
                            objpositionQry_Output.out_current_cost = unpacker.GetStr("current_cost");
                            objpositionQry_Output.out_pre_buy_amount = unpacker.GetStr("pre_buy_amount");
                            objpositionQry_Output.out_pre_sell_amount = unpacker.GetStr("pre_sell_amount");
                            objpositionQry_Output.out_pre_buy_balance = unpacker.GetStr("pre_buy_balance");
                            objpositionQry_Output.out_pre_sell_balance = unpacker.GetStr("pre_sell_balance");
                            objpositionQry_Output.out_buy_amount = unpacker.GetStr("buy_amount");
                            objpositionQry_Output.out_sell_amount = unpacker.GetStr("sell_amount");
                            objpositionQry_Output.out_buy_balance = unpacker.GetStr("buy_balance");
                            objpositionQry_Output.out_sell_balance = unpacker.GetStr("sell_balance");
                            objpositionQry_Output.out_buy_fee = unpacker.GetStr("buy_fee");
                            objpositionQry_Output.out_sell_fee = unpacker.GetStr("sell_fee");

                            list_objpositionQry_Output.Add(objpositionQry_Output);
                            unpacker.Next();
                        }
                    }
                    else
                    {
                        positionQry_Output objpositionQry_Output = new positionQry_Output();
                        objpositionQry_Output.out_error_no = iRet.ToString();
                        objpositionQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                    }

                }

            }

            return list_objpositionQry_Output;
        }
        #endregion

        #region 31003 期货持仓查询

        public List<FuturepositionQry_Output> Fun31003_FuturepositionQry(FuturepositionQry_Input objFuturepositionQry_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("market_no", strType, 255, 4);
            packer.AddField("combi_no", strType, 255, 4);
            packer.AddField("stock_code", strType, 255, 4);
            packer.AddField("hold_seat", strType, 255, 4);
            packer.AddField("invest_type", strType, 255, 4);
            packer.AddField("position_flag", strType, 255, 4);

            packer.AddStr(objFuturepositionQry_Input.in_user_token);
            packer.AddStr(objFuturepositionQry_Input.in_asset_no);
            packer.AddStr(objFuturepositionQry_Input.in_account_code);
            packer.AddStr(objFuturepositionQry_Input.in_stockholder_id);
            packer.AddStr(objFuturepositionQry_Input.in_market_no);
            packer.AddStr(objFuturepositionQry_Input.in_combi_no);
            packer.AddStr(objFuturepositionQry_Input.in_stock_code);
            packer.AddStr(objFuturepositionQry_Input.in_hold_seat);
            packer.AddStr(objFuturepositionQry_Input.in_invest_type);
            packer.AddStr(objFuturepositionQry_Input.in_position_flag);

            packer.EndPack();

            int iRet = conn.SendBiz(31003, packer, 0, 0, 1);
            List<FuturepositionQry_Output> list_objFuturepositionQry_Output = new List<FuturepositionQry_Output>();
            try
            {
                if (iRet < 0)
                {
                    FuturepositionQry_Output objFuturepositionQry_Output = new FuturepositionQry_Output();
                    objFuturepositionQry_Output.out_error_no = iRet.ToString();
                    objFuturepositionQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                    list_objFuturepositionQry_Output.Add(objFuturepositionQry_Output);
                }
                else
                {
                    string error = null;
                    CT2UnPacker unpacker = null;
                    iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                    if (iRet == 0 || iRet == 1)
                    {

                        if (unpacker.GetDatasetCount() > 1)
                        {
                            unpacker.SetCurrentDatasetByIndex(1);

                            while (unpacker.IsEOF() != 1)
                            {
                                FuturepositionQry_Output objFuturepositionQry_Output = new FuturepositionQry_Output();
                                objFuturepositionQry_Output.out_account_code = unpacker.GetStr("account_code");
                                objFuturepositionQry_Output.out_asset_no = unpacker.GetStr("asset_no");
                                objFuturepositionQry_Output.out_combi_no = unpacker.GetStr("combi_no");
                                objFuturepositionQry_Output.out_market_no = unpacker.GetStr("market_no");
                                objFuturepositionQry_Output.out_stock_code = unpacker.GetStr("stock_code");
                                objFuturepositionQry_Output.out_stockholder_id = unpacker.GetStr("stockholder_id");
                                objFuturepositionQry_Output.out_hold_seat = unpacker.GetStr("hold_seat");
                                objFuturepositionQry_Output.out_position_flag = unpacker.GetStr("position_flag");
                                objFuturepositionQry_Output.out_invest_type = unpacker.GetStr("invest_type");
                                objFuturepositionQry_Output.out_current_amount = unpacker.GetStr("current_amount");
                                objFuturepositionQry_Output.out_enable_amount = unpacker.GetStr("enable_amount");
                                objFuturepositionQry_Output.out_begin_cost = unpacker.GetStr("begin_cost");
                                objFuturepositionQry_Output.out_current_cost = unpacker.GetStr("current_cost");
                                objFuturepositionQry_Output.out_current_cost_price = unpacker.GetStr("current_cost_price");
                                objFuturepositionQry_Output.out_pre_buy_amount = unpacker.GetStr("pre_buy_amount");
                                objFuturepositionQry_Output.out_pre_sell_amount = unpacker.GetStr("pre_sell_amount");
                                objFuturepositionQry_Output.out_pre_buy_balance = unpacker.GetStr("pre_buy_balance");
                                objFuturepositionQry_Output.out_pre_sell_balance = unpacker.GetStr("pre_sell_balance");
                                objFuturepositionQry_Output.out_buy_amount = unpacker.GetStr("buy_amount");
                                objFuturepositionQry_Output.out_sell_amount = unpacker.GetStr("sell_amount");
                                objFuturepositionQry_Output.out_buy_balance = unpacker.GetStr("buy_balance");
                                objFuturepositionQry_Output.out_sell_balance = unpacker.GetStr("sell_balance");
                                objFuturepositionQry_Output.out_buy_fee = unpacker.GetStr("buy_fee");
                                objFuturepositionQry_Output.out_sell_fee = unpacker.GetStr("sell_fee");
                                objFuturepositionQry_Output.out_accumulate_profit = unpacker.GetStr("accumulate_profit");

                                list_objFuturepositionQry_Output.Add(objFuturepositionQry_Output);
                                unpacker.Next();
                            }
                        }
                        else
                        {
                            FuturepositionQry_Output objFuturepositionQry_Output = new FuturepositionQry_Output();
                            objFuturepositionQry_Output.out_error_no = iRet.ToString();
                            objFuturepositionQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                            list_objFuturepositionQry_Output.Add(objFuturepositionQry_Output);
                        }

                    }

                }
            }
            catch
            {

            }


            return list_objFuturepositionQry_Output;
        }
        #endregion


        #region 32003 期货委托查询
        public List<FutureentrustQry_Output> Fun32003_FutureentrustQry(FutureentrustQry_Input objFutureentrustQry)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("entrust_no", strType, 255, 4);
            packer.AddField("batch_no", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("position_str", strType, 255, 4);
            packer.AddField("extsystem_id", strType, 255, 4);
            packer.AddField("entrust_state_list", strType, 255, 4);
            packer.AddField("request_num", strType, 255, 4);
            packer.AddField("combi_no", strType, 255, 4);

            packer.AddStr(objFutureentrustQry.in_user_token);
            packer.AddStr(objFutureentrustQry.in_entrust_no);
            packer.AddStr(objFutureentrustQry.in_batch_no);
            packer.AddStr(objFutureentrustQry.in_account_code);
            packer.AddStr(objFutureentrustQry.in_asset_no);
            packer.AddStr(objFutureentrustQry.in_stockholder_id);
            packer.AddStr(objFutureentrustQry.in_position_str);
            packer.AddStr(objFutureentrustQry.in_extsystem_id);
            packer.AddStr(objFutureentrustQry.in_entrust_state_list);
            packer.AddStr(objFutureentrustQry.in_request_num);
            packer.AddStr(objFutureentrustQry.in_combi_no);

            packer.EndPack();

            //功能号，业务包
            int iRet = conn.SendBiz(32003, packer, 0, 0, 1);

            List<FutureentrustQry_Output> list_FutureentrustQry_Output = new List<FutureentrustQry_Output>();
            try
            {
                if (iRet < 0)
                {
                    FutureentrustQry_Output objFutureentrustQry_Output = new FutureentrustQry_Output();
                    objFutureentrustQry_Output.out_error_no = iRet.ToString();
                    objFutureentrustQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                    list_FutureentrustQry_Output.Add(objFutureentrustQry_Output);
                }
                else
                {
                    string error = null;
                    CT2UnPacker unpacker = null;
                    iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                    if (iRet == 0 || iRet == 1)
                    {

                        if (unpacker.GetDatasetCount() > 1)
                        {
                            unpacker.SetCurrentDatasetByIndex(1);


                            while (unpacker.IsEOF() != 1)
                            {
                                FutureentrustQry_Output objFutureentrustQry_Output = new FutureentrustQry_Output();
                                objFutureentrustQry_Output.out_entrust_date = unpacker.GetStr("entrust_date");
                                objFutureentrustQry_Output.out_entrust_time = unpacker.GetStr("entrust_time");
                                objFutureentrustQry_Output.out_operator_no = unpacker.GetStr("operator_no");
                                objFutureentrustQry_Output.out_batch_no = unpacker.GetStr("batch_no");
                                objFutureentrustQry_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                                objFutureentrustQry_Output.out_report_no = unpacker.GetStr("report_no");
                                objFutureentrustQry_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                                objFutureentrustQry_Output.out_third_reff = unpacker.GetStr("third_reff");
                                objFutureentrustQry_Output.out_account_code = unpacker.GetStr("account_code");
                                objFutureentrustQry_Output.out_asset_no = unpacker.GetStr("asset_no");
                                objFutureentrustQry_Output.out_combi_no = unpacker.GetStr("combi_no");
                                objFutureentrustQry_Output.out_stockholder_id = unpacker.GetStr("stockholder_id");
                                objFutureentrustQry_Output.out_report_seat = unpacker.GetStr("report_seat");
                                objFutureentrustQry_Output.out_market_no = unpacker.GetStr("market_no");
                                objFutureentrustQry_Output.out_stock_code = unpacker.GetStr("stock_code");
                                objFutureentrustQry_Output.out_entrust_direction = unpacker.GetStr("entrust_direction");
                                objFutureentrustQry_Output.out_futures_direction = unpacker.GetStr("futures_direction");
                                objFutureentrustQry_Output.out_price_type = unpacker.GetStr("price_type");
                                objFutureentrustQry_Output.out_entrust_price = unpacker.GetStr("entrust_price");
                                objFutureentrustQry_Output.out_entrust_amount = unpacker.GetStr("entrust_amount");
                                objFutureentrustQry_Output.out_pre_buy_frozen_balance = unpacker.GetStr("pre_buy_frozen_balance");
                                objFutureentrustQry_Output.out_pre_sell_balance = unpacker.GetStr("pre_sell_balance");
                                objFutureentrustQry_Output.out_confirm_no = unpacker.GetStr("confirm_no");
                                objFutureentrustQry_Output.out_entrust_state = unpacker.GetStr("entrust_state");
                                objFutureentrustQry_Output.out_first_deal_time = unpacker.GetStr("first_deal_time");
                                objFutureentrustQry_Output.out_deal_amount = unpacker.GetStr("deal_amount");
                                objFutureentrustQry_Output.out_deal_balance = unpacker.GetStr("deal_balance");
                                objFutureentrustQry_Output.out_deal_price = unpacker.GetStr("deal_price");
                                objFutureentrustQry_Output.out_deal_times = unpacker.GetStr("deal_times");
                                objFutureentrustQry_Output.out_withdraw_amount = unpacker.GetStr("withdraw_amount");
                                objFutureentrustQry_Output.out_withdraw_cause = unpacker.GetStr("withdraw_cause");
                                objFutureentrustQry_Output.out_position_str = unpacker.GetStr("position_str");


                                list_FutureentrustQry_Output.Add(objFutureentrustQry_Output);

                                unpacker.Next();

                            }
                        }
                        else
                        {
                            FutureentrustQry_Output objFutureentrustQry_Output = new FutureentrustQry_Output();
                            objFutureentrustQry_Output.out_error_no = iRet.ToString();
                            objFutureentrustQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                            list_FutureentrustQry_Output.Add(objFutureentrustQry_Output);
                        }

                    }

                }
            }
            catch
            {

            }


            return list_FutureentrustQry_Output;

        }

        public List<FutureentrustQry_Output> Fun32003_FutureentrustQry2(FutureentrustQry_Input objFutureentrustQry)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("entrust_no", strType, 255, 4);
            packer.AddField("batch_no", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("position_str", strType, 255, 4);
            packer.AddField("extsystem_id", strType, 255, 4);
            packer.AddField("entrust_state_list", strType, 255, 4);
            packer.AddField("request_num", strType, 255, 4);

            packer.AddStr(objFutureentrustQry.in_user_token);
            packer.AddStr(objFutureentrustQry.in_entrust_no);
            packer.AddStr(objFutureentrustQry.in_batch_no);
            packer.AddStr(objFutureentrustQry.in_account_code);
            packer.AddStr(objFutureentrustQry.in_asset_no);
            packer.AddStr(objFutureentrustQry.in_stockholder_id);
            packer.AddStr(objFutureentrustQry.in_position_str);
            packer.AddStr(objFutureentrustQry.in_extsystem_id);
            packer.AddStr(objFutureentrustQry.in_entrust_state_list);
            packer.AddStr(objFutureentrustQry.in_request_num);

            packer.EndPack();

            //功能号，业务包
            int iRet = conn.SendBiz(32003, packer, 0, 0, 1);

            List<FutureentrustQry_Output> list_FutureentrustQry_Output = new List<FutureentrustQry_Output>();
            try
            {
                if (iRet < 0)
                {
                    FutureentrustQry_Output objFutureentrustQry_Output = new FutureentrustQry_Output();
                    objFutureentrustQry_Output.out_error_no = iRet.ToString();
                    objFutureentrustQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                    list_FutureentrustQry_Output.Add(objFutureentrustQry_Output);
                }
                else
                {
                    string error = null;
                    CT2UnPacker unpacker = null;
                    iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                    if (iRet == 0 || iRet == 1)
                    {

                        if (unpacker.GetDatasetCount() > 1)
                        {
                            unpacker.SetCurrentDatasetByIndex(1);


                            while (unpacker.IsEOF() != 1)
                            {
                                FutureentrustQry_Output objFutureentrustQry_Output = new FutureentrustQry_Output();
                                objFutureentrustQry_Output.out_entrust_date = unpacker.GetStr("entrust_date");
                                objFutureentrustQry_Output.out_entrust_time = unpacker.GetStr("entrust_time");
                                objFutureentrustQry_Output.out_operator_no = unpacker.GetStr("operator_no");
                                objFutureentrustQry_Output.out_batch_no = unpacker.GetStr("batch_no");
                                objFutureentrustQry_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                                objFutureentrustQry_Output.out_report_no = unpacker.GetStr("report_no");
                                objFutureentrustQry_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                                objFutureentrustQry_Output.out_third_reff = unpacker.GetStr("third_reff");
                                objFutureentrustQry_Output.out_account_code = unpacker.GetStr("account_code");
                                objFutureentrustQry_Output.out_asset_no = unpacker.GetStr("asset_no");
                                objFutureentrustQry_Output.out_combi_no = unpacker.GetStr("combi_no");
                                objFutureentrustQry_Output.out_stockholder_id = unpacker.GetStr("stockholder_id");
                                objFutureentrustQry_Output.out_report_seat = unpacker.GetStr("report_seat");
                                objFutureentrustQry_Output.out_market_no = unpacker.GetStr("market_no");
                                objFutureentrustQry_Output.out_stock_code = unpacker.GetStr("stock_code");
                                objFutureentrustQry_Output.out_entrust_direction = unpacker.GetStr("entrust_direction");
                                objFutureentrustQry_Output.out_futures_direction = unpacker.GetStr("futures_direction");
                                objFutureentrustQry_Output.out_price_type = unpacker.GetStr("price_type");
                                objFutureentrustQry_Output.out_entrust_price = unpacker.GetStr("entrust_price");
                                objFutureentrustQry_Output.out_entrust_amount = unpacker.GetStr("entrust_amount");
                                objFutureentrustQry_Output.out_pre_buy_frozen_balance = unpacker.GetStr("pre_buy_frozen_balance");
                                objFutureentrustQry_Output.out_pre_sell_balance = unpacker.GetStr("pre_sell_balance");
                                objFutureentrustQry_Output.out_confirm_no = unpacker.GetStr("confirm_no");
                                objFutureentrustQry_Output.out_entrust_state = unpacker.GetStr("entrust_state");
                                objFutureentrustQry_Output.out_first_deal_time = unpacker.GetStr("first_deal_time");
                                objFutureentrustQry_Output.out_deal_amount = unpacker.GetStr("deal_amount");
                                objFutureentrustQry_Output.out_deal_balance = unpacker.GetStr("deal_balance");
                                objFutureentrustQry_Output.out_deal_price = unpacker.GetStr("deal_price");
                                objFutureentrustQry_Output.out_deal_times = unpacker.GetStr("deal_times");
                                objFutureentrustQry_Output.out_withdraw_amount = unpacker.GetStr("withdraw_amount");
                                objFutureentrustQry_Output.out_withdraw_cause = unpacker.GetStr("withdraw_cause");
                                objFutureentrustQry_Output.out_position_str = unpacker.GetStr("position_str");


                                list_FutureentrustQry_Output.Add(objFutureentrustQry_Output);

                                unpacker.Next();

                            }
                        }
                        else
                        {
                            FutureentrustQry_Output objFutureentrustQry_Output = new FutureentrustQry_Output();
                            objFutureentrustQry_Output.out_error_no = iRet.ToString();
                            objFutureentrustQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                            list_FutureentrustQry_Output.Add(objFutureentrustQry_Output);
                        }

                    }

                }
            }
            catch
            {

            }


            return list_FutureentrustQry_Output;

        }

        #endregion


        #region 33003 期货成交查询
        public List<FuturedealQry_Output> Fun33003_FuturedealQry(FuturedealQry_Input objFuturedealQry_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("position_str", strType, 255, 4);

            packer.AddStr(objFuturedealQry_Input.in_user_token);
            packer.AddStr(objFuturedealQry_Input.in_asset_no);
            packer.AddStr(objFuturedealQry_Input.in_position_str);

            packer.EndPack();

            int iRet = conn.SendBiz(33003, packer, 0, 0, 1);

            List<FuturedealQry_Output> list_FuturedealQry_Output = new List<FuturedealQry_Output>();
            if (iRet < 0)
            {
                FuturedealQry_Output objFuturedealQry_Output = new FuturedealQry_Output();
                objFuturedealQry_Output.out_error_no = iRet.ToString();
                objFuturedealQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                list_FuturedealQry_Output.Add(objFuturedealQry_Output);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {
                    if (unpacker.GetDatasetCount() > 1)
                    {

                        unpacker.SetCurrentDatasetByIndex(1);


                        while (unpacker.IsEOF() != 1)
                        {
                            FuturedealQry_Output objFuturedealQry_Output = new FuturedealQry_Output();
                            objFuturedealQry_Output.out_deal_date = unpacker.GetStr("deal_date");
                            objFuturedealQry_Output.out_deal_no = unpacker.GetStr("deal_no");
                            objFuturedealQry_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objFuturedealQry_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                            objFuturedealQry_Output.out_third_reff = unpacker.GetStr("third_reff");
                            objFuturedealQry_Output.out_account_code = unpacker.GetStr("account_code");
                            objFuturedealQry_Output.out_asset_no = unpacker.GetStr("asset_no");
                            objFuturedealQry_Output.out_combi_no = unpacker.GetStr("combi_no");
                            objFuturedealQry_Output.out_instance_no = unpacker.GetStr("instance_no");
                            objFuturedealQry_Output.out_stockholder_id = unpacker.GetStr("stockholder_id");
                            objFuturedealQry_Output.out_market_no = unpacker.GetStr("market_no");
                            objFuturedealQry_Output.out_stock_code = unpacker.GetStr("stock_code");
                            objFuturedealQry_Output.out_entrust_direction = unpacker.GetStr("entrust_direction");
                            objFuturedealQry_Output.out_deal_amount = unpacker.GetStr("deal_amount");
                            objFuturedealQry_Output.out_deal_price = unpacker.GetStr("deal_price");
                            objFuturedealQry_Output.out_deal_balance = unpacker.GetStr("deal_balance");
                            objFuturedealQry_Output.out_total_fee = unpacker.GetStr("total_fee");
                            objFuturedealQry_Output.out_deal_time = unpacker.GetStr("deal_time");
                            objFuturedealQry_Output.out_position_str = unpacker.GetStr("position_str");

                            list_FuturedealQry_Output.Add(objFuturedealQry_Output);
                            unpacker.Next();
                        }
                    }
                    else
                    {
                        FuturedealQry_Output objFuturedealQry_Output = new FuturedealQry_Output();
                        objFuturedealQry_Output.out_error_no = iRet.ToString();
                        objFuturedealQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                        list_FuturedealQry_Output.Add(objFuturedealQry_Output);
                    }

                }

            }

            return list_FuturedealQry_Output;
        }
        #endregion

        #region 34003 期货保证金查询
        public FuturedepositQry_Output Fun34003_FuturedepositQry(FuturedepositQry_Input objFuturedepositQry_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');

            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("combi_no", strType, 255, 4);


            packer.AddStr(objFuturedepositQry_Input.in_user_token);
            packer.AddStr(objFuturedepositQry_Input.in_account_code);
            packer.AddStr(objFuturedepositQry_Input.in_asset_no);
            packer.AddStr(objFuturedepositQry_Input.in_combi_no);


            packer.EndPack();

            int iRet = conn.SendBiz(34003, packer, 0, 0, 1);
            FuturedepositQry_Output objFuturedepositQry_Output = new FuturedepositQry_Output();

            if (iRet < 0)
            {
                objFuturedepositQry_Output.out_error_no = iRet.ToString();
                objFuturedepositQry_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                if (iRet == 0 || iRet == 1)
                {
                    objFuturedepositQry_Output.out_error_no = "0";
                    objFuturedepositQry_Output.out_error_info = "";
                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        objFuturedepositQry_Output.out_error_no = "0";
                        objFuturedepositQry_Output.out_error_info = "";

                        while (unpacker.IsEOF() != 1)
                        {
                            objFuturedepositQry_Output.out_account_code = unpacker.GetStr("account_code");
                            objFuturedepositQry_Output.out_asset_no = unpacker.GetStr("asset_no");
                            objFuturedepositQry_Output.out_occupy_deposit_balance = unpacker.GetStr("occupy_deposit_balance");
                            objFuturedepositQry_Output.out_enable_deposit_balance = unpacker.GetStr("enable_deposit_balance");


                            unpacker.Next();
                        }
                    }
                    else
                    {
                        objFuturedepositQry_Output.out_error_no = iRet.ToString();
                        objFuturedepositQry_Output.out_error_info = conn.GetErrorMsg(iRet);
                    }

                }

            }

            return objFuturedepositQry_Output;


        }
        #endregion


        #region 91008 基金委托

        public FundEntrust_Output Fun91008_FundEntrust(FundEntrust_Input objFundEntrust_Input)
        {
            //打包请求报文
            CT2Packer packer = new CT2Packer(2);
            sbyte strType = Convert.ToSByte('S');
            sbyte intType = Convert.ToSByte('I');
            packer.BeginPack();
            packer.AddField("user_token", strType, 255, 4);
            packer.AddField("account_code", strType, 255, 4);
            packer.AddField("asset_no", strType, 255, 4);
            packer.AddField("stockholder_id", strType, 255, 4);
            packer.AddField("market_no", strType, 255, 4);
            packer.AddField("stock_code", strType, 255, 4);
            packer.AddField("entrust_direction", strType, 255, 4);
            packer.AddField("entrust_price", strType, 255, 4);
            packer.AddField("entrust_amount", strType, 255, 4);
            packer.AddField("extsystem_id", strType, 255, 4);


            packer.AddStr(objFundEntrust_Input.in_user_token);
            packer.AddStr(objFundEntrust_Input.in_account_code);
            packer.AddStr(objFundEntrust_Input.in_asset_no);
            packer.AddStr(objFundEntrust_Input.in_stockholder_id);
            packer.AddStr(objFundEntrust_Input.in_market_no);
            packer.AddStr(objFundEntrust_Input.in_stock_code);
            packer.AddStr(objFundEntrust_Input.in_entrust_direction);
            packer.AddStr(objFundEntrust_Input.in_entrust_price);
            packer.AddStr(objFundEntrust_Input.in_entrust_amount);
            packer.AddStr(objFundEntrust_Input.in_extsystem_id);

            packer.EndPack();

            int iRet = conn.SendBiz(91008, packer, 0, 0, 1);

            FundEntrust_Output objFundEntrust_Output = new FundEntrust_Output();

            if (iRet < 0)
            {
                objFundEntrust_Output.out_error_no = iRet.ToString();
                objFundEntrust_Output.out_error_info = conn.GetErrorMsg(iRet);
            }
            else
            {
                string error = null;
                CT2UnPacker unpacker = null;
                iRet = conn.RecvBiz(iRet, out error, out unpacker, 40000, 0);
                string b = conn.GetErrorMsg(iRet);
                if (iRet == 0 || iRet == 1)
                {
                    objFundEntrust_Output.out_error_no = "";
                    objFundEntrust_Output.out_error_info = "";

                    if (unpacker.GetDatasetCount() > 1)
                    {
                        unpacker.SetCurrentDatasetByIndex(1);

                        while (unpacker.IsEOF() != 1)
                        {
                            objFundEntrust_Output.out_extsystem_id = unpacker.GetStr("extsystem_id");
                            objFundEntrust_Output.out_entrust_no = unpacker.GetStr("entrust_no");
                            objFundEntrust_Output.out_batch_no = unpacker.GetStr("batch_no");
                            objFundEntrust_Output.out_entrust_fail_code = unpacker.GetStr("entrust_fail_code");
                            objFundEntrust_Output.out_fail_cause = unpacker.GetStr("fail_cause");
                            objFundEntrust_Output.out_risk_serial_no = unpacker.GetStr("risk_serial_no");

                            unpacker.Next();
                        }
                    }
                    else
                    {
                        objFundEntrust_Output.out_error_no = unpacker.GetStr("ErrorCode");
                        objFundEntrust_Output.out_error_info = unpacker.GetStr("ErrorMsg");
                    }


                }
                else if (iRet < 0)
                {
                    objFundEntrust_Output.out_error_no = iRet.ToString();
                    objFundEntrust_Output.out_error_info = conn.GetErrorMsg(iRet);
                }
                else if (iRet == 2)
                {
                    objFundEntrust_Output.out_error_no = iRet.ToString();
                    objFundEntrust_Output.out_error_info = "解包失败";
                }
            }

            return objFundEntrust_Output;
        }
        #endregion


    }

    public unsafe class callbacktest : CT2CallbackInterface
    {
        //public callbacktest() { }
        //public callbacktest(HSO32Pack11 objHSPack) { m_lpOwner = objHSPack; }
        //public Form1 m_lpOwner;

        public override void OnConnect(CT2Connection lpConnection)
        {
            System.Console.WriteLine("OnConnect");
        }
        public override void OnSafeConnect(CT2Connection lpConnection)
        {
            System.Console.WriteLine("OnSafeConnect");
        }
        public override void OnRegister(CT2Connection lpConnection)
        {
            System.Console.WriteLine("OnRegister");
        }
        public override void OnClose(CT2Connection lpConnection)
        {
            System.Console.WriteLine("OnClose");
        }

        public override void OnReceivedBiz(CT2Connection lpConnection, int hSend, String lppStr, CT2UnPacker lppUnPacker, int nResult)
        {

        }

        public override void OnReceivedBizEx(CT2Connection lpConnection, int hSend, CT2RespondData lpRetData, String lppStr, CT2UnPacker lppUnPacker, int nResult)
        {
        }

        public override void OnSent(CT2Connection lpConnection, int hSend, void* lpData, int nLength, int nQueuingData)
        {

        }

        public override void OnReceivedBizMsg(CT2Connection lpConnection, int hSend, CT2BizMessage lpMsg)
        {
            //int iRetCode = lpMsg.GetErrorNo();//获取返回码
            //int iErrorCode = lpMsg.GetReturnCode();//获取错误码
            //int iFunction = lpMsg.GetFunction();
            //if (iRetCode != 0)
            //{
            //    m_lpOwner.DisplayText("异步接收出错：" + lpMsg.GetErrorNo().ToString() + lpMsg.GetErrorInfo());
            //}
            //else
            //{
            //    if (iFunction == 620000)//1.0消息中心心跳
            //    {
            //        lpMsg.ChangeReq2AnsMessage();
            //        lpConnection.SendBizMsg(lpMsg, 1);
            //        return;
            //    }
            //    else if (iFunction == 620003 || iFunction == 620025) //收到发布过来的行情
            //    {
            //        m_lpOwner.DisplayText("收到主推消息！");
            //        int iKeyInfo = 0;
            //        void* lpKeyInfo = lpMsg.GetKeyInfo(&iKeyInfo);
            //        CT2UnPacker unPacker = new CT2UnPacker(lpKeyInfo, (uint)iKeyInfo);
            //        m_lpOwner.PrintUnPack(unPacker);
            //        unPacker.Dispose();
            //    }
            //    else if (iFunction == 620001)
            //    {
            //        m_lpOwner.DisplayText("收到订阅应答！");
            //        return;
            //    }
            //    else if (iFunction == 620002)
            //    {
            //        m_lpOwner.DisplayText("收到取消订阅应答！");
            //        return;
            //    }
            //    CT2UnPacker unpacker = null;
            //    unsafe
            //    {
            //        int iLen = 0;
            //        void* lpdata = lpMsg.GetContent(&iLen);
            //        unpacker = new CT2UnPacker(lpdata, (uint)iLen);
            //    }
            //    //返回业务错误
            //    if (iErrorCode != 0)
            //    {
            //        m_lpOwner.DisplayText("异步接收业务出错：\n");
            //        m_lpOwner.PrintUnPack(unpacker);
            //    }
            //    //正常业务返回
            //    else
            //    {
            //        m_lpOwner.DisplayText("异步接收业务成功：\n");
            //        m_lpOwner.PrintUnPack(unpacker);
            //    }
            //    if (unpacker != null)
            //    {
            //        unpacker.Dispose();
            //    }
            //}
        }
    };





    public unsafe class CSubCallback : CT2SubCallbackInterface
    {
        //public Form1 m_lpOwner;
        //public CSubCallback(Form1 form1)
        //{
        //    m_lpOwner = form1;
        //}
        public override void OnReceived(CT2SubscribeInterface lpSub, int subscribeIndex, void* lpData, int nLength, tagSubscribeRecvData lpRecvData)
        {
            //m_lpOwner.DisplayText("订阅收到数据***************************\n");
            //String strInfo = String.Format("附加数据长度：       {0}\n", lpRecvData.iAppDataLen);
            //m_lpOwner.DisplayText(strInfo);
            //if (lpRecvData.iAppDataLen > 0)
            //{
            //    unsafe
            //    {
            //        strInfo = String.Format("附加数据：           {0}\n", Marshal.PtrToStringAuto(new IntPtr(lpRecvData.lpAppData)));
            //        m_lpOwner.DisplayText(strInfo);
            //    }
            //}
            //m_lpOwner.DisplayText("过滤字段部分：\n");
            //if (lpRecvData.iFilterDataLen > 0)
            //{
            //    CT2UnPacker lpUnpack = new CT2UnPacker(lpRecvData.lpFilterData, (uint)lpRecvData.iFilterDataLen);
            //    m_lpOwner.PrintUnPack(lpUnpack);
            //    lpUnpack.Dispose();
            //}
            //CT2UnPacker lpUnPack1 = new CT2UnPacker((void*)lpData, (uint)nLength);
            //if (lpUnPack1 != null)
            //{
            //    m_lpOwner.PrintUnPack(lpUnPack1);
            //    lpUnPack1.Dispose();
            //}
            //m_lpOwner.DisplayText("***************************\n");
        }
        public override void OnRecvTickMsg(CT2SubscribeInterface lpSub, int subscribeIndex, string TickMsgInfo)
        {

        }

    };
}
