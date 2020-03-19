using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstSingleTable.Models
{
    public class Pagination
    {

        public Pagination(int count)
        {
            this.count = count;
        }

        public int count { get; set; }
    }
}
