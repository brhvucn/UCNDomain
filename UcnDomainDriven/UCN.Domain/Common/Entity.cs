using System;
using System.Collections.Generic;
using System.Text;

namespace UCN.Domain.Common
{
    /// <summary>
    /// A generic entity that specifies how the key for an entity looks. This might be Guid or it might be an int
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
