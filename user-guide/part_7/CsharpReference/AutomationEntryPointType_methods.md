---
uid: AutomationEntryPointType_methods
---

## AutomationEntryPointType methods

#### Equals(Object)

Determines whether the specified object is equal to the current object. Returns *true* if the specified object is equal to the current object.

```txt
bool Equals(Object obj)
bool Equals(AutomationEntryPointType other)
```

> [!NOTE]
> The Automation entry point type is considered equal if the ID of the specified object equals the ID of this object.

#### GetEntryPointTypeByID

Retrieves the entry point type by ID.

```txt
AutomationEntryPointType GetEntryPointTypeByID(AutomationEntryPointType.Types id)
```

#### GetHashCode

Calculates the hash code for this object.

```txt
int GetHashCode()
```
