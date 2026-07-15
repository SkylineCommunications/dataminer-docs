---
uid: Categories_1.2.7
---

# Categories 1.2.7

> [!NOTE]
> This version requires:
>
> - DataMiner 10.5.11/10.6.0 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.

## Changes

### Enhancements

#### Improved category lookup and filtering across scopes [ID 45604]

Category lookup and filtering have been improved, especially in environments where multiple categories share the same name across different scopes or parent categories.

You can now retrieve categories more reliably by combining name, scope, and parent-category context. Filtering with category exposers has also been improved, making it easier to find categories in a specific scope, child categories under a specific parent, and top-level categories created directly at the root of a scope. The latter can now be identified correctly using the new `CategoryExposers.IsRootCategory`, making it easier to distinguish between top-level and nested categories.

This update also introduces a **breaking change**: `CategoryRepository.Read(string name)` and `CategoryRepository.Read(IEnumerable<string> names)` now throw `NotSupportedException`. These methods were ambiguous when duplicate category names existed across scopes, which could lead to incorrect or unreliable behavior. To avoid this, category reads must now be done with scope-aware overloads:

- `Read(Scope scope, string name)`
- `Read(Scope scope, IEnumerable<string> names)`

> [!IMPORTANT]
> If your code currently reads categories by name only, you will need to update it to use the new scope-based overloads.

### Fixes

#### Categories DevPack: Passing an empty filter returned all instances instead of none [ID 45497]

Passing an empty filter to the `Read(FilterElement<T>)` and `Count(FilterElement<T>)` methods of the different repositories available through the Skyline.DataMiner.Dev.Utils.Solutions.Categories DevPack caused all instances of that repository to be returned. This has been fixed: `Read` now returns an empty enumerable, and `Count` returns `0` when the filter is empty.
