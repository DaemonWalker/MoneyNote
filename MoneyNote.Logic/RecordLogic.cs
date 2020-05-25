using AutoMapper;
using MoneyNote.DbModels;
using MoneyNote.DomainModel;
using MoneyNote.IRepository;
using MoneyNote.Logic.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyNote.Logic
{
    public class RecordLogic
    {
        private readonly IMapper mapper;
        private IRepository<RecordDto> feeItemRepository;
        public RecordLogic(IRepository<RecordDto> feeItemRepository, IMapper mapper)
        {
            this.feeItemRepository = feeItemRepository;
            this.mapper = mapper;
        }
        public IEnumerable<RecordModel> GetRecords(int userID, int? typeID = null,
            IEnumerable<int> typeIDs = null, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var result = feeItemRepository.Get(p => p.UserID == userID)
                .Where(p => p.TypeIDs.Contains(typeID.Value), typeID)
                .Where(p => p.TypeIDs.Intersect(typeIDs).Any(), typeIDs)
                .Where(p => p.Date >= beginDate, beginDate)
                .Where(p => p.Date <= endDate, endDate);

            return mapper.Map<IEnumerable<RecordModel>>(result);
        }
    }
}
