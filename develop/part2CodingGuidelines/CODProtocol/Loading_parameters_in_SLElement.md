---
uid: Loading_parameters_in_SLElement
---

# Loading parameters in SLElement

- RTDisplay must only be set to "true" when necessary. Every parameter of type "read" that has RTDisplay set to "true" will be loaded into the SLElement process. In case a parameter is not positioned on any page and RTDisplay is set to "true" in order to make it externally accessible, provide a comment explaining why this is necessary. In addition, set the onAppLevel attribute to "true".
