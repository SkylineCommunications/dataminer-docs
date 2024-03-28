---
uid: Overview_MediaOps_Data_Model
---

# MediaOps data model

All functions of the MediaOps solution are built on the Common Data Model (CDM). Each object in this model, such as virtual signal groups, resources, jobs, etc., is described by a definition. Multiple definitions that belong together functionally are grouped into modules. Below, you can find an overview of the different modules and their definitions.

![MediaOps high-level data model](~/dataminer-overview/images/MediaOps_data_model_high_level.png)

## Workflows

Workflows are a central concept to the MediaOps solution. They describe what needs to happen when creating a connection between a source and a destination, when executing certain job, delivering a type of service, etc.

Workflows are created in the [Workflow Designer](xref:Overview_MediaOps_Workflow_Designer) app. Each workflow consists of a set of nodes and a set of connections between these nodes. These typically describe how a source signal (virtual signal group) is transported to a destination and how it gets processed in between. Workflows can be executed either largely manually or in a highly automated fashion.

<!-- TBD: What is the purpose of this table? This does not seem to belong in the high-level overview.
|Field name|Type|Description|Possible values|Default value|
|---|---|---|---|---|
|Name|String|Name of the workflow|||
|Workflow execution script|String|Name of the script that should be triggered when executing this workflow||MediaOps.Workflow.Default|
|At job start|Enum|Determines if and when a service will be created to monitor this workflow|Create service immediately, Create service at workflow start, Don't create service|| -->

<!-- 
> [!TIP]
> See also: [Workflows]() -->

Within the workflows module, a **job** represents a specific execution of a workflow, delivery of a service, network connection, etc. Jobs are similar in structure to workflows, as they also contain a list of nodes and connections, but jobs have some extra information on them like a start and a stop time, cost and billing information etc.

## Virtual signal groups

In the MediaOps environment, a **flow** represents the lowest level of media content, i.e. the individual video, audio, or data streams. The flows database contains flow senders and flow receivers, which are linked to a certain element and (optionally) an interface in the network. They can be of different types, such as SDI, IP 2110, IP 2022-6, ASI, etc. For some of these types, some extra parameters have to be provided, like the source IP address, multicast IP address, and port for a multicast IP sender. For others, like an SDI signal, the element and port (interface) are sufficient.

<!-- TBD: What is the purpose of this table? This does not seem to belong in the high-level overview.
|Field name|Type|Description|Possible values|Default value|
|---|---|---|---|---|
|Name|String|Name of the flow|   |   |
|Transport type|Enum|Network transport type of the flow|SDI, IP ST2022-6, IP ST2110-20, IP ST2110-22, IP ST2110-30, IP ST2110-31, IP ST2110-40|   |
|Operational state|Enum|Indicates whether or not this flow is currently operational|Up, Down|   |
|Administrative state state|Enum|Indicates whether or not this flow should currently be available for use by operators|Up, Down|   |
|Flow direction|Enum|Indicates whether this is a flow sender (Tx) or receiver (Rx)|Tx, Rx||
|Element|String|The DataMiner Element on which this flow sender/receiver is present||   |
|Interface|String|If this flow sender/receiver is only present on a specific interface of the element, this can be specified in this field|   |   | -->

**Virtual signal groups** arrange multiple flow senders and flow receivers together into sources and destinations. With virtual signal groups, multiple video, audio, and data streams can be connected from a sender to a receiver in one go. Virtual signal groups are therefore the main object that operators interact with to execute connect and disconnect actions.

<!-- TBD: What is the purpose of this table? This does not seem to belong in the high-level overview.
|Field name|Type|Description|Possible values|Default value|
|---|---|---|---|---|
|Name|String|Name of the virtual signal group|   |   |
|Role|Enum|Select whether this virtual signal group acts as a source, a destination or both.|Source, Destination|   |
|Operational state|Enum|️Indicate whether this virtual signal group is currently operational or not.|Up/Down|   |
|Administrative state|Enum|️️Indicate whether this virtual signal group can currently be used by operators or not. As long as the Administrative state is set to 'Down' this virtual signal group will not appear in operator control panels.|Up/Down|   |
|Type|DomInstance: Virtual Signal Groups Types|||| -->

When a flow is added to a virtual signal group, the **level** where it should be added always has to be specified. Some examples of levels could be "VID 1", "AUD 2", "AUD 3", "DATA", etc. Adding flows to virtual signal groups on a specific level makes it easier to connect the right things when trying to connect a source with many senders to a destination with many receivers. The level structure is defined system-wide: it is the same for all virtual signal groups on the system.

Users can define a list of virtual **signal group types** and then assign each virtual signal group in the system to one of these types. These types could for example be "SDI Input", "IP 2110 Signal", "IP Monitor", etc. These types are used to decide what to do when a certain source should be connected to a certain destination.

**Workflow mappings** are used to map a combination of a source vSG type and a destination vSG type to a workflow. Whenever a user requests MediaOps to connect a source to a destination, the system will look up the applicable workflow for the type of the selected source and the type of the selected destination, and then it will execute this workflow.

## Domains and areas

Because there can be many source, destinations, resources, workflows, etc. in a large-scale MediaOps environment, they can be arranged into domains and areas to allow to easily filtering in the UI. Objects can be assigned to one or more domains.

Areas are the top-level hierarchical grouping object in the a MediaOps system. Domains can be assigned to one or more areas.
