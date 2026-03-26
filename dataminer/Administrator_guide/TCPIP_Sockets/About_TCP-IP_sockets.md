---
uid: About_TCP-IP_sockets
---

# About TCP-IP sockets

A DataMiner Agent can be configured to forward information to third-party applications via TCP/IP sockets.

### Forwarding of alarm events (unsolicited)

Typically, alarm events are forwarded to third-party applications using SNMP notifications, which are sent via UDP. UDP, however, is a connectionless messaging protocol. This means that, if no precautions are taken, alarm information can get lost due to, for example, network interruptions.

So, if you wish to opt for a (safer) alternative to SNMP notification forwarding, DataMiner Agents can be configured to forward alarm events to third-party applications via TCP/IP socket messages.

### Forwarding of information about elements and parameters (upon request)

In addition to unsolicited alarm forwarding, a DataMiner Agent can also be configured to forward information about elements and parameters to third-party applications upon receiving a request to do so.
