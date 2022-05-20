---
uid: LogicActionPriorityLockUnlock
---

# priority lock/priority unlock

These actions must be executed on protocol.

These actions are similar to the "lock" and "unlock" actions. The only difference is that a "priority lock" gets priority over any other action.

> [!NOTE]
> A “priority lock” action will not unlock existing locks. It will wait until the existing lock is unlocked.

## Attributes

### Type@nr

(Optional.) Specifies the connection on which the lock has to be taken/released.

Default: 0

## Examples

```xml
<Action id="10">
  <On>protocol</On>
  <Type nr="1">priority lock</Type>
</Action>
```
