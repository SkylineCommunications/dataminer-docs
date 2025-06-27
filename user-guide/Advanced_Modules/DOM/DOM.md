---
uid: DOM
---

# DataMiner Object Models (DOM)

From DataMiner 10.1.2/10.2.0 onwards, DataMiner Object Models can be used for the modeling of any type of administrative or business-related objects within your system. These can for example be planned maintenance records, product catalog data, contractual and customer records, etc. Modeling these using DOM allows you to connect your business workflows to your technical and operational workflows.

A DataMiner Object Model is a generic data storage system that makes it possible to quickly create new applications or solutions. It consists of a collection of [generic objects](xref:DOM_objects) and a [generic DOM manager](xref:DOM_managers). Create, read, update, and delete (CRUD) actions can be executed on these objects in a script or application using the [DomHelper](xref:DomHelper_class). Data is [stored in an indexing database](xref:DOM_data_storage).

> [!NOTE]
> DOM data can be displayed in dashboards and applications from DataMiner 10.1.7 onwards. In versions prior to DataMiner 10.3.6/10.4.0, this feature is in soft launch, so you will need to activate the *DOMManager* [soft-launch option](xref:SoftLaunchOptions) to use it.

> [!TIP]
> To visualize and control your DataMiner Object Model (DOM) definitions and instances, the [DOM Viewer](xref:domviewer_about) application can come in very handy.

## Getting started with DOM

If you are just getting started with the DataMiner Object Models (DOM), this is what we recommend:

1. **Watch the introduction video**

   Begin by watching the introduction video [Kata #15: Getting started with DataMiner Object Models](https://www.youtube.com/watch?v=c4RmylxOpfA).

   You can also find further details related to this in the tutorial [Getting started with DOM](xref:DOM_Getting_Started_With_DOM).

1. **Watch the follow-up video**

   Once you understand the basics, watch the follow-up video [Kata #24: Make a DOM module state-aware](https://www.youtube.com/watch?v=VyV28_xWGFI).

   For further details related to this, check the tutorial [Making DOM objects state-aware](xref:DOM_Making_DOM_Stateful).

1. **Explore basic tutorial via code**

   For hands-on experience, follow the [basic tutorial to create a DOM setup via code](xref:DOM_Create_Basic_Setup).

   This will help you understand the required steps to create a DOM setup, including a low-code app.

1. **Review examples**

   Explore practical examples to gain insight in how DOM is applied. Specifically, you can check the [Invoice app example](xref:DOM_Invoice_app_example) and the [Status system example](xref:DOM_status_system_example).

   These showcase real-world scenarios where DOM can be beneficial.

1. **Dive into the detailed documentation**

   To gain a comprehensive understanding and discover advanced capabilities, explore all the remaining technical documentation available in this DataMiner Object Models (DOM) section. This will provide you with in-depth knowledge and insights into leveraging DOM effectively within your applications.
