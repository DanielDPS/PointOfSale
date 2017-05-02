using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class SessionUser
    {
        public User Currentuser { get; set; }
        private static SessionUser _Instance;
        private static  volatile object lock_this = new object();

        private SessionUser()
        {
            Currentuser = new User();
        }

        public static SessionUser Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (lock_this)
                    {
                        _Instance = new SessionUser();
                    }
                }
                return _Instance;

            }
        }
    }
}
