---
uid: IDP_1.2.0_CU1
---

# IDP 1.2.0 CU1

## Fixes

#### SLProtocol RTE during rack layout initialization [ID_33938]

If there was a mismatch between the data in DataMiner and in the Rack Layout Manager, or the information became out of sync in such a way that the rack layout could not be recovered, an SLProtocol run-time error could be thrown.

To prevent this, string comparisons will now ignore casing to avoid a mismatch between the local data and the DataMiner data, and detection of element and view modifications has been improved.

#### RTE when provisioning more than 200 elements [ID_34131]

If there was a request to provision more than 200 elements, it could occur that the QAction responsible for provisioning the elements took more than 15 minutes to complete, causing a run-time error.

To prevent this, the QAction has now been changed into a queued QAction.
