using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alice.Shared.DTOs;

public class PaginationDTO
{
    public int Id { get; set; }
    public int Page { get; set; } = 1;
    public int RecordsPerPage { get; set; } = 10;
}