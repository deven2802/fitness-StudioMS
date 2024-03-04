using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessStudioMobileApp.Services
{
    public interface IFirebaseDatabase
    {
        Task<string> GetDataAsync(string path);
        Task SetDataAsync(string path, string data);



    }


}
