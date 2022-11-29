using Microsoft.AspNetCore.Authorization;

namespace SmartHealthcare.Api.Filter
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    //ResponseMsg responseMsg = new ResponseMsg(null);
        //    //filterContext.HttpContext.Response.Write(JsonConvert.SerializeObject(responseMsg));

        //    //注释掉父类方法，因为父类里的OnAuthorization方法会调用AuthorizeCore
        //    base.OnAuthorization(filterContext);
        //}

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    if (!String.IsNullOrWhiteSpace(httpContext.Request.Headers["Token"]))
        //    {
        //        //jwt验证
        //        return true;
        //    }
        //    else
        //    {
        //        httpContext.Response.Write(JsonContent.SerializeObject(new ResponseMsg(null)
        //        {
        //            ResponseCode = ResponseCode.LOGINNEEDED,
        //            Msg = "Token验证失败"
        //        }));
        //        return false;
        //    }

        //}
        //public class ResponseMsg
        //{

        //    public ResponseCode ResponseCode = ResponseCode.SUCCESS;
        //    public string Msg = "";
        //    public object Data = default;

        //    public ResponseMsg(object obj)
        //    {
        //        this.Data = obj;
        //    }
        //    public ResponseMsg() { }
        //    //public string msg;
        //}

        //public enum ResponseCode
        //{
        //    SUCCESS = 1, ERROR = -1, LOGINNEEDED = 0
        //}

    }
}
