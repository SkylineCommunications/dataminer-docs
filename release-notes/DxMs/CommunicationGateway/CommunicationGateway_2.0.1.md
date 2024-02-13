---
uid: CommunicationGateway_2.0.1
---

# Communication Gateway 2.0.1

## Fixes

#### Communication Gateway tried to read response stream indefinitely when exception occurred [ID_37893]

When a subscription is created and an exception other than an RPC exception occurs with status code Unavailable, Communication Gateway tries to set up the connection with the gRPC service again, to send out the request, and to read the response stream.

However in case another exception occurred, Communication Gateway did not try to set up the connection again but just read out the stream, which would immediately fail again. This resulted in the service trying to read out the response stream over and over again, causing a high CPU load until the connector removed the subscription.

To resolve this, when an exception occurs that is not likely to be resolved with a reconnect, Communication Gateway will no longer attempt to retry. It will be up to the connector to decide when to recreate the subscription.
