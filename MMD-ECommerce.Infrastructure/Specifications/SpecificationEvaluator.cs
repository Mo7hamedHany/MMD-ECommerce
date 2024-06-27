using Microsoft.EntityFrameworkCore;
using MMD_ECommerce.Data.Bases;

namespace MMD_ECommerce.Infrastructure.Specifications
{
    public class SpecificationEvaluator<TEntity, TKey> where TEntity : ModelKey<TKey>
    {
        public static IQueryable<TEntity> BuildQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)

                query = query.Where(specification.Criteria);

            if (specification.OrderBy != null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDesc != null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if (specification.IsPaginated == true)
                query = query.Skip(specification.Skip).Take(specification.Take);

            if (specification.IncludeExpressions.Any())
            {
                query = specification.IncludeExpressions
                  .Aggregate(query, (currentQuery, expression) => currentQuery.Include(expression));
            }

            if (specification.ThenIncludeExpressions.Any())
            {
                foreach (var thenIncludeExpression in specification.ThenIncludeExpressions)
                {
                    var includeExpression = thenIncludeExpression.Item1;
                    var thenIncludeExpr = thenIncludeExpression.Item2;

                    query = query.Include(includeExpression).ThenInclude(thenIncludeExpr);
                }
            }

            return query;

        }
    }
}
