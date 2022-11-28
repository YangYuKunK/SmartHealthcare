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
            CreateMap<Tb_sys_DoctorInfo, Tb_sys_DoctorInfoViewModel>().ReverseMap();//医生
            CreateMap<Tb_sys_GoodsInfo, Tb_sys_GoodsInfoViewModel>().ReverseMap();//商品
            CreateMap<Tb_sys_GoodsType, Tb_sys_GoodsTypeViewModel>().ReverseMap();//商品分类
        }
    }
}
