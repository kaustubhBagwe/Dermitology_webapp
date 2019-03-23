using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using V01_InnovtionWebAPP.Model;

namespace V01_InnovtionWebAPP.ActionMethod
{
    class aboutController
    {
        //Admin
        public List<aboutCategoryModel> getAboutCategoryList(aboutCategoryModel aboutCategoryParams)
        {
            using (DAL db = new DAL())
            {
                List<aboutCategoryModel> lsaboutcategory = new List<aboutCategoryModel>();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_getAboutCategoriesAdmin";
                    DataSet ds = db.ReturnDataset(cmd);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        aboutCategoryModel data = new aboutCategoryModel();
                        lsaboutcategory.Add(data);
                    }
                    return (lsaboutcategory);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        // Admin
        public List<aboutImagesModel> getAboutImagesList(aboutImagesModel aboutImagesParams)
        {
            using (DAL db = new DAL())
            {
                List<aboutImagesModel> lsaboutimage = new List<aboutImagesModel>();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_getAboutImagesAdmin";
                    DataSet ds = db.ReturnDataset(cmd);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        aboutImagesModel data = new aboutImagesModel();
                        lsaboutimage.Add(data);
                    }
                    return (lsaboutimage);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public results saveAboutCategory(aboutCategoryModel aboutCategoryParams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_saveAboutCategory";
                    cmd.Parameters.AddWithValue("@Id", aboutCategoryParams.id);
                    cmd.Parameters.AddWithValue("@title", aboutCategoryParams.title);
                    cmd.Parameters.AddWithValue("@description", aboutCategoryParams.description);
                    cmd.Parameters.AddWithValue("@degrees", aboutCategoryParams.degrees);
                    cmd.Parameters.AddWithValue("@loginID", "123");
                    cmd.Parameters.AddWithValue("@Mode", aboutCategoryParams.mode);
                    DataSet ds = db.ReturnDataset(cmd);

                    results.flag = Convert.ToBoolean(ds.Tables[0].Rows[0]["Flag"]);
                    results.msg = Convert.ToString(ds.Tables[0].Rows[0]["msg"]);

                    return results;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public results saveAboutImages(aboutImagesModel aboutImagesParams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_saveAboutImages";
                    cmd.Parameters.AddWithValue("@Id", aboutImagesParams.id);
                    cmd.Parameters.AddWithValue("@catID", aboutImagesParams.catID);
                    cmd.Parameters.AddWithValue("@imgTitle", aboutImagesParams.imgTitle);
                    cmd.Parameters.AddWithValue("@imgPath", aboutImagesParams.imgPath);
                    cmd.Parameters.AddWithValue("@onHomePage", aboutImagesParams.onHomePage);
                    cmd.Parameters.AddWithValue("@active", aboutImagesParams.active);
                    cmd.Parameters.AddWithValue("@loginID", "123");
                    cmd.Parameters.AddWithValue("@Mode", aboutImagesParams.mode);
                    DataSet ds = db.ReturnDataset(cmd);

                    results.flag = Convert.ToBoolean(ds.Tables[0].Rows[0]["Flag"]);
                    results.msg = Convert.ToString(ds.Tables[0].Rows[0]["msg"]);

                    return results;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public results deleteAboutImages(aboutImagesModel aboutImagesParams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_deleteAboutImages";
                    cmd.Parameters.AddWithValue("@Id", aboutImagesParams.id);
                    DataSet ds = db.ReturnDataset(cmd);
                    results.flag = Convert.ToBoolean(ds.Tables[0].Rows[0]["Flag"]);
                    results.msg = Convert.ToString(ds.Tables[0].Rows[0]["msg"]);

                    return results;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public class results
        {
            public Boolean flag { get; set; }
            public string msg { get; set; }

        }

    }
}