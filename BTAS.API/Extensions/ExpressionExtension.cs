using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BTAS.API.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> CombineWithAnd<T>(
            this IEnumerable<Expression<Func<T, bool>>> expressions)
        {
            if (!expressions.Any())
            {
                return x => true;
            }

            Expression<Func<T, bool>> result = expressions.First();

            foreach (var expression in expressions.Skip(1))
            {
                var invokedExpr = Expression.Invoke(expression, result.Parameters.Cast<Expression>());
                result = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(result.Body, invokedExpr), result.Parameters);
            }

            return result;
        }
    }
}
