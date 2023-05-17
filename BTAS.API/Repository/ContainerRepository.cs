using AutoMapper;
using BTAS.API.Dto;
using BTAS.API.Models;
using BTAS.API.Models.Links;
using BTAS.API.Repository.Interface;
using BTAS.Data;
using BTAS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ContainerRepository : IRepository<tbl_containerDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;

        public ContainerRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all container
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_containerDto>> GetAllAsync()
        {
            IEnumerable<tbl_container> _list = await _context.tbl_containers.ToListAsync();
            return _mapper.Map<List<tbl_containerDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single container based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_containerDto> GetByIdAsync(int id)
        {

            tbl_container result = await _context.tbl_containers.FirstOrDefaultAsync(x => x.idtbl_container == id);
            return _mapper.Map<tbl_containerDto>(result);

        }

        /// <summary>
        /// Creates/updates a container record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_containerDto> CreateUpdateAsync(tbl_containerDto entity)
        {
            try
            {
                tbl_container mappedHouse = _mapper.Map<tbl_containerDto, tbl_container>(entity);


                _context.tbl_containers.Add(mappedHouse);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_container, tbl_containerDto>(mappedHouse);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a container record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_containerDto entity, string shipperId)
        {
            try
            {
                string referenceNumber = await GetNextId(shipperId);
                entity.tbl_container_code = referenceNumber;
                entity.tbl_container_status = "OPEN";

                tbl_container result = _mapper.Map<tbl_containerDto, tbl_container>(entity);

                if (result.idtbl_container > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate container record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (!String.IsNullOrEmpty(result.MasterCode))
                    {
                        var parent = await _context.tbl_masters.FirstOrDefaultAsync(x => x.tbl_master_code == result.MasterCode);
                        if (parent != null)
                        {
                            result.tbl_master_id = parent.idtbl_master;
                            result.MasterCode = parent.tbl_master_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link item. Provided MASTER reference was not found.",
                                IsSuccess = false
                            };
                        }
                    }

                    await _context.tbl_containers.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Container successfully created.",
                        IsSuccess = true,
                        ReferenceNumber = result.tbl_container_code
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Updates a container record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_containerDto entity)
        {
            try
            {
                var result = await _context.tbl_containers
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_container_code == entity.tbl_container_code);

                _mapper.Map<tbl_containerDto, tbl_container>(entity, result);
                if (result != null)
                {
                    if (result.MasterCode != "" && entity.MasterCode != null)
                    {
                        var master = await _context.tbl_masters
                        .FirstOrDefaultAsync(x => x.tbl_master_code == entity.MasterCode);

                        if (master != null)
                        {
                            result.tbl_master_id = master.idtbl_master;
                            result.MasterCode = master.tbl_master_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Invalid MASTER id or code.",
                                IsSuccess = false
                            };
                        }
                    }


                    _context.tbl_containers.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Container does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Container successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_container_code
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<ResponseDto> LinkToMasterAsync(LinkToMasterRequest request)
        {
            try
            {
                var parent = await _context.tbl_masters.FirstOrDefaultAsync(x => x.tbl_master_code == request.parentReference);
                if (parent != null)
                {
                    List<string> failed = new();
                    foreach (var reference in request.ReferencesToLink)
                    {
                        var entity = await _context.tbl_containers.FirstOrDefaultAsync(x => x.tbl_container_code == reference && x.tbl_container_code.Contains(request.shipperId));
                        if (entity != null)
                        {
                            entity.tbl_master_id = parent.idtbl_master;
                            entity.MasterCode = parent.tbl_master_code;
                            _context.tbl_containers.Update(entity);

                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            failed.Add(reference);
                        }
                    }

                    return new ResponseDto
                    {
                        IsSuccess = true,
                        Result = failed,
                        DisplayMessage = failed.Count > 0 ? "failed" : "Container successfully updated with MASTER # " + request.parentReference,
                        ReferenceNumber = request.parentReference
                    };
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request.ReferencesToLink,
                    DisplayMessage = "Invalid MASTER code."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request,
                    ErrorMessages = new List<string>() { ex.Message }
                };
            }
        }

        public async Task<List<tbl_containerDto>> CreateRangeAsync(List<tbl_containerDto> entities)
        {
            List<tbl_container> result = _mapper.Map<List<tbl_containerDto>, List<tbl_container>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_containers.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_container>, List<tbl_containerDto>>(result);
        }

        /// <summary>
        /// Deletes existing container record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_container result = await _context.tbl_containers.FirstOrDefaultAsync(x => x.idtbl_container == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_containers.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByMaster(string referenceNumber)
        {
            try
            {
                var result = await _context.tbl_containers.Where(x => x.MasterCode == referenceNumber).ToListAsync();

                return new ResponseDto
                {
                    Result = _mapper.Map<List<tbl_containerDto>>(result)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Error retrieving record."
                };
            }
        }

        public async Task<string> GetNextId(string shipperId)
        {
            tbl_container result = await _context.tbl_containers.OrderByDescending(x => x.idtbl_container).FirstOrDefaultAsync();

            string referenceCode = "CN" + shipperId + String.Format("{0:0000000000}", (result != null ? result.idtbl_container + count : 1));
            return referenceCode;
        }

        /// <summary>
        /// Retrieves filtered House
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_containerDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            try
            {

                var jsonString = JsonConvert.SerializeObject(filter.searchFields);
                var _searchFilter = JsonConvert.DeserializeObject<tbl_containerDto>(jsonString);
                var qList = _context.tbl_containers.AsQueryable();
                var parent = _searchFilter.GetType();

                qList = qList
                            .Include(p => p.master)
                            .Include(x => x.houses).ThenInclude(x => x.houseItems);

                if (_searchFilter != null)
                {
                    var properties = parent.GetProperties();

                    foreach (var property in properties)
                    {
                        var value = property.GetValue(_searchFilter, null);

                        PropertyInfo propertyInfo = _searchFilter.GetType().GetProperty(property.Name);

                        if (property != null && value != null)
                        {
                            if ((propertyInfo.PropertyType != typeof(object) ||
                                property.PropertyType.IsClass) &&
                                Type.GetTypeCode(value.GetType()) != TypeCode.Object)
                            {
                                Type elementType = qList.ElementType;
                                ParameterExpression parameter = Expression.Parameter(elementType, "p");
                                MemberExpression childProperty = Expression.Property(parameter, property.Name);
                                ConstantExpression valueConstant = null;

                                switch (value.GetType().Name.ToUpper())
                                {
                                    case "INT32":
                                        {
                                            if ((int)value > 0)
                                            {
                                                valueConstant = Expression.Constant(value);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                            break;
                                        }
                                    case "DATETIME":
                                        {
                                            DateTime dateToCheck;
                                            if (DateTime.TryParse(Convert.ToString(value), out dateToCheck) && dateToCheck != new DateTime(1900, 1, 1, 0, 0, 0))
                                            {
                                                valueConstant = Expression.Constant(DateTime.Parse(value.ToString()));
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            valueConstant = Expression.Constant(value);
                                            break;
                                        }
                                }

                                BinaryExpression equalsExpression = Expression.Equal(childProperty, valueConstant);
                                Expression<Func<tbl_container, bool>> lambda = Expression.Lambda<Func<tbl_container, bool>>(equalsExpression, parameter);

                                if (valueConstant != null)
                                {
                                    qList = qList.Provider.CreateQuery<tbl_container>(Expression.Call(
                                    typeof(Queryable),
                                    "Where",
                                    new[] { elementType },
                                    qList.Expression,
                                    lambda
                                ));
                                }
                            }
                            else
                            {
                                PropertyInfo childItemInfo = typeof(tbl_containerDto).GetProperty(property.Name);


                                foreach (var objProp in value.GetType().GetProperties())
                                {
                                    var jsonProp = objProp.GetCustomAttributes(true);
                                    object objValue = null;

                                    // Check if the property is an indexed property
                                    if (objProp.GetIndexParameters().Length > 0)
                                    {
                                        // If it's an indexed property, get its value using an index value
                                        object[] index = new object[] { 0 }; // Replace 0 with the actual index value you want to retrieve

                                        // Check if the property is public or not
                                        if (!objProp.GetGetMethod().IsPublic)
                                        {
                                            // If the property is not public, set its accessibility to true
                                            objProp.SetValue(value, null);
                                        }

                                        // Check if the property has an indexed getter method
                                        if (objProp.GetIndexParameters().Length > 0)
                                        {
                                            try
                                            {
                                                objValue = objProp.GetValue(value, index);
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.StackTrace);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // If it's not an indexed property, get its value directly

                                        // Check if the property is public or not
                                        if (!objProp.GetGetMethod().IsPublic)
                                        {
                                            // If the property is not public, set its accessibility to true
                                            objProp.SetValue(value, null);
                                        }

                                        try
                                        {
                                            objValue = objProp.GetValue(value);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.StackTrace);
                                        }
                                    }

                                    //var objValue = objProp.GetValue(value);
                                    string propertyName = "";

                                    foreach (var attribute in jsonProp)
                                    {
                                        if (attribute is JsonPropertyAttribute displayAttribute)
                                        {
                                            propertyName = displayAttribute.PropertyName;
                                            break;
                                        }
                                    }

                                    if (propertyName != string.Empty || objValue != null)
                                    {
                                        JObject jsonObject = JObject.Parse(jsonString);
                                        bool isObjectExists = jsonObject.ContainsKey(propertyName);
                                        bool isPropertyExists = jsonObject[propertyName] != null;

                                        if (!isObjectExists || !isPropertyExists)
                                        {
                                            isObjectExists = jsonObject[propertyInfo.Name]?[propertyName] != null;
                                        }

                                        if ((isObjectExists || isPropertyExists) && propertyName != string.Empty)
                                        {
                                            if (objValue != null)
                                            {
                                                foreach (var subProperty in objValue.GetType().GetProperties())
                                                {
                                                    var subPropertyValue = subProperty.GetValue(objValue);

                                                    if (Type.GetTypeCode(subPropertyValue.GetType()) != TypeCode.Object)
                                                    {
                                                        Type elementType = qList.ElementType;
                                                        ParameterExpression parameter = Expression.Parameter(elementType, "p");
                                                        MemberExpression voyageProperty = Expression.Property(parameter, property.Name);
                                                        MemberExpression etdProperty = Expression.Property(voyageProperty, objProp.Name);
                                                        ConstantExpression valueConstant = null;

                                                        switch (objValue.GetType().Name.ToUpper())
                                                        {
                                                            case "INT32":
                                                                {
                                                                    if ((int)objValue > 0)
                                                                    {
                                                                        valueConstant = Expression.Constant(objValue);
                                                                        //qList = qList.Where(x => objProp.GetValue(x, null) == objValue);
                                                                    }
                                                                    else
                                                                    {
                                                                        continue;
                                                                    }

                                                                    break;
                                                                }
                                                            case "DATETIME":
                                                                {
                                                                    try
                                                                    {
                                                                        valueConstant = Expression.Constant(DateTime.Parse(objValue.ToString()));

                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        throw;
                                                                    }
                                                                    break;
                                                                }
                                                            default:
                                                                {
                                                                    valueConstant = Expression.Constant(objValue);
                                                                    break;
                                                                }
                                                        }

                                                        BinaryExpression equalsExpression = Expression.Equal(etdProperty, valueConstant);
                                                        Expression<Func<tbl_container, bool>> lambda = Expression.Lambda<Func<tbl_container, bool>>(equalsExpression, parameter);

                                                        if (valueConstant != null)
                                                        {
                                                            qList = qList.Provider.CreateQuery<tbl_container>(Expression.Call(
                                                            typeof(Queryable),
                                                            "Where",
                                                            new[] { elementType },
                                                            qList.Expression,
                                                            lambda
                                                        ));
                                                        }

                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                var filtered = await qList.Skip((filter.Page ?? 0) * filter.PageSize).Take(filter.PageSize).ToListAsync();
                return _mapper.Map<IEnumerable<tbl_containerDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<IEnumerable<tbl_containerDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_containerDto>> GetAllAsyncWithChildren(searchFilter<tbl_containerDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
