---
uid: Overview_MediaOps_supported_connectors
---

# Supported connectors for MediaOps

For connectors that need to be able to set up flows through Flow Engineering and report as-is flows to the Flow Monitoring app, some integration work is required:

- These connectors need to implement an API that can accept a standardized message coming from Flow Engineering and translate this into commands that need to be sent to the device; so that the connection requested by Flow Engineering can effectively be set up.

- These connectors must have certain tables where they report flows monitored on the device, so that these can be visualized in the as-is flow paths in the Flow Monitoring app.

The following connectors are currently already integrated to set up and monitor flows in the MediaOps solution:

> [!IMPORTANT]
> This list provides an indicative overview of connectors that are intended to be integrated with MediaOps. However, note that this list is still subject to potential changes and updates.

| Connector | Flow Engineering | Flow Monitoring | Virtual Signal Groups (automatic import) |
|--|--|--|--|
| [AMWA NMOS IS-05](https://catalog.dataminer.services/details/connector/7691) | Yes | Yes | Yes |
| [Arista MCS](https://catalog.dataminer.services/details/connector/7867) | Yes | Yes | - |
| [NetInsight Nimbra Edge](https://catalog.dataminer.services/details/connector/7656) | Yes | Yes | - |
| [AppearTV X20 Platform](https://catalog.dataminer.services/details/connector/5412) | Yes | Yes | - |

> [!TIP]
> Are you a developer looking to integrate new connectors into the solution? Take a look at our example [on GitHub](https://github.com/SkylineCommunications/SLC-C-Example_Flow-Engineering/blob/main/README.md).
