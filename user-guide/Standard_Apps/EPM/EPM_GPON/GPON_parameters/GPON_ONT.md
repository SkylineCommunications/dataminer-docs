---
uid: GPON_ONT
--- 

# ONT Available parameters

The current parameter list for an ONT in the GPON EPM solution is:

## Indexable parameters

These are parameters that will not be available in an alarm template, but can be used by queries or automation scripts to execute complex actions.

- **Serial number:** as informed by the vendor, this value will be the index for this ONT element through all GPON EPM queries and aggregations.
- **Manufacturer:** who created this ONT? This field can be used in user defined dashboards with **GQI** to have insights on performance and recalls.
- **Hardware version:** model or revision for the electronics that compose the ONT. It can't be included in an alarm or trend template.
- **Software version:** firmware version that is running on the ONT.
- **Uptime:** the reported time in _timeticks_ converted to a human readable HH:mm:ss format. This indicates for how long the ONT has been working without a restart.
- **CPU:** percentage value that represents the overall CPU usage in an ONT, if this value gets too high, the ONT may be experiencing issues that may impact the subscriber service.
- **Memory:** percentage value that represents how much of the embedded memory is used in an ONT, if this value gets too high, the ONT may start dropping packets or require a restart to work properly again.
- **State:** the informed registration ONT status. It can be any of the following, Initial (O1) -> Standby (O2) -> Serial number (O3) -> Ranging (O4) -> Operation (O5). However, it varies too much from vendor to vendor.
- **Bias Current:** numerical value informing the actual Bias current.
- **Supply Voltage:** numerical value informing the actual Supply Voltage.
- **Rx Power:** numerical value informing the actual Rx Power.
- **Tx Power:** numerical value informing the actual Tx Power.
- **Transceiver Temperature:** numerical value informing the actual Transceiver Temperature.
