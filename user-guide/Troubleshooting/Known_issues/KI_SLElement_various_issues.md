---
uid: KI_SLElement_various_issues
---

# Various SLElement issues

A number of issues could lead to SLElement problems, which could cause a memory leak or an unexpected DMA restart. Below you can find an overview of these issues.

| Issue | Affected versions | Workaround | Fix |
|--|--|--|--|
| When a parameter name is overridden on element level, this causes the parameter pointers to be recreated. However, these are not updated in the service cache, which can lead to a problem in SLElement. | TBD | If a parameter name override is needed, instead of configuring it in the information template at runtime, do so directly in the [Description.xml](xref:Elements1#descriptionxml) file while the DMA is stopped. | TBD |

> [!TIP]
> See also: [Various resolved SLElement issues](xref:KI_SLElement_various_resolved_issues)
