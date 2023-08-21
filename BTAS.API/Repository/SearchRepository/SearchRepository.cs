using BTAS.API.Models;
using System.Linq.Expressions;
using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Internal.Mappers;
using BTAS.API.Dto;
using Newtonsoft.Json;
using BTAS.Data.Models;
using Newtonsoft.Json.Linq;

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
            else if (type == typeof(byte))
            {
                return GetLambda<T, byte>(propertyInfo, filter, parent);
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

        private static BinaryExpression GetBinaryExpression(MemberExpression memberExpression, ConstantExpression constantExpression, string condition)
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
    
        public static (bool, string) MakeVoyageJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_voyageDto voyage = new tbl_voyageDto();
            if (filter.fieldName == "ETA")
            {
                containsDateTime = true;
                voyage.tbl_voyage_eta = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(voyage);
            }
            else if (filter.fieldName == "ETD")
            {
                containsDateTime = true;
                voyage.tbl_voyage_etd = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(voyage);
            }
            else if (filter.fieldName == "ATA")
            {
                containsDateTime = true;
                voyage.tbl_voyage_ata = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(voyage);
            }
            else if (filter.fieldName == "ATD")
            {
                containsDateTime = true;
                voyage.tbl_voyage_ata = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(voyage);
            }
            else if (filter.fieldName == "ETADischarge")
            {
                containsDateTime = true;
                voyage.tbl_voyage_etaDischarge = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(voyage);
            }
            return (containsDateTime, jsonString);
        }
        public static (bool, string) MakeMasterJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_masterDto master = new tbl_masterDto();
            if (filter.fieldName == "CreatedDate")
            {
                containsDateTime = true;
                master.tbl_master_createdDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(master);
            }
            return (containsDateTime, jsonString);
        }

        public static (bool, string) MakeContainerJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_containerDto container = new tbl_containerDto();
            if (filter.fieldName == "CreatedDate")
            {
                containsDateTime = true;
                container.tbl_container_createdDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(container);
            }
            return (containsDateTime, jsonString);
        }
        public static (bool, string) MakeHouseJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_houseDto house = new tbl_houseDto();
            if (filter.fieldName == "CreatedDate")
            {
                containsDateTime = true;
                house.tbl_house_createdDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(house);
            }
            else if (filter.fieldName == "DeliveryDate")
            {
                containsDateTime = true;
                house.tbl_house_deliveryDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(house);
            }
            else if (filter.fieldName == "ClearanceDate")
            {
                containsDateTime = true;
                house.tbl_house_clearanceDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(house);
            }
            return (containsDateTime, jsonString);
        }

        public static (bool, string) MakeReceptacleJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_receptacleDto receptacle = new tbl_receptacleDto();
            if (filter.fieldName == "CreatedDate")
            {
                containsDateTime = true;
                receptacle.tbl_receptacle_createdDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(receptacle);
            }
            return (containsDateTime, jsonString);
        }

        public static (bool, string) MakeShipmentJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_shipmentDto shipment = new tbl_shipmentDto();
            if (filter.fieldName == "CreatedDate")
            {
                containsDateTime = true;
                shipment.tbl_shipment_createdDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(shipment);
            }
            else if (filter.fieldName == "ReadyDate")
            {
                containsDateTime = true;
                shipment.tbl_shipment_readyDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(shipment);
            }
            else if (filter.fieldName == "DeliveryDate")
            {
                containsDateTime = true;
                shipment.tbl_shipment_deliveryDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(shipment);
            }
            return (containsDateTime, jsonString);
        }

        public static (bool, string) MakeClientHeaderJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_client_headerDto clientHeader = new tbl_client_headerDto();
            if (filter.fieldName == "CreatedDate")
            {
                containsDateTime = true;
                clientHeader.tbl_client_header_createdDate = new DateTime(1000, 01, 01);
                jsonString = JsonConvert.SerializeObject(clientHeader);
            }
            return (containsDateTime, jsonString);
        }
        
        public static (bool, string) MakeAddressJsonString(CustomFilter<dynamic> filter, bool containsDateTime, string jsonString)
        {
            tbl_addressDto address = new tbl_addressDto();
            if (filter.fieldName == "StartTime")
            {
                containsDateTime = true;
                address.tbl_address_startTime = new TimeOnly(12, 01);
                jsonString = JsonConvert.SerializeObject(address);
            }
            else if (filter.fieldName == "EndTime")
            {
                containsDateTime = true;
                address.tbl_address_endTime = new TimeOnly(12, 01);
                jsonString = JsonConvert.SerializeObject(address);
            }
            return (containsDateTime, jsonString);
        }

        public static (PropertyInfo, object, bool) GetPropertyInfo<TDto, T> (string jsonString, PropertyInfo propertyInfo, CustomFilter<dynamic> filter, bool containsDateTime, JToken originalValue)
        {
            var objFields = JsonConvert.DeserializeObject<TDto>(jsonString);
            var properties = objFields.GetType().GetProperties();
            //propertyInfo: get the data table column name from JsonProperty
            foreach (var property in properties)
            {
                var value = property.GetValue(objFields, null);
                //not default value, including int, string, datetime, double and byte
                if (property != null && (value != null && !value.Equals(0) && !value.Equals(new DateTime(0001, 1, 1, 0, 0, 0)))
                                        && !value.Equals(0m) && !value.Equals((byte)0) && !value.Equals(false))
                {
                    propertyInfo = typeof(T).GetProperty(property.Name);
                    filter.fieldValue = value;

                    if (containsDateTime)
                    {
                        propertyInfo = typeof(T).GetProperty(property.Name);
                        filter.fieldValue = originalValue;
                    }
                    break;
                }
            }
            return (propertyInfo, filter.fieldValue, containsDateTime);
        }
        public static (PropertyInfo, object, bool) GetParentPropertyInfo<T, TParent, TParentDto>(string jsonString, PropertyInfo propertyInfo, CustomFilter<dynamic> filter, bool containsDateTime, JToken originalValue)
        {
            var parentFields = JsonConvert.DeserializeObject<TParentDto>(jsonString);
            var properties = parentFields.GetType().GetProperties();
            //propertyInfo: get the data table column name from JsonProperty
            foreach (var property in properties)
            {
                var value = property.GetValue(parentFields, null);
                if (property != null && (value != null && !value.Equals(0) && !value.Equals(new DateTime(0001, 1, 1, 0, 0, 0)))
                    && !value.Equals(0m) && !value.Equals((byte)0))
                {
                    var pProperty = typeof(T).GetProperty(filter.tableName);
                    propertyInfo = pProperty.PropertyType.GetProperty(property.Name);
                    filter.fieldValue = value;

                    if (containsDateTime == true)
                    {
                        propertyInfo = typeof(TParent).GetProperty(property.Name);
                        filter.fieldValue = originalValue;
                    }
                    break;
                }
            }
            return (propertyInfo, filter.fieldValue, containsDateTime);
        }
    }
}