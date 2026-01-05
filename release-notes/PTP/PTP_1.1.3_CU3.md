---
uid: PTP_1.1.3_CU3
---

# PTP 1.1.3 CU3

## Enhancements

#### Support for Seiko Time Server Pro. TS-1550 connector added [ID 36415]

DataMiner PTP now supports the Seiko Time Server Pro. TS-1550 connector.

#### Support for EVS Neuron NAP - COMPRESS connector added [ID 36978]

DataMiner PTP now supports the EVS Neuron NAP - COMPRESS connector.

#### Improved detection of grandmaster changes [ID 38432]

The following improvements have been implemented in the PTP app:

- Overall performance and stability of the PTP app has improved when a PTP device starts synchronizing with a different grandmaster.

- In the *Summary* tab of the PTP app, the devices overview pop-up window now includes a *Refresh* button. When you click this button, the local clock identity and reporter grandmaster clock identity of all devices is retrieved and the status of the devices is calculated again. When elements are stopped, the clock identities will be filled in as *N/A* and the status will be filled in as *Unknown*. This refresh is also executed automatically every 30 minutes.

#### Standard DataMiner PTP Device mediation connector updated [ID 38433]

The included version of the Standard DataMiner PTP Device mediation connector has been incremented from 1.0.0.15 to 1.0.0.20. For details, refer to the version info in the [Catalog](https://catalog.dataminer.services/details/59d8a85e-5ee6-4203-a7c4-2b06ad665d96).

> [!NOTE]
> You can always deploy a new version of the mediation connector from the Catalog independently of the PTP application. See [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).
