---
uid: IDP_Connectivity_tab
---

# Connectivity tab

This tab consists of two subtabs, as detailed below.

## Managed

This tab displays an overview of existing managed connections.

Select a managed element in the list and click *Show details* to view the external connections of the selected element.

## Discovered

This tab displays an overview of discovered connections and allows easy DCF provisioning.

The following buttons are available at the top of the overview:

- *Show details*: Displays detailed information on the connectivity discovery operation for the selected element in a pane on the right. This includes the status (*OK* or *NOK*), chassis ID and progress. It also includes the following two tables:

  - *Discovered Connections*: Lists the connections that have been discovered on the element and for which the elements on both side of the connection have reported its existence. You can select a discovered connection and click *Provision DCF* to provision the connection. The *Include Managed* toggle button at the top determines whether discovered connections that are already provisioned by IDP are included in the table or not.

  - *Unresolved Connections*: Lists the connections that were only discovered by the selected element, i.e. connections for which the element at the other side of the connection is still unknown. These connections cannot be provisioned in DCF.

- *Discover*: Starts a connectivity discovery action for the selected element.

- *Provision DCF*: (Called "Provision All DCF" prior to IDP 1.1.18.) Provisions the discovered connections for the selected element(s) in DCF.
