using Dapper;

using IdentityServer4.Models;
using IdentityServer4.Validation;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Service.Helper.Dapper;
using Service.Helper.Extensions;

using System.Data;
using System.Security.Claims;

namespace Auth
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        public DapperFactory _conn;

        public ResourceOwnerPasswordValidator(DapperFactory conn)
        {
            this._conn = conn;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {


            var userName = context.UserName;
            var password = context.Password;

            //switch (context.Request.Client.ClientName)
            //{
            //    case "UserClient":
            userDto User = new userDto();
            //var Password = Crypto.GetEncryptMD5(context.Password);
            var Password = context.Password;
            //查询数据库 
            var dataJson = _conn.CreateClient().QueryList<dynamic>($@"Select * From tb_users ", null);

            //if (!string.IsNullOrEmpty(dataJson))
            //{
            //    User = JsonHelper.JSONToObject<userDto>(dataJson);
            //}
            //else
            //{
            //    using (var db = new dbContext())
            //    {
            //        User = db.TUser.Where(x => x.IsDelete == false && (x.Name == context.UserName || x.Phone == context.UserName) && x.PassWord == Password).Select(x => new userDto
            //        {
            //            Id = x.Id.ToString(),
            //            Phone = x.Phone,
            //            CreatedTime = x.CreateTime,
            //            Password = x.PassWord,
            //            Name = x.Name,
            //            TenantId = x.TenantId
            //        }).FirstOrDefault();
            //    }

            //    }
            //    if (User != null && User != default && User.Password == Password)
            //    {
            //context.Result = new GrantValidationResult(
            //                   subject: context.UserName,
            //                   authenticationMethod: "custom",
            //                   claims: new Claim[] {
            //            new Claim("Name", context.UserName),
            //            new Claim("Id", loginUser.Id.ToString()),
            //            new Claim("RealName", loginUser.RealName),
            //            new Claim("Email", loginUser.Email)
            //                   }
            //               );
            //    }
            //    else
            //    {
            //        //验证失败
            context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "账号密码错误"
                );
            //    }
            //    break;
            //case "UMUserClient":
            //    uMClientUserDto uMUser = null;
            //    //查询数据库
            //    dataJson = GlobalServices.ServiceProvider.GetService<ICacheService>().GetString("CacheClientUserList" + context.UserName);

            //    if (!string.IsNullOrEmpty(dataJson))
            //    {
            //        uMUser = JsonHelper.JSONToObject<uMClientUserDto>(dataJson);
            //    }
            //    else
            //    {
            //        using (var db = new dbContext())
            //        {
            //            uMUser = db.TUser.Where(x => x.IsDelete == false && x.Id.ToString() == context.UserName).Select(x => new uMClientUserDto
            //            {
            //                Id = x.Id.ToString(),
            //                Phone = x.Phone,
            //                CreatedTime = x.CreateTime,
            //                Name = x.Name,
            //                TenantId = x.TenantId
            //            }).FirstOrDefault();
            //        }
            //    }
            //    if (uMUser != null && uMUser != default)
            //    {
            //context.Result = new GrantValidationResult(
            //                   subject: context.UserName,
            //                   authenticationMethod: "custom",
            //                   claims: new Claim[] {
            //            new Claim("Name", context.UserName),
            //            new Claim("Id", loginUser.Id.ToString()),
            //            new Claim("RealName", loginUser.RealName),
            //            new Claim("Email", loginUser.Email)
            //                   }
            //               );
            //         );
            //        CacheUserListAsync(uMUser);
            //    }
            //    else
            //    {
            //        //验证失败
            //        context.Result = new GrantValidationResult(
            //            TokenRequestErrors.InvalidGrant,
            //            "账号密码错误"
            //            );
            //    }
            //    break;
            //default:
            //    break;
            //}
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");

            return Task.FromResult(0);
        }
    }
}
