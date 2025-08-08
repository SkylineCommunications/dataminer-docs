---
uid: Hidden_elements
---

# Hidden elements

Hidden elements are mostly created for internal purposes. They have no virtual IP address.

Typically, a hidden element will be used to extract information from physical devices, which is then passed on to a virtual element.

You could, for example, create a hidden IO gateway that reads analog and digital contacts and then passes on the retrieved information to a virtual element that shows the parameter values.

> [!NOTE]
> Hidden elements have no influence on the alarm state of a view. They are also not included in DataMiner dashboards or reports.

## Creating hidden elements

To create a hidden element, follow the normal procedure for element creation, but select the option *Hidden*.

> [!TIP]
> See also: [Adding elements](xref:Adding_elements)

## Viewing hidden elements

To view hidden elements in DataMiner Cube:

1. On the *Elements* page of a view card, click the filter icon in the lower right corner.

1. Select *Hidden elements*.
