using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.4
    /// 修改日期：2016-03-08
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public class Config
    {

        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        // 合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public static string partner = "2088222051249139";

        // 收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        public static string seller_id = partner;
		
		//商户的私钥,原始格式，RSA公私钥生成：https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.nBDxfy&treeId=58&articleId=103242&docType=1
        public static string private_key = "MIIEowIBAAKCAQEAnydIjvRVG0nrDecS9HddOVCikUuvITVl22QyVWL5rxD1XtqGHbAAeCNzJk/m3lzGKtaO8HCy9BRJTIU1tKvhENzwVOxnS3U+5g2kqeNVolIHanSJn7Q62DIn8596hcnEr0s30nc4J6CXQ2JhyZ7HNyzZ+rks/D+IZY3Sjqw7yql+6L8UU7DARSRhlYVALiKmbGO7mHqOLomGCaTJ5s2XsQKayBTF0WMid5FauQFz3jMwnsSW9437DflLQmNt8GBSJB9XdJCubkICzzEkEu7ZnaSa+02N4sxlZZdKjxeKn2WUEZcY0KLGcbJsq7d9AMvpDLA2qLrqw7wP34VIGsWMgQIDAQABAoIBABHTKIE6RD3mLXlFJA5VQA+nRE3ZmCez/1BvDGQbzbMZxyF0gAjbKXJLJh5oXIcTBO7PUPsE5EYJ75uuX7F4fqCQ3inkwDznSMAjTwnn+DNR1JrLqo5EdUK5e1gByIsraefoGLxttdBaYBaf8ivOqKk5UMCP9MXbp78X/zkTeS7dV66QAJv4H8YT7fYMW8rIq5JJl9irW1g4tpocbzJJiZnnuozHt/qOHTkve5PIFzsHKositfHAbQgtqM2bj6exI4hpozbJbPR7AJhhDut2Q21h6e7hFNSgydx2DSeWEqm/hK7mz5kNTwmc+iEBODS66FOHfWRlgbYwhzmEBuNhOkECgYEAyfu2WPynhgDh/k4sHIzMCx79K/MoAjXH5JMvJNb+580SZBDT/p1yAoev1HPtdYUWd/ZH2k05QdDZlzNA30uaLeLg1cxoUhXH4Uow7Y9OCST7uyWXUsGM5Sylw5kbUeFMMYVZ6j/bHN4PqOux5pg932pIFdMJpvCIunjiwvxhHrUCgYEAybdVfa2Boh/bkWMrUNx5ZuITwe4I4p8wcTvCeAt0/IAkg5Fd6L7SBZga1hhOnzu7SfJiMUd5vG0pJ+CqZTxA7+J581ejasnCo2yrIvb2F+mdmRNo0DS5EP1gPcz/EqmnmZHWRrSaLd6NSgdVe/keHThiy3V4IcuWwSul/l+KCh0CgYA/cgvDRAmzNA/I+/ErPqbRT3ijF4wXtaEGkZ0ba1VCps4CFK8iqX4ogUqf55JNefKm1/uV/O/hVqMitXzJJ0xU4ZFSVxTlw+W3RMC9vmf6w103WgWAfz+stSuUl0FXpPd0DrlBtbE0DiTJINAO6P92cEIYaOP9Rk0MlfBU40X2iQKBgFNJs6702TXL2akqPVRh9G6aonXMhzarbCEU/7L5aBBqCKmaeCAFykotB8emua/dxfM+dXTLgmRe3kNs7G5odpeV96yWXw9Ux10bHX6OYgZ1m3D9JqXxXwi41eguoJNgIaezI7qGD7Mo1UXfyVgrAFgoVAKWOkgZ++E+2Iczg5exAoGBAKArcyQQ4NUqRgaxh/VrAgBO56AnBCyC0BtTQZH6nJFLTnC5Tc5DajcFnc9JAYCz+p4i8nAO/BbP+QxVt2OOGbgUxIXN9LG1CGkEmnNlQXGaA/HzM6z+nYsStR3lcvT17+tdJXPLHWoz1UFOvjxyMUrEQ8P3IiVliH9kUkjqmgqU";

        //支付宝的公钥，查看地址：https://b.alipay.com/order/pidAndKey.htm 
        public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnydIjvRVG0nrDecS9HddOVCikUuvITVl22QyVWL5rxD1XtqGHbAAeCNzJk/m3lzGKtaO8HCy9BRJTIU1tKvhENzwVOxnS3U+5g2kqeNVolIHanSJn7Q62DIn8596hcnEr0s30nc4J6CXQ2JhyZ7HNyzZ+rks/D+IZY3Sjqw7yql+6L8UU7DARSRhlYVALiKmbGO7mHqOLomGCaTJ5s2XsQKayBTF0WMid5FauQFz3jMwnsSW9437DflLQmNt8GBSJB9XdJCubkICzzEkEu7ZnaSa+02N4sxlZZdKjxeKn2WUEZcY0KLGcbJsq7d9AMvpDLA2qLrqw7wP34VIGsWMgQIDAQAB";
		
        // 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        public static string notify_url = "http://商户网关地址/alipay.wap.create.direct.pay.by.user-CSHARP-UTF-8/notify_url.aspx";

        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        public static string return_url = "http://商户网关地址/alipay.wap.create.direct.pay.by.user-CSHARP-UTF-8/return_url.aspx";

        // 签名方式
        public static string sign_type = "RSA";

        // 调试用，创建TXT日志文件夹路径，见AlipayCore.cs类中的LogResult(string sWord)打印方法。
        public static string log_path = HttpRuntime.AppDomainAppPath.ToString() + "log/";

        // 字符编码格式 目前支持utf-8
        public static string input_charset = "utf-8";

        // 支付类型 ，无需修改
        public static string payment_type = "1";

        // 调用的接口名，无需修改
        public static string service = "alipay.wap.create.direct.pay.by.user";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    }
}