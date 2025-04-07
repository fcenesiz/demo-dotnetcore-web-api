using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_dotnetcore_web_api.src.Helpers
{
    public class Pagination<T>
    {
        public List<T> Items { get; set; } = [];
        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public Pagination(List<T> items, int count, int index, int size)
        {
            Items = items;
            Count = count;
            Index = index;
            Size = size;
            Pages = (int)Math.Ceiling(count / (double)size);
            HasPrevious = index > 1;
            HasNext = index < Pages;
        }

        public static Pagination<T> Paginate<T>(List<T> source, int index, int size)
        {

            if (index <= 0) index = 1; // index'in pozitif olduğundan emin olun
            if (size <= 0) size = 10;  // size'ın pozitif olduğundan emin olun

            var count = source.Count();
            var items = source.Skip((index - 1) * size).Take(size).ToList();
            return new Pagination<T>(items, count, index, size);
        }
    }


}