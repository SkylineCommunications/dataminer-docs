---
uid: SubscriptOptions_properties
---

## SubscriptOptions properties

- [ForceLockElements](#forcelockelements)

- [LockElements](#lockelements)

- [PerformChecks](#performchecks)

- [ScriptName](#scriptname)

- [Synchronous](#synchronous)

- [WaitWhenLocked](#waitwhenlocked)

#### ForceLockElements

Gets or sets a value indicating whether the script is allowed to steal the element lock from another user.

```txt
bool ForceLockElements
```

#### LockElements

Gets or sets a value indicating whether the script is allowed to lock the elements it needs.

```txt
bool LockElements
```

#### PerformChecks

Gets or sets a value indicating whether the script will verify the outcome of "set parameter" actions.

```txt
bool PerformChecks
```

#### ScriptName

Gets or sets the name of the subscript.

```txt
string Name
```

#### Synchronous

Gets or sets a value indicating whether the script will be executed synchronously.

```txt
bool Synchronous
```

#### WaitWhenLocked

Gets or sets a value indicating whether the script will delay execution instead of failing when another script is running on the same element or when the element is locked by another user.

```txt
bool WaitWhenLocked
```
