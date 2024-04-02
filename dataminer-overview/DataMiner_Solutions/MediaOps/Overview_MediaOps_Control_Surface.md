---
uid: Overview_MediaOps_Control_Surface
---

# Control Surface app

The Control Surface app allows operators to perform their day-to-day activities, such as setting up connections between sources and destinations, doing configuration parameter control on devices, and viewing monitoring information coming from the devices. The MediaOps installation package<!-- TBD: add link when package is available --> comes with an out-of-the-box example control surface with the following functionality:

- Connecting a source to a destination.
- Disconnecting a destination.
- Locking a destination, to prevent other users from making changes to the destination without explicitly unlocking the destination first.
- Smart filtering, i.e. the app eliminates invalid connection attempts by filtering out sources and destinations that cannot be connected.

![Control Surface UI](~/dataminer-overview/images/control_surface1.png)

You can use the sample control surface as is, but you can also easily customize it further or even use it as a starting point to build your own control surface. Like the other out-of-the-box apps in the MediaOps package, this app is built using the DataMiner Low-Code Apps framework. This allows DevOps engineers to easily tweak the content, functionality, and look and feel of the app.

The source and destination buttons on the control surface are populated using DataMiner's Generic Query Interface (GQI). With GQI, you can easily create queries that retrieve sources and destinations from the system using your own filtering criteria, which allows you to build tailored panels for specific audiences or situations.

Within the Low-Code Apps framework, you can use the template editor to tweak the look and feel of the app. You can for instance configure your own own conditional button layout with specific labels, colors, icons etc. You can also edit the app itself and add any other component from the Low-Code Apps component library to the control surface to visualize data operators need at hand, or you can even change the behavior of the control surface. The Low-Code Apps editor allows you to tweak or add any button in the app and plug in any DataMiner Automation script.
