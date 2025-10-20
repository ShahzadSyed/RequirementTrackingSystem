using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS
{
    class Global
    {
        public static int empcode;
        public static int GEmpCode
        {
            get { return empcode; }
            set { empcode = value; }
        }



        public static int UserId = 0;
        public static int GetUserId
        {
            get { return UserId; }
            set { UserId = value; }
        }


        public static string UserName = "";
        public static string GUserName
        {
            get { return UserName; }
            set { UserName = value; }
        }


        public static string UserDepart = "Admin";
        public static string GUserDepart
        {
            get { return UserDepart; }
            set { UserDepart = value; }
        }

        public static string SysMachineName = "";
        public static string USysMachineName
        {
            get { return SysMachineName; }
            set { SysMachineName = value; }
        }

        public static string DisplayName = "";
        public static string GDisplayName
        {
            get { return DisplayName; }
            set { DisplayName = value; }
        }


        public static string HOD = "";
        public static string GHOD
        {
            get { return HOD; }
            set { HOD = value; }
        }

        public static int UserDepartId = 0;
        public static int GUserDepartId
        {
            get { return UserDepartId; }
            set { UserDepartId = value; }
        }


        public static bool isAdmin = false;
        public static bool GisAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
    }
}
