using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mohammadi.Models
{
    public interface IGRClass<T>{
        public T Id  { get; set; }
    }
    public class GRClass<T> : IGRClass<T>
    {
        public T Id { get ; set ; }
    }
}
