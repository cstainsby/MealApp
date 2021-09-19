using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIClientManager
{
    interface ProcessorInterface
    {
        public Task GetByIdAsync(int Id = 0);


    }
}
