using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Repositories.Abstract;

namespace MyBlog.Domain.Repositories.EntityFramework
{
    public class EFPostItemsRepository : IPostItemsRepository
    {
        private readonly BlogDbContext context;
        public EFPostItemsRepository(BlogDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PostItem> GetPostItems()
        {
            return context.PostItems;
        }
        public PostItem GetPostItemById(Guid id)
        {
            return context.PostItems.FirstOrDefault(x => x.Id == id);
        }
        public void SavePostItem(PostItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;// объект будет добавлен как новый
            else
                context.Entry(entity).State = EntityState.Modified;// старый объект будет изменён
            context.SaveChanges();
        }
        public void DeletePostItem(Guid id)
        {
            context.PostItems.Remove(new PostItem() { Id = id });
            context.SaveChanges();
        }
    }
}
