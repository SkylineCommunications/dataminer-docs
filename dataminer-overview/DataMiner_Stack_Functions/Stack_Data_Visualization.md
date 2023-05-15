---
uid: Stack_Data_Visualization
---

# Data Visualization

***Convert bits and bytes into uncluttered dashboards and easy control panels***

![stack.functions.categories](~/dataminer-overview/images/stack_data_visualization.png)

## Spectral Data Processing

**Processing remote sensing data from operational and historic missions in an online platform.**

DataMiner Spectrum Analysis provides operators with the unique opportunity to benefit from real-time remote, multi-user RF measurements, as well as continuous 24/7 RF fault and performance management, by integrating with and processing RF data from:

**any spectrum analyzer:**

- high-end analyzers at strategic points in your operation
- mainstream commodity analyzers in high volume
- any product with spectrum monitoring measurement (e.g. cable modem, CMTS, remote PHY, etc.)

**but also:**

- legacy products
- packaged carrier management systems

**and**

- RF routing/switching solutions (L-band router, return path switch, etc.)

DataMiner brings it all together in one standard UI, with a rich set of features and capabilities that runs completely transparently across any analyzer you have today or will have at any time in the future.

> [!TIP]
> For more information:
>
> - Solution Overview: [Spectrum analysis, monitoring and management](https://community.dataminer.services/solution/manage-your-rf-with-care-dataminer-spectrum-analysis-monitoring-and-management/)
> - Discover all the capabilities of DataMiner Spectrum Management in this 60-min. [Experts & Insights webinar](https://community.dataminer.services/video/experts-insights-dataminer-spectrum-management/) ![Video](~/user-guide/images/video_Duo.png)
> - Example use case: [Spectrum Assurance and Teleport Interference](https://community.dataminer.services/use-case/spectrum-assurance-and-teleport-interference/)
> - Example use case: [L-Band Spectrum Monitoring](https://community.dataminer.services/use-case/l-band-spectrum-monitoring/)
> - Different spectrum-related videos in the [Dojo video library](https://community.dataminer.services/videos/?_sf_s=spectrum) ![Video](~/user-guide/images/video_Duo.png)
> - User Guide: [DataMiner Spectrum Analysis](xref:SpectrumAnalysis)

## Performance Management

**Ensuring that a set of activities and outputs meets an organization's goals in an effective and efficient manner.**

This particular stack function keeps track of detailed historical key performance readings up to more than one year. Any parameter made available by the API of any data source (e.g. interface bandwidth, utilization (Mbps, %), rate errors, collisions, CPU usage, etc.) can be trended for later evaluation of its performance, for example for debugging or forecasting of future behavior.

DataMiner allows the user to define exactly for which parameters trending information has to be logged in the trending database and which kind of trending information has to be included. In a trend template, you can define both the scope (which parameters) and the type (real-time data, average trending, or a combination of both) of the trend information to be stored in the trending database.

In systems with a Cassandra and Elasticsearch database, DataMiner’s [Augmented Operations](xref:Stack_Augmented_Operations) are enabled, including AI features such as trend prediction, pattern matching and much more.

> [!TIP]
> For more information:
>
> - [Trending](xref:trending) in the DataMiner User Guide.

## Visual Overview

**Clear visualization of data and insights.**

DataMiner provides one of the most comprehensive and most powerful and fully user-definable UIs to display mimic diagrams that are compatible with Microsoft Visio®. As such, operators can leverage existing Microsoft Visio® drawings and the power of Microsoft Visio® to create appealing and fully customized graphical presentations of the operational ecosystem managed by DataMiner. Any part of the user's network can be graphically represented according to the user's needs, on any level of the network and completed with any requested real-time data.

DataMiner enriches these Visio® drawings, using special shape data fields, to provide highly customized graphical user interfaces.

In a nutshell, Visual Overviews provide you with a very powerful and graphical way to navigate, monitor, and manage your entire infrastructure.

> [!TIP]
> For more information:
>
> - Demo Video about the [Benefits of the Visual Overviews](https://community.dataminer.services/video/benefits-of-the-visual-overviews/)
> - Visual Overview sample of [an Earth Station uplink](https://community.dataminer.services/use-case/earth-station-uplink-visual-overview-sample/)
> - Visual Overview sample of [control surfaces and panels](https://community.dataminer.services/use-case/control-surfaces/)
> - [DataMiner Ziine Demo System - Your reference for Visual Overview functionality](https://community.dataminer.services/ziine-your-reference-for-visual-overview-functionality/)
> - User Guide: [Visio® drawings](xref:visio)
> - Full course about [Visual Overview in DataMiner](https://community.dataminer.services/courses/visio/)
> - More videos related to Visual Overview in the [Video Library](https://community.dataminer.services/videos?_sf_s=visual%20overview/)
> - [Expert Hub](https://community.dataminer.services/exphub-visualoverview/)

## Event Correlation

**Detect identifiable patterns by relating various events.**

The fully integrated Correlation Engine is a valuable asset for operators who wish to reduce the time to repair by means of automated root cause analysis, and who wish to move towards a proactive operation.

Correlation Engine provides the technology to further enhance the alarm detection on the operational environment by processing the raw alarm information based on a user-defined knowledge base, in real time as events occur.  It’s capable of:

- Detecting single alarm events as well as patterns of alarm occurrences across the entire system
- Checking real-time values of parameters prior to making any decisions and taking actions
- Detecting single occurrences, persistent occurrences or recurring occurrences of single alarms events or alarm patterns across the entire operational environment
- Taking actions when certain conditions occur in the operational environment, including generating new alarm messages for the operator (i.e. most probable cause), triggering automation scripts (e.g. to take automatic corrective measurements), notifying operators, etc.

DataMiner also includes root cause analysis based on connectivity information. Connectivity information can be fed into the system via the integrated connectivity editor, or by linking the DataMiner System to a third-party connectivity database. DataMiner RCA provides a very intuitive way for the operator to find the most probable cause and to filter out sympathetic alarms. This is achieved by assigning a so-called RCA level to each alarm. The RCA level indicates how far away the device is located from the most probable cause.

> [!TIP]
> For more information:
>
> - DataMiner Correlation in the [User Guide](xref:correlation)
> - Full course about [DataMiner Correlation](https://community.dataminer.services/courses/dataminer-advanced/lessons/dms-correlation-2/)

## Fault Management

**Detect, isolate, and resolve problems.**

Fault Management is one of the most fundamental and critical functionalities of a management platform.

Fault Management is about the ability to detect, isolate and correct malfunctions in the operational systems. Nevertheless, it is still one of the most challenging objectives for many operators.

With the current trends in the industry, this is getting more challenging by the day. The main cause of failing or very poor fault management is a loosely coupled architecture and the attempt to aggregate faults generated by disparate systems. **By tapping into every piece of the actual installed base, DataMiner provides a real-time, end-to-end view of the complete ecosystem**. To leverage the data, DataMiner, as one of the most powerful fault management solutions in the industry, offers a **suite of fault management related innovations**, enabling operators to pinpoint and resolve operational issues faster than ever before by providing them with an **intuitive multi-user management of active and historical alarms**.

This ranges from small gems such as highly user-definable device icons that offer at-a-glance historical fault context information, up to a notification banner including service impact analysis data, and revamped data tables with heatmap overlays and integrated histogram analysis. Furthermore, the core engine offers [**sophisticated off-the-shelf, self-learning algorithms**](xref:Stack_Augmented_Operations) to intelligently and effortlessly monitor and track the most challenging operational metrics, including traffic loads, slowly degrading quality metrics, and much more.

**Raw data collection** is today the foundation of an efficient architecture. It maximizes the amount of information available for the management platform to perform its functions.

**Good data hygiene** solves the majority of the challenges of fault detection. DataMiner includes many ways to guarantee data hygiene. Some examples are:

- fully user-definable & run-time applied alarm thresholds defined in templates
- dynamically switch alarm definitions based on time or events (e.g. upon service activation)
- ability to stack alarm templates to easily and efficiently manage thresholds across vast deployments
- support for relative & absolute thresholds, including a variety of base line methods
- hysteresis on trigger and/or clear, applicable to all individual thresholds
- conditional alarming preventing unnecessary alarm clutter

**Unified fault detection** is one of the most fundamental and critical functionalities of a management platform. DataMiner offers a unified approach with significant advantages:

- gain massive amounts of time to define and apply thresholds across your entire operation
- define it exactly the way it needs to be for your operation – no noisy alarms
- trigger alarms in a far more intelligent way & reduce the alarm count to what is really needed
- save valuable resources and time by reducing the need to resolve shortcomings with complex and cumbersome event correlation
- significantly reduce MTTR, increase optional efficiency, drive down operational cost and increase QoS

The unified platform provides **highly enriched fault messages** and does it **out of the box with zero effort**.

> [!TIP]
> For more information:
>
> - The best way to see it in action is by means of **illustrating videos**. We have a series of bite size videos available, that give a quick impression of this extensive feature set in DataMiner, such as the element states, the alarm console features, and much more. Please find them at [**New to DataMiner (DataMiner Operator)**](https://www.youtube.com/playlist?list=PLFb70A6JV6vgaop9IVx3PeEQWktDjJegU)
> - Even more videos related to alarm and fault management in our extensive [Video Library](https://community.dataminer.services/videos?_sf_s=alarm)
> - Full course about the [DataMiner Alarm Console](https://community.dataminer.services/courses/dataminer-operator/lessons/alarm-console-3/)
> - Experts & Insights webinar about [End-to-end fault management](https://community.dataminer.services/video/experts-insights-end-to-end-fault-management/)
> - Alarms in the [User Guide](xref:alarms)


## Dashboards

**Visual representation of any data.**

DataMiner Dashboards enables operators to tap more efficiently into the vast amount of valuable real-time and historical operational information available in the DataMiner platform.

With the Dashboards app, you can **make, manage, and view** dashboards that can display a **wealth of information** about the managed system.

Moreover, Dashboards follow DevOps principles and can easily evolve over time at run-time and can even be **shared with just about anybody outside of the company** through [dataminer.services](xref:Overview_DCP). Our built-in security functionality allows you to decide which data to share with whom and for how long. Refer to [Dashboard Share](xref:Overview_Collaboration#dashboard-share) for more information.

Many different visualizations are available, which can make use of all sorts of data feeds, including GQI-based query feeds. This “Queries” data item allows you to [construct a query](xref:Configuring_GQI_feeds) in order to tap into the wealth of data available in your DataMiner System. See also [Your next step towards a data-driven operation: the brand-new DataMiner Generic Query Interface (GQI)](https://community.dataminer.services/your-next-step-towards-a-data-driven-operation-the-brand-new-dataminer-generic-query-interface-gqi)

> [!TIP]
> For more information:
>
> - Example Use Case: [Dashboard Components Showcase](https://community.dataminer.services/use-case/dashboard-components-showcase/)
> - Example Use Case: [Monitor a Group of Servers via GQI](https://community.dataminer.services/use-case/monitor-a-group-of-servers-via-gqi/)
> - DataMiner Dashboards in the [User Guide](xref:correlation)
> - Videos related to DataMiner Dashboards in the [Video Library](https://community.dataminer.services/videos?_sf_s=dashboard)
> - Videos related to Dashboards and GQI in the [Video Library](https://community.dataminer.services/videos?_sf_s=GQI)
> - [Analyzing a network of switches with the DataMiner Dashboards module](https://www.youtube.com/watch?v=e0tqNFMqgwo&ab_channel=DataMinerbySkylineCommunications)
> - [Analyzing performance of a Kubernetes Cluster with the DataMiner Dashboard module](https://www.youtube.com/watch?v=eST-XhA4P7I&ab_channel=DataMinerbySkylineCommunications)
> - Full course about [DataMiner Dashboards](https://community.dataminer.services/courses/dashboard/)

## Button Panel (a.k.a. Control Panel)

**Software button panels.**

As media operations grow more complex and demanding so too does the need to have a control panel that's tailored to any specific situation or need. And on top of that, operators need to be able to execute complex actions at the push of a button.

With the DataMiner Button Panels, you can easily create different panels for different situations and securely share them with your stakeholders.

First of all, DataMiner Control Panels **allow versatile control actions with a mere press of a button!** You can trigger anything from simple actions, like an XY-style crosspoint, to a wide variety of complex workflows, like launching automation scripts, controlling multiple bookings, or orchestrating both virtual and physical matrixes and endpoints.

Secondly, you’re able to **customize the appearance and design** of every one of your DataMiner Control Panels; not only with buttons, but also with trend charts, thumbnails, real-time metrics and KPIs, spectrum analyzers, or whatever else fits your needs!  

And finally, the control panels **enable true multitenant operations**: you can create tailor-made control panels for any customer, partner, or supplier, and share them via the DataMiner Cloud Platform.

> [!TIP]
> For more information:
>
> - Example Use Case about [DataMiner Button Panels](https://community.dataminer.services/use-case/dataminer-button-panels/)
> - Example Use Case about [Sony LEO router Panels](https://community.dataminer.services/use-case/sony-leo-router-panels/)
> - Integration Use Case: [Sony LEO – Riedel Smart Panel Integration](https://community.dataminer.services/use-case/riedel-smart-panel-integration/)
> - Demo Video: [Tailor-made control panels in a jiffy](https://community.dataminer.services/tailor-made-control-panels-in-a-jiffy/)
> - Webinar Video: [DataMiner Routing Control Panel, control any service with the click of a button](https://community.dataminer.services/webinars/dataminer-routing-control-panel/)
> - [Real-time Software Router Control Panel Sharing](https://community.dataminer.services/real-time-software-router-control-panel-sharing/)

## No Code Apps

**Create application software through graphical user interfaces.**

The No Code/Low Code Apps toolset let you **compose tailor made apps** for specific audiences, from the ground up **with little to no coding experience**.

**Leverage your data!** Thanks to DataMiner support for every possible category of integration, no code apps can harness from your data lake to produce further insights and value, monitor metrics from any data source in real time, aggregate and operate on data abstracted from hardware products, and create views to cater to the needs of each of your teams. Perform **real-time analytics** using the *[**Generic Query Interface (GQI)**](https://community.dataminer.services/your-next-step-towards-a-data-driven-operation-the-brand-new-dataminer-generic-query-interface-gqi/), also supporting external data sources.

Empower your teams to design, deploy and operate their own customized applications with complete freedom, both on content and layout. **Tailored applications** increase efficiency and quality of your operations by letting teams focus on what's really essential to them.

No code apps include graphical editors allowing you to define on-event behavior to exercise **control and automation** over your operations.

They run on HTML5, meaning they are **accessible from anywhere**, including mobile devices, for those working in the field.

> [!TIP]
> For more information:
>
> - [Create your own powerful apps regardless of your coding abilities](https://community.dataminer.services/low-code-apps-create-your-own-powerful-apps-regardless-of-your-coding-abilities/)
> - Demo Video: [DataMiner Low-code Apps: 5 things you need to know](https://community.dataminer.services/video/dataminer-low-code-apps-5-things-you-need-to-know/)
> - Demo Video : [Using Button Components and Header Bars in Low-Code Apps](https://community.dataminer.services/video/using-button-components-and-header-bars-in-dataminer-apps/)
> - Demo Video : [Version Control for Low-Code Apps](https://community.dataminer.services/video/make-the-most-out-of-version-control-for-low-code-apps/)
> - Example Use Case : [Switch configuration with DataMiner Low-Code Apps](https://community.dataminer.services/use-case/switch-configuration-with-dataminer-low-code-apps/)
> - Workflow Use Case : [DataMiner Low-Code Apps & Telestream Vantage – Media Asset Workflow Automation](https://community.dataminer.services/use-case/media-asset-workflow-automation-with-telestream-vantage/)
> - User Guide : [DataMiner Low-Code Apps](xref:Application_framework)
