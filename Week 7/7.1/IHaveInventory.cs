﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    public interface IHaveInventory
    {
        public GameObject Locate(string id);
        string Name { get; }
    }
}
