using MediatR;

namespace Sky.Domain.Base
{
    public abstract class Entity
    {
        protected abstract IEnumerable<object> GetIdentityComponents();

        public long? ClientId { get; set; }
        public bool IsRemoved { get; set; } 
        public long? CreateBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Note { get; set; }




        private List<INotification>? domainEvents;
        public IReadOnlyCollection<INotification>? DomainEvents => domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            domainEvents ??= new List<INotification>();
            domainEvents.Add(eventItem);
        }

        public virtual IEnumerable<INotification> GetDomainEventsToBeProducedOnEverySave()
        {
            return new INotification[0];
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (GetUnproxiedType(this) != GetUnproxiedType(obj)) return false;
            var other = obj as Entity;
            return GetIdentityComponents().SequenceEqual(other.GetIdentityComponents());
        }

        public override int GetHashCode()
        {
            var hash = 17;
            foreach (var obj in GetIdentityComponents())
                hash = hash * 23 + (obj != null ? obj.GetHashCode() : 0);
            return hash;
        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null);
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        internal static Type GetUnproxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
                return type.BaseType;

            return type;
        }
    }

}
