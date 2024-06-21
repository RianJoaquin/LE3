using BlogDataLibrary.Models;
using BlogDataLibrary.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BlogDataLibrary.Data
{
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDB";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public UserModel Authenticate(string username, string password)
        {
            UserModel results = _db.LoadData<UserModel, dynamic>("dbo.spUsers_Authenticate",
                                                                 new { username, password },
                                                                 connectionStringName,
                                                                 true).FirstOrDefault();
            return results;
        }

        public void Register(string username, string firstName, string lastName, string password)
        {
            _db.SaveData<dynamic>(
                "dbo.spUsers_Register",
                new { username, firstName, lastName, password },
                connectionStringName,
                true);
        }

        public void AddPost(PostModel post)
        {
            _db.SaveData("spPosts_Insert", new { post.UserId, post.Title, post.Body, post.DateCreated },
        connectionStringName, true);
        }

        public List<ListPostModel> ListPosts()
        {
            return _db.LoadData<ListPostModel, dynamic>("dbo.spPosts_List", new { },
        connectionStringName, true).ToList();
        }

        public ListPostModel ShowPostDetail(int id)
        {
            return _db.LoadData<ListPostModel, dynamic>("dbo.spPosts_Detail", new { id },
        connectionStringName, true).FirstOrDefault();
        }
    }
}