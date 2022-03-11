---
uid: Protocol.RCA.Protocol.Link-valueFilter
---

# valueFilter attribute

Specifies a filter.

## Content Type

string

## Parent

[Link](xref:Protocol.RCA.Protocol.Link)

## Remarks

If you want to specify an RCA level on tables that have no direct foreign key relationship, it is sometimes necessary to specify a filter.

If, for example, you have frequencies per node table (19100) and frequencies per street table (19400), these tables are connected to the node table and street table respectively. But if you want RCA between the frequency tables, you need the select the correct frequency (19403 == 19103):

```xml
<Link path="19104;19404" valueFilter="19104,19403 == *19103*"/>
```

If you need multiple value filters, you can separate them with semicolons:

```xml
<Link path="30905;19106;19406" valueFilter="30905,19103 == *30903*;19106,19403 == *19103*"/>
```

In this case, table 30900 and 19100 should be linked by linking columns 19103 and 30903, and tables 19100 and 19400 should be linked by linking columns 19403 and 19103.
