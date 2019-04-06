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
    class blogController
    {
        public List<blogModel> getUsersBlogList(blogModel blogParams)
        {
            using (DAL db = new DAL())
            {
                List<blogModel> lsblog = new List<blogModel>();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetUsersBlogList";
                    cmd.Parameters.AddWithValue("@showOnHomePage", Convert.ToBoolean(blogParams.onHomePage));
                    DataSet ds = db.ReturnDataset(cmd);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        blogModel data = new blogModel();
                        lsblog.Add(data);
                    }
                    return (lsblog);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<blogModel> getAdminBlogsList()
        {
            using (DAL db = new DAL())
            {
                List<blogModel> lsblog = new List<blogModel>();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetAdminBlogsList";
                    DataSet ds = db.ReturnDataset(cmd);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        blogModel data = new blogModel();
                        lsblog.Add(data);
                    }
                    return (lsblog);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataTable getBlogWithId(blogModel blogparams)
        {
            using (DAL db = new DAL())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetBlogWithId";
                    cmd.Parameters.AddWithValue("@id", blogparams.id);
                    DataTable dt = db.ReturnDataTable(cmd);
                    return (dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public results saveBlogs(blogModel blogparams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_SaveBlogs";
                    cmd.Parameters.AddWithValue("@Id", blogparams.id);
                    cmd.Parameters.AddWithValue("@Title", blogparams.title);
                    cmd.Parameters.AddWithValue("@Description", blogparams.description);
                    cmd.Parameters.AddWithValue("@SEOTitle", blogparams.SEOtitle);
                    cmd.Parameters.AddWithValue("@SEOMeta", blogparams.SEOmeta);
                    cmd.Parameters.AddWithValue("@onHomePage", blogparams.onHomePage);
                    cmd.Parameters.AddWithValue("@Active", blogparams.active);
                    cmd.Parameters.AddWithValue("@loginID", "123");
                    cmd.Parameters.AddWithValue("@Mode", blogparams.mode);

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

        public results deleteBlogs(blogModel blogparams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_DeleteBlogs";
                    cmd.Parameters.AddWithValue("@Id", blogparams.id);
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
