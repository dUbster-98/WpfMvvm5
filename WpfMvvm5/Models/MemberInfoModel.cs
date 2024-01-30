﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm5.Models
{
    public class MemberInfoModel
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }

        public DateTime? Birth { get; set; }
        public DateTime? JoinDate { get; set; }

        public string Birth_Str => Birth.HasValue ? Birth.Value.ToString("yyyy-MM-dd") : "-";
        public string JoinDate_Str => JoinDate.HasValue ? JoinDate.Value.ToString("yyyy-MM-dd") : "-";
    }
}
