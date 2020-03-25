using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.Models
{
    public class PageInfo
    {
        public int endCursor;
        public int startCursor;
        public bool hasNextPage;

        public PageInfo(int endCursor, int startCursor, bool hasNextPage)
        {
            this.endCursor = endCursor;
            this.startCursor = startCursor;
            this.hasNextPage = hasNextPage;
        }
    }
}
