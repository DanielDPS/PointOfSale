using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using Service.Requests;
using Service.Responses;
namespace Service
{
    public class UserService
    {

        IUserRepository IuserRepository;
        public UserService(IUserRepository IUR)
        {
            IuserRepository = IUR;
        }

        public UserResponse GetUser(UserRequest userRequest)
        {

            UserResponse userResponse = new UserResponse();
            try
            {
                User puser = IuserRepository.GetUserByUserPassword(userRequest.user, userRequest.password);
                if (puser.Username.Equals(userRequest.user) && puser.Password.Equals(userRequest.password))
                {
                    userResponse.user = puser;
                    userResponse.Success = true;
                }
                else
                {
                    userResponse.Success = false;
                }
         
            }
            catch (Exception e)
            {
            }
            return userResponse;
        }
    }
}
