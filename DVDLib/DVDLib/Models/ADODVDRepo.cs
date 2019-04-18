using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DVDLib.Models
{
    public class ADODVDRepo : IDVDRepo
    {
        public DVD Create(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateDVD";

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return dvd;
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDVD";

                cmd.Parameters.AddWithValue("@DvdId", id);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<DVD> Get()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAll";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();
                        yield return currentRow;
                    }
                }
            }
            yield break;
        }

        public IEnumerable<DVD> GetByDirector(string director)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDirector";

                cmd.Parameters.AddWithValue("@Director", director);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();
                        yield return currentRow;
                    }
                }
            }
            yield break;
        }
    

        public DVD GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetById";

                cmd.Parameters.AddWithValue("@DvdId", id);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        return currentRow;
                    }
                }
            }
            return null;
        }

        public IEnumerable<DVD> GetByRating(string rating)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetRating";

                cmd.Parameters.AddWithValue("@Rating", rating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();
                        yield return currentRow;
                    }
                }
            }
            yield break;
        }

        public IEnumerable<DVD> GetByTitle(string title)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTitle";

                cmd.Parameters.AddWithValue("@Title", title);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();
                        yield return currentRow;
                    }
                }
            }
            yield break;
        }

        public IEnumerable<DVD> GetByYear(string year)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetYear";

                cmd.Parameters.AddWithValue("@Year", year);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.RealeaseYear = dr["RealeaseYear"].ToString();
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();
                        yield return currentRow;
                    }
                }
            }
            yield break;
        }

        public void Update(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=DVDLibrary;"
                            + "User Id = DVDLibrary;Password= Testing123;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDVD";

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@RealeaseYear", dvd.RealeaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}