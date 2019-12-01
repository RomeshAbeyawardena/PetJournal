using PetJournal.Domains;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetJournal.Contracts
{
    public interface IEntityChangedEvent<TEntity> : IEvent<TEntity>
        where TEntity : class
    {
        ChangedEventType Event { get; }
    }
}
