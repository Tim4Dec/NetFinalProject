using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NetFinalProject.Utils
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync<TKey>(IQueryable<T> source, int pageIndex, int pageSize, Func<T, TKey> sort, bool isAsc = true)
        {
            var count = await source.CountAsync();
            List<T> items;
            if (isAsc)
            {
                items = source.OrderBy<T, TKey>(sort).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = source.OrderByDescending<T, TKey>(sort).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
