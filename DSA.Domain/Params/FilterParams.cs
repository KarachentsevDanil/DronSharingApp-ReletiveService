using System;
using System.Linq.Expressions;

namespace RCS.Domain.Params
{
    public class FilterParams<T> where T : class
    {
        public int Take { get; set; } = 25;

        public int Skip { get; set; } = 0;

        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
