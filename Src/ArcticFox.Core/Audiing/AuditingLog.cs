using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArcticFox.Audiing
{
    /// <summary>
    /// 审计日志
    /// </summary>
    public class AuditingLog
    {
        [Key]
        public long Id { set; get; }
        /// <summary>
        /// 访问的服务名
        /// </summary>
        public string ServerName { set; get; }
        /// <summary>
        /// 耗时
        /// </summary>
        public double Duration { set; get; }
        /// <summary>
        /// 产生的一场
        /// </summary>
        public string Exception { set; get; }
        /// <summary>
        /// 客户端Ip
        /// </summary>
        public string IPAddress { set; get; }
        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime ExecutionTime { set; get; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { set; get; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public string Result { set; get; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public override string ToString()
        {
            return $"审计：{IPAddress} - {ExecutionTime} 访问了 {ServerName} 传入参数 {Parameters} 耗时 {Duration}ms 返回结果 {Result}";
        }
    }
}
