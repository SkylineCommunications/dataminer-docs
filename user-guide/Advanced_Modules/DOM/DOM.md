---
uid: DOM
---

# DataMiner Object Models (DOM)

DataMiner Object Models can be used for the modeling of any type of administrative or business-related objects within your system. These can for example be planned maintenance records, product catalog data, contractual and customer records, etc. Modeling these using DOM allows you to connect your business workflows to your technical and operational workflows.

A DataMiner Object Model is a generic data storage system that makes it possible to quickly create new applications or solutions. It consists of a collection of [generic objects](xref:DOM_objects) and a [generic DOM manager](xref:DOM_managers). Create, read, update, and delete (CRUD) actions can be executed on these objects in a script or application using the [DomHelper](xref:DomHelper_class). Data is [stored in the Elasticsearch database](xref:DOM_data_storage).

> [!NOTE]
>
> - DOM data can be displayed in dashboards and applications from DataMiner 10.1.7 onwards. However, this feature is currently still in soft launch, so you will need to activate the *DOMManager* [soft-launch option](https://community.dataminer.services/documentation/soft-launch-options/) to use it.
> - The DataMiner Jobs module functions in the same way as a DOM manager. The main difference is in the naming of the objects used. In addition, multiple DOM manager instances can run at the same time, while there can only be one Jobs module.
