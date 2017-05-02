using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace MVP.Views
{
    public interface IUserListView
    {
        User user { get; }
        void SuccessUser(User  gUser);
        void ErrorUser(string error);

    }
}
