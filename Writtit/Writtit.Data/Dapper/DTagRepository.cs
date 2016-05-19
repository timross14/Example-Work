using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Writtit.Models;

namespace Writtit.Data.Dapper
{
    public class DTagRepository:ITagRepository
    {
        private readonly string _connection = ConfigurationManager.ConnectionStrings["Writtit"].ConnectionString;

        public List<Tag> ReadAllTags()
        {
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                return cn.Query<Tag>("SELECT * FROM Tags t").ToList();
            }
        }

        public List<Tag> ReadTagByPostID(int? postID)
        {
            List<Tag> tags = new List<Tag>();

            using (SqlConnection cn = new SqlConnection(_connection))
            {
                
                tags = cn.Query<Tag>("SELECT * FROM Tags t " +
                                     "Inner Join TagPosts tp " +
                                     "On t.TagID = tp.Tag_TagID " +
                                     "Inner Join Posts p " +
                                         "On p.PostID = tp.Post_PostID " +
                                         "WHERE p.PostID = @postid", new {postid=postID}).ToList();
            }

            return tags;
        }

        public Tag ReadTagByID(int? tagID)
        {
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                return cn.Query<Tag>("SELECT * FROM Tags t " +
                                     "WHERE t.tagID = @tagid", new {tagid=tagID}).FirstOrDefault();
            }
        }

        public int WriteNewTag(Tag tag)
        {
            int tagID;

            using (SqlConnection cn = new SqlConnection(_connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@frequency", tag.Frequency);
                param.Add("@name", tag.Name);

                param.Add("@TagID", DbType.Int32, direction: ParameterDirection.Output);

                cn.Execute("CreateNewTag", param, commandType: CommandType.StoredProcedure);
                tagID = param.Get<int>("@TagID");
            }

            return tagID;
        }

        public void UpdateTag(Tag tag, Post post)
        {
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Frequency", tag.Frequency);
                param.Add("@TagID", tag.TagId);
                param.Add("@PostID", post.PostID);

                cn.Execute("UPDATE Tags " +
                           "SET Frequency = @Frequency " + 
                           "WHERE TagID = @TagID " +
                           "INSERT INTO TagPosts (Post_PostID, Tag_TagId) " +
                           "VALUES (@PostID, @TagID)", param);
            }
        }

        public void DeleteTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public List<Tag> ReadAllTagsFrequency()
        {
            using (SqlConnection cn = new SqlConnection(_connection))
            {
                return cn.Query<Tag>("SELECT t.Name, COUNT(Tag_TagId) AS Frequency FROM TagPosts tp " +
                                     "LEFT JOIN Tags t ON t.TagId = tp.Tag_TagId " +
                                     "LEFT JOIN Posts p ON p.PostID = tp.Post_PostID " +
                                     "WHERE p.IsHidden = '0' AND p.IsApproved = '1' " +
                                     "GROUP BY Name").ToList();
            }
        }
    }
}
