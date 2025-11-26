---
uid: ConnectionsService
---

# Service

In DataMiner Cube, it is possible to create enhanced services. These are services that can display additional information in their card. The content is defined in a service definition protocol.

The [Skyline Service Definition Basic](https://catalog.dataminer.services/details/809251d6-724d-499a-9c3c-d41ae1b5492b) protocol should be used as starting point when creating new service definitions. It already contains an overview of the status of the elements included in the service. These parameters should not be removed. It contains a parameter with ID 3 that is automatically filled in by DataMiner and that will cause a QAction to be triggered and fill in parameter 2 and table 100 (Service Severity and Service Element status).

The type of the protocol needs to be of type "service".
