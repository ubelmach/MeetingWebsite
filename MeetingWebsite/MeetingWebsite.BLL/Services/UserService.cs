using MeetingWebsite.DAL.Interfaces;

namespace MeetingWebsite.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }
        private readonly IAccountService _accountService;
        public UserService(IUnitOfWork uow,
            IAccountService accountService)
        {
            Database = uow;
            _accountService = accountService;
        }
    }
}