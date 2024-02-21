---
uid: CommunicationGateway_1.2.1
---

# Communication Gateway 1.2.1

## Changes

### Fixes

#### CommunicationGateway will no longer trigger ConnectionStateChanged event when no subscriptions are active [ID_37264]

The `ConnectionStateChanged` event is triggered when the state of the connection changes. This event is then typically used in a DataMiner connector to alter the timeout state of the element.

If no subscriptions were active, eventually the connection was closed because of inactivity, which triggered this event. However, because the connection with the gRPC endpoint could still be created after a new service call, it was incorrect and confusing that this would then result in a timeout alarm. Because of this, this event will no longer be triggered when there are no subscriptions active.
