using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadPictureAjax.Models;

namespace UploadPictureAjax.Controllers
{
    public class ProductController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: Product
        public ActionResult AddNewProduct()
        {
            Product model = new Product();
            return View(model);
        }
        [HttpPost]
        public ActionResult ProductLoad()
        {
            List<Product> data = dbc.Products.ToList();

            return PartialView("_TableProducts", data);
        }
        [HttpPost]
        public JsonResult SaveData( string ProductName, HttpPostedFileBase ImageUpload)
        {
            var url = "";
            if (ImageUpload != null)
            {
                Bitmap bmp = (Bitmap)Bitmap.FromStream(ImageUpload.InputStream);
                bmp.Save(Server.MapPath("/Upload/Images/" + Path.GetFileName(ImageUpload.FileName)));
                url = "/Upload/Images/"+ ImageUpload.FileName;
                //update
            }
            else
            {
                url = "Product.PNG";
            }
            try
            {
                //upload file

                Product model;
               
                    model=new Product();
                    model.PicUrl = url;
                    model.ProductName = ProductName;
                    dbc.Products.Add(model);
                
                

                dbc.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                //Product model;
                //if (Id == null)
                //{
                //    model = new Product();
                //}
                //else
                //{
                //    model = dbc.Products.Find(Id.Value);
                //}
                //model.ProductName = ProductName;
                //if (ImageUpload != null) model.PicUrl = "/Upload/Images/" + ImageUpload.FileName;
                //if (Id == null) dbc.Products.Add(model);
                //dbc.SaveChanges();
                //return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult Update(int? Id, string ProductName, HttpPostedFileBase ImageUpload)
        {
            var url = "";
            if (ImageUpload != null)
            {
                Bitmap bmp = (Bitmap)Bitmap.FromStream(ImageUpload.InputStream);
                bmp.Save(Server.MapPath("/Upload/Images/" + Path.GetFileName(ImageUpload.FileName)));
                url = "/Upload/Images/" + ImageUpload.FileName;
                //update
            }
            else
            {
                url = "Product.PNG";
            }
            try
            {
                //upload file

                var product = dbc.Products.Find(Id);


                product.PicUrl = url;
                product.ProductName = ProductName;
                    
               

                dbc.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                //Product model;
                //if (Id == null)
                //{
                //    model = new Product();
                //}
                //else
                //{
                //    model = dbc.Products.Find(Id.Value);
                //}
                //model.ProductName = ProductName;
                //if (ImageUpload != null) model.PicUrl = "/Upload/Images/" + ImageUpload.FileName;
                //if (Id == null) dbc.Products.Add(model);
                //dbc.SaveChanges();
                //return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Edit(int Id)
        {
            Product item = dbc.Products.Find(Id);
            return View("AddNewProduct", item);
        }
    }
}