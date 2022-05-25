using EFaturaTakip.Business.Abstract;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Exceptions.User;
using System.Linq.Expressions;

namespace EFaturaTakip.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDao _userDao;

        public UserManager(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void Create(User user)
        {
            user.Id = Guid.NewGuid();
            bool isExistUser = IsExistUser(user.Email, user.Phone);
            if (isExistUser)
                throw new UserExistException("Bu telefon numarası veya EMail ile kullanıcı kayıtlıdır.");
            _userDao.Create(user);
        }
        public void Delete(User entity)
        {
            _userDao.Delete(entity);
        }

        public User GetUser(Expression<Func<User, bool>> filter)
        {
            return _userDao.GetUser(filter);
        }

        public bool IsExistUser(string email, string phone)
        {
            return _userDao.FindByCondition(i => i.Email.ToLower().Equals(email.ToLower()) || i.Phone.Equals(phone)).Any();
        }

        public void Update(User entity)
        {
            _userDao.Update(entity);
        }
    }
}
