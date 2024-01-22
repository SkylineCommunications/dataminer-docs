---
uid: BasicConcepts
---

# Basic concepts

This section introduces some concepts that you need to understand when you are new to DataMiner. These concepts will return throughout the DataMiner documentation, so if you are not yet familiar with them, read through this section before you go on to the rest of the documentation.

## DataMiner Agent and client

To be able to work with DataMiner, you must have at least one DataMiner Agent and a DataMiner client.

| Concept | Description |
|--|--|
| DataMiner Agent or DMA | A physical or virtual compute instance or "node" running the DataMiner software. |
| DataMiner System or DMS | A group of one or more DataMiner Agents, seamlessly working together as one system. |
| DataMiner client | An entity communicating with a DataMiner Agent. The term is mostly used to denote a client application that allows users to interact with a DataMiner System. |

> [!TIP]
> See also: [DataMiner System layout](xref:GeneralLayout)

## System components

In a DataMiner System, you can find different kinds of “objects”, representing components of the system:

| Concept | Description |
|--|--|
| [Element](xref:About_elements) | Elements represent data sources managed by DataMiner. By means of DataMiner connectors (a.k.a. protocols), elements in DataMiner can communicate with external data sources. Elements can also be created to display data from elsewhere within the DataMiner System, rather than from external data sources. |
| [Parameter](xref:parameters) | Parameters are variables that refer to specific data in the system. Their value may be retrieved from a data source or may depend on user input. Values may be part of a range limited by a particular minimum and maximum, or they may be part of a limited set of predetermined values. Examples: the temperature of a device, the description of a location, etc. |
| [Service](xref:About_services) | Services are collections of data sources that are used together. They consist of a group of elements or partial elements, combined from the perspective of a particular business aspect. This way, a DataMiner service can reflect all components required for an actual business service. |
| [View](xref:About_views) | Views allow you to create structure in the overview of the various objects in your system. These function as a kind of “folders”, which can for instance contain elements and subviews. By logically combining components in a view, you can ensure users can quickly access all components that belong together in some way. |
| [Redundancy group](xref:RedundancyGroups) | Redundancy groups are used to represent redundant device architectures while masking the underlying complexity for operators. They represent a group of devices that have been configured in such a way that if one or more of them fail, others can take over automatically. This makes it possible to dynamically change the devices in a service, so that it will automatically only use the devices it actually relies upon. |

## DataMiner functionality

The following concepts pertain to the way DataMiner gathers and visualizes information about your system:

| Concept | Description |
|--|--|
| [Protocol](xref:Protocols1) | A protocol, also known as "connector" or "driver", is an XML file that allows DataMiner to communicate with a data source in the system. |
| [Visual overview](xref:visio#visio-drawings) | A visual overview is a graphical representation of components and data in the system. The visual overviews in DataMiner are created in Microsoft Visio and can represent information in many different ways. They can also be made interactive, so that the user can interact with the DataMiner system by clicking areas in the visual overview. |
| [Alarm](xref:About_alarms) | An alarm is a notification that a parameter value has crossed a particular threshold, or a parameter has attained a particular value. With alarms, users are made aware of any abnormal situation in the system. Alarms can have different severity levels, and may be linked to other alarms. |
| [Trending](xref:trending) | DataMiner can store measurements of parameter values, taken over a period of time, so that these can be shown in graphs to visualize trends in the system. |

## DataMiner modules

A DataMiner System can have several additional modules or apps. Depending on the type of DataMiner license you have, these may or may not be available in your system. However, as some of these modules are mentioned quite often throughout the documentation, it is useful to know what they are, even if you will not use them yourself.

| Concept | Description |
|--|--|
| [Automation](xref:automation) | A module used to create scripts that can execute certain tasks automatically. Scripts can for instance set parameters, change element states, send notifications, etc. |
| [Business Intelligence](xref:sla) | A module used to track the parameters of a Service Level Agreement or SLA. It allows the creation of a special type of element, an SLA element, that monitors the SLA information related to a particular DataMiner service. |
| [Correlation](xref:About_DMS_Correlation) | A module that can gather information about parameter values and alarms, and trigger specific actions, such as generating a new, correlated alarm, based on triggers defined by the user. |
| [Dashboards and Low-Code Apps](xref:Dashboards_and_Low_Code_Apps) | These modules allow you to create and manage dashboards, i.e. pages displaying information about components of the DataMiner System, and low-code apps, i.e. apps combining multiple such pages, with added functionality. |
| [Scheduler](xref:About_the_Scheduler_module) | A module that can schedule certain actions in the DataMiner System. It works in close relation with the Automation module. |
| [Spectrum Analysis](xref:SpectrumAnalysis) | A module that allows the integration of spectrum analyzers in a DataMiner System. |
| System Center | A DataMiner Cube module that contains many DataMiner administrator functionalities, such as management of [users](xref:About_DMS_Security) and [DMAs](xref:DataminerAgents). |
| Apps | DataMiner can have countless custom-made apps, designed specifically for a particular vendor or technology. The possibilities for these apps are endless, so they are not all included in this documentation. |

> [!NOTE]
> For information on the other modules, refer to the module in question in the section [DataMiner modules](xref:Part4AdvancedModules).

## DataMiner Standard Apps

The DataMiner Standard Apps combine different DataMiner features into one ready-made package that can easily be deployed in a DataMiner System.

The package contains all the necessary components and default configurations, including protocols, views, Automation scripts, etc. Certain DataMiner features and licenses can be required as prerequisites, depending on the app.

> [!TIP]
> See also: [DataMiner Standard Apps](xref:Part5StandardApps)
