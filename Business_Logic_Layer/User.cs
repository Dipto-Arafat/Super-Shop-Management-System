using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer
{
    public class User
    {
        DataAccess da = new DataAccess();

        string user_Name, user_Id, user_Password, user_Gender, user_Phone, user_House, user_Road, user_City, user_TypeName;
        int user_Salary, user_Type;
        public byte[] user_Image;
        public string User_Name
        {
            get { return this.user_Name; }
            set { this.user_Name = value; }
        }
        public string User_ID
        {
            get { return this.user_Id; }
            set { this.user_Id = value; }
        }
        public int User_Type
        {
            set { this.user_Type = value; }
            get { return this.user_Type; }
        }
        public string User_Password
        {
            get { return this.user_Password; }
            set { this.user_Password = value; }
        }
        public string User_Gender
        {
            get { return this.user_Gender; }
            set { this.user_Gender = value; }
        }
        public int User_Salary
        {
            set { this.user_Salary = value; }
            get { return this.user_Salary; }
        }
        public string User_Phone
        {
            get { return this.user_Phone; }
            set { this.user_Phone = value; }
        }

        public string User_House
        {
            get { return this.user_House; }
            set { this.user_House = value; }
        }
        public string User_Road
        {
            get { return this.user_Road; }
            set { this.user_Road = value; }
        }
        public string User_City
        {
            get { return this.user_City; }
            set { this.user_City = value; }
        }
        public string User_TypeName
        {
            set { this.user_TypeName = value; }
            get { return this.user_TypeName; }
        }
        
        public bool Duplicate_ID_Check_User(string id)
        {
            bool id_chk = da.Duplicate_ID_Check(id);
            return id_chk;
        }
        public void InsertUser(string name, string userid, string pass, string gender, string phone, string house, string road, string city, byte[] img)
        {
            da.Insert(name, userid, pass, gender, phone, house, road, city, img);
        }
        public void CreateUser(string name, string userid, string pass, string gender, string phone, string house, string road, string city, byte[] img,string salary,string type)
        {
            da.Delete(name, userid, pass, gender, phone, house, road, city, img,salary,type);
        }
        public List<User>Manage_Account_ShowAllUsers()
        {
            var users = new List<User>();
            for (int i = 0; i < da.GetAllUsers().Rows.Count; i++)
            {
                var u = new User();
                u.User_Name = da.GetAllUsers().Rows[i]["Name"].ToString();
                u.User_ID = da.GetAllUsers().Rows[i]["User_id"].ToString();
                u.User_Gender = da.GetAllUsers().Rows[i]["Gender"].ToString();
                u.User_Phone = da.GetAllUsers().Rows[i]["Phone_Number"].ToString();
                u.User_Salary = int.Parse(da.GetAllUsers().Rows[i]["Salary"].ToString());
                u.user_Type = int.Parse(da.GetAllUsers().Rows[i]["Type_No"].ToString());
                u.User_House = da.GetAllUsers().Rows[i]["House_No"].ToString();
                u.User_Road = da.GetAllUsers().Rows[i]["Road_No"].ToString();
                u.User_City = da.GetAllUsers().Rows[i]["City"].ToString();
                u.User_TypeName = da.GetAllUsers().Rows[i]["Designation"].ToString();
                users.Add(u);
            }
            return users;
        }
        public void UpdateOwnProfile(string id,string name,string pass,string gender,string phone,string house,string road,string city)
        {
            da.UpdateOwnProfile_Data_Access(id,name,pass,gender,phone,house,road,city);
        }
        public User ViewOwnProfile(string id)
        {
            var u = new User();
            u.User_Name = da.GetOwnProfile(id).Rows[0]["Name"].ToString();
            u.User_ID = da.GetOwnProfile(id).Rows[0]["User_id"].ToString();
            u.User_Password = da.GetOwnProfile(id).Rows[0]["Password"].ToString();
            u.User_Gender = da.GetOwnProfile(id).Rows[0]["Gender"].ToString();
            u.User_Phone = da.GetOwnProfile(id).Rows[0]["Phone_Number"].ToString();
            u.User_Salary = int.Parse(da.GetOwnProfile(id).Rows[0]["Salary"].ToString());
            u.user_Type = int.Parse(da.GetOwnProfile(id).Rows[0]["Type_No"].ToString());
            u.User_House = da.GetOwnProfile(id).Rows[0]["House_No"].ToString();
            u.User_Road = da.GetOwnProfile(id).Rows[0]["Road_No"].ToString();
            u.User_City = da.GetOwnProfile(id).Rows[0]["City"].ToString();
            u.User_TypeName = da.GetOwnProfile(id).Rows[0]["Designation"].ToString();
            u.user_Image= (byte[])da.GetOwnProfile(id).Rows[0]["Image"];
            return u;
        }
        public bool LogInUser(string id, string pass)
        {
            bool approval = da.LogIn(id, pass);
            return approval;
        }
        public User RunTimeObjectFromDataAccess()
        {
            User usr = new User();
            usr.User_Name = da.RunTimeObject().Rows[0]["Name"].ToString();
            usr.User_ID = da.RunTimeObject().Rows[0]["User_id"].ToString();
            usr.user_Password = da.RunTimeObject().Rows[0]["Password"].ToString();
            usr.User_Gender = da.RunTimeObject().Rows[0]["Gender"].ToString();
            usr.User_Phone = da.RunTimeObject().Rows[0]["Phone_Number"].ToString();
            usr.User_Salary = int.Parse(da.RunTimeObject().Rows[0]["Salary"].ToString());
            usr.User_Type = int.Parse(da.RunTimeObject().Rows[0]["Type_No"].ToString());
            usr.User_House = da.RunTimeObject().Rows[0]["House_No"].ToString();
            usr.User_Road = da.RunTimeObject().Rows[0]["Road_No"].ToString();
            usr.User_City = da.RunTimeObject().Rows[0]["City"].ToString();
            usr.user_Image = (byte[])da.RunTimeObject().Rows[0]["Image"];
            return usr;
        }
        public void DeleteAccount(string id)
        {
            da.DeleteAccounts(id);
        }
        public void UpdateAccount(string id, string type,string salary)
        {
            da.UpdateAccounts(id,type,salary);
        }
    }
}
