using System.Collections.Generic;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.Services
{
    public class ZodiacSignsService : IZodiacSignsService
    {
        private IUnitOfWork _database;

        public ZodiacSignsService(IUnitOfWork database)
        {
            _database = database;
        }

        public IEnumerable<ZodiacSigns> GetAll()
        {
            return _database.ZodiacSignsRepository.GetAll();
        }
    }
}