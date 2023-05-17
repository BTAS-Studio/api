namespace BTAS.API.Extensions
{
    using System;
    using System.Linq.Expressions;

    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>()
        {
            return x => true;
        }

        public static Expression<Func<T, bool>> False<T>()
        {
            return x => false;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var invokedExpression = Expression.Invoke(right, left.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, invokedExpression), left.Parameters);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var invokedExpression = Expression.Invoke(right, left.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, invokedExpression), left.Parameters);
        }
    }
}
