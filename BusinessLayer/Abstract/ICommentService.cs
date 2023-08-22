using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        // void DeleteComment(Comment comment);
        // void UpdateComment(Comment comment);
        List<Comment> GetList(int id);
        // Comment GetById(int id);
    }
}