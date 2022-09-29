using EFaturaTakip.Business.Abstract;
using EFaturaTakip.Common.Enums;
using EFaturaTakip.DataAccess.Abstract;
using EFaturaTakip.Entities;
using EFaturaTakip.Exceptions.Company;
using EFaturaTakip.Exceptions.User;
using System.Linq.Expressions;

namespace EFaturaTakip.Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDao _userDao;
        private readonly IUserRoleDao _userRoleDao;
        private readonly ICompanyDao _companyDao;
        public UserManager(IUserDao userDao, IUserRoleDao userRoleDao, ICompanyDao companyDao)
        {
            _userDao = userDao;
            _userRoleDao = userRoleDao;
            _companyDao = companyDao;
        }

        public void Create(User user)
        {
            user.Id = Guid.NewGuid();
            bool isExistUser = IsExistUser(user.Email, user.Phone);
            if (isExistUser)
                throw new UserExistException("Bu telefon numarası veya EMail ile kullanıcı kayıtlıdır.");
            _userDao.Create(user);
            Save();
        }
        public void Delete(User entity)
        {
            _userDao.Delete(entity);
            Save();
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
            Save();
        }
        public void UpdateWithRoles(User entity, List<Guid> roles)
        {
            var recordedRoles = _userDao.GetUserRoles(entity.Id);
            var deletedRoles = recordedRoles.Where(i => !roles.Contains(i.RoleId)).ToList();
            var addedRoles = roles.Where(i => !recordedRoles.Select(r => r.RoleId).Contains(i)).Select(i => new UserRole { RoleId = i, UserId = entity.Id }).ToList();
            _userRoleDao.Delete(deletedRoles);
            entity.Roles = addedRoles;
            _userDao.Update(entity);
            Save();
        }
        public List<User> SearchFinancialAdvisor(string name, int take = 20)
        {
            if (string.IsNullOrWhiteSpace(name)) return _userDao.FindByConditionFinincialAdvisor(i => i.Type == (int)EnumUserType.Accountant).Take(take).ToList();
            return _userDao.FindByConditionFinincialAdvisor(i => i.Type == (int)EnumUserType.Accountant && (i.FirstName.Contains(name) || i.LastName.Contains(name))).Take(take).ToList();
        }
        public List<User> GetAll()
        {
            return _userDao.GetAllUserWithRoles();
        }
        private void Save()
        {
            _userDao.Save();
        }
    }
}
