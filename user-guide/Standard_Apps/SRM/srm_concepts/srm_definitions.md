---
uid: srm_definitions
---

# SRM definitions

This section explains the definitions used in the SRM framework.

## Connector

A DataMiner connector (also known as a "protocol" or "driver") is an **XML file that allows the DataMiner System to communicate with a data source**.

> [!TIP]
> For more information, see [About DataMiner connectors](xref:Introduction) (in the development documentation) and [Protocols](xref:Protocols1) in the user guide.

## Virtual function

As a single device can provide multiple functions at the same time, it is important to approach a platform from a function perspective rather than a device perspective. This means that all supported functions that a specific data source can expose should be defined. In the context of DataMiner Service and Resource Management, this means that the functions linked to a connector should all be defined, so that it is clear which types of functions are exposed by a specific device. For example, a cloud-based server provides multiple encoding and decoding functions. Although the server could potentially be used for any function, for SRM orchestration, the functions that are exposed must be clearly defined.

A virtual function is a definition. It is not yet an actual resource. A virtual function only **describes the functions a specific connector can expose and the parameters related to this**.

Virtual functions also have **interfaces** defined (called "function interfaces"), which will be of a specific type. A virtual function of type "Encapsulating" could for example have a function interface "SDI" on the input and a function interface "IP" on the output. This will make sure that you can only connect functions that can be interconnected. These function interfaces can also contain specific information. For example, an IP interface could typically have a multicast IP address.

Virtual functions are **defined in XML**. This works in a very similar way as the way the definition for DVEs ([Dynamic Virtual Elements](xref:Dynamic_virtual_elements)) is defined in a connector. However, an important difference with DVEs is the fact that the definition of the virtual function is not defined within the connector itself but in a separate file linked to the connector. This provides more flexibility in case different virtual functions need to be supported. Each virtual function corresponds with an XML section describing one specific function of a connector. The virtual function definition groups all KPIs related to a specific function and its function interfaces.

In practice, this means that a connector file (protocol.xml) will be accompanied by a virtual functions file (functions.xml), which defines all virtual functions the connector can expose.

## Profile parameter

A profile parameter is a **generic definition of a parameter** that is used in SRM orchestration.

For example, a "bit rate" parameter can be defined slightly differently in different connectors (e.g. different naming, units, etc.) If a profile parameter "bit rate" is created, a Profile-Load Script can provide the mapping and translation between the generic "bit rate" profile parameter and the corresponding parameter of the connector.

Different types of profile parameters exist:

- **Configuration**: A parameter that will be used to orchestrate. For example, L-band frequency on a demodulating function.

- **Monitoring**: A parameter that will be used to monitor. For example, SNR measured on a demodulating function.

- **Capacity**: A parameter that will be used to request a specific capacity of a resource. For example, bit rate on a router interface.

- **Capability**: A parameter that will be used to request a specific capability of a resource. For example, HD and UHD for an encoding function.

## Profile definition

A profile definition is a **group of profile parameters that are needed to orchestrate and manage a virtual function**. As a result, a virtual function is also linked to a profile definition. For example, a profile definition "Encoding" could group all profile parameters needed to orchestrate and manage an "Encoding" virtual function.

A profile definition can be created for a virtual function, but also for the interfaces that a virtual function contains. A profile definition contains the profile parameters for the virtual function or for the function interface that it is connected to.

A single profile definition will not contain the parameters for both the virtual function and all its interfaces, as this would make it less modular. Typically, profile definitions that are created for function interfaces are re-used for the interfaces of other virtual functions. For example, the IP output on the encoding function will typically be linked to the same IP input interface of the decoding function.

Another example of a profile definition could be a profile definition "IP Interface", which groups all profile parameters that are required to orchestrate and manage an IP interface of a virtual function.

## Service definition

Service definitions are only used in the context of Service Orchestration.

In essence, a service definition is a **definition of multiple virtual functions connected together through their interfaces**. It describes the various functions used to deliver a specific service (e.g. a video or data service) and how each function is connected. For example, a service definition could define how an "encoding" virtual function is linked to a "decoding" virtual function.

A service definition is a key component in the management and orchestration of services. In addition to the definition of connecting virtual functions, it contains information needed to correctly manage booking creation and orchestration. When a booking is created, this typically involves the selection of a specific service definition and of profile instances for each of the virtual functions included in that service definition. Resources can then be selected manually or automatically. The service definition itself does not contain any resource or profile configuration.

## Service profile definition

Service profile definitions are only used in the context of Service Orchestration.

A service profile definition is a **subset of the virtual function configuration of one or multiple similar service definitions**. It is used to **predefine and combine the minimum configuration** required to spin up a service.

This is an optional feature that is used to ease the creation of a booking. When users create a booking using a service profile definition, they will not need to select as many things.
