---
uid: DMA_client_and_inter_DMA_communication
description: "Review DMA-client and inter-DMA communication, and learn about the differences between gRPC or .NET Remoting."
---

# DMA-client and inter-DMA communication

## DMA-client communication

From DataMiner 10.5.10/10.6.0 onwards, Cube uses gRPC by default to communicate with DataMiner. Prior to this, .NET Remoting is used by default, but gRPC can be enabled manually.

> [!TIP]
>
> - For details on when which type of communication is enabled and on how you can harden security, refer to [Secure Cube-server communication](xref:DataMiner_hardening_guide#secure-cube-server-communication).
> - For details on client communication settings, refer to [DMA configuration related to client applications](xref:DMA_configuration_related_to_client_applications).

## Inter-DMA communication

From DataMiner 10.5.10/10.6.0 onwards, gRPC is used by default for communication between DataMiner Agents. Prior to this, .NET Remoting is used by default, but gRPC can be enabled manually.

> [!TIP]
> For details on when which type of communication is enabled and on how you can harden security, refer to [Secure server-server communication](xref:DataMiner_hardening_guide#secure-server-server-communication).

## gRPC vs. .NET Remoting

Aside from the security differences, for which you can find details in the [DataMiner hardening guide](xref:DataMiner_hardening_guide#dataminer-agent-hardening), these are the main differences between gRPC and .NET Remoting:

![Schematic overview of the differences between .NET Remoting and gRPC communication](~/dataminer/images/gRPCvsdotnetRemoting.png)

- **.NET Remoting** with **eventing** can deliver subscription messages instantly, but requires setting up a TCP connection from DMA to client, which is often not possible because of firewalls or NAT.

- **.NET Remoting** with **polling** uses "short polling", where the waiting happens on the client side, and the server answers immediately (either with some messages that were waiting to be delivered, or with an empty response). By default, a slow polling cycle of 1000 ms is used, along with a fast polling cycle of 100 ms if the previous cycle received messages.

- With **gRPC streaming**, the client performs a single HTTP request with an infinite response: the server uses "Transfer-Encoding: chunking" and delivers messages as soon as they occur, each in another chunk. However, this may not always work if there is a (reverse) proxy, gateway, or deep-packet-inspecting firewall in between. These may either transform the random chunk sizes into fixed-length chunks, or buffer the chunking to try and convert it into a Content-Length response, or they may cause requests that take longer than a specific number of seconds to be aborted. DataMiner has detection mechanisms for this, and if chunking is not working as expected, it falls back to polling.

- **gRPC** with **polling** uses "long polling", where the waiting happens on the server side. The client has an infinite loop of HTTP requests, and the server will wait up to 20 seconds until it has messages ready to be delivered. This has the advantage that no extra delay is introduced like with "short polling" and that it does not rely on special HTTP features such as chunking or infinite responses. All subscription requests are typically pipelined on the same TCP connection, though this depends on the .NET HTTP connection pooling logic. This type of polling is also used for [Cube remote access](xref:About_Remote_Access).
