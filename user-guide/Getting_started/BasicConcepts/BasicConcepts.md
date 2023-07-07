---
uid: BasicConcepts
---

# Basic concepts

This section introduces some concepts that you need to understand when you are new to DataMiner. These concepts will return throughout the DataMiner Help, so if you are not yet familiar with them, it is advisable to read through this section before you go on to the rest of the documentation.

## DataMiner Agent and client

To be able to work with DataMiner, you must have at least one DataMiner Agent and a DataMiner client.

| Concept | Description |
|--|--|
| DataMiner Agent or DMA | A physical or virtual compute instance running the DataMiner software. |
| DataMiner client | An entity communicating with the Agent. The term is mostly used to denote a client application that allows users to interact with the DataMiner Agent. |

> [!TIP]
> See also: [DataMiner System layout](xref:GeneralLayout)

## System components

On a DataMiner Agent you can find different kinds of “objects”, representing components of your system:

| Concept | Description |
|--|--|
| An element | A data source that is monitored by the DataMiner System. |
| A parameter | A variable that refers to pieces of data in the system. Its value may be detected by DataMiner, or may depend on user input. Values may be part of a range limited by a particular minimum and maximum, or part of a limited set of predetermined values. |
| A service | A group of elements or partial elements, combined from the perspective of a particular business aspect. As such, a DataMiner service can reflect all components required for an actual business service. |
| A view | A folder that can contain elements, services and other DataMiner components. Logically combining components in a view allows the user to quickly access all components that belong together in some way. |
| A redundancy group | A group of devices that have been configured in such a way that if one or more of them fail, others can take over automatically. |

> [!NOTE]
> For more information about these components, refer to the relevant section in [Basic DataMiner functionality](xref:Part2BasicFunctionalities#basic-dataminer-functionality).

## DataMiner functionality

The following concepts pertain to the way DataMiner gathers and visualizes information about your system:

| Concept | Description |
|--|--|
| A protocol | An XML file that allows the DMA to communicate with a data source in the system. Also known as “connector” or “driver”. See also: [Protocols and Templates](xref:protocols#protocols-and-templates) |
| A visual overview | A graphical representation of components and data in the system. The visual overviews in DataMiner are created in Microsoft Visio and can represent information in many different ways. They can also be made interactive, so that the user can interact with the DataMiner system by clicking areas in the visual overview. See also: [Visio drawings](xref:visio#visio-drawings). |
| An alarm | A notification that a parameter value has crossed a particular threshold, or a parameter has attained a particular value. With alarms, users are made aware of any abnormal situation in the system. Alarms can have different severity levels, and may be linked to other alarms. |
| Trending | DataMiner can store measurements of parameter values, taken over a period of time, so that these can be shown in graphs to visualize trends in the system. |

## DataMiner modules

A DataMiner System can have several additional modules or apps. Depending on the type of DataMiner license you have, these may or may not be available in your system. However, as some of these modules are mentioned quite often throughout the documentation, it is useful to know what they are, even if you will not use them yourself.

| Concept | Description |
|--|--|
| Automation | A module used to create scripts that can execute certain tasks automatically. Scripts can for instance set parameters, change element states, send notifications, etc. |
| Business Intelligence | A module used to track the parameters of a Service Level Agreement or SLA. It allows the creation of a special type of element, an SLA element, that monitors the SLA information related to a particular DataMiner service. |
| Correlation | A module that can gather information about parameter values and alarms, and trigger specific actions, such as generating a new, correlated alarm, based on triggers defined by the user. |
| Scheduler | A module that can schedule certain actions in the DataMiner System. It works in close relation with the Automation module. |
| Spectrum Analysis | A module that allows the integration of spectrum analyzers in a DataMiner System. |
| System Center | A module that contains most of the administrator functionalities in DataMiner, such as management of databases and DMAs. |
| Dashboards | A module that allows you to view, create and manage dashboards, i.e. pages displaying information about components of the DataMiner System. These dashboards can be viewed in a separate app or embedded in a visual overview. |
| Apps | DataMiner can have countless custom-made apps, designed specifically for a particular vendor or technology. The possibilities for these apps are endless, so they are not all included in this documentation. |

> [!NOTE]
> For information on the other modules, refer to the module in question in the section [DataMiner modules](xref:Part4AdvancedModules).

## DataMiner Standard Apps

The DataMiner Standard Apps combine different DataMiner features into one ready-made package that can easily be deployed in a DataMiner System.

The package contains all the necessary components and default configurations, including protocols, views, Automation scripts, etc. Certain DataMiner features and licenses can be required as prerequisites, depending on the app.

> [!TIP]
> See also: [DataMiner Standard Apps](xref:Part5StandardApps)
