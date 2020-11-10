using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Domain.Repositories.Abstract;

namespace MyBlog.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IPostItemsRepository PostItems { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IPostItemsRepository postItemsRepository)
        {
            TextFields = textFieldsRepository;
            PostItems = postItemsRepository;
        }
    }
}
