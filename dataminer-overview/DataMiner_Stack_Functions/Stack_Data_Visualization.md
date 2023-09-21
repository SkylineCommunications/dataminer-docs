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
> - Different videos related to Visual Overview in the [Dojo video library](https://community.dataminer.services/videos/?_sf_s=visual%20overview) ![Video](~/user-guide/images/video_Duo.png)
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

DataMiner provides one of the most comprehensive and powerful UIs with extensive user-definable capabilities, allowing the display of mimic diagrams that are compatible with Microsoft Visio. By leveraging existing Visio drawings and harnessing the power of Microsoft Visio, operators can create visually appealing and fully customized graphical presentations of their DataMiner-managed operational ecosystem. Any part of the user's network can be graphically represented, tailored to their specific needs, at any level of the network and completed by any requested real-time data.

DataMiner further enriches these Visio drawings, using special shape data fields to provide highly customized graphical user interfaces.

In summary, Visual Overview offers a remarkably powerful and graphical way to navigate, monitor, and manage your entire infrastructure.

> [!TIP]
> See also:
>
> - [Benefits of the Visual Overviews](https://community.dataminer.services/video/benefits-of-the-visual-overviews/) ![Video](~/user-guide/images/video_Duo.png)
> - [Earth Station Uplink Visual Overview sample](https://community.dataminer.services/use-case/earth-station-uplink-visual-overview-sample/)
> - [Control Surfaces](https://community.dataminer.services/use-case/control-surfaces/)
> - [Ziine – your reference for Visual Overview functionality](https://community.dataminer.services/ziine-your-reference-for-visual-overview-functionality/)
> - User Guide: [Visio drawings](xref:visio)
> - [Visual Overview training course](https://community.dataminer.services/courses/visio/)
> - [Expert Hub - DataMiner Visual Overview](https://community.dataminer.services/exphub-visualoverview/)

## Event correlation

**Detect identifiable patterns by relating various events.**

The fully integrated Correlation Engine is a valuable asset for operators seeking to expedite the repair process through automated root cause analysis and move towards a proactive operation.

Correlation Engine provides the technology to further enhance alarm detection within the operational environment by processing the raw alarm information utilizing on a user-defined knowledge base, in real time as events occur.

The Correlation Engine is capable of:

- Detecting single alarm events and patterns of alarm occurrences across the entire system.

- Checking real-time parameter values, prior to making any decisions or taking actions.

- Detecting single occurrences, persistent occurrences, or recurring occurrences of both single alarms events and alarm patterns across the entire operational environment.

- Taking actions when certain conditions occur within the operational environment, including generating new alarm messages for the operator (e.g. the most probable cause), triggering Automation scripts (e.g. to take automatic corrective measures), notifying operators, and more.

DataMiner also includes root cause analysis (RCA) based on connectivity information. Connectivity information can be fed into the system via the integrated connectivity editor or by linking the DataMiner System to a third-party connectivity database. DataMiner's RCA functionality offers operators a highly intuitive method to determine the most probable cause and filter out sympathetic alarms. This is achieved by assigning an RCA level to each alarm, indicating how far they are removed from their probable root cause.

> [!TIP]
> For more information:
>
> - [DataMiner Correlation](xref:correlation)
> - [DMS Correlation training video](https://community.dataminer.services/courses/dataminer-advanced/lessons/dms-correlation-2/) ![Video](~/user-guide/images/video_Duo.png)

## Fault management

**Detect, isolate, and resolve problems.**

Fault Management is one of the most fundamental and critical functionalities of a management platform.

It involves the ability to detect, isolate, and correct malfunctions in operational systems. However, achieving effective fault management remains a significant challenge for many operators.

With the current trends in the industry, this challenge is growing even more daunting by the day. The main cause of inadequate fault management is a loosely coupled architecture and the attempt to aggregate faults generated by disparate systems. **By tapping into every piece of the actual installed base, DataMiner provides a real-time, end-to-end view of the complete ecosystem**. As one of the most powerful fault management solutions in the industry, DataMiner offers a **suite of fault management-related innovations** that enable operators to pinpoint and resolve operational issues, faster than ever before by providing them with an **intuitive multi-user management of active and historical alarms**.

These innovations range from small gems such as highly user-definable device icons, which offer historical fault context information at a glance, to a notification banner with service impact analysis data, and revamped data tables with heatmap overlays and integrated histogram analysis. Furthermore, the core engine offers [**sophisticated off-the-shelf, self-learning algorithms**](xref:Stack_Augmented_Operations) to intelligently and effortlessly monitor and track the most challenging operational metrics, including traffic loads, slowly degrading quality metrics, and much more.

Today, **raw data collection** is the foundation of an efficient architecture. It maximizes the availability of information for the management platform to carry out its functions.

To address the challenges of fault detection, ensuring **good data hygiene** is key. DataMiner includes various ways to guarantee data hygiene, including:

- Fully user-definable and run-time-applied alarm thresholds defined in templates.
- Dynamic switching of alarm definitions based on time or events (e.g. upon service activation).
- Ability to stack alarm templates to easily and efficiently manage thresholds across vast deployments.
- Support for relative and absolute thresholds, including a variety of baseline methods.
- Hysteresis on trigger and/or clear, applicable to all individual thresholds.
- Conditional alarming to prevent unnecessary alarm clutter.

**Unified fault detection** is one of the most fundamental and critical functionalities of a management platform. DataMiner offers a unified approach with significant advantages:

- Gaining massive amounts of time to define and apply thresholds across your entire operation.
- Customizing alarm definitions exactly the way your operation requires, eliminating noisy alarms.
- Triggering alarms in a far more intelligent way and reducing the alarm count to what is truly necessary.
- Conserving valuable resources and time by reducing the need to resolve shortcomings with complex and cumbersome event correlation.
- Significantly reducing Mean Time to Repair (MTTR), increasing operational efficiency, lowering operational costs, and increasing Quality of Service (QoS).

The unified platform provides **highly enriched fault messages**, **out of the box requiring zero effort**.

> [!TIP]
> For more information:
>
> - [New to DataMiner (DataMiner Operator)](https://www.youtube.com/playlist?list=PLFb70A6JV6vgaop9IVx3PeEQWktDjJegU): a collection of bite-sized videos on element states, Alarm Console features, etc. ![Video](~/user-guide/images/video_Duo.png)
> - Videos related to alarm and fault management in our extensive [Video Library](https://community.dataminer.services/videos?_sf_s=alarm) ![Video](~/user-guide/images/video_Duo.png)
> - [DataMiner Alarm Console training course](https://community.dataminer.services/courses/dataminer-operator/lessons/alarm-console-3/)
> - [Experts & Insights – End-to-end fault management](https://community.dataminer.services/video/experts-insights-end-to-end-fault-management/) ![Video](~/user-guide/images/video_Duo.png)
> - User Guide: [Alarms](xref:About_alarms)

## Dashboards

**Visual representation of any data.**

DataMiner Dashboards enables operators to efficiently leverage the extensive, valuable real-time and historical operational information available in the DataMiner platform.

With the Dashboards app, you can **create, manage, and view** dashboards that display a **wealth of information** about the managed system.

Moreover, dashboards adhere to DevOps principles and can easily evolve over time at run-time. They can even be **shared with just about anybody outside of the company** through [dataminer.services](xref:Overview_DCP). Our built-in security functionality allows you control over the data you share, enabling you to determine which data is shared, with whom, and for how long.

> [!TIP]
> See [Dashboard Share](xref:Overview_Collaboration#dashboard-share) for more information.

DataMiner Dashboards offers a wide range of visualizations that can make use of various data feeds, including GQI-based query feeds. This “Queries” data item allows you to [construct queries](xref:Creating_GQI_query) to access the wealth of data available in your DataMiner System. See also: [Your next step towards a data-driven operation: the brand-new DataMiner Generic Query Interface (GQI)](https://community.dataminer.services/your-next-step-towards-a-data-driven-operation-the-brand-new-dataminer-generic-query-interface-gqi)

> [!TIP]
> For more information:
>
> - Example use case: [Dashboard Components Showcase](https://community.dataminer.services/use-case/dashboard-components-showcase/)
> - Example use case: [Monitor a Group of Servers via GQI](https://community.dataminer.services/use-case/monitor-a-group-of-servers-via-gqi/)
> - User Guide: [DataMiner Dashboards](xref:newR_D)
> - [Videos on the Dashboards app](https://community.dataminer.services/videos?_sf_s=dashboard) ![Video](~/user-guide/images/video_Duo.png)
> - [GQI-related videos](https://community.dataminer.services/videos?_sf_s=GQI) ![Video](~/user-guide/images/video_Duo.png)
> - [Analyzing a network of switches with the DataMiner Dashboards module](https://www.youtube.com/watch?v=e0tqNFMqgwo&ab_channel=DataMinerbySkylineCommunications) ![Video](~/user-guide/images/video_Duo.png)
> - [Analyzing performance of a Kubernetes Cluster with the DataMiner Dashboard module](https://www.youtube.com/watch?v=eST-XhA4P7I&ab_channel=DataMinerbySkylineCommunications) ![Video](~/user-guide/images/video_Duo.png)
> - [DataMiner Dashboards training course](https://community.dataminer.services/courses/dashboard/)

## Button Panel (i.e. Control Panel)

**Software button panels.**

As media operations grow more complex and demanding so too does the need to have a control panel that is tailored to any specific situation or need. And on top of that, operators need to be able to execute complex actions with the push of a button.

With the DataMiner Button Panels, you can easily create different panels for different situations and securely share them with your stakeholders.

First of all, DataMiner Control Panels **allow versatile control actions with the simple press of a button!** You can trigger a wide range of actions, ranging from simple actions like an XY-style crosspoint, to complex workflows such as launching Automation scripts, controlling multiple bookings, or orchestrating both virtual and physical matrixes and endpoints.

Moreover, you have the freedom to **customize the appearance and design** of each DataMiner Control Panel. This includes not only buttons but also trend charts, thumbnails, real-time metrics and KPIs, spectrum analyzers, or any other elements that align with your specific needs.

And finally, the control panels **enable true multi-tenant operations**. You can create tailor-made control panels for any customer, partner, or supplier, and share them via the DataMiner Cloud Platform.

> [!TIP]
> For more information:
>
> - Example use case: [DataMiner Button Panels](https://community.dataminer.services/use-case/dataminer-button-panels/)
> - Example use case:[Sony LEO - router Panels](https://community.dataminer.services/use-case/sony-leo-router-panels/)
> - Integration use case: [Sony LEO – Riedel Smart Panel Integration](https://community.dataminer.services/use-case/riedel-smart-panel-integration/)
> - [Tailor-made control panels in a jiffy](https://community.dataminer.services/tailor-made-control-panels-in-a-jiffy/) ![Video](~/user-guide/images/video_Duo.png)
> - Webinar: [DataMiner Routing Control Panel](https://community.dataminer.services/webinars/dataminer-routing-control-panel/) ![Video](~/user-guide/images/video_Duo.png)
> - [Real-time Software Router Control Panel Sharing](https://community.dataminer.services/real-time-software-router-control-panel-sharing/)

## No-Code Apps

**Create application software through graphical user interfaces.**

The No-Code/Low-Code Apps toolset enables you to **compose tailor-made apps** for specific audiences, from the ground up **with little to no coding experience**.

**Leverage your data!** Thanks to DataMiner's support for every possible category of integration, no-code apps can leverage your data lake, providing deeper insights and value. You can monitor metrics from any data source in real time, aggregate and manipulate data abstracted from hardware products, and create views tailored to the needs of each of your teams. Perform **real-time analytics** using the *[**Generic Query Interface (GQI)**](xref:Creating_GQI_query), also supporting [external data sources](xref:Configuring_an_ad_hoc_data_source_in_a_query).

> [!TIP]
> See also: [Your next step towards a data-driven operation: the brand-new DataMiner Generic Query Interface (GQI)](https://community.dataminer.services/your-next-step-towards-a-data-driven-operation-the-brand-new-dataminer-generic-query-interface-gqi/)

Empower your teams to design, deploy, and operate their own customized applications with complete freedom in terms of both content and layout. **Tailored applications** increase efficiency and quality of your operations by letting teams focus on what truly matters to them.

No-code apps include graphical editors allowing you to define on-event behavior, enabling **control and automation** over your operations.

These apps run on HTML5, making them **accessible from anywhere**, including mobile devices, which is particularly beneficial for those working in the field.

> [!TIP]
> For more information:
>
> - [Create your own powerful apps regardless of your coding abilities](https://community.dataminer.services/low-code-apps-create-your-own-powerful-apps-regardless-of-your-coding-abilities/)
> - [DataMiner Low-Code Apps: 5 things you need to know](https://community.dataminer.services/video/dataminer-low-code-apps-5-things-you-need-to-know/) ![Video](~/user-guide/images/video_Duo.png)
> - [Using Button Components and Header Bars in Low-Code Apps](https://community.dataminer.services/video/using-button-components-and-header-bars-in-dataminer-apps/) ![Video](~/user-guide/images/video_Duo.png)
> - [Version Control for Low-Code Apps](https://community.dataminer.services/video/make-the-most-out-of-version-control-for-low-code-apps/) ![Video](~/user-guide/images/video_Duo.png)
> - Example use case : [Switch configuration with DataMiner Low-Code Apps](https://community.dataminer.services/use-case/switch-configuration-with-dataminer-low-code-apps/)
> - Workflow use case : [DataMiner Low-Code Apps & Telestream Vantage – Media Asset Workflow Automation](https://community.dataminer.services/use-case/media-asset-workflow-automation-with-telestream-vantage/)
> - User Guide: [DataMiner Low-Code Apps](xref:Application_framework)
