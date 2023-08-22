using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface INewsLetterService
    {
        void AddNewsLetter(NewsLetter newsLetter);
    }
}