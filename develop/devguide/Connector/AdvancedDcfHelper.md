---
uid: AdvancedDcfHelper
description: "Use the DataMiner Connectivity Framework helper package when implementing DCF behavior in a connector."
---

# DCF helper class

The Skyline.DataMiner.Core.ConnectivityFramework.Protocol package provides a helper class for implementing DataMiner Connectivity Framework (DCF) interfaces and connections in a connector. Add the package to the connector project; the helper complements the generated protocol interfaces and DCF configuration in *Protocol.xml* rather than replacing them. For setup details, see [Defining DCF interfaces](xref:AdvancedDcfDefiningInterfaces).

> [!NOTE]
> Before upgrading the package, check its compatibility with the connector's target SDK. An incompatible version can cause build or runtime errors.
