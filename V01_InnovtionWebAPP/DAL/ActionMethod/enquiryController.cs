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
    class enquiryController
    {
        public List<enquiryModel> getAdminEnquiryList()
        {
            using (DAL db = new DAL())
            {
                List<enquiryModel> lsenquiry = new List<enquiryModel>();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetAdminEnquiryList";
                    DataSet ds = db.ReturnDataset(cmd);
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        enquiryModel data = new enquiryModel();
                        lsenquiry.Add(data);
                    }
                    return (lsenquiry);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public results saveEnquiryAdmin(enquiryModel enquiryParams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_SaveEnquiryAdmin";
                    cmd.Parameters.AddWithValue("@response", enquiryParams.response);
                    cmd.Parameters.AddWithValue("@respondedUsing", enquiryParams.respondedUsing);
                    cmd.Parameters.AddWithValue("@comments", enquiryParams.comments);
                    cmd.Parameters.AddWithValue("@loginID", "123");
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

        public results saveEnquiryUser(enquiryModel enquiryParams)
        {
            using (DAL db = new DAL())
            {
                results results = new results();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_SaveEnquiryUser";
                    cmd.Parameters.AddWithValue("@fullname", enquiryParams.fullname);
                    cmd.Parameters.AddWithValue("@email", enquiryParams.email);
                    cmd.Parameters.AddWithValue("@contactNumber", enquiryParams.contactNumber);
                    cmd.Parameters.AddWithValue("@queryMessage", enquiryParams.queryMessage);
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
