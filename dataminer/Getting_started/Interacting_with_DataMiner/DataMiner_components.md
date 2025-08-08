---
uid: DataMiner_components
---

# DataMiner components

In a DataMiner System, you can find different kinds of "objects", representing components of the system. The most important objects are [elements](#elements), [services](#services), [views](#views), and [alarms](#alarms).

Other DataMiner objects also exist, but these four are the core components you need to be familiar with in order to work with DataMiner.

## Elements

[Elements](xref:About_elements) represent data sources monitored by DataMiner. Elements serve as the digital twin of devices or products within your network.

Elements are created based on DataMiner [protocols](xref:Protocols1), also known as **connectors**. Typically, a protocol will be used to communicate with external data sources. However, they can also retrieve data from elsewhere within the DataMiner System.

Elements have two main kinds of pages. You can see these by selecting the element in DataMiner Cube or in the Monitoring app, and they can also be embedded in a dashboard or low-code app.

- **Visual overview pages**: These pages provide a graphical representation of data related to the element. They can also be interactive, so that users can interact with the DataMiner System by clicking areas in the visual overview.

  These pages are based on [Visio drawings](xref:visio#visio-drawings). Using Microsoft Visio, users with sufficient rights can create their own visual overview pages or customize existing pages according to their preferences.

- **Data pages**: These pages contain the parameters defined in the DataMiner protocol. [Parameters](xref:parameters) are variables that refer to specific data in the system. Their value may be retrieved from a data source or may depend on user input. They can for example indicate the temperature of a device, the description of a location, etc.

  DataMiner can store measurements of parameter values taken over a period of time, so that these can be shown in graphs to [visualize trends](xref:trending) in the data.

  ![Visualize trends](~/dataminer/images/Visualize_Trends.gif)<br/>*Element card in DataMiner 10.4.1*

## Services

[Services](xref:About_services) are collections of data sources that are used together. They consist of a group of elements or partial elements, combined from the perspective of a particular business aspect. This way, a DataMiner service can reflect all components required for an actual business service.

Like elements, services have visual overview pages and data pages. The data pages of a service represent the different service children, i.e. the elements or partial elements included in the service.

![Services](~/dataminer/images/Services.gif)<br/>*Service card in DataMiner 10.2.8*

## Views

[Views](xref:About_views) allow you to create structure in the overview of the various objects in your system. Views function as a kind of “folders”, which can for instance contain elements and subviews. By logically combining components in a view, you can ensure that users can quickly access all components that belong together in some way.

![Views](~/dataminer/images/Views.gif)<br/>*Element card in DataMiner 10.4.1*

## Alarms

An [alarm](xref:About_alarms) is a notification that a parameter value has crossed a particular threshold, or a parameter has attained a particular value. With alarms, users are made aware of an abnormal situation in the system. Alarms can have different severity levels represented by different colors, and may be linked to other alarms.

Typically, alarms are not triggered for all parameters, but only for those parameters that are of interest for monitoring. To determine which parameters are monitored and which parameter values should trigger an alarm, [alarm templates](xref:About_alarm_templates) are configured.

By default, alarms will bubble up throughout the DataMiner user interface. This means that if there is an alarm on a particular parameter, this will bubble up to the element containing that parameter, and from there to the view containing that element, and to the view containing that view, and so on. For example, if there is a critical (red) alarm on the "Audio Output Level" parameter of the element "Skyline HQ" within the view "EUR", a critical alarm will not only be shown for the parameter, but also for that element and that view.

![Alarms](~/dataminer/images/Alarms.gif)<br/>*Surveyor in DataMiner 10.4.1*
