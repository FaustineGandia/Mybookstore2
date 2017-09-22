using MyBookstore.App_Code;
using MyBookstore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookstore.Controllers
{
    public class AuthorsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<AuthorModels> list = new List<AuthorModels> ();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT authorID, authorLN, authorFN, authorPhone, authorAddress, authorCity, authorState, authorZip FROM authors";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            foreach(DataRow row in dt.Rows)
                            {
                                var author = new AuthorModels();
                                author.ID = Convert.ToInt32 (row["authorID"].ToString());
                                author.lastname = row["authorLN"].ToString();
                                author.firstname = row["authorFN"].ToString();
                                author.phone = row["authorPhone"].ToString();
                                author.address = row["authorAddress"].ToString();
                                author.city = row["authorCity"].ToString();
                                author.state = row["authorState"].ToString();
                                author.zip = row["authorZip"].ToString();
                                list.Add(author);
                            }
                        }
                    }
                }
            
            }
                return View(list);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(AuthorModels author)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            //finally
            //{

            //}
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"INSERT INTO authors VALUES
                (@authorLN, @authorfN, @authorPhone, @authorAddress, @authorCity, @authorState, @authorZip)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@authorLN", author.lastname);
                    cmd.Parameters.AddWithValue("@authorFN", author.firstname);
                    cmd.Parameters.AddWithValue("@authorPhone", author.phone);
                    cmd.Parameters.AddWithValue("@authorAddress", author.address);
                    cmd.Parameters.AddWithValue("@authorCity", author.city);
                    cmd.Parameters.AddWithValue("@authorState", author.state);
                    cmd.Parameters.AddWithValue("@authorZip", author.zip);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                        
                }
            }

        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Index");
            }

            AuthorModels author = new AuthorModels();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT authorLN, authorFN, authorPhone, authorAddress, authorState, authorCity, authorZip
                FROM authors
                WHERE authorID=@authorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@authorID", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                author.lastname = dr["authorLN"].ToString();
                                author.firstname = dr["authorFN"].ToString();
                                author.phone = dr["authorPhone"].ToString();
                                author.address = dr["authorAddress"].ToString();
                                author.city = dr["authorCity"].ToString();
                                author.state = dr["authorState"].ToString();
                                author.zip = dr["authorZip"].ToString();
                            }
                            return View(author);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
        }

        // POST: Authors/Edit/5
        [HttpPost]
        public ActionResult Edit(AuthorModels author)
        {
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"UPDATE authors SET authorLN=@authorLN,
                authorFN=@authorFN, authorPhone=@authorPhone, authorAddress=@authorAddress,
                authorCity=@authorCity, authorState=@authorState, authorZip=@authorZip
                WHERE authorID=@authorID";
                using (SqlCommand cmd = new SqlCommand(query, con))

                {
                    cmd.Parameters.AddWithValue("@authorLN", author.lastname);
                    cmd.Parameters.AddWithValue("@authorFN", author.firstname);
                    cmd.Parameters.AddWithValue("@authorPhone", author.phone);
                    cmd.Parameters.AddWithValue("@authorAddress", author.address);
                    cmd.Parameters.AddWithValue("@authorCity", author.city);
                    cmd.Parameters.AddWithValue("@authorState", author.state);
                    cmd.Parameters.AddWithValue("@authorZip", author.zip);
                    cmd.Parameters.AddWithValue("authorID", author.ID);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");

                }




            }
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Index");
            }

            AuthorModels author = new AuthorModels();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"DELETE
                FROM authors
                WHERE authorID=@authorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@authorID", id);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                    
                    
                }
            }
        }

        // POST: Authors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
