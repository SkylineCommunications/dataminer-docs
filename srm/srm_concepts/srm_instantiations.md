---
uid: srm_instantiations
---

# SRM instantiations

This section explains the instantiations in the SRM framework, which are actual objects created based on SRM definitions.

## Element

A DataMiner element represents a data source that is monitored by the DataMiner System. An element uses a connector to retrieve information from the data source. Typically, an element is linked to a single physical device or platform.

While a connector defines how to communicate with a data source and which information should be retrieved from the data source, an element using a connector actually retrieves the information. Usually, an element is created for each data source.

For example, an element could be created to represent a cloud-based server. The element will show all KPIs retrieved from that server.

> [!TIP]
> See also: [About elements](xref:About_elements)

## Virtual function resource

While a virtual function is a definition, a virtual function resource is the corresponding actual virtual function instance exposed by the platform. Consequently, this object is also known as a "virtual function instance". For example, a cloud-based platform could expose 4 encoding instances and 4 decoding instances. Each encoding instance is an instance of the virtual function "encoding".

Both the terms "virtual function resource" and "virtual function instance" are used in the SRM framework, but these mean exactly the same thing. In the example above, the 4 encoding virtual function instances exposed by the platform are represented as 4 different resources, each based on the same virtual function. These resources are managed by DataMiner Resource Manager.

The technique used by the SRM framework is very similar to the technique used to generate [Dynamic Virtual Elements](xref:Dynamic_virtual_elements) (DVEs). A virtual function is created based on a main element and only visualizes a selection of metrics of that main element, i.e. the metrics that are relevant for that particular virtual function. The main difference with DVEs is that the definition for virtual functions is not coded into the connector itself but defined in a separate *functions.xml* file.

As a resource represents a specific virtual function, and the virtual function links to a profile definition grouping multiple profile parameters, resources can expose capacities and capabilities listed in that linked profile definition. For example, if an encoding instance is only capable of providing SD encoding, when a resource with HD capability is requested, this encoding instance will not be a candidate.

By default, a virtual function resource is represented as a virtual element while the booking using that resource is active.
