---
uid: Get_views
---

# Get views

Available from DataMiner 10.2.0/10.1.4 onwards. The *Get views* data source retrieves a list of the views in the DMS. By default, only the columns *View ID* and *Name* are included, but you can include additional columns using a [*Select* operator](xref:GQI_Select).

## Updates

From DataMiner 10.3.10/10.4.0 onwards<!-- RN 36789 -->, this data source supports [real-time updates](xref:Query_updates).

> [!NOTE]
>
> - Real-time updates are not yet supported for views that are deleted. This means that rows for deleted views will not be removed automatically until the query is executed again.
> - There is no metadata yet for views added through real-time updates, so you will not be able to use those as a view feed.
