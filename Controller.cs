using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOANS_projekt
{
public interface Controller
{
    enum ControllerType
    {
        Battle,
        Marketplace,
        Menu
    }
    void Commence(ControllerType type);
}
}