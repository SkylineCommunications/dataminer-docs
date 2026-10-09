---
uid: ConnectionsService
description: "Learn how to create protocols for enhanced services, also known as service protocols, starting from the Skyline Service Definition Basic example."
---

# Service

In DataMiner Cube, it is possible to create enhanced services. These are services that can display additional information in their card. The content is defined in a service protocol (formerly also known as "service definition").

When creating new service protocols, use the [Skyline Service Definition Basic](https://catalog.dataminer.services/details/809251d6-724d-499a-9c3c-d41ae1b5492b) protocol as your starting point. This protocol already contains an overview of the status of the elements included in the service. These parameters should not be removed. It also contains a parameter with ID 3 that is automatically filled in by DataMiner and that will cause a QAction to be triggered and fill in parameter 2 and table 100 (Service Severity and Service Element status).

The type of the protocol needs to be of type "service".
