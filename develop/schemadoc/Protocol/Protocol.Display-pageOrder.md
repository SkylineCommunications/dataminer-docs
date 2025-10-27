---
uid: Protocol.Display-pageOrder
---

# pageOrder attribute

Defines the order of the pages.

## Content Type

string

## Parent

[Display](xref:Protocol.Display)

## Remarks

By default, the pages will be ordered alphabetically.

It is also possible to add separators and web interface links as described below.

### Including separators

In case you want to insert a separator between pages in the page overview, provide an entry that starts with at least three dash characters (‘-‘), e.g. “-----”. It is recommended to use strings consisting exclusively of dashes for separators.

When a page starts with “-”, Cube will see this as a page separator. This is not the case when it also includes other text.

### Including web interfaces

In case you want to add a web interface link to the page overview, add an entry that has a "#" followed by the URI of the link (e.g. `Web Interface#http://[id:100]`).

The following placeholders can be used:

- [Polling IP]: Includes the polling IP (e.g. `Webinterface#http://[Polling Ip]`)

- [id:Parameter ID]: Includes the value of the specified parameter (e.g. `WebInterface#http://[id:ParameterID]`).

  > [!NOTE]
  > The parameter referenced in a placeholder must have [Interprete.Type](xref:Protocol.Params.Param.Interprete.Type) set to "string" and [RTDisplay](xref:Protocol.Params.Param.Display.RTDisplay) set to "true".

> [!NOTE]
> The identifiers used for separators and web interfaces should not match the name of an existing page in the protocol. In case it does, it will not be considered a separator or web interface link.

### Custom order for EPM integration data pages

From DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!-- RN 29748+42221 -->, if the `CPEIntegration_` prefix is added to data pages in an EPM protocol, you can apply a custom order for these pages in the *pageOrder* attribute of the *Display* tag in the protocol. For example:

```xml
<Display type="element manager" pageOptions="*;CPEOnly" defaultPage="General" pageOrder="General;Configurations;----------;CPEIntegration_Data/General;CPEIntegration_Data/Fiber;CPEIntegration_Data/Household;CPEIntegration_Data/Service Usage"/>
```
