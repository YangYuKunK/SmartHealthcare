﻿using SmartHealthcare.Domain;
using SmartHealthcare.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.UserInfo
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        List<Tb_sys_UserInfo> GetUserLists();

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户试图模型</param>
        /// <returns></returns>
        int CreateUserInfo(Tb_sys_UserInfoViewModel user);

        /// <summary>
        /// 删除该用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        int DeleteUser(int userid);
    }
}
