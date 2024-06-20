---
uid: flow_engineering_app
---

# Flow Engineering

Unlike the other components listed on this page, Flow Engineering is not an application that end-users interact with. It's the engine running in the background to successfully execute requests to set up flows in the network between a flow sender and a flow receiver. It's responsible for three things:

* Flow path calculation: Flow Engineering first calculates the path between the source and the destination of the requested flow. For this, it runs a Dijkstra algorithm on the elements in DataMiner and the physical connectivity defined between them (stored in DataMiner's DCF database)
* Flow execution: when the flow path has been calculated, all elements in the path need to be informed of the request to set up the flow. This is done using a standardized message sent to the elements. The connector is then responsible for making sure that the flow is correctly set up on its underlying product.
* Flow documentation: the result of the path calculation is also stored, so it can be used for monitoring and other purposes.

![screenshot](~/user-guide/images/mediaops_fe_overview.png)

## Flow path calculation

The first step in setting up a flow, is calculating a path for it over the network between sender and receiver. Every flow sender and receiver should at least be linked to an element (see also: [Flow senders & receivers](xref:virtual_signal_groups_app#flow-senders--receivers)). Flow engineering will calculate the shortest path of DCF connections between the sender element and the receiver element using the Dijkstra algorithm. If the flow sender and/or receiver are also linked to a specific interface on the element, Flow Engineering will force the path calculation to start/end on that interface. In case there are internal DCF connections between the interfaces of an element, these will also be taken into account when calculating a path. If there are no internal DCF connections on a given interface, Flow Engineering will assume it can be connected with every other interface on that element.

## Flow execution

After the flow path has been calculated, flow engineering will instruct all elements in the flow path to set up the requested flow. This is done by sending a standardized message to all relevant elements containing certain information about the requested flow, such as the incoming interface, outgoing interface and more technology specific information such as an IP address. It is then up to the connector of each element to handle this incoming request and make sure that the necessary commands are sent to the underlying product to effectively set up the flow.

## Flow documentation

For every interface a flow passes through, Flow Engineering creates a record in its database. This information is used to visualize the "as-engineered" path in the [Flow Monitoring](xref:flow_monitoring_app) application, showing the path of a flow as calculated by Flow Engineering, and therefore its expected state in the network.

## Options

Developers that want to use Flow Engineering to develop their own custom scripts can use the following options on Flow Engineering to tune the path calculation to their specific needs:

* Exclude a list of nodes
* Request for a number of shortest paths between source and destination
* Request for a given path to be excluded in order for a complete redundant path to be calculated
* Take internal DCF connectivity into account or not
