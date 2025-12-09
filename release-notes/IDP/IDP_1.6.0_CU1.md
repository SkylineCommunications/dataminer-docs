---
uid: IDP_1.6.0_CU1
---

# IDP 1.6.0 CU1

## Fixes

#### IDP Provisioning: Missing method exception [ID 44301]

When provisioning was done through the Connector API or a user-defined API, this could result in a missing method exception because SLAutomation and SLScripting do not perform assembly unification. This issue has been resolved by unifying the dependencies.
