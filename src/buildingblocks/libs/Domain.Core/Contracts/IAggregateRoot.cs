using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Contracts
{
  public interface IAggregateRoot
  {
    List<INotification> DomainEvents { get; }
    void AddDomainEvent(INotification eventItem);

    void RemoveDomainEvent(INotification eventItem);

    void ClearDomainEvents();
  }
}
