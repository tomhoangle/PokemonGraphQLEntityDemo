using GraphQL.Types;
using GraphQLGraphTypeFirstSingleTable.Models;
using GraphQLGraphTypeFirstSingleTable.Interfaces;

namespace GraphQLGraphTypeFirstSingleTable.GraphQL
{
    public class PageInfoType : ObjectGraphType<PageInfo>
    {
        public PageInfoType()
        {
            Field(a => a.startCursor, type: typeof(IntGraphType));
            Field(a => a.endCursor, type: typeof(IntGraphType));
            Field(a => a.hasNextPage, type: typeof(BooleanGraphType));
        }
    }
}
