using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer
{
   public  class Category
    {

        DataAccess da = new DataAccess();
        int category_Id; string category_Type;

        public int Category_Id
        {
            set { this.category_Id = value; }
            get { return this.category_Id; }
        }

        public string Category_Type
        {
            set { this.category_Type = value; }
            get { return this.category_Type; }
        }
        public List<Category> Manage_ShowAllCategories()
        {
            var categories = new List<Category>();
            for (int i = 0; i < da.GetAllCategories().Rows.Count; i++)
            {
                var c = new Category();
                c.Category_Id= int.Parse(da.GetAllCategories().Rows[i]["Category_Id"].ToString());
                c.Category_Type = da.GetAllCategories().Rows[i]["Type"].ToString();

                categories.Add(c);
            }
            return categories;
        }

        public void UpdateCategory(string id,string type)
        {
            da.UpdateCategories(id, type);
        }

        public bool DeleteCategory(string id,string type)
        {
           bool a= da.DeleteCategories(id,type);
            return a;
        }

        public void InsertCategory(string type)
        {
            da.InsertCategories(type);
        }
    }
}
