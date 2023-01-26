---
uid: IDP_1.2.0_CU2
---

# IDP 1.2.0 CU2

## Enhancements

#### Improved logic to detect unmanaged elements [ID_35078]

The logic to detect unmanaged elements has been enhanced, so that IDP will now better be able to detect elements in the system, especially ones that have been duplicated manually by a user.

Duplicated elements retain the element properties used by IDP to determine whether an element is managed, so the logic will now double-check with the information present in the IDP app instead of only looking at these properties.

## Fixes

#### Element parameters not configured after exception while verifying whether new element has started [ID_35113]

In some cases, when IDP verified whether an element had started completely after it was created, an exception could be thrown, which could cause element parameters to not be configured properly.

To prevent this, a protection mechanism has now been added to capture this exception, and IDP will also retry the verification multiple times if necessary.

#### Problem in IDP when retrieving interfaces for unavailable element [ID_35166]

When IDP tried to retrieve the interfaces for an element that did not exist or was not available in the system, an error could occur that caused IDP to stop functioning properly.

In the DataMiner IDP Connectivity logging, an exception like the example below would be logged:

```txt
2022/12/08 07:03:37.801|SLManagedScripting.exe|ManagedInterop|ERR|0|180|QA100|100|Run|Exception thrown:
System.NullReferenceException: Object reference not set to an instance of an object.
```
