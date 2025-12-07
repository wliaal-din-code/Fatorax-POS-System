using FX_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Buisness
{
    public class clsUser
    {

        enum enMode { Add, Update }

        enMode Mode = enMode.Add;

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte Role { get; set; }
        public byte IsActive { get; set; }

        public clsUser()
        {
            this.UserId = -1;
            this.Username = "";
            this.Password = "";
            this.Role = 0;
            this.IsActive = 0;
            Mode = enMode.Add;
        }

        public clsUser(int UserId, string Username, string Password, byte Role, byte IsActive)
        {
            this.UserId = UserId;
            this.Username = Username;
            this.Password = Password;
            this.Role = Role;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserId = clsUserData.AddNewUsers(this.Username, this.Password, this.Role, this.IsActive);

            return (this.UserId != -1);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUsers(this.UserId, this.Username, this.Password, this.Role, this.IsActive);
        }

        public static bool DeleteUser(int UserId)
        {
            return clsUserData.DeleteUsers(UserId);
        }

        public static clsUser Find(int UserId)
        {
            string UserName = "", Password = "";
            byte Role = 0, IsActive = 0;

            bool IsFound = clsUserData.GetUserByUserId(UserId, ref UserName, ref Password, ref Role, ref IsActive);

            if (IsFound)
            {
                return new clsUser(UserId, UserName, Password, Role, IsActive);
            }
            else
            {
                return null;
            }

        }

        public static clsUser FindUserByUserNameAndPassword(string UserName, string Password)
        {
            int UserId = 0;
            byte Role = 0, IsActive = 0;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword(UserName, Password, ref UserId, ref Role, ref IsActive);

            if (IsFound)
            {
                return new clsUser(UserId, UserName, Password, Role, IsActive);
            }
            else
            {
                return null;
            }

        }

        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool isUserExist(string UserName, string Password)
        {
            return clsUserData.IsUserExist(UserName, Password);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if (_AddNewUser())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return _UpdateUser();

            }
            return false;
        }
    }
}
