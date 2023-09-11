---
uid: Get_views
---

# Get views

Available from DataMiner 10.2.0/10.1.4 onwards. The *Get views* data source retrieves a list of the views in the DMS. By default, only the columns *View ID* and *Name* are included, but you can include additional columns using a [*Select* operator](xref:GQI_Select).

## Updates

From DataMiner 10.3.11 onwards, this data source supports [real-time updates](xref:Query_updates).

> [!WARNING]
> There are no updates yet for views that are deleted. That means rows for deleted views will not be removed automatically until you re-execute the query.
