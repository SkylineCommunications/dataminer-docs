---
uid: GPON_ONT
--- 

# EPM GPON ONT parameters

Below you can find the indexable parameters for an ONT in the GPON EPM solution.

These are parameters that will not be available in an alarm template, but that can be used by queries or Automation scripts to execute complex actions.

- **Serial number**: The serial number reported by the vendor. This value will be the index for this ONT element through all GPON EPM queries and aggregations.

- **Manufacturer**: The creator of the ONT. This field can be used in user-defined dashboards with [GQI](xref:Generic_Query_Interface) to get insights in performance and recalls.

- **Hardware version**: The model or revision for the electronics of the ONT. This cannot be included in an alarm or trend template.

- **Software version**: The firmware version running on the ONT.

- **Uptime**: The reported time in *timeticks* converted to a human-readable HH:mm:ss format. This indicates for how long the ONT has been working without a restart.

- **CPU**: Percentage value representing the overall CPU usage in an ONT. If this value gets too high, the ONT may be experiencing issues that can affect the subscriber service.

- **Memory**: Percentage value representing how much of the embedded memory is used in an ONT. If this value gets too high, the ONT may start dropping packets or require a restart to work properly again.

- **State**: The informed registration ONT status. This can be any of the following, though this varies from vendor to vendor:

  - Initial (O1)

  - Standby (O2)

  - Serial number (O3)

  - Ranging (O4)

  - Operation (O5)

- **Bias Current**: Numerical value representing the actual bias current.

- **Supply Voltage**: Numerical value representing the actual supply voltage.

- **Rx Power**: Numerical value representing the actual Rx power.

- **Tx Power**: Numerical value representing the actual Tx power.

- **Transceiver Temperature**: Numerical value representing the actual transceiver temperature.
