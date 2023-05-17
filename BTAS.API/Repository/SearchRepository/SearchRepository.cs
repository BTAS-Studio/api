using BTAS.API.Models;
using System.Linq.Expressions;
using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Internal.Mappers;

namespace BTAS.API.Repository.SearchRepository
{
    public class SRepository
    {
        public static Expression<Func<T, bool>> GetPropertyLambda<T>(PropertyInfo propertyInfo, CustomFilter<dynamic> filter, bool parent)
        {
            Type type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            if (type == typeof(string))
            {
                return GetLambda<T, string>(propertyInfo, filter, parent);
            }
            else if (type == typeof(DateTime))
            {
                return GetLambda<T, DateTime>(propertyInfo, filter, parent);
            }
            else if (type == typeof(int))
            {
                return GetLambda<T, int>(propertyInfo, filter, parent);
            }
            else if (type == typeof(decimal))
            {
                return GetLambda<T, decimal>(propertyInfo, filter, parent);
            }
            else
            {
                return null;
            }
        }

        private static Expression<Func<T, bool>> GetLambda<T, TValue>(PropertyInfo propertyInfo, CustomFilter<dynamic> filter, bool parent = false)
        {
            ConstantExpression constant;
            // Create a ParameterExpression to represent the instance of tbl_master
            var parameter = Expression.Parameter(typeof(T), "p");
            MemberExpression property;

            if (parent)
            {
                // Create a MemberExpression to represent the voyage property in tbl_master
                var parentProperty = Expression.Property(parameter, typeof(T).GetProperty(filter.tableName));
                // Create a MemberExpression to represent the voyage.id property in voyage
                property = Expression.Property(parentProperty, propertyInfo);
            }
            else
            {
                //create a MemberExpression that represents accessing a property
                property = Expression.Property(parameter, propertyInfo);
            }            
            
            if (filter.condition.ToUpper() != "CONTAINS")
            {
                constant = Expression.Constant(Convert.ChangeType(filter.fieldValue, typeof(TValue)), typeof(TValue));
                //Binary Expression
                var body = GetBinaryExpression(property, constant, filter.condition);
                return Expression.Lambda<Func<T, bool>>(body, parameter);
            }
            //Contains (Like) condition
            else
            {
                constant = Expression.Constant(Convert.ChangeType(filter.fieldValue, typeof(string)), typeof(string));
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                if (propertyInfo.PropertyType != typeof(string))
                {
                    var toStringExpression = Expression.Call(property, typeof(object).GetMethod("ToString"));
                    var body = Expression.Call(toStringExpression, containsMethod, constant);
                    return Expression.Lambda<Func<T, bool>>(body, parameter);
                }
                else
                {
                    var body = Expression.Call(property, containsMethod, constant);
                    return Expression.Lambda<Func<T, bool>>(body, parameter);
                }
                //MethodCall Expression
                //var body = Expression.Call(toStringProperty, containsMethod, constant);
                
            }
            
        }

        private static BinaryExpression GetBinaryExpression(MemberExpression memberExpression, ConstantExpression constantExpression, string condition/*, Type type*/)
        {
            var memberType = memberExpression.Type;
            Expression nullableConstantExpression = Expression.Convert(constantExpression, memberType);
            switch (condition)
            {
                case "==":
                    return Expression.Equal(memberExpression, nullableConstantExpression);
                case ">":
                    return Expression.GreaterThan(memberExpression, nullableConstantExpression);
                case ">=":
                    return Expression.GreaterThanOrEqual(memberExpression, nullableConstantExpression);
                case "<":
                    return Expression.LessThan(memberExpression, nullableConstantExpression);
                case "<=":
                    return Expression.LessThanOrEqual(memberExpression, nullableConstantExpression);
                case "!=":
                    return Expression.NotEqual(memberExpression, nullableConstantExpression);
                default:
                    throw new ArgumentException("Invalid condition");
            }
        }
    }
}