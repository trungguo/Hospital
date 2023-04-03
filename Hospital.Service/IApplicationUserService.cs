using Hospital.Utilities;
using Hospital.ViewModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int pageNumber,int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllPatient(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string Spicility=null);

    }
}
