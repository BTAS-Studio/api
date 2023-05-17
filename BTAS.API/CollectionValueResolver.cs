using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTAS.API
{
    public class CollectionValueResolver<TDto, TItemDto, TModel, TItemModel> : IMemberValueResolver<TDto, TModel, IEnumerable<TItemDto>, IEnumerable<TItemModel>>
        where TDto : class
        where TModel : class
    {
        private readonly Func<TItemDto, TItemModel, bool> _keyMatch;
        private readonly Func<TItemDto, bool> _saveOnlyIf;

        public CollectionValueResolver(Func<TItemDto, TItemModel, bool> keyMatch, Func<TItemDto, bool> saveOnlyIf = null)
        {
            _keyMatch = keyMatch;
            _saveOnlyIf = saveOnlyIf;
        }

        public IEnumerable<TItemModel> Resolve(TDto sourceDto, TModel destinationModel, IEnumerable<TItemDto> sourceDtos, IEnumerable<TItemModel> destinationModels, ResolutionContext context)
        {
            var mapper = context.Mapper;

            var models = new List<TItemModel>();
            foreach (var dto in sourceDtos)
            {
                if (_saveOnlyIf == null || _saveOnlyIf(dto))
                {
                    var existingModel = destinationModels.SingleOrDefault(model => _keyMatch(dto, model));
                    if (EqualityComparer<TItemModel>.Default.Equals(existingModel, default(TItemModel)))
                    {
                        models.Add(mapper.Map<TItemModel>(dto));
                    }
                    else
                    {
                        mapper.Map(dto, existingModel);
                        models.Add(existingModel);
                    }
                }
            }

            return models;
        }
    }
}
