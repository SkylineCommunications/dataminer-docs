---
uid: FAQ_Limitations_generic_SNMP_connector
---

# What are the limitations when using the Generic SNMP connector as opposed to a dedicated connector?

The Generic SNMP connector consists mainly of a table with entries for each SNMP parameter polled from a specific device. By means of the OID, this connector queries the data from the device and displays it either as a string or a numeric value.

It has significant limitations compared to dedicated connectors:

- **Tables**: The Generic SNMP connector is only useful for single parameters. It cannot retrieve full SNMP tables from a device.

- **Parsing**: The Generic SNMP connector simply retrieves a value from the device and parses it either as a string or a numeric value, nothing more. In a lot of cases, raw data that is retrieved from the device needs to be parsed in a specific format (which is not possible with the Generic SNMP connector):

  - Sometimes, datetime values are read as a number (milliseconds since epoch time) and need to be converted into a human-readable format.
  - Sometimes, alarms are retrieved in hexadecimal format and need to be displayed as different status parameters in a connector.
  - Sometimes, table parameters have to be converted to single parameters or vice versa (e.g. in case the device MIB is not logically built).
  - Sometimes, a value needs to be divided or multiplied by 100 or some other value.
  - etc.

- **Visio files**: On each element, you can define a custom Visual Overview by linking it to a Visio drawing. If a Visio drawing is linked to an element with a specific custom connector, all elements with that same connector will show the same Visual Overview. In case you were to use only Generic SNMP, all devices, regardless of the type of device, would have the same Visual Overview and look the same.

- **Sets**: Via the Generic SNMP connector, you can only retrieve info. You cannot change or set any value on the device.

- **Units**: The Generic SNMP connector only retrieves the raw data from the device. No units are added to the parameter. Without units, values may not be clear. When operators who notice an alarm in the Alarm Console only see a value, it will be difficult for them to know what is going on.

In summary, the Generic SNMP connector is to be used for very simple devices that only have a few straightforward parameters, and even then a dedicated connector is to be preferred.

For example, below you can find two elements that monitor a laptop computer ("System Uptime" is highlighted). The first one uses the Generic SNMP connector, while the second one uses the Microsoft Platform SNMP connector.

![Generic SNMP connector](~/dataminer-overview/images/FAQ_Generic_SNMP_connector.png)<br>
*Generic SNMP connector*

![Dedicated connector/connector](~/dataminer-overview/images/FAQ_Dedicated_connector.png)<br>
*Dedicated connector*
