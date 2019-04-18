using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer
{
    
    public class Supplier
    {
        DataAccess da = new DataAccess();
        int supplier_Id;
        string supplier_Name, supplier_Location, supplier_Mail, supplier_Phone;

        public int Supplier_Id
        {
            set { this.supplier_Id = value; }
            get { return this.supplier_Id; }
        }

        public string Supplier_Name
        {
            set { this.supplier_Name = value; }
            get { return this.supplier_Name; }
        }

        public string Supplier_Location
        {
            set { this.supplier_Location = value; }
            get { return this.supplier_Location; }
        }

        public string Supplier_Phone
        {
            set { this.supplier_Phone = value; }
            get { return this.supplier_Phone; }
        }

        public string Supplier_Mail
        {
            set { this.supplier_Mail= value; }
            get { return this.supplier_Mail; }
        }

        public List<Supplier> Manage_ShowAllSuppliers()
        {
            var suppliers = new List<Supplier>();
            for (int i = 0; i < da.GetAllSuppliers().Rows.Count; i++)
            {
                var s = new Supplier();
               s.Supplier_Id = int.Parse(da.GetAllSuppliers().Rows[i]["Supplier_Id"].ToString());
                s.Supplier_Name = da.GetAllSuppliers().Rows[i]["Supplier_Name"].ToString();
                s.Supplier_Location = da.GetAllSuppliers().Rows[i]["Location"].ToString();
                s.Supplier_Phone= da.GetAllSuppliers().Rows[i]["Phone"].ToString();
                s.Supplier_Mail = da.GetAllSuppliers().Rows[i]["Mail"].ToString();

                suppliers.Add(s);
            }
            return suppliers;
        }
        public void UpdateSupplier(string id, string name, string loc, string phone, string mail)
        {
            da.UpdateSuppliers(id, name, loc, phone, mail);
        }
        public bool DeleteSupplier(string id)
        {
            bool a = da.Delete_Supplier_Data_Access(id);
            return a;
        }

        public void CreateSupplier(string name, string location, string phone, string mail)
        {
            da.CreateSupplier_Data_Access(name, location, phone, mail);
        }
    }
}
