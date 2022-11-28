using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 分页
    /// </summary>
    public class QueryInfo
    {
        public string? files { get; set; } //表字段
        public string? tableName { get; set; } //表名
        public string? where { get; set; } //查询条件
        public string? orderby { get; set; } //排序
        public int pageindex { get; set; } //当前页
        public int pagesize { get; set; } //当前页显示条数
        //public int total { get; set; } //结果集条数
    }
}
