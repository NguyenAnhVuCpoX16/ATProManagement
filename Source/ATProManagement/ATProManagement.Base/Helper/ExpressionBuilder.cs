using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ATProManagement.Base
{
    public class ExpressionBuilder
    {
        public static Expression<Func<T, bool>>? Build<T>(List<FilterItem> filters)
        {
            if (filters == null || filters.Count == 0)
                return null;

            var param = Expression.Parameter(typeof(T), "x");

            Expression? body = null;

            foreach (var f in filters)
            {
                var prop = Expression.Property(param, f.Field);
                var constant = Expression.Constant(Convert.ChangeType(f.Value, prop.Type));

                Expression? exp = f.Operator switch
                {
                    "==" => Expression.Equal(prop, constant),
                    ">" => Expression.GreaterThan(prop, constant),
                    "<" => Expression.LessThan(prop, constant),

                    "contains" => Expression.Call(
                        prop,
                        typeof(string).GetMethod("Contains", new[] { typeof(string) })!,
                        constant),

                    _ => null
                };


                body = body == null ? exp : Expression.AndAlso(body, exp??Expression.Constant(false));
            }

            return Expression.Lambda<Func<T, bool>>(body??Expression.Constant(false), param);
        }
    }
}
