---
uid: CommunicationGateway_2.0.2
---

# Communication Gateway 2.0.2

## Changes

### Enhancements

#### Improved exception handling for outgoing gRPC service calls [ID_38071]

In some scenarios it could happen that an exception which was being thrown as a result of the outgoing gRPC service call would be swallowed. This had as consequence that no response would be generated for the middleware so it had to unnecessarily wait for the configured timeout time to elapse.
