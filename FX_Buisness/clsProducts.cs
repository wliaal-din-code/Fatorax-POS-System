using FX_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FX_Buisness
{
    public class clsProducts
    {

        public enum enMode { AddNew, Update }
        enMode Mode = enMode.AddNew;
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Stock { get; set; }

        public clsProducts()
        {
            this.ProductId = 0;
            this.Name = "";
            this.Price = 0;
            this.Cost = 0;
            this.Stock = 0;
            Mode = enMode.AddNew;
        }

        public clsProducts(int productId, string name, decimal price, decimal cost, int stock)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Cost = cost;
            Stock = stock;
            Mode = enMode.Update;
        }

        public clsProducts(int productId, string name)
        {

            ProductId = productId;
            Name = name;

        }



        //public override string ToString()
        //{
        //    return this.Name = "";
        //}

        public static DataTable GetAllProducts()
        {
            return clsProductsData.GetAllProducts();
        }


        public static DataTable GetAllProductSCok()
        {
            return clsProductsData.GetAllProductSCok();
        }
        public static DataTable MoreProdutctsPuy(string DeceOrAsc, DateTime dtfrom, DateTime dtEnd)
        {
            return clsProductsData.MoreProdutctsPuy(DeceOrAsc, dtfrom, dtEnd);
        }

        private bool _AddNewProducts()
        {
            this.ProductId = clsProductsData.AddNewProduct(this.Name, this.Price, this.Cost, this.Stock);
            return (this.ProductId != -1);
        }

        private bool _UpdateProducts()
        {
            return clsProductsData.UpdateProduct(this.ProductId, this.Name, this.Price, this.Cost, this.Stock);
        }

        public static bool _UpdateStock(int ProductId,int Stock)
        {
            return clsProductsData.UpdateProduct(ProductId, Stock);
        }

        public static bool DeleteProducts(int ProductId)
        {
            return clsProductsData.DeleteProduct(ProductId);
        }

        public static clsProducts Find(int ProductId)
        {
            string name = "";
            decimal price = 0;
            decimal cost = 0;
            int stock = 0;

            if (clsProductsData.GetProductByProductId(ProductId, ref name, ref price, ref cost, ref stock))
                return new clsProducts(ProductId, name, price, cost, stock);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewProducts())
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
                    _UpdateProducts();
                    return true;
            }
            return false;


        }

        public static bool IsProductExist(string Name)
        {
            return clsProductsData.IsProductExist(Name);
        }

        public static clsProducts Find(string Name)
        {


            decimal price = 0;
            decimal cost = 0;
            int stock = 0, ProductId = 0;

            if (clsProductsData.GetProductInfoByName(ref ProductId, Name, ref price, ref cost, ref stock))
                return new clsProducts(ProductId, Name, price, cost, stock);
            else
                return null;

        }
    }
}
