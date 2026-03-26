---
uid: HyperLinks.HyperLink-combineParameters
---

# combineParameters attribute

Set to "true" in order to combine parameters in case multiple alarms have been selected.

## Content Type

boolean

## Parents

[HyperLink](xref:HyperLinks.HyperLink)

## Remarks

By default, the different parameters will be separated by means of "+" characters. If you want to specify a custom separator, add a separator attribute, and specify the separator.

Example:

```xml
<HyperLink id="1"
        version="2"
        name="Automation Script"
        menu="root/utils"
        type="script"
        combineParameters="true"
        separator="&amp;">
  Information Generator||Parameter=[ENAME]||Tooltip|
</HyperLink>
```

> [!NOTE]
> When you use an XML reserved character as a separator, it has to be escaped. (e.g., "`&amp;`" instead of "&").
