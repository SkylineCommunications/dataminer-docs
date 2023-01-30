---
uid: SRM_1.2.28_CU1
---

# SRM 1.2.28 CU1

> [!NOTE]
> This version requires that **DataMiner 10.2.7.0-11922 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## Enhancements

#### New RenameElement method [ID_34991]

A new method, *RenameElement*, had been added to the *IActionableElement* in the SLSRMLibrary. It will allow you to change the name of a DataMiner element.

```csharp
/// <summary>
/// Changes the name of an element.
/// </summary>
/// <param name="element">The element to be renamed.</param>
/// <param name="engine"><see cref="Engine"/> instance used to communicate with DataMiner.</param>
/// <param name="name">New element name.</param>
/// <exception cref="ArgumentNullException">In case <paramref name="element"/> or <paramref name="engine"/> are null.</exception>
/// <exception cref="ArgumentException">In case <paramref name="name"/> is null or white-space.</exception>
public static void RenameElement(this IActionableElement element, Engine engine, string name)
```
