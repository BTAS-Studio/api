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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BTAS.API.Repository
{
    public class ReceptacleRepository : IRepository<tbl_receptacleDto>
    {
        private readonly MainDbContext _context;
        private IMapper _mapper;
        private int count;
        public ReceptacleRepository(MainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            count = 1;
        }

        /// <summary>
        /// Retrieves all Receptacle
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<tbl_receptacleDto>> GetAllAsync()
        {
            IEnumerable<tbl_receptacle> _list = await _context.tbl_receptacles
                .Include(r => r.shipments)
                .ToListAsync();
            _list = _list.Take(200);
            return _mapper.Map<List<tbl_receptacleDto>>(_list);
        }

        /// <summary>
        /// Retrieves a single Receptacle based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<tbl_receptacleDto> GetByIdAsync(int id)
        {

            tbl_receptacle result = await _context.tbl_receptacles
                .Include(c => c.shipments)
                .FirstOrDefaultAsync(x => x.idtbl_receptacle == id);
                
            return _mapper.Map<tbl_receptacleDto>(result);

        }

        /// <summary>
        /// Creates/updates a Receptacle record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<tbl_receptacleDto> CreateUpdateAsync(tbl_receptacleDto entity)
        {
            try
            {
                tbl_receptacle mapped = _mapper.Map<tbl_receptacleDto, tbl_receptacle>(entity);


                _context.tbl_receptacles.Add(mapped);
                await _context.SaveChangesAsync();
                return _mapper.Map<tbl_receptacle, tbl_receptacleDto>(mapped);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Creates a Receptacle record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> CreateAsync(tbl_receptacleDto entity, string shipperId)
        {
            try
            {

                string referenceNumber = await GetNextId(shipperId);
                entity.tbl_receptacle_code = referenceNumber;
                entity.tbl_receptacle_status = "OPEN";
                entity.tbl_receptacle_createdDate = DateTime.Now;

                tbl_receptacle result = _mapper.Map<tbl_receptacleDto, tbl_receptacle>(entity);

                if (result.idtbl_receptacle > 0)
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Unable to create duplicate receptacle record",
                        IsSuccess = false
                    };
                }
                else
                {
                    if (result.HouseCode != null && result.HouseCode != "")
                    {
                        tbl_house house = await _context.tbl_houses.FirstOrDefaultAsync(x => x.tbl_house_code == result.HouseCode);
                        if (house != null)
                        {
                            result.tbl_house_id = house.idtbl_house;
                            result.HouseCode = house.tbl_house_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Provided HOUSE code was not found.",
                                IsSuccess = false
                            };
                        }
                    }
                    
                    await _context.tbl_receptacles.AddAsync(result);
                    await _context.SaveChangesAsync();
                    return new ResponseDto
                    {
                        Result = _mapper.Map<tbl_receptacleDto>(result),
                        ReferenceNumber = result.tbl_receptacle_code,
                        DisplayMessage = "Receptacle successfully created.",
                        IsSuccess = true
                    };
                }
                
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.Message.ToString(),
                    IsSuccess = false
                };
            }

        }

        /// <summary>
        /// Updates a Receptacle record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ResponseDto> UpdateAsync(tbl_receptacleDto entity)
        {
            try
            {
                var result = await _context.tbl_receptacles
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.tbl_receptacle_code == entity.tbl_receptacle_code);

                _mapper.Map<tbl_receptacleDto, tbl_receptacle>(entity, result);
                if (result != null)
                {
                    if (entity.HouseCode != "" && entity.HouseCode != null)
                    {
                        var parent = await _context.tbl_houses
                        .FirstOrDefaultAsync(x => x.tbl_house_code == entity.HouseCode);

                        if (parent != null)
                        {
                            result.tbl_house_id = parent.idtbl_house;
                            result.HouseCode = parent.tbl_house_code;
                        }
                        else
                        {
                            return new ResponseDto
                            {
                                Result = entity,
                                DisplayMessage = "Unable to link receptacle. Invalid HOUSE id or code.",
                                IsSuccess = false
                            };
                        }
                    }


                    _context.tbl_receptacles.Update(result);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new ResponseDto
                    {
                        Result = entity,
                        DisplayMessage = "Receptacle does not exists.",
                        IsSuccess = false
                    };
                }

                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = "Receptacle successfully updated.",
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_receptacle_code
                };
            }
            catch(Exception ex)
            {
                return new ResponseDto
                {
                    Result = entity,
                    DisplayMessage = ex.StackTrace.ToString(),
                    IsSuccess = false
                };
            }
        }

        public async Task<ResponseDto> LinkToHouseAsync(LinkToHouseRequest request)
        {
            try
            {
                var parent = await _context.tbl_houses.FirstOrDefaultAsync(x => x.tbl_house_code == request.parentReference);
                if (parent != null)
                {
                    List<string> failed = new();
                    foreach (var reference in request.ReferencesToLink)
                    {
                        var entity = await _context.tbl_receptacles.FirstOrDefaultAsync(x => x.tbl_receptacle_code == reference);
                        if (entity != null)
                        {
                            entity.tbl_house_id = parent.idtbl_house;
                            entity.HouseCode = parent.tbl_house_code;
                            _context.tbl_receptacles.Update(entity);

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
                        DisplayMessage = failed.Count > 0 ? "failed" : "Receptacle successfully updated with HOUSE #" + request.parentReference,
                        ReferenceNumber = request.parentReference
                    };
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Result = request.ReferencesToLink,
                    DisplayMessage = "Unable to link receptacle. Invalid HOUSE number."
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

        public async Task<List<tbl_receptacleDto>> CreateRangeAsync(List<tbl_receptacleDto> entities)
        {
            List<tbl_receptacle> result = _mapper.Map<List<tbl_receptacleDto>, List<tbl_receptacle>>(entities);
            if (entities.Count > 0)
            {
                _context.tbl_receptacles.AddRange(result);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<List<tbl_receptacle>, List<tbl_receptacleDto>>(result);
        }

        /// <summary>
        /// Deletes existing receptacle record based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                tbl_receptacle result = await _context.tbl_receptacles.FirstOrDefaultAsync(x => x.idtbl_receptacle == id);
                if (result == null)
                {
                    return false;
                }
                _context.tbl_receptacles.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseDto> GetByReference(string referenceNumber, bool includeChild = false)
        {
            try
            {
                tbl_receptacle result = new();

                if (includeChild)
                {
                    result = await _context.tbl_receptacles
                        .Include(x => x.shipments)
                        .FirstOrDefaultAsync(x => x.tbl_receptacle_code == referenceNumber);
                }
                else
                {
                    result = await _context.tbl_receptacles
                        .FirstOrDefaultAsync(x => x.tbl_receptacle_code == referenceNumber);
                }
                return new ResponseDto
                {
                    IsSuccess = true,
                    ReferenceNumber = result.tbl_receptacle_code,
                    DisplayMessage = "Success",
                    Result = _mapper.Map<tbl_receptacleDto>(result)
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

        public async Task<ResponseDto> GetByHouseBillNo(string houseBillNo)
        {
            try
            {
                var houseResult = await _context.tbl_houses.OrderByDescending(x => x.idtbl_house)
                    .FirstOrDefaultAsync(y => y.tbl_house_billNumber == houseBillNo);
                //Edited by HS on 01/02/2023
                tbl_receptacle result = await _context.tbl_receptacles.OrderByDescending(x => x.idtbl_receptacle)
                    .FirstOrDefaultAsync(y => y.HouseCode == houseResult.tbl_house_code);
                return new ResponseDto
                {
                    IsSuccess = true, 
                    DisplayMessage = "Successfully retrieved House by reference" + houseBillNo,
                    Result = _mapper.Map<tbl_receptacleDto>(result),
                    ReferenceNumber = result.tbl_receptacle_code
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
        //Added by HS on 01/02/2023
        public async Task<ResponseDto> GetDummyByMasterBillNo(string referenceNumber)
        {
            try
            {
                tbl_master masterResult = await _context.tbl_masters.OrderByDescending(x => x.idtbl_master)
                    .FirstOrDefaultAsync(y => y.tbl_master_billNumber== referenceNumber);
                var masterReference = masterResult.tbl_master_code;
                tbl_house houseResult = await _context.tbl_houses.OrderByDescending(x => x.idtbl_house)
                    .FirstOrDefaultAsync(y => (y.MasterCode == masterReference && y.tbl_house_billNumber == "DUMMY"));
                var houseReference = houseResult.tbl_house_code;
                tbl_receptacle receptacleResult = await _context.tbl_receptacles.OrderByDescending(x => x.idtbl_receptacle)
                    .FirstOrDefaultAsync(y => y.HouseCode == houseReference);

                return new ResponseDto
                {
                    IsSuccess = true,
                    DisplayMessage = "Successfully retrieved Dummy Receptacle by master bill number" + referenceNumber,
                    Result = _mapper.Map<tbl_receptacleDto>(receptacleResult),
                    ReferenceNumber = receptacleResult.tbl_receptacle_code
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    DisplayMessage = "Error retrieving dummy receptacle. " + ex.Message,
                };
            }
        }

        public async Task<string> GetNextId(string shipperId)
        {

            tbl_receptacle result = await _context.tbl_receptacles.OrderByDescending(x => x.idtbl_receptacle).FirstOrDefaultAsync();

            string referenceCode = "RC" + shipperId + String.Format("{0:0000000000}", (result != null ? result.idtbl_receptacle + count : 1));
            count++;
            return referenceCode;
        }

        public async Task<IEnumerable<tbl_receptacleDto>> GetAllAsyncWithChildren(searchFilter filter = null)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(filter.searchFields);
                var _searchFilter = JsonConvert.DeserializeObject<tbl_receptacleDto>(jsonString);
                var qList = _context.tbl_receptacles.AsQueryable();
                var parent = _searchFilter.GetType();

                qList = qList
                            .Include(p => p.house)
                            .Include(p => p.shipments).ThenInclude(p => p.shipmentItems);

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
                                Expression<Func<tbl_receptacle, bool>> lambda = Expression.Lambda<Func<tbl_receptacle, bool>>(equalsExpression, parameter);

                                if (valueConstant != null)
                                {
                                    qList = qList.Provider.CreateQuery<tbl_receptacle>(Expression.Call(
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
                                PropertyInfo childItemInfo = typeof(tbl_receptacleDto).GetProperty(property.Name);


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
                                                        ConstantExpression valueConstant = null;

                                                        switch (objValue.GetType().Name.ToUpper())
                                                        {
                                                            case "INT32":
                                                                {
                                                                    if ((int)objValue > 0)
                                                                    {
                                                                        valueConstant = Expression.Constant(objValue);
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

                                                        BinaryExpression equalsExpression = Expression.Equal(parameter, valueConstant);
                                                        Expression<Func<tbl_receptacle, bool>> lambda = Expression.Lambda<Func<tbl_receptacle, bool>>(equalsExpression, parameter);

                                                        if (valueConstant != null)
                                                        {
                                                            qList = qList.Provider.CreateQuery<tbl_receptacle>(Expression.Call(
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
                return _mapper.Map<IEnumerable<tbl_receptacleDto>>(filtered);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<IEnumerable<tbl_receptacleDto>> GetAllAsyncWithChildren()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<tbl_receptacleDto>> GetAllAsyncWithChildren(searchFilter<tbl_receptacleDto> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
