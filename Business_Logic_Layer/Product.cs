using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;

namespace Business_Logic_Layer
{
   public class Product
    {
        DataAccess da = new DataAccess();
        Category c;
        public Product() { }

        string product_Id, product_Name, product_Date, category_Type;
        float product_Price, product_Quantity;
        int  self_No, discount;

        public string Product_Id
        {
            set { this.product_Id = value; }
            get { return this.product_Id; }
        }
        public string Product_Name
        {
            set { this.product_Name = value; }
            get { return this.product_Name; }
        }
        public float Product_Quantity
        {
            set { this.product_Quantity = value; }
            get { return this.product_Quantity; }
        }
        public float Product_Price
        {
            set { this.product_Price = value; }
            get { return this.product_Price; }
        }
        
        public string Product_Date
        {
            set { this.product_Date = value; }
            get { return this.product_Date; }
        }
        
        public string Category_Type
        {
            set { this.category_Type = value; }
            get { return this.category_Type; }
        }
       // public int Row_No { set { this.row_No = value; } get { return this.row_No; } }
        public int Self_No
        {
            set { this.self_No = value; }
            get { return this.self_No; }
        }
        public int DiscountRate
        {
            set { this.discount = value; }
            get { return this.discount; }
        }

        public List<Product> GenerateBillAll()
        {
            var products= new List<Product>();

            for (int i = 0; i < da.GenerateBillAlls().Rows.Count; i++)
            {

                var product = new Product();
                c = new Category();
                product.Product_Id = da.GenerateBillAlls ().Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.GenerateBillAlls().Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.GenerateBillAlls().Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.GenerateBillAlls().Rows[i]["Quantity"].ToString());
                product.Product_Date = da.GenerateBillAlls().Rows[i]["Add_Date"].ToString();
               // product.Category_Id = int.Parse(da.GetAllProducts().Rows[i]["Category_Id"].ToString());
                product.Category_Type = c.Category_Type; product.Category_Type = da.GenerateBillAlls().Rows[i]["Type"].ToString();
                product.Self_No = int.Parse(da.GenerateBillAlls().Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.GenerateBillAlls().Rows[i]["Discount_Rate"].ToString());
                da.UpdateInventory(product.Product_Id,product.product_Quantity);
                product.product_Quantity = 1;
                products.Add(product);
            }
            return products;
        }
        public List<string> GetAllNameCategory()
        {
            List<string> arrList = new List<string>();
            var products = new List<Product>();
            for (int i = 0; i < da.GetAllNameCategories().Rows.Count; i++)
            {

                var product = new Product();
                product.Product_Name = da.GetAllNameCategories().Rows[i]["Product_Name"].ToString();
                products.Add(product);
                arrList.Add(product.Product_Name);
            }
            for (int i = 0; i < da.GetAllNameCategories2().Rows.Count; i++)
            {
                var product = new Product();
                c = new Category();
                product.Category_Type = c.Category_Type; product.Category_Type = da.GetAllNameCategories2().Rows[i]["Type"].ToString();
                products.Add(product);
                arrList.Add(product.Category_Type);
            }
            return arrList;

        }

        public List<Product> SearchByNameCategory(string name)
        {
            var products = new List<Product>();
            for (int i = 0; i < da.SearchByNameCategories(name).Rows.Count; i++)
            {
                var product = new Product();
                //c = new Category();
                product.Product_Id = da.SearchByNameCategories(name).Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.SearchByNameCategories(name).Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.SearchByNameCategories(name).Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.SearchByNameCategories(name).Rows[i]["Quantity"].ToString());
                product.Product_Date = da.SearchByNameCategories(name).Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.SearchByNameCategories(name).Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.SearchByNameCategories(name).Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.SearchByNameCategories(name).Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }
        public List<Product> SearchAllDiscount()
        {
            var products = new List<Product>();
            for (int i = 0; i < da.SearchAllDiscounts().Rows.Count; i++)
            {
                var product = new Product();
                product.Product_Id = da.SearchAllDiscounts().Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.SearchAllDiscounts().Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.SearchAllDiscounts().Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.SearchAllDiscounts().Rows[i]["Quantity"].ToString());
                product.Product_Date = da.SearchAllDiscounts().Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.SearchAllDiscounts().Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.SearchAllDiscounts().Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.SearchAllDiscounts().Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }

        public List<Product> Manage_ShowAllProducts()
        {
            var products = new List<Product>();
            for (int i = 0; i < da.ShowAllProducts().Rows.Count; i++)
            {
                var product = new Product();
                product.Product_Id = da.ShowAllProducts().Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.ShowAllProducts().Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.ShowAllProducts().Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.ShowAllProducts().Rows[i]["Quantity"].ToString());
                product.Product_Date = da.ShowAllProducts().Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.ShowAllProducts().Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.ShowAllProducts().Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.ShowAllProducts().Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }

       public void DeleteProduct(string id)
        {
            da.DeleteProducts(id);
        }

        public List<Product> SearchByName(string name)
        {
            var products = new List<Product>();
            for (int i = 0; i < da.SearchByNames(name).Rows.Count; i++)
            {
                var product = new Product();
                product.Product_Id = da.SearchByNames(name).Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.SearchByNames(name).Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.SearchByNames(name).Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.SearchByNames(name).Rows[i]["Quantity"].ToString());
                product.Product_Date = da.SearchByNames(name).Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.SearchByNames(name).Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.SearchByNames(name).Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.SearchByNames(name).Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }

        public List<Product> SearchByCategory(string category)
        {
            var products = new List<Product>();
            for (int i = 0; i < da.SearchByCategories(category).Rows.Count; i++)
            {
                var product = new Product();
                product.Product_Id = da.SearchByCategories(category).Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.SearchByCategories(category).Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.SearchByCategories(category).Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.SearchByCategories(category).Rows[i]["Quantity"].ToString());
                product.Product_Date = da.SearchByCategories(category).Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.SearchByCategories(category).Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.SearchByCategories(category).Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.SearchByCategories(category).Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }

        public List<Product> SearchByDiscountRange(string min,string max,string category)
        {
            var products = new List<Product>();
            for (int i = 0; i < da.SearchByDiscountRanges(min,max,category).Rows.Count; i++)
            {
                var product = new Product();
                product.Product_Id = da.SearchByDiscountRanges(min, max, category).Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.SearchByDiscountRanges(min, max, category).Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.SearchByDiscountRanges(min, max, category).Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.SearchByDiscountRanges(min, max, category).Rows[i]["Quantity"].ToString());
                product.Product_Date = da.SearchByDiscountRanges(min, max, category).Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.SearchByDiscountRanges(min, max, category).Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.SearchByDiscountRanges(min, max, category).Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.SearchByDiscountRanges(min, max, category).Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }

        public List<Product> SearchByPriceLower(string price, string category)
        {
            var products = new List<Product>();
            for (int i = 0; i < da.SearchByPriceLowers(price, category).Rows.Count; i++)
            {
                var product = new Product();
                product.Product_Id = da.SearchByPriceLowers(price, category).Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.SearchByPriceLowers(price, category).Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.SearchByPriceLowers(price, category).Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.SearchByPriceLowers(price, category).Rows[i]["Quantity"].ToString());
                product.Product_Date = da.SearchByPriceLowers(price, category).Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.SearchByPriceLowers(price, category).Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.SearchByPriceLowers(price, category).Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.SearchByPriceLowers(price, category).Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }

        public List<Product> SearchByPriceUpper(string price, string category)
        {
            var products = new List<Product>();
            for (int i = 0; i < da.SearchByPriceUppers(price, category).Rows.Count; i++)
            {
                var product = new Product();
                product.Product_Id = da.SearchByPriceUppers(price, category).Rows[i]["Product_Id"].ToString();
                product.Product_Name = da.SearchByPriceUppers(price, category).Rows[i]["Product_Name"].ToString();
                product.Product_Price = float.Parse(da.SearchByPriceUppers(price, category).Rows[i]["Price"].ToString());
                product.Product_Quantity = float.Parse(da.SearchByPriceUppers(price, category).Rows[i]["Quantity"].ToString());
                product.Product_Date = da.SearchByPriceUppers(price, category).Rows[i]["Add_Date"].ToString();
                product.Self_No = int.Parse(da.SearchByPriceUppers(price, category).Rows[i]["Self_No"].ToString());
                product.DiscountRate = int.Parse(da.SearchByPriceUppers(price, category).Rows[i]["Discount_Rate"].ToString());
                product.Category_Type = da.SearchByPriceUppers(price, category).Rows[i]["Type"].ToString();
                products.Add(product);
            }
            return products;
        }

        public void UpdateProduct(string id, string name, string price, string quantity, string type, string selfno, string discount)
        {
            da.UpdateProducts(id, name, price, quantity, type, selfno, discount);
        }

        public Product InsertProduct(string name,string date,string quantity,string price,string catid,string supplierid,string self,string rate)
        {
            da.InsertPorducts(name, date, quantity, price, catid, supplierid, self, rate);
            var product = new Product();
            product.Product_Id = da.ReturnProductId().Rows[0]["Product_Id"].ToString();
            return product;
        }
    }
}
