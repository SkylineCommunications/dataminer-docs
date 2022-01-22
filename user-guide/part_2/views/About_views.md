---
uid: About_views
---

# About views

DataMiner views are hierarchically structured folders containing elements and services.

In a DMS, there is always at least one view: the master view or root view. The name of that view is the name of the operator.

> [!TIP]
> See also:
> [Naming of elements, services, views, etc.](xref:NamingConventions#naming-of-elements-services-views-etc)

#### Using views to reflect your infrastructure layout

Views typically reflect the physical or functional layout of your infrastructure.

Examples:

- A view named “Location1” could, for example, contain all elements that are physically located at Location 1.

- A view named “Modulators” could, for example, contain all modulator elements.

> [!NOTE]
> - The same element or service can be placed in different views. A modulator element at Location 1, for example, can be placed in both the “Location1” view and the “Modulators” view.
> - Before you start to create views, make sure your views structure has been well thought through. It will have a large impact on the way you run your DMS, as it will influence security, navigation, filtering, and more.
>
