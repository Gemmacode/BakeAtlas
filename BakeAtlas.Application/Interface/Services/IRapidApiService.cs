using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Services
{
    public interface IRapidApiService
    {
        string GetCakeDataAsync(int id);
    }
}
