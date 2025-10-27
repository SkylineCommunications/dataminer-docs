---
uid: Get_view_relations
---

# Get view relations

Available from DataMiner 10.2.0/10.1.4 onwards. The *Get view relations* data source retrieves a list of the DataMiner objects that are direct children of views in the DMS. The list includes the following columns:

- *View ID*: The ID of the view containing the object.

- *Child ID*: The ID of the object.

- *Depth*: The level of the object in the tree view in relation to the root view.

Select the *Recursive* option for this data source to also include objects that are not directly included in a view, e.g. child objects of objects within the view.
