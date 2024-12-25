using MediatR;

namespace Ordering.Domain.Abstractions;


// We want to inherit from INotification interface from the MediatR to perform domain events. Bcoz MediatR provides
// very good interface to implement domain event operations inside of the domain layers.
// for this, we will add Nuget "MediatR" in the domain project.
public interface IDomainEvent : INotification
{
    // "=>" is called expression-bodied members. This is used to define default values direclty for members of an 
    // interface.
    
    Guid EventId => Guid.NewGuid();

    // Another way to write this is
    //Guid EventId{ get { return Guid.NewGuid(); } } // Default implementation
    //It explicitly shows that these are read-only properties with calculated values

    public DateTime OccurredOn => DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName;

}
