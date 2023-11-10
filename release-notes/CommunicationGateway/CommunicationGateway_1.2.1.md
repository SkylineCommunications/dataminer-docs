---
uid: CommunicationGateway_1.2.1
---

# Communication Gateway 1.2.1

## Changes

### Fixes

#### CommunicationGateway will no longer trigger ConnectionStateChanged event when no subscriptions are active [ID_37264]

The `ConnectionStateChanged` event triggers when the state of the connection changes. This event is then typically used in a DataMiner Connector to alter the timeout state of the element.

If no subscriptions are active eventually the connection will get closed due to inactivity which will then trigger the event. Because the connection with the gRPC endpoint could still be created after a new service call, it is incorrect and confusing that this would then result into a timeout alarm. Because of this reason, the event will no longer be triggered when there are no subscriptions active.
