﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Model;

public class GetAllModelResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? BrandId { get; set; }
    public string? BrandName { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

}
