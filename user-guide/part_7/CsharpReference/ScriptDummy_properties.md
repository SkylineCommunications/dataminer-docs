---
uid: ScriptDummy_properties
---

## ScriptDummy properties

#### Name

Gets the name of the dummy.

```txt
string Name
```

Example:

```txt
var dummy = engine.GetDummy("dummy1");
string elementName = element.Name; // Returns "dummy1".
```

> [!NOTE]
> To retrieve the name of the element the dummy is linked to, use the *ElementName* property.
