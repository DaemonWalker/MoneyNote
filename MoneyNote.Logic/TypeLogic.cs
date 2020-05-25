using AutoMapper;
using MoneyNote.DbModels;
using MoneyNote.DomainModel;
using MoneyNote.IRepository;
using MoneyNote.Logic.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MoneyNote.Logic
{
    public class TypeLogic
    {
        private readonly IRepository<TypeDto> typeRepository;
        private readonly IMapper mapper;
        public TypeLogic(IRepository<TypeDto> typeRepository, IMapper mapper)
        {
            this.typeRepository = typeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<TypeModel> GetFeeTypes(int userID, string name = null)
        {
            var result = typeRepository.Get(p => p.UserID == userID)
                .Where(p => p.Name == name, name);
            return mapper.Map<IEnumerable<TypeModel>>(result);
        }

    }
}
