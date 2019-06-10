using System.Collections.Generic;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class PurposeService : IPurposeService
    {
        private IUnitOfWork _database;

        public PurposeService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<PurposeOfDating> GetAll()
        {
            return _database.PurposeRepository.GetAll();
        }

        public void Update(UserPurpose item)
        {
            _database.PurposeRepository.Update(item);
        }


    }
}