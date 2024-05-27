﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoDomain.Models
{
    public class ITENS_NOTA
    {
        public int ITEM_NUM { get; set; }
        public int ID_PRO { get; set; }
        public int ID_NOTA { get; set; }
        public int ID_SEC { get; set; }
        public double? QTD_PRO { get; set; }
        public double? PRE_UNIT { get; set; }
        public double? TOTAL_ITEM { get; set; }
        public double? EST_LIN { get; set; }

    }
}
