---
uid: CommunicationGateway_2.0.2
---

# Communication Gateway 2.0.2

## Changes

### Enhancements

#### Improved exception handling for outgoing gRPC service calls [ID_38071]

In some scenarios it could happen that an exception which was being thrown as a result of the outgoing gRPC service call would be swallowed. This had as consequence that no response would be generated for the middleware so it had to unnecessarily wait for the configured timeout time to elapse.

#### gRPC service calls would wait forever for a response and hold resources because of that [ID_38139]

When a request is sent out to a gRPC service, Communication Gateway would wait forever for a response. However, for various reasons, the gRPC service could never send out a response. A timeout time of five seconds has been introduced to be protected against those scenarios. After the timeout time elapses, a response with status code `DEADLINE_EXCEEDED` will be returned to the middleware. That response can be used to trigger whatever is necessary (e.g. set element into timeout, trigger a reconnect, ...).
