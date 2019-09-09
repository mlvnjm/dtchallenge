using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DealerTrack.Models
{
    interface IFileManager
    {
        List<Deal> ParseFileData(IFormFile file);
    }
}
