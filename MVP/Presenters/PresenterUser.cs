using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
using Service;
using Service.Responses;
using Service.Requests;
using MVP.Views;
namespace MVP.Presenters
{
    public class PresenterUser
    {

        private IUserListView _view;
        private UserService userService;
        public PresenterUser(IUserRepository iuser, IUserListView view )
        {
            userService = new UserService(iuser);
            _view = view;
           
        }

        public void GetUserPresenter()
        {
            UserRequest userRequest  = new UserRequest();
            userRequest.user = _view.user.Username;
            userRequest.password = _view.user.Password;
            UserResponse userResponse = userService.GetUser(userRequest);
            if (userResponse.Success)
            {
                _view.SuccessUser(userResponse.user);
            }
            else
            {
                _view.ErrorUser("mal");
            }

        }

    }
}
