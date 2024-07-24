---
uid: Usage2
---

# Usage

#### Device representation

A device is represented using the Node and the Parameter type. Each node may have any number of child nodes and parameters, while a parameter may not have child nodes or parameters.

#### Querying data provider

To query a data provider, a GetDirectory command can be issued. You can do so by appending the GetDirectory command to the node you want to get the children from. The data provider then responds with the same structure, but appends the child nodes and parameters (if any).

#### Updating a parameter

To update a parameter, the consumer must transmit the structure containing the parameter that should be changed, specifying the value to set the parameter to. Upon receiving the value change request, the data provider evaluates the new value. If valid, the provider applies the requested change and responds with the new value. If invalid, the provider discards the request and responds with the current value.

#### Keep-Alive

A basic Keep-Alive mechanism can be implemented by using the S101 commands "Keep-Alive Request" and "Keep-Alive Response".
