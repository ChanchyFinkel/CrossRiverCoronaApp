﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal.Models;

public class User
{
    public int Id { get; set; }
    [EmailAddress]
    public string Name { get; set; }
    [MinLength(8)]
    public string Password { get; set; }
}
