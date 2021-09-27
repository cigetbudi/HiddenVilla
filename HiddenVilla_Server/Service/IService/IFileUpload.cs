using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiddenVilla_Server.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UnggahFile(IBrowserFile file);
        bool HapusFile(string fileName);
    }
}
