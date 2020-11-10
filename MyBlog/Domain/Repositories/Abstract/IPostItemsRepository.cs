using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Domain.Repositories.Abstract
{
    public interface IPostItemsRepository
    {
        IQueryable<PostItem> GetPostItems();
        PostItem GetPostItemById(Guid id);
        void SavePostItem(PostItem entity);
        void DeletePostItem(Guid id);
    }
}
