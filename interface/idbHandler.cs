using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
    interface idbHandler
    {
        void read();
        void insert(user one);
        void delete(user one);
        void deleteAll();
        void update(user one);
    }
}
