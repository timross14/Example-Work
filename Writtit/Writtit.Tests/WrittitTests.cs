using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using NFluent;
using NUnit.Framework;
using Writtit.BLL;
using Writtit.Data;
using Writtit.Data.Dapper;
using Writtit.Models;

namespace Writtit.Tests
{
    [TestFixture]
    public class WrittitTests
    {
        private IPostRepository _postRepo;
        private ICategoryRepository _catRepo;
        private IPageRepository _pageRepo;
        private ITagRepository _tagRepo;
        private DUserRepository _userRepo;
        private WrittitOperations _ops;
        private TransactionScope _scope;
        private Post _p;

        [SetUp]
        public void Init()
        {
            switch (ConfigurationManager.AppSettings.Get("DataInteraction"))
            {
                case "Entity":
                    _postRepo = new EFPostsRepository();
                    _catRepo = new EFCategoriesRepository();
                    _pageRepo = new EFPagesRepository();
                    _tagRepo = new EFTagsRepository();
                    break;
                default:
                    _postRepo = new DPostRepository();
                    _catRepo = new DCategoryRepository();
                    _pageRepo = new DPageRepository();
                    _tagRepo = new DTagRepository();
                    break;
            }
            _userRepo = new DUserRepository();

            _ops = new WrittitOperations();

            _p = new Post
            {
                UserEmail = "jpalazzo225@gmail.com",
                Company = "TestCompany",
                Title = "This is a test post",
                Content = "<p>Test Post<p>",
                CategoryID = 1,
                DateTime = DateTime.Parse("1/2/03"),
            };

            _scope = new TransactionScope();
        }

        [TearDown]
        public void Cleanup()
        {
            _scope.Dispose();
        }

        #region Post Tests

        [Test]
        public void AddPostTest()
        {
            int id = _postRepo.AddNewPost(_p);
            Assert.AreEqual(_postRepo.GetPostByID(id).Title, _p.Title);
            Assert.AreEqual(_postRepo.GetPostByID(id).UserEmail, _p.UserEmail);
            Assert.AreEqual(_postRepo.GetPostByID(id).Company, _p.Company);
            Assert.AreEqual(_postRepo.GetPostByID(id).Content, _p.Content);
            Assert.AreEqual(_postRepo.GetPostByID(id).CategoryID, _p.CategoryID);
            Assert.AreEqual(_postRepo.GetPostByID(id).DateTime, _p.DateTime);
        }

        /// <summary>
        /// TODO: WILL NEED TO CHANGE BASED ON NEW SCHEMA AND DATA SCRIPT
        /// </summary>
        [Test]
        public void GetAllPostsTest()
        {
            List<Post> allPosts = _postRepo.GetAllPosts();
            Assert.AreEqual(allPosts.Count, 16);
            int id = _postRepo.AddNewPost(_p);
            allPosts = _postRepo.GetAllPosts();
            Assert.AreEqual(allPosts.Last().PostID, id);
            Assert.AreEqual(allPosts.Count == 17, true);
            Assert.AreEqual(allPosts[allPosts.Count - 2].Content != null, true);
        }

        /// <summary>
        /// TODO: WILL NEED TO CHANGE BASED ON NEW SCHEMA AND DATA SCRIPT
        /// </summary>
        [Test]
        public void GetPostByIDTest()
        {
            Post post = _postRepo.GetPostByID(1);
            Assert.AreEqual(post.Content, "<em>Look at this text!</em>");
        }

        [Test]
        public void UpdatePostTest()
        {
            Post post = new Post
            {
                IsApproved = true,
                IsHidden = true,
                PostID = 1
            };

            _postRepo.UpdatePost(post);

            Assert.AreEqual(_postRepo.GetPostByID(1).IsApproved, true);
            Assert.AreEqual(_postRepo.GetPostByID(1).IsHidden, true);

            post.IsApproved = false;
            post.IsHidden = false;

            _postRepo.UpdatePost(post);

            Assert.AreEqual(_postRepo.GetPostByID(1).IsApproved, false);
            Assert.AreEqual(_postRepo.GetPostByID(1).IsHidden, false);
        }

        [Test]
        public void UpdateAllPostTest()
        {
            var posts = _postRepo.GetAllPosts();

            foreach (var post in posts)
            {
                post.IsHidden = true;
                post.IsApproved = false;
            }

            bool test = false;
            foreach (var post in posts)
            {
                if (post.IsApproved && !post.IsHidden)
                {
                    test = true;
                }
            }
            Assert.AreEqual(test, false);
            _ops.UpdateAllPosts(posts);
            posts = _postRepo.GetAllPosts();

            test = true;
            foreach (var post in posts)
            {
                if (post.IsApproved || !post.IsHidden)
                {
                    test = false;
                }
            }
            Assert.AreEqual(test, true);
        }

        #endregion

        [Test]
        public void TestGetAllCategories()
        {
            var catList = _catRepo.GetAllCategories();
            
            Assert.AreEqual(catList.Count,6);

            Assert.AreEqual(catList.LastOrDefault().Name=="Johns Category",true);
        }

        /// <summary>
        /// Not implemented in dapper code
        /// </summary>
        //[Test]
        //public void TestGetCategoryByID()
        //{
        //    Assert.AreEqual(catRepo.GetCategoryByID(1).Name, "New Category");
        //    Assert.AreEqual(catRepo.GetCategoryByID(1).CategoryID, 1);
        //    Assert.AreEqual(catRepo.GetCategoryByID(3).Name, "Company Event");
        //    Assert.AreNotEqual(catRepo.GetCategoryByID(1).Name, "Break ya neck");
        //}

        [Test]
        public void TestAddNewCategory()
        {
            Category c = new Category
            {
                Name = "Stache Raab"
            };

            var catList = _catRepo.GetAllCategories();
            Assert.AreNotEqual(catList.Last().Name,"Stache Raab");
            _catRepo.AddNewCategory(c);
            catList = _catRepo.GetAllCategories();
            Assert.AreEqual(catList.Last().Name,"Stache Raab");
        }

        [Test]
        public void TestGetAllPages()
        {
            var pages = _pageRepo.GetAllPages();
            Assert.AreEqual(pages.Count,2);
            Assert.AreEqual(pages.LastOrDefault().Title,"FAQ");
            Assert.AreNotEqual(pages.LastOrDefault().Title,"Test");
        }

        [Test]
        public void TestGetPageByID()
        {
            Assert.AreEqual(_pageRepo.GetPageByID(1).PageID,1);
            Assert.AreNotEqual(_pageRepo.GetPageByID(1).PageID,2);
            Assert.AreEqual(_pageRepo.GetPageByID(2).Title,"FAQ");
        }

        [Test]
        public void TestAddNewPage()
        {
            Page p = new Page()
            {
                IsHidden = true,
                IsHome = false,
                Content = "<p>Test</p>",
                Title = "Awwwww Yeahhhhh"
            };

            Assert.AreNotEqual(p.Title,_pageRepo.GetAllPages().LastOrDefault().Title);
            _pageRepo.AddNewPage(p);
            Assert.AreEqual(p.Title, _pageRepo.GetAllPages().LastOrDefault().Title);
        }

        [Test]
        public void TestPageDefaultNotHome()
        {
            Page p = new Page()
            {
                IsHome = true
            };

            _ops.AddNewPage(p);
            Assert.AreEqual(_pageRepo.GetAllPages().LastOrDefault().IsHome,false);
        }

        [Test]
        public void TestUpdatePage()
        {
            Page p = new Page()
            {
                PageID = 1,
                IsHome = false,
                IsHidden = false,
                Content = "<p>Test</p>",
                Title = "Aw Yeh"
            };

            Assert.AreNotEqual(_pageRepo.GetPageByID(1).Content, p.Content);
            _pageRepo.UpdatePage(p);
            Assert.AreEqual(p.Content, _pageRepo.GetPageByID(1).Content);
        }

        [Test]
        public void TestDeletePage()
        {
            Page p = _pageRepo.GetPageByID(1);
            Assert.AreNotEqual(p.IsHidden,true);
            p.IsHidden = true;
            _pageRepo.DeletePage(p);
            Assert.AreEqual(_pageRepo.GetPageByID(1).IsHidden,true);
        }

        [Test]
        public void TestReadAllTags()
        {
            var tagList = _tagRepo.ReadAllTags();
            Assert.AreEqual(tagList.Count,28);
            Assert.AreEqual(tagList[10].Name,"cleveland");
            Assert.AreNotEqual(tagList[10].Name,"Test");
        }

        [Test]
        public void TestReadTagByPostID()
        {
            var tagList = _tagRepo.ReadTagByPostID(1);

            Assert.AreEqual(tagList.Count,4);
            Check.That(tagList).HasSize(4);
            Check.That(tagList[0].Name).Equals("Brand");
        }

        [Test]
        public void TestReadTagByID()
        {
            Check.That(_tagRepo.ReadTagByID(3).TagId).Equals(3);
            Check.That(_tagRepo.ReadTagByID(3).Name).Equals("Tag");
        }

        [Test]
        public void TestGetAllUserRoles()
        {
            Check.That(_userRepo.GetAllUserRoles()).HasSize(4);
            Check.That(_userRepo.GetAllUserRoles()[1].RoleID).IsEqualTo(2);
        }
    }
}