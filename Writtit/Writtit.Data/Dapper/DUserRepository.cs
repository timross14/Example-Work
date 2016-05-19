using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Writtit.Models;

namespace Writtit.Data.Dapper
{
    public class DUserRepository
    {
        private readonly string _connection = ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString;

        public List<UserRoleModel> GetAllUserRoles()
        {
            List<UserRoleModel> userRoles;
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                userRoles = cn.Query<UserRoleModel>("SELECT u.Email,r.RoleId, ro.Name FROM AspNetUsers u " +
                                                    "LEFT JOIN AspNetUserRoles r " +
                                                    "ON u.Id = r.UserId " +
                                                    "LEFT JOIN AspNetRoles ro " +
                                                    "ON ro.Id=r.RoleId").ToList();
            }
            return userRoles;
        }

        public void WriteUserRoles(UserRoleModel newUserRoles)
        {
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                var p = new DynamicParameters();

                p.Add("@UserEmail", newUserRoles.Email);
                p.Add("@NewRole", (int)newUserRoles.UserChange);

                if (newUserRoles.RoleID == null)
                {
                    cn.Execute("INSERT INTO AspNetUserRoles (UserId, RoleID) " +
                               "SELECT u.Id, 3 FROM AspNetUsers u " +
                               "WHERE u.Email = @UserEmail", p);
                }
                else
                {
                    cn.Execute("UPDATE ur " +
                            "SET ur.RoleId = @NewRole " +
                            "FROM AspNetUserRoles ur " +
                            "INNER JOIN AspNetUsers u " +
                            "ON u.Id = ur.UserId " +
                            "WHERE u.Email = @UserEmail", p);
                }
            }
        }
    }
}