using System;
using System.Collections.Generic;

#nullable disable

namespace data.models
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            Units = new HashSet<Unit>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
