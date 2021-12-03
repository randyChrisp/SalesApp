﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesApp.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected SalesAppContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(SalesAppContext ctx)
        {
            this.context = ctx;
            this.dbset = this.context.Set<T>();
        }

        private int? count;
        public int Count => count ?? dbset.Count();

        public virtual IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }

        public virtual T Get(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }
        public virtual T Get(int id) => dbset.Find(id);

        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Update(T entity) => dbset.Update(entity);
        public virtual void Delete(T entity) => dbset.Remove(entity);
        public virtual void Save() => context.SaveChanges();

        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = this.dbset;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            if (options.HasWhere)
            {
                foreach (var clause in options.WhereClauses)
                {
                    query = query.Where(clause);
                }
                this.count = query.Count();
            }

            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                {
                    query = query.OrderBy(options.OrderBy);
                }
                else
                {
                    query = query.OrderByDescending(options.OrderBy);
                }
            }

            if (options.HasPaging)
                query = query.PageBy(options.PageNumber, options.PageSize);

            return query;
        }

    }
}
