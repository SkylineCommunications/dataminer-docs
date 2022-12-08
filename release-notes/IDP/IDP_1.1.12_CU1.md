---
uid: IDP_1.1.12_CU1
---

# IDP 1.1.12 CU1

## Enhancements

#### Support for provisioning of elements with communication prefix in IP address \[ID_29147\]

IDP now supports the provisioning of elements that have a communication prefix in the IP address field, e.g. *wss://192.168.1.1*.

## Fixes

#### IDP setup wizard created Processes view even without Process Automation \[ID_29134\]

When the IDP setup wizard was executed, it could occur that it created the *Processes* view even if Process Automation was not available in the system.

#### Provisioned element not detected as managed element \[ID_29145\]

When a discovered element was provisioned from the *Discovery* data page of the IDP application instead of from the visual overview, it could occur that the request identifier was not included in the provisioning request. This caused the element to be created but not detected by IDP as a new managed element.
