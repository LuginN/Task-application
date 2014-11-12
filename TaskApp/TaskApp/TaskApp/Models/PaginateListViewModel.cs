using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskApp.Models
{
    public class PaginatedListViewModel<T>
    {
        public int CurrentPage { get; private set; }
        public int ItemsPerPage { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public IEnumerable<T> Items { get; private set; }
  
        public PaginatedListViewModel(IEnumerable<T> source, int itemsPerPage, int currentPage)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = source.Count();
            TotalPages = (int)Math.Ceiling((double)TotalItems / ItemsPerPage);

            Items = source
                .Skip((CurrentPage - 1) * ItemsPerPage)
                .Take(ItemsPerPage);
        }

        public bool HasNextPage
        {
           get { return (CurrentPage + 1) <= TotalPages; }
        }

        public bool HasPreviosPage
        {
            get { return (CurrentPage - 1) > 0; }
        }
    }
}