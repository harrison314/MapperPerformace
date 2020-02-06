using System;
using System.Collections.Generic;

namespace MapperPerformace.Dal
{
    public partial class LocalEvent
    {
        public int LocalEventId { get; set; }
        public int? Id { get; set; }
        public string PersonalId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int? Complexity { get; set; }
        public string Description { get; set; }
        public Guid? Hdata { get; set; }
    }
}
