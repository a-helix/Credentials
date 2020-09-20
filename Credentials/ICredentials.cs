using System;
using System.Collections.Generic;
using System.Text;

namespace Credentials
{
    interface ICredentials
    {
        string getPort();
        string getHost();
        string getDescription();
    }
}
