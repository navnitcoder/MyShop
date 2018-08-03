using System;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    internal class list<T>
    {
        public Product Find { get; internal set; }


        //public Product Find { get; internal set; }

        internal void Add(Product p)
        {
            throw new NotImplementedException();
        }
        //internal void Find(Product p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}