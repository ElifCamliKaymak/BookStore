using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.RequestFeatures
{
    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;   //bu koşul true ise öncesinde sayfa var demektir.
        public bool HasPage => CurrentPage < TotalPage;   //bu koşul doğru ie sonrasında sayfa yoktur.
    }
}
