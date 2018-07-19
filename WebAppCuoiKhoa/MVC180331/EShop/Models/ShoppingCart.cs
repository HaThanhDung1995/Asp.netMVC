using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    /// <summary>
    /// Mô phỏng giỏ hàng điện tử
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Danh sách các mặt hàng trong giỏ
        /// </summary>
        public List<Product> Items = new List<Product>();
        /// <summary>
        /// Thêm mặt hàng vào giỏ
        /// </summary>
        /// <param name="Id">Mã mặt hàng cần thêm</param>
        public void Add(int Id)
        {
            try
            {
                var Item = Items.Single(p => p.Id == Id);
                Item.Quantity++;
            }
            catch
            {
                using (var dbc = new EShopDbContext())
                {
                    var Item = dbc.Products.Find(Id);
                    Item.Quantity = 1;
                    Items.Add(Item);
                }
            }
        }
        /// <summary>
        /// Xóa mặt hàng khỏi giỏ
        /// </summary>
        /// <param name="Id">Mã mặt hàng</param>
        public void Remove(int Id)
        {
            var Item = Items.Single(p => p.Id == Id);
            Items.Remove(Item);
        }
        /// <summary>
        /// Xóa sạch giỏ hàng
        /// </summary>
        public void Clear()
        {
            Items.Clear();
        }
        /// <summary>
        /// Cập nhật giỏ hàng
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Quantity"></param>
        public void Update(int Id, int Quantity)
        {
            var Item = Items.Single(p => p.Id == Id);
            Item.Quantity = Quantity;
        }
        /// <summary>
        /// Lấy tổng số tiền của giỏ hàng
        /// </summary>
        public double Amount
        {
            get
            {
                return Items.Sum(p => p.Quantity * p.UnitPrice * (1 - p.Discount));
            }
        }
        /// <summary>
        /// Lấy tổng số lượng các mặt hàng trong giỏ
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(p => p.Quantity);
            }
        }
    }
}