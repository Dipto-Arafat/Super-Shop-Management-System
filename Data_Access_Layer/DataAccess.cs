using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Data_Access_Layer
{
   
    public class DataAccess
    {
        SqlConnection con;
        DataTable dtbl;
        public DataAccess()
        {
            con = new SqlConnection(@"Data Source=DELL_N5559\DIPTOTAWHID;Initial Catalog=CSharpProject;Integrated Security=True");
        }
        public bool Duplicate_ID_Check(string a)
        {
            bool value = false;
            con.Open();
            string query = "SELECT * FROM USER_INFO WHERE User_id='" + a +"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                value = false;
                dtbl = dt;
            }
            else
            {
                value = true;
            }
            con.Close();
            return value;
        }
        public DataTable GetAllUsers()
        {
            con.Open();
            string query = "SELECT u.*,t.Designation FROM USER_INFO AS u, USER_TYPE AS t WHERE u.Type_No=t.Type_No";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public DataTable GetOwnProfile(string id)
        {
            con.Open();
            string query = "SELECT u.*,t.Designation FROM USER_INFO AS u, USER_TYPE AS t WHERE u.Type_No=t.Type_No and User_Id='"+id+"'";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public void Insert(string name, string userid, string pass, string gender, string phone, string house, string road, string city, byte[] img)
        {
                con.Open();
                string query = "INSERT INTO USER_INFO (Name,User_id,Password,Gender,Phone_Number,Salary,Type_No,Image,House_No,Road_No,City) VALUES ('" + name + "','" + userid + "','" + pass + "','" + gender + "','" + phone + "',0,3,@img,'" + house + "','" + road + "','" + city + "')";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@img", img));
                command.ExecuteNonQuery();
                con.Close();
        }
        public void Delete(string name, string userid, string pass, string gender, string phone, string house, string road, string city, byte[] img,string sal,string type)
        {
            int salary = int.Parse(sal);
            int typeuser = int.Parse(type);
            con.Open();
            string query = "INSERT INTO USER_INFO (Name,User_id,Password,Gender,Phone_Number,Salary,Type_No,Image,House_No,Road_No,City) VALUES ('" + name + "','" + userid + "','" + pass + "','" + gender + "','" + phone + "',"+salary+","+typeuser+",@img,'" + house + "','" + road + "','" + city + "')";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.Add(new SqlParameter("@img", img));
            command.ExecuteNonQuery();
            con.Close();
        }

        public bool LogIn(string id, string pass)
        {
            bool tempApproval = false;
            con.Open();
            string query = "SELECT * FROM USER_INFO WHERE User_id='" + id + "' and Password='" + pass + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                tempApproval = true;
                dtbl = dt;
            }
            else
            {
                tempApproval = false;
            }
            con.Close();
            return tempApproval;
        }
        public DataTable RunTimeObject()
        {
            return dtbl;
        }
        public void UpdateOwnProfile_Data_Access(string id, string name, string pass, string gender, string phone, string house, string road, string city)
        {
            con.Open();
            string query = "UPDATE USER_INFO SET Name='"+name+"',Password='" + pass + "',Gender='"+gender+"',Phone_Number='"+phone+"',House_No='" + house + "',Road_No='" + road + "', City='" + city+ "' WHERE User_Id='" + id + "'";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();

        }
        public DataTable ShowAllStores()
        {
            con.Open();
            string query = "SELECT * FROM Store_Info";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public DataTable GenerateBillAlls()
        {
            DataTable dt2 = new DataTable();
            DataTable dtAll = new DataTable();
            var reader = new StreamReader(File.OpenRead("C:\\Users\\User\\Desktop\\Scan session.csv"));
            var listA = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                listA.Add(line.ToString());
            }
        
           // var firstlistA = listA.ToArray();
            con.Open();
           // int[] arr = new int[] { 4, 6 };
            for (int i = 0; i <listA.Count; i++)
            {
                string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id AND p.Product_Id="+listA[i]+"";
                SqlCommand str = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(str);
                DataTable dt1 = new DataTable();
                da.Fill(dt1);
                dtAll = dtAll.Copy();
                dtAll.Merge(dt1);
            }
            con.Close();
            return dtAll;
        }

        public void UpdateInventory(string a,float quantity)
        {
            quantity = quantity - 1;
            con.Open();
            string query = "UPDATE PRODUCT_INFO SET Quantity="+quantity+" where Product_Id='"+a+"'";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetAllNameCategories()
        {
            con.Open();
            string query = "SELECT p.Product_name FROM PRODUCT_INFO AS p";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public DataTable GetAllNameCategories2()
        {
            con.Open();
            string query = "SELECT TYPE FROM PRODUCT_CATEGORY ";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public DataTable SearchByNameCategories(string name)
        {
            con.Open();
            string query = "SELECT p.*,c.TYPE FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id and p.Product_Name ='" + name + "' OR c.Type='" + name + "'";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public void DeleteAccounts(string id)
        {
            con.Open();
            string query = "DELETE FROM USER_INFO WHERE User_Id='" + id + "' ";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateAccounts(string id,string type, string sal)
        {
            int salary = int.Parse(sal);
            con.Open();
            string query = "UPDATE USER_INFO SET Type_No="+type+",Salary=" + sal +"WHERE User_Id='" + id + "'";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateStores(string id, string name, string loc, string phone, string mail)
        {
            con.Open();
            string query = "UPDATE STORE_INFO SET Store_Name='" + name + "', Location='" + loc + "',Phone='" + phone + "',Mail='" + mail + "' where Store_Id='" + id + "'";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }
        public void CreateStore_Data_Access(string name, string location, string phone, string mail)
        {
            con.Open();
            string query = "INSERT INTO STORE_INFO (Store_Name,Location,Phone,Mail) VALUES ('" + name + "','" + location + "','" + phone + "','" + mail +"')";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteStore_Data_Access(string id)
        {
            con.Open();
            string query = "DELETE FROM STORE_INFO WHERE Store_Id='" + id + "' ";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }
        public DataTable ShowOurStores(string name)
        {
            con.Open();
            string query = "SELECT * FROM STORE_INFO WHERE Store_Name='" + name + "'";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;

        }
        public DataTable GetAllProducts()
        {

            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;

        }
        public DataTable SearchAllDiscounts()
        {
            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id and p.Discount_Rate>0";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public DataTable GetAllSuppliers()
        {
            con.Open();
            string query = "SELECT * FROM PRODUCT_SUPPLIER";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public void UpdateSuppliers(string id, string name, string loc, string phone, string mail)
        {
            con.Open();
            string query = "UPDATE PRODUCT_SUPPLIER SET Supplier_Name='" + name + "', Location='" + loc + "',Phone='" + phone + "',Mail='" + mail + "' where Supplier_Id='" + id + "'";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }
        public bool Delete_Supplier_Data_Access(string id)
        {
            bool a;
            con.Open();
            string query = "SELECT * FROM PRODUCT_INFO WHERE Supplier_Id=" + id + "";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            if (dt1.Rows.Count == 0)
            {
                a = true;
                string query1 = "DELETE FROM PRODUCT_SUPPLIER WHERE Supplier_Id='" + id + "' ";
                SqlCommand str1 = new SqlCommand(query1, con);
                str1.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                a = false;
                con.Close();
            }
            return a;
        }

        public void CreateSupplier_Data_Access(string name, string location, string phone, string mail)
        {
            con.Open();
            string query = "INSERT INTO PRODUCT_SUPPLIER (Supplier_Name,Location,Phone,Mail) VALUES ('" + name + "','" + location + "','" + phone + "','" + mail + "')";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetAllCategories()
        {
            con.Open();
            string query = "SELECT * FROM PRODUCT_CATEGORY";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public void UpdateCategories(string id, string type)
        {
            con.Open();
            string query = "UPDATE PRODUCT_CATEGORY SET Type='" + type+ "' where Category_Id='" + id + "'";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }

        public bool DeleteCategories(string id,string type)
        {
            bool a;
            con.Open();
            string query = "SELECT * FROM PRODUCT_INFO WHERE Category_Id=" + id + "";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            if (dt1.Rows.Count == 0)
            {
                a = true;
                string query1 = "DELETE FROM PRODUCT_CATEGORY WHERE Category_Id='" + id + "' ";
                SqlCommand str1 = new SqlCommand(query1, con);
                str1.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                a = false;
                con.Close();
            }
            return a;
        }

        public void InsertCategories(string type)
        {
            con.Open();
            string query = "INSERT INTO PRODUCT_CATEGORY(Type) VALUES ('" + type + "')";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
        }

        public DataTable ShowAllProducts()
        {
            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id ";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public void DeleteProducts(string id)
        {
            con.Open();
            string query = "DELETE FROM PRODUCT_INFO WHERE Product_Id='" + id + "' ";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }

        public DataTable SearchByNames(string name)
        {
            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id and p.Product_Name LIKE '%"+name+"%'";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public DataTable SearchByCategories(string category)
        {
            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id and p.Category_Id IN (SELECT Category_Id FROM PRODUCT_CATEGORY WHERE Type='"+category+"')";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public DataTable SearchByDiscountRanges(string min,string max,string category)
        {
            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id and p.Category_Id IN (SELECT Category_Id FROM PRODUCT_CATEGORY WHERE Type='" + category + "') AND p.Discount_Rate BETWEEN "+min+" AND "+max+"";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }

        public DataTable SearchByPriceLowers(string price, string category)
        {
            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id and p.Category_Id IN (SELECT Category_Id FROM PRODUCT_CATEGORY WHERE Type='" + category + "') AND p.Price <="+price+"";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
        public DataTable SearchByPriceUppers(string price, string category)
        {
            con.Open();
            string query = "SELECT p.*,c.* FROM PRODUCT_INFO AS p, PRODUCT_CATEGORY AS c WHERE c.Category_Id=p.Category_Id and p.Category_Id IN (SELECT Category_Id FROM PRODUCT_CATEGORY WHERE Type='" + category + "') AND p.Price >=" + price + "";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }


        public void UpdateProducts(string id, string name, string price, string quantity, string type, string selfno, string discouunt)
        {
            con.Open();
            string query = "UPDATE PRODUCT_INFO SET Product_Name='" + name + "',Price=" + price + ",Quantity=" + quantity + ", Self_No=" + selfno + ",Discount_Rate=" + discouunt + " where Product_Id='" + id + "'";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }

        public void InsertPorducts(string name, string date, string quantity, string price, string catid, string supplierid, string self, string rate)
        {
            con.Open();
            string query = "INSERT INTO PRODUCT_INFO(Product_Name,Add_Date,Quantity,Price,Category_Id,Supplier_Id,Self_No,Discount_Rate) VALUES('"+name+"','"+date+"',"+quantity+","+price+","+catid+","+supplierid+","+self+","+rate+")";
            SqlCommand str = new SqlCommand(query, con);
            str.ExecuteNonQuery();
            con.Close();
        }

        public DataTable ReturnProductId()
        {
            con.Open();
            string query = "SELECT MAX(Product_Id) AS Product_Id FROM PRODUCT_INFO ";
            SqlCommand str = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(str);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            con.Close();
            return dt1;
        }
    }
}
