using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.Models
{
    public class Pagination
    {

        public Pagination(int count, int first = 0, int after = 0, int countPerPage = 0, int currentPage = 0, int totalPage = 0)
        {
            this.count = count;
            this.first = first;
            this.after = after;
            this.countPerPage = countPerPage;
            this.currentPage = currentPage;
            this.totalPages = totalPage;
            if (first == 0 && after == 0) endCursor = count;
            else endCursor = first + after + 1;
        }

        public int count { get; set; }
        public int first { get; set; }
        public int last { get; set; }
        public int after { get; set; }
        public int startCursor { get; set; }
        public int endCursor { get; set; }
        public bool hasNextPage { get; set; }
        public int countPerPage { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
    }
}
