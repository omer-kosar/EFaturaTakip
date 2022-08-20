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
        private readonly IUserRoleDao _userRoleDao;
        public UserManager(IUserDao userDao, IUserRoleDao userRoleDao)
        {
            _userDao = userDao;
            _userRoleDao = userRoleDao;
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

        private bool IsExistUser(string email, string phone)
        {
            return _userDao.FindByCondition(i => i.Email.ToLower().Equals(email.ToLower()) || i.Phone.Equals(phone)).Any();
        }

        public void Update(User entity)
        {
            _userDao.Update(entity);
        }
        public void UpdateWithRoles(User entity, List<Guid> roles)
        {
            var recordedRoles = _userDao.GetUserRoles(entity.Id);
            var deletedRoles = recordedRoles.Where(i => !roles.Contains(i.RoleId)).ToList();
            var addedRoles = roles.Where(i => !recordedRoles.Select(r => r.RoleId).Contains(i)).Select(i => new UserRole { RoleId = i, UserId = entity.Id }).ToList();
            _userRoleDao.RemoveRange(deletedRoles);
            entity.Roles = addedRoles;
            _userDao.Update(entity);
        }

        public List<User> GetAll()
        {
            return _userDao.GetAllUserWithRoles();
        }
    }
}
