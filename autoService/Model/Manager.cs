using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoService
{
    public partial class Manager
    {
        public string FullName {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }
    }
}
