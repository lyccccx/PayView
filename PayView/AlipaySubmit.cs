using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Submit
    /// 功能：支付宝各接口请求提交类
    /// 详细：构造支付宝各接口表单HTML文本，获取远程HTTP数据
    /// 版本：3.3
    /// 修改日期：2011-07-05
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考
    /// </summary>
    public class Submit
    {
        #region 字段
        //支付宝网关地址（新）
        private static string GATEWAY_NEW = "https://mapi.alipay.com/gateway.do?";
        //商户的私钥
        private static string _private_key = "MIIEowIBAAKCAQEAnydIjvRVG0nrDecS9HddOVCikUuvITVl22QyVWL5rxD1XtqGHbAAeCNzJk/m3lzGKtaO8HCy9BRJTIU1tKvhENzwVOxnS3U+5g2kqeNVolIHanSJn7Q62DIn8596hcnEr0s30nc4J6CXQ2JhyZ7HNyzZ+rks/D+IZY3Sjqw7yql+6L8UU7DARSRhlYVALiKmbGO7mHqOLomGCaTJ5s2XsQKayBTF0WMid5FauQFz3jMwnsSW9437DflLQmNt8GBSJB9XdJCubkICzzEkEu7ZnaSa+02N4sxlZZdKjxeKn2WUEZcY0KLGcbJsq7d9AMvpDLA2qLrqw7wP34VIGsWMgQIDAQABAoIBABHTKIE6RD3mLXlFJA5VQA+nRE3ZmCez/1BvDGQbzbMZxyF0gAjbKXJLJh5oXIcTBO7PUPsE5EYJ75uuX7F4fqCQ3inkwDznSMAjTwnn+DNR1JrLqo5EdUK5e1gByIsraefoGLxttdBaYBaf8ivOqKk5UMCP9MXbp78X/zkTeS7dV66QAJv4H8YT7fYMW8rIq5JJl9irW1g4tpocbzJJiZnnuozHt/qOHTkve5PIFzsHKositfHAbQgtqM2bj6exI4hpozbJbPR7AJhhDut2Q21h6e7hFNSgydx2DSeWEqm/hK7mz5kNTwmc+iEBODS66FOHfWRlgbYwhzmEBuNhOkECgYEAyfu2WPynhgDh/k4sHIzMCx79K/MoAjXH5JMvJNb+580SZBDT/p1yAoev1HPtdYUWd/ZH2k05QdDZlzNA30uaLeLg1cxoUhXH4Uow7Y9OCST7uyWXUsGM5Sylw5kbUeFMMYVZ6j/bHN4PqOux5pg932pIFdMJpvCIunjiwvxhHrUCgYEAybdVfa2Boh/bkWMrUNx5ZuITwe4I4p8wcTvCeAt0/IAkg5Fd6L7SBZga1hhOnzu7SfJiMUd5vG0pJ+CqZTxA7+J581ejasnCo2yrIvb2F+mdmRNo0DS5EP1gPcz/EqmnmZHWRrSaLd6NSgdVe/keHThiy3V4IcuWwSul/l+KCh0CgYA/cgvDRAmzNA/I+/ErPqbRT3ijF4wXtaEGkZ0ba1VCps4CFK8iqX4ogUqf55JNefKm1/uV/O/hVqMitXzJJ0xU4ZFSVxTlw+W3RMC9vmf6w103WgWAfz+stSuUl0FXpPd0DrlBtbE0DiTJINAO6P92cEIYaOP9Rk0MlfBU40X2iQKBgFNJs6702TXL2akqPVRh9G6aonXMhzarbCEU/7L5aBBqCKmaeCAFykotB8emua/dxfM+dXTLgmRe3kNs7G5odpeV96yWXw9Ux10bHX6OYgZ1m3D9JqXxXwi41eguoJNgIaezI7qGD7Mo1UXfyVgrAFgoVAKWOkgZ++E+2Iczg5exAoGBAKArcyQQ4NUqRgaxh/VrAgBO56AnBCyC0BtTQZH6nJFLTnC5Tc5DajcFnc9JAYCz+p4i8nAO/BbP+QxVt2OOGbgUxIXN9LG1CGkEmnNlQXGaA/HzM6z+nYsStR3lcvT17+tdJXPLHWoz1UFOvjxyMUrEQ8P3IiVliH9kUkjqmgqU";
        //编码格式
        private static string _input_charset = "utf-8";
        //签名方式
        private static string _sign_type = "SRA";
        #endregion

        static Submit()
        {
            _private_key = Config.private_key;
            _input_charset = Config.input_charset.Trim().ToLower();
            _sign_type = Config.sign_type.Trim().ToUpper();
        }

        /// <summary>
        /// 生成请求时的签名
        /// </summary>
        /// <param name="sPara">请求给支付宝的参数数组</param>
        /// <returns>签名结果</returns>
        private static string BuildRequestMysign(Dictionary<string, string> sPara)
        {
            //把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            string prestr = Core.CreateLinkString(sPara);

            //把最终的字符串签名，获得签名结果
            string mysign = "";
            switch (_sign_type)
            {
                case "RSA":
                    mysign = RSAFromPkcs8.sign(prestr, _private_key, _input_charset);
                    break;
                default:
                    mysign = "";
                    break;
            }

            return mysign;
        }

        /// <summary>
        /// 生成要请求给支付宝的参数数组
        /// </summary>
        /// <param name="dictPara">请求前的参数数组</param>
        /// <returns>要请求的参数数组</returns>
        private static Dictionary<string, string> BuildRequestPara(SortedDictionary<string, string> dictPara)
        {
            //待签名请求参数数组
            Dictionary<string, string> dictParaTemp = new Dictionary<string, string>();
            //签名结果
            string mysign = "";

            //过滤签名参数数组
            dictParaTemp = Core.FilterPara(dictPara);

            //获得签名结果
            mysign = BuildRequestMysign(dictParaTemp);

            //签名结果与签名方式加入请求提交参数组中
            dictParaTemp.Add("sign", mysign);
            dictParaTemp.Add("sign_type", _sign_type);

            return dictParaTemp;
        }

        /// <summary>
        /// 生成要请求给支付宝的参数数组
        /// </summary>
        /// <param name="dictPara">请求前的参数数组</param>
        /// <param name="code">字符编码</param>
        /// <returns>要请求的参数数组字符串</returns>
        private static string BuildRequestParaToString(SortedDictionary<string, string> dictPara, Encoding code)
        {
            //待签名请求参数数组
            Dictionary<string, string> dictParaTemp = new Dictionary<string, string>();
            dictParaTemp = BuildRequestPara(dictPara);

            //把参数组中所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串，并对参数值做urlencode
            string strRequestData = Core.CreateLinkStringUrlencode(dictParaTemp, code);

            return strRequestData;
        }

        /// <summary>
        /// 建立请求，以表单HTML形式构造（默认）
        /// </summary>
        /// <param name="dictPara">请求参数数组</param>
        /// <param name="strMethod">提交方式。两个值可选：post、get</param>
        /// <param name="strButtonValue">确认按钮显示文字</param>
        /// <returns>提交表单HTML文本</returns>
        public static string BuildRequest(SortedDictionary<string, string> dictPara, string strMethod, string strButtonValue)
        {
            //待请求参数数组
            Dictionary<string, string> dictParaTemp = new Dictionary<string, string>();
            dictParaTemp = BuildRequestPara(dictPara);

            StringBuilder sbHtml = new StringBuilder();

            sbHtml.Append("<form id='alipaysubmit' name='alipaysubmit' action='" + GATEWAY_NEW + "_input_charset=" + _input_charset + "' method='" + strMethod.ToLower().Trim() + "'>");

            foreach (KeyValuePair<string, string> temp in dictParaTemp)
            {
                sbHtml.Append("<input type='hidden' name='" + temp.Key + "' value='" + temp.Value + "'/>");
            }

            //submit按钮控件请不要含有name属性
            sbHtml.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");

            sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");

            return sbHtml.ToString();
        }

        /// <summary>
        /// 用于防钓鱼，调用接口query_timestamp来获取时间戳的处理函数
        /// 注意：远程解析XML出错，与IIS服务器配置有关
        /// </summary>
        /// <returns>时间戳字符串</returns>
        public static string Query_timestamp()
        {
            string url = GATEWAY_NEW + "service=query_timestamp&partner=" + Config.partner + "&_input_charset=" + Config.input_charset;
            string encrypt_key = "";

            XmlTextReader Reader = new XmlTextReader(url);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Reader);

            encrypt_key = xmlDoc.SelectSingleNode("/alipay/response/timestamp/encrypt_key").InnerText;

            return encrypt_key;
        }
    }
}