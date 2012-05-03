using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.DomainEntity
{
    public class Episode
    {
        public string Title { get; set; }
        public DateTime Duration { get; set; }
        public string StoryLine { get; set; }
        public int Class { get; set; }
    }
}
