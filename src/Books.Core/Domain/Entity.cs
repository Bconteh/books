using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
    
}
