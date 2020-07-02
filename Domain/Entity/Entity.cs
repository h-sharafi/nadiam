using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
