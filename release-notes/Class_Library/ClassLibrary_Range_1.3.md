---
uid: ClassLibrary_Range_1.3
---

# Class Library Range 1.3

> [!NOTE]
> Range 1.3.x.x is supported as from DataMiner version 10.1.11

### 1.3.0.1

#### Overloads have been added for specifying primary/display key [ID_35048]

Update to several methods on IDmsColumn. It refers to 'key' instead of 'primaryKey'. By default the software will check by Display Key and if not found, then by Primary Key.
These methods have also been marked obsolete.

New methods exist that accepts a KeyType to specify if you are using Primary Key or Display Key.

An overload method for SetValue has been added to IDmsColumn to specify which KeyType is being used.
