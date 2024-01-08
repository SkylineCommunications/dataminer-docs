---
uid: CommunicationGateway_2.0.2
---

# Communication Gateway 2.0.2

## Changes

### Fixes

#### Insufficient exception handling for outgoing gRPC service calls [ID_38071]

In some scenarios, it could happen that an exception that was thrown as a result of an outgoing gRPC service call was not processed. Because of this, no response was generated for the middleware, so it had to needlessly wait for the configured timeout time to elapse. Exception handling has now been improved so that every exception will always generate a response for the middleware.

#### gRPC service calls waiting indefinitely for response and holding resources as a consequence [ID_38139]

When a request was sent out to a gRPC service, Communication Gateway would keep waiting indefinitely for a response. However, for various reasons, it could occur that the gRPC service never sent a response.

A timeout time of five seconds has now been introduced as a protection against such scenarios. When the timeout time elapses, a response with status code `DEADLINE_EXCEEDED` will be returned to the middleware. That response can be used to trigger whatever is necessary (e.g. set element into timeout, reconnect, etc.).
