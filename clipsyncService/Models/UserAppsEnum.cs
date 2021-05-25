using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAppsService.Interfaces;

namespace clipsyncService.Models
{
    public class UserAppsEnum : IEnumerator
    {
        public IApp[] _apps;

        private int _position = -1;

        public UserAppsEnum(IApp[] list)
        {
            _apps = list;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _apps.Length);
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return _apps[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    }
}
