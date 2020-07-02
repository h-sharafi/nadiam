using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mohammadi.Controllers.sa
{
    [Authorize]
    public class ManageController : Controller
    { }
}