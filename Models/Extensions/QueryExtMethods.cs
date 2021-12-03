﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public static class QueryExtMethods
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> items,
            int pagenumber, int pagesize)
        {
            return items
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
        }
    }
}
