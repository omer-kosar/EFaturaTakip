using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Exceptions.User;

namespace EFaturaTakip.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDao _userDao;

        public UserManager(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void Create(User entity)
        {
            bool isExistUser = IsExistUser(entity.Email, entity.Phone);
            if (isExistUser)
                throw new UserExistException("Bu telefon numarası veya EMail ile kullanıcı kayıtlıdır.");
            _userDao.Create(entity);
        }

        public void Delete(User entity)
        {
            _userDao.Delete(entity);
        }

        public bool IsExistUser(string email, string phone)
        {
            return _userDao.FindByCondition(i => i.Email.ToLower().Equals(email.ToLower()) || i.Phone.Equals(phone)) != null;
        }

        public void Update(User entity)
        {
            _userDao.Update(entity);
        }
    }
}
