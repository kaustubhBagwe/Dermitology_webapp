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
    class mediaController
    {
        public List<mediaModel> getUsersMediaList(mediaModel mediaParams)
        {
            using (DAL db = new DAL())
            {
                List<mediaModel> lsmedia = new List<mediaModel>();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetUsersMediaList";
                    cmd.Parameters.AddWithValue("@showOnHomePage", Convert.ToBoolean(mediaParams.onHomePage));
                    DataSet ds = db.ReturnDataset(cmd);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        mediaModel data = new mediaModel();
                        lsmedia.Add(data);
                    }
                    return (lsmedia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<mediaModel> getAdminMediaList()
        {
            using (DAL db = new DAL())
            {
                List<mediaModel> lsmedia = new List<mediaModel>();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetAdminMediaList";
                    DataSet ds = db.ReturnDataset(cmd);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        mediaModel data = new mediaModel();
                        lsmedia.Add(data);
                    }
                    return (lsmedia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public results saveMedia(mediaModel mediaparams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_SaveMedia";
                    cmd.Parameters.AddWithValue("@Id", mediaparams.id);
                    cmd.Parameters.AddWithValue("@Title", mediaparams.title);
                    cmd.Parameters.AddWithValue("@Description", mediaparams.description);
                    cmd.Parameters.AddWithValue("@youtubeLink", mediaparams.youtubeLink);
                    cmd.Parameters.AddWithValue("@onHomePage", mediaparams.onHomePage);
                    cmd.Parameters.AddWithValue("@Active", mediaparams.active);
                    cmd.Parameters.AddWithValue("@loginID", "123");
                    cmd.Parameters.AddWithValue("@Mode", mediaparams.mode);

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

        public results deleteMedia(mediaModel mediaparams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_DeleteMedia";
                    cmd.Parameters.AddWithValue("@Id", mediaparams.id);
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
