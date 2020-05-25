using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MoneyNote.Logic.Internal
{
    public static class Extenssions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> ts, Expression<Func<T, bool>> where, object nullable)
        {
            if (nullable != null)
            {
                return ts.Where(where.Compile());
            }
            else
            {
                return ts;
            }
        }
    }
}
