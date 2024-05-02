---
uid: DOM
---

# DataMiner Object Models (DOM)

From DataMiner 10.1.2/10.2.0 onwards, DataMiner Object Models can be used for the modeling of any type of administrative or business-related objects within your system. These can for example be planned maintenance records, product catalog data, contractual and customer records, etc. Modeling these using DOM allows you to connect your business workflows to your technical and operational workflows.

A DataMiner Object Model is a generic data storage system that makes it possible to quickly create new applications or solutions. It consists of a collection of [generic objects](xref:DOM_objects) and a [generic DOM manager](xref:DOM_managers). Create, read, update, and delete (CRUD) actions can be executed on these objects in a script or application using the [DomHelper](xref:DomHelper_class). Data is [stored in an indexing database](xref:DOM_data_storage).

> [!NOTE]
>
> - DOM data can be displayed in dashboards and applications from DataMiner 10.1.7 onwards. In versions prior to DataMiner 10.3.6/10.4.0, this feature is in soft launch, so you will need to activate the *DOMManager* [soft-launch option](xref:SoftLaunchOptions) to use it.  
> - The DataMiner Jobs module functions in a similar way as a DOM manager. The main difference is in the naming of the objects used. In addition, multiple DOM manager instances can run at the same time, while there can only be one Jobs module.

## Getting Started

DataMiner Object Models (DOM) provide a powerful way to manage and manipulate data within your applications. Follow these steps to get started with DOM:

### 1. Watch the introduction video

   Begin by watching the introduction video titled "Kata #15: Getting started with DataMiner Object Models" available [here](https://community.dataminer.services/video/kata-15-getting-started-with-dataminer-object-models/). Additionally, you can access a written tutorial for further details [here](xref:DOM_Getting_Started_With_DOM).

### 2. Watch the follow-up video

   After understanding the basics, watch the follow-up video titled "Kata #24: Make a DOM module state-aware" [here](https://community.dataminer.services/video/kata-24-make-a-dom-module-state-aware/). This video builds upon the introductory concepts. Access the corresponding written tutorial [here](xref:DOM_Making_DOM_Stateful).

### 3. Explore basic tutorial via code

   For hands-on experience, check out the basic tutorial to create a DOM setup via code [here](xref:DOM_Create_Basic_Setup). This will help you understand the required steps to create a DOM setup via code, including a low-code app.

### 4. Review examples

   Explore practical examples to grasp the application of DOM. Check out the "Invoice app example" [here](xref:DOM_Invoice_app_example) and the "Status system example" [here](xref:DOM_status_system_example). These examples showcase real-world scenarios where DOM can be beneficial.

### 5. Dive into detailed documentation

   For a comprehensive understanding and to discover advanced capabilities, explore all the remaining technical documentation available. This will provide you with in-depth knowledge and insights into leveraging DOM effectively within your applications.
