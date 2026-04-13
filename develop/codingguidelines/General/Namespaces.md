---
uid: Namespaces
---

# Namespaces

- Components of a namespace name should use PascalCasing and should be separated with periods. In case a component uses nontraditional casing, this casing should be adhered to (even if it deviates from the above-mentioned casing rules).

- The name of a namespace should be different from the name of types defined in that namespace.

- In case a generic QAction contains code related to different topics (e.g., a general QAction defining some methods to process an XML response and a number of classes defining the data model used in the connector), different namespaces should be introduced so related things can be grouped together. The name of the namespace should start with Skyline.Protocol.
