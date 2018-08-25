using Paginator;
using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights.Extensibility;

namespace Example1.Models
{
    public class Paginator<T> : IPaginatedResults<T> where T : class
    {
        public Paginator()
        {
            ItemsPerPage = 5;
            Items = new List<T>();
        }

        private Paginator(IReadOnlyList<T> items) : this()
        {
            if (items != null)
            {
                Items = items;
            }
        }

        public Paginator(IReadOnlyList<T> items, int totalItems) : this(items)
        {
            TotalItems = totalItems;
        }

        public Paginator(int currentPage, int itemsPerPage)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
        }

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public int NumberOfPages
        {
            get
            {
                if (ItemsPerPage > 0)
                {
                    return Items != null
                        ? TotalItems % ItemsPerPage == 0 ? TotalItems / ItemsPerPage :
                        Math.Abs(TotalItems / ItemsPerPage) + 1
                        : 0;
                }

                return 0;
            }
        }

        public IReadOnlyList<T> Items { get; set; }
    }
}