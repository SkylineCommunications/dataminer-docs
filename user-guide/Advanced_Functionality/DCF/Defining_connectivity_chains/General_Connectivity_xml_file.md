---
uid: General_Connectivity_xml_file
---

# General Connectivity.xml file

The main *Connectivity.xml* file is located in the *C:\\Skyline DataMiner\\Connectivity\\* folder. It can contain two settings:

| Tag | Description |
|--|--|
| ServiceConnectivity | Determines whether changes in connectivity settings can trigger element inclusion/exclusion within services. If set to “true”, users configuring services will be able to conditionally include elements in a service based on whether they are part of a particular connectivity chain.<br> Values: “true” or “false”<br> See [Conditionally including an element in a service](xref:Conditionally_including_an_element_in_a_service). |
| RedundancyGroupConnectivity | Determines whether changes in connectivity settings can trigger element switches within redundancy groups.<br> Values: “true” or “false”<br> See [Creating a redundancy group](xref:Creating_a_redundancy_group). |

> [!NOTE]
> These settings should be set to “true” AFTER all connectivity chains have been configured, but BEFORE users start to configure services and redundancy groups.

Example of the main *Connectivity.xml* file:

```xml
<DCF>
  <ServiceConnectivity>true</ServiceConnectivity>
  <RedundancyGroupConnectivity>true</RedundancyGroupConnectivity>
</DCF>
```
