﻿using CahanMotors.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.Areas.Admin.Models
{
    public class UserRoleAssignAjaxViewModel
    {
        public UserRoleAssignDto UserRoleAssignDto { get; set; }
        public UserDto UserDto { get; set; }
        public string RoleAssignPartial { get; set; }
    }
}
