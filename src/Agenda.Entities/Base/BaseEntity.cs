﻿using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Entities.Base
{
    public interface IDomainEvent : INotification { }

    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid CreateUserId { get; set; }
        public Guid? UpdateUserId { get; set; }

        [NotMapped]
        public List<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            var compareTo = obj as BaseEntity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public void QueueDomainEvent(IDomainEvent @event)
        {
            DomainEvents.Add(@event);
        }
    }
}
