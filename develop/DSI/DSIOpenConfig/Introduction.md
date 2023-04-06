---
uid: DSI_OpenConfig_Introduction
---

# OpenConfig

OpenConfig is an informal working group with members such as Google, Microsoft, AT&T, and British Telecom.

An important aspect of the OpenConfig initiative is the creation of a set of vendor-neutral [data models](#data-models). These data models are designed to take actual operator requirements and needs into account.

In addition to data models, OpenConfig also defines communication protocols such as [gNMI](#gnmi) and [gNOI](#gnoi).

> [!TIP]
> Useful links:
>
> - The official OpenConfig website: [openconfig.net](https://www.openconfig.net/)
> - The OpenConfig GitHub page: [github.com/openconfig](https://github.com/openconfig)
>
> Related articles on DataMiner Dojo:
>
> - Blog: [Simplify Network Operations With Streaming Telemetry Data](https://community.dataminer.services/blog/)
> - Example use case: [OpenConfig](https://community.dataminer.services/use-case/openconfig/)

> [!NOTE]
> To get started with OpenConfig, you should be aware that not all devices with telemetry actually support OpenConfig, or more specifically, gNMI. They may use different gRPC services, which will be defined by one or more .proto files. With this in mind, we recommend that you read the sections below before heading over to the [middleware page](xref:DSI_OpenConfig_Middleware) and implementing a client.

## Data models

### Definitions

OpenConfig data models are defined using YANG, a data modeling language that originates from NETCONF, developed by the [NETMOD](https://datatracker.ietf.org/wg/netmod/about/) (IETF) working group.

- [RFC 6020](https://tools.ietf.org/html/rfc6020) YANG - A Data Modeling Language for the Network Configuration Protocol (NETCONF)
- [RFC 7950](https://tools.ietf.org/html/rfc7950) The YANG 1.1 Data Modeling Language

YANG is a rich modeling language that supports concepts such as containers, lists, leaves, custom types, etc. You can think of a YANG model as a tree structure where each node or leaf in the tree has a specific path.

OpenConfig publishes the data models they create in [the OpenConfig GitHub repository](https://github.com/openconfig/public/tree/master/release). There are OpenConfig YANG data models for [interfaces](https://github.com/openconfig/public/blob/master/release/models/interfaces/openconfig-interfaces.yang), [ospf](https://github.com/openconfig/public/tree/master/release/models/ospf), etc.

To browse and search YANG models, [yangcatalog.org](https://yangcatalog.org/) is a useful site. For example, [this link](https://yangcatalog.org/yang-search/yang_tree/openconfig-interfaces@2019-11-19#.) gives an overview of the OpenConfig interfaces YANG data model (click *Expand all* to expand all nodes).

![YANG Tree for Module: 'openconfig-interfaces@2019-11-19'](~/develop/images/DSI_OpenConfig_experthub.png)

Alternatively, tools such as Pyang can be used to visualize or validate YANG models. Below is a visual representation of the OpenConfig interfaces YANG data model using Pyang.

```yang
+--rw interfaces
 +--rw interface* [name]
    +--rw name             -> ../config/name
    +--rw config
    |  +--rw name?            string
    |  +--rw type             identityref
    |  +--rw mtu?             uint16
    |  +--rw loopback-mode?   boolean
    |  +--rw description?     string
    |  +--rw enabled?         boolean
    +--ro state
    |  +--ro name?            string
    |  +--ro type             identityref
    |  +--ro mtu?             uint16
    |  +--ro loopback-mode?   boolean
    |  +--ro description?     string
    |  +--ro enabled?         boolean
    |  +--ro ifindex?         uint32
    |  +--ro admin-status     enumeration
    |  +--ro oper-status      enumeration
    |  +--ro last-change?     oc-types:timeticks64
    |  +--ro logical?         boolean
    |  +--ro counters
    |     +--ro in-octets?             oc-yang:counter64
    |     +--ro in-pkts?               oc-yang:counter64
    |     +--ro in-unicast-pkts?       oc-yang:counter64
    |     +--ro in-broadcast-pkts?     oc-yang:counter64
    |     +--ro in-multicast-pkts?     oc-yang:counter64
    |     +--ro in-discards?           oc-yang:counter64
    |     +--ro in-errors?             oc-yang:counter64
    |     +--ro in-unknown-protos?     oc-yang:counter64
    |     +--ro in-fcs-errors?         oc-yang:counter64
    |     +--ro out-octets?            oc-yang:counter64
    |     +--ro out-pkts?              oc-yang:counter64
    |     +--ro out-unicast-pkts?      oc-yang:counter64
    |     +--ro out-broadcast-pkts?    oc-yang:counter64
    |     +--ro out-multicast-pkts?    oc-yang:counter64
    |     +--ro out-discards?          oc-yang:counter64
    |     +--ro out-errors?            oc-yang:counter64
    |     +--ro carrier-transitions?   oc-yang:counter64
    |     +--ro last-clear?            oc-types:timeticks64
    +--rw hold-time
    |  +--rw config
    |  |  +--rw up?     uint32
    |  |  +--rw down?   uint32
    |  +--ro state
    |     +--ro up?     uint32
    |     +--ro down?   uint32
    +--rw subinterfaces
       +--rw subinterface* [index]
          +--rw index     -> ../config/index
          +--rw config
          |  +--rw index?         uint32
          |  +--rw description?   string
          |  +--rw enabled?       boolean
          +--ro state
             +--ro index?          uint32
             +--ro description?    string
             +--ro enabled?        boolean
             +--ro name?           string
             +--ro ifindex?        uint32
             +--ro admin-status    enumeration
             +--ro oper-status     enumeration
             +--ro last-change?    oc-types:timeticks64
             +--ro logical?        boolean
             +--ro counters
                +--ro in-octets?             oc-yang:counter64
                +--ro in-pkts?               oc-yang:counter64
                +--ro in-unicast-pkts?       oc-yang:counter64
                +--ro in-broadcast-pkts?     oc-yang:counter64
                +--ro in-multicast-pkts?     oc-yang:counter64
                +--ro in-discards?           oc-yang:counter64
                +--ro in-errors?             oc-yang:counter64
                +--ro in-unknown-protos?     oc-yang:counter64
                +--ro in-fcs-errors?         oc-yang:counter64
                +--ro out-octets?            oc-yang:counter64
                +--ro out-pkts?              oc-yang:counter64
                +--ro out-unicast-pkts?      oc-yang:counter64
                +--ro out-broadcast-pkts?    oc-yang:counter64
                +--ro out-multicast-pkts?    oc-yang:counter64
                +--ro out-discards?          oc-yang:counter64
                +--ro out-errors?            oc-yang:counter64
                +--ro carrier-transitions?   oc-yang:counter64
                +--ro last-clear?            oc-types:timeticks64
```

### Deviations

YANG provides ways to augment, extend, and define deviations from other YANG models. As it is possible that an implementor does not support everything defined in an OpenConfig YANG model, implementors can provide additional YANG models describing any deviations.

For example, for the CISCO NX-OS 9.3(5), [multiple deviations are defined](https://github.com/YangModels/yang/tree/master/vendor/cisco/nx/9.3-5). The  Cisco-nx-OpenConfig interfaces deviations model states that the */oc-if:interfaces/oc-if:interface/oc-if:state/oc-if:counters/oc-if:carrier-transitions* node is not supported. Similarly, Arista defines some deviations from the OpenConfig data models. For example, for Arista EOS, [the following model](https://github.com/aristanetworks/yang/blob/master/EOS-4.20.10M/release/openconfig/models/interfaces/arista-intf-deviations.yang) indicates that the */oc-if:interfaces/oc-if:interface/oc-if:state/oc-if:counters/oc-if:last-clear* is not supported.

## Services and remote procedure calls

In addition to defining vendor-neutral data models, OpenConfig also defines a communication protocol defined as gRPC services.

gRPC, which stands for “gRPC Remote Procedure Call”, is a remote procedure call framework defined by Google. A gRPC service can define unary RPCs, server or client streaming RPCs, and bidirectional streaming RPCs.

gRPC services use [protocol buffers](https://developers.google.com/protocol-buffers/docs/overview) (which are also created by Google) as the interface description language (IDL). Protocol buffers are a language- and platform-neutral and extensible way of serializing structured data for use in communication protocols or data storage. The official website is [grpc.io](https://grpc.io/).

### gNxI

[gNMI](#gnmi) and [gNOI](#gnoi) are collectively referred to as gNxI.

### gNMI

gNMI is a gRPC service defined by OpenConfig. "gNMI" stands for “gRPC Network Management Interface”. The proto file defining the gNMI service can be found on the [OpenConfig GitHub page](https://github.com/openconfig/gnmi/blob/master/proto/gnmi/gnmi.proto). The full specification is available in the [gnmi-specification.md](https://github.com/openconfig/reference/blob/master/rpc/gnmi/gnmi-specification.md).

The gNMI RPC service provides the following four RPCs:

- **[Capabilities](#capabilities)**: Allows a client to obtain the capabilities that are supported by the target (service version, supported models, and supported encodings).
- **[Get](#get)**: Allows the retrieval of a snapshot of data from the target.
- **[Set](#set)**: Modifies the state of data on the target.
- **[Subscribe](#subscribe)**: Allows a client to subscribe.

#### Capabilities

This RPC can be used by clients to obtain more information from a target about its capabilities. The capabilities comprise:

- The version of the gNMI protocol (e.g. 0.7.0).
- The supported encodings (e.g. Json, Proto).
- The supported data models: A list of all the supported models. Each entry defines the name of the model, the version of the model, and the organization that published the model.

> [!NOTE]
> The list of supported models is not restricted to OpenConfig models. For example, implementors typically also define their own proprietary YANG models.

#### Get

The Get RPC can be used by clients to obtain a snapshot of the requested data (the data requested is provided as a number of paths from the data model tree).

Note that a Get RPC should only be used to obtain small amounts of data from the target. To request larger data sets, using a subscription is recommended.

#### Set

The Set RPC can be used to modify the state of a target. A set request supports the deletion, replacement, and updating of items. All changes that are defined in a set request are considered as one transaction.

#### Subscribe

The Subscribe RPC allows a client to create subscriptions. gNMI supports three different subscription modes:

- **ONCE**: Acts as a single request/response channel. The client sends a subscribe request, which gets processed by the target. The target then responds with a series of update messages and finally closes the RPC.

- **POLL**: This is a long-lasting RPC that can be used for on-demand data retrieval. The target sends a subscribe request indicating the paths it wishes to subscribe to. Every time the client wishes to poll these paths, it sends an additional poll message via this long-lasting RPC. Upon receiving such a poll request, the target then generates update messages accordingly.

- **STREAM**: This is a long-lasting RPC, where the target sends updates for the subscribed paths according to the specified mode. Three modes are supported with a STREAM subscription:

  - **On change**: Data updates are sent when the value of the data item changes.

  - **Sampled**: Data updates are sent by the target once per sample interval (as specified by the subscription made by the client).

  - **Target defined**: The client specifies that it is up to the target to decide whether an on-change or sampled subscription mechanism is used.

gNMI allows dial-in streaming telemetry. First, the client connects with the target and subscribes to specific paths. Then the target continuously sends updates according to the selected subscription method until the RPC is closed by the client.

> [!NOTE]
>
> - Implementors can put limits on the number of RPCs that can exist simultaneously.
> - Implementors do not always support all types of subscriptions on all paths. For example, CISCO NX-OS 9.3(5) currently does not support on-change stream subscriptions on octet counters (e.g. in-octets, out-octets) defined in the OpenConfig interfaces YANG model.
> - When using long-lasting RPCs, it is possible that you will need to configure keep-alive settings to avoid the RPCs being closed by the target. You can find more information in [keepalive.md](https://github.com/grpc/grpc/blob/master/doc/keepalive.md).

> [!TIP]
> For additional information about gNMI, go to [gnmi-specification.md](https://github.com/openconfig/reference/blob/master/rpc/gnmi/gnmi-specification.md).

### gNOI

gNOI is another gRPC service defined by OpenConfig. "gNOI" stands for “gRPC Network Operator Interface”.

You can find more information related to gNOI in the [gNOI repository](https://github.com/openconfig/gnoi).
