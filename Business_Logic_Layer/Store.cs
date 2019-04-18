using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer
{
    public class Store
    {
        DataAccess da = new DataAccess();
        int store_Id;
        string store_Name, store_Location, store_Phone, store_Mail;

        public int Store_Id
        {
            set { this.store_Id = value; }
            get { return this.store_Id; }
        }
        public string Store_Name
        {
            set { this.store_Name = value; }
            get { return this.store_Name; }
        }
        public string Store_Location
        {
            set { this.store_Location = value; }
            get { return this.store_Location; }
        }
        public string Store_Phone
        {
            set { this.store_Phone = value; }
            get { return this.store_Phone; }
        }
        public string Store_Mail
        {
            set { this.store_Mail = value; }
            get { return this.store_Mail; }
        }
        public List<Store> ShowAllStore()
        {
            var stores = new List<Store>();
            for (int i = 0; i < da.ShowAllStores().Rows.Count; i++)
            {
                var u = new Store();
                u.Store_Id = int.Parse(da.ShowAllStores().Rows[i]["Store_Id"].ToString());
                u.Store_Name = da.ShowAllStores().Rows[i]["Store_Name"].ToString();
                u.Store_Location = da.ShowAllStores().Rows[i]["Location"].ToString();
                u.Store_Phone = da.ShowAllStores().Rows[i]["Phone"].ToString();
                u.Store_Mail = da.ShowAllStores().Rows[i]["Mail"].ToString();
                stores.Add(u);
            }
            return stores;
        }
        public void CreateStore(string name,string location,string phone,string mail)
        {
            da.CreateStore_Data_Access(name,location,phone,mail);
        }
        public void UpdateStore(string id, string name, string loc, string phone, string mail)
        {
            da.UpdateStores(id, name, loc, phone, mail);
        }
        public void DeleteStore(string id)
        {
            da.DeleteStore_Data_Access(id);
        }
        public Store ShowOurStore(string name)
        {
            Store s = new Store();
            s.Store_Name = da.ShowOurStores(name).Rows[0]["Store_Name"].ToString();
            s.Store_Location = da.ShowOurStores(name).Rows[0]["Location"].ToString();
            s.Store_Phone = da.ShowOurStores(name).Rows[0]["Phone"].ToString();
            s.Store_Mail = da.ShowOurStores(name).Rows[0]["Mail"].ToString();
            return s;
        }
    }
}
