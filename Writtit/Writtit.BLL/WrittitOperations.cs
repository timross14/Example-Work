using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writtit.Data;
using Writtit.Data.Dapper;
using Writtit.Models;
using Writtit.UI.Models;

namespace Writtit.BLL
{
    public class WrittitOperations
    {
        public IPostRepository postRepo;
        public ICategoryRepository catRepo;
        public IPageRepository pageRepo;
        public ITagRepository tagRepo;
        public DUserRepository userRepo;

        public WrittitOperations()
        {
            switch (ConfigurationManager.AppSettings.Get("DataInteraction"))
            {
                case "Entity":
                    postRepo = new EFPostsRepository();
                    catRepo = new EFCategoriesRepository();
                    pageRepo = new EFPagesRepository();
                    tagRepo = new EFTagsRepository();
                    break;
                default:
                    postRepo = new DPostRepository();
                    catRepo = new DCategoryRepository();
                    pageRepo = new DPageRepository();
                    tagRepo = new DTagRepository();
                    break;
            }
            userRepo = new DUserRepository();
        }

        #region

        public List<Post> GetAllPosts()
        {
            var posts = postRepo.GetAllPosts().OrderByDescending(p=>p.PostID).ToList();

            foreach (var post in posts)
            {
                post.Tags = tagRepo.ReadTagByPostID(post.PostID.Value);
            }

            return posts;
        }

        public Post GetPostByID(int? postID)
        {
            return postRepo.GetPostByID(postID);
        }

        public int AddNewPost(Post post)
        {
            return postRepo.AddNewPost(post);
        }

        public void UpdatePost(Post post)
        {
            postRepo.UpdatePost(post);
        }

        public void DeletePost(Post post)
        {
            postRepo.DeletePost(post);
        }

        public void UpdateAllPosts(List<Post> posts)
        {
            foreach (var post in posts)
            {
                postRepo.UpdatePost(post);
            }
        }

        #endregion


        #region 

        public List<Category> GetAllCategories()
        {
            return catRepo.GetAllCategories();
        }

        public Category GetCategoryByID(int? categoryID)
        {
            return catRepo.GetCategoryByID(categoryID);
        }

        public void AddNewCategory(Category category)
        {
            catRepo.AddNewCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            catRepo.UpdateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            catRepo.DeleteCategory(category);
        }

        #endregion


        #region 

        public List<Page> GetAllPages()
        {
            return pageRepo.GetAllPages();
        }

        public Page GetPageByID(int? pageID)
        {
            return pageRepo.GetPageByID(pageID);
        }

        public void AddNewPage(Page page)
        {
            page.IsHome = false;
            pageRepo.AddNewPage(page);
        }

        public void UpdatePage(Page page)
        {
            pageRepo.UpdatePage(page);
        }

        public void DeletePage(Page page)
        {
            pageRepo.DeletePage(page);
        }

        #endregion


        #region 

        public List<Tag> GetAllTags()
        {
            return tagRepo.ReadAllTags();
        }

        public Tag GetTagByID(int? tagID)
        {
            return tagRepo.ReadTagByID(tagID);
        }

        public int AddNewTag(Tag tag)
        {
            return tagRepo.WriteNewTag(tag);
        }

        public void UpdateTag(Tag tag, Post post)
        {
            tagRepo.UpdateTag(tag, post);
        }

        public void DeleteTag(Tag tag)
        {
            tagRepo.DeleteTag(tag);
        }

        public List<Tag> GetTagsByPostID(int id)
        {
            return tagRepo.ReadTagByPostID(id);
        }

        public List<Tag> GetTagFrequency()
        {
            return tagRepo.ReadAllTagsFrequency();
        } 

        #endregion

        public List<UserRoleModel> GetAllUserRoles()
        {
            return userRepo.GetAllUserRoles();
        }

        public void SetAllUserRoles(List<UserRoleModel> newUserRoleModel)
        {
            foreach (var userRoleModel in newUserRoleModel)
            {
                userRepo.WriteUserRoles(userRoleModel);
            }
            
        }

        #region Search Functions

        public List<Post> SearchThrough(string searchField, string searchType)
        {
            List<Post> posts = GetAllPosts();

            if (searchField == null || searchField.All(s => s.Equals(' ')))
            {
                return posts;
            }
            switch (searchType)
            {
                case "Category":
                    posts = posts.Where(p => ContainsIgnore(p.CategoryID.ToString(), searchField)).ToList();
                    break;

                case "Tag":
                    posts = posts.Where(p => p.Tags.Any(t => ContainsIgnore(t.Name, searchField))).ToList();
                    break;

                case "Title":
                    posts = posts.Where(p => ContainsIgnore(p.Title, searchField)).ToList();
                    break;

                case "Company":
                    posts = posts.Where(p => ContainsIgnore(p.Company, searchField)).ToList();
                    break;

                case "Email":
                    posts = posts.Where(p => ContainsIgnore(p.UserEmail, searchField)).ToList();
                    break;
            }

            return posts;
        }

        public static bool ContainsIgnore(string source, string check)
        //Custom string contains function that ignores case
        {
            return source != null && check != null && source.IndexOf(check, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        #endregion
    }
}
