using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SmartHealthcare.Domain;
using SmartHealthcare.Service.ViewModel;

namespace SmartHealthcare.Service
{
    /// <summary>
    /// 配置AutoMapper映射规则
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {  
            //          数据模型  视图模型
            //CreateMap<Movies, MoviesViewModel>().ReverseMap(); // 例子
            CreateMap<Tb_sys_UserInfo, Tb_sys_UserInfoViewModel>().ReverseMap();//用户
        }
    }
}
