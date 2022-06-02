using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPPatioAsociado.Models
{
    public interface IAppVersion
    {

        string GetVersion();
        int GetBuild();

    }
}
