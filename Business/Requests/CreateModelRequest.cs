using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests;

public class CreateModelRequest
{
    public string Name { get; set; }
    public int BrandId { get; set; }
}
