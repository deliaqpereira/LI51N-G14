using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.DomainEntity
{
    public class Serie
    {
        public ProgItem progItem { get; set; }
        public IEnumerable<Episode> repo {get; set;}
    }
}
