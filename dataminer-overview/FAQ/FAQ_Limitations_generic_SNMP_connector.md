---
uid: FAQ_Limitations_generic_SNMP_connector
---

# What are the limitations when using Generic SNMP connector as opposed to a dedicated connector?

The Generic SNMP connector is mainly a table with entries for each SNMP parameter you want to poll from a device. By means of the OID, this connector queries the data from the device and displays it either as a string or a numeric value.

Major points to highlight when comparing the Generic SNMP connector with any other dedicated connector:

- **Tables**: The Generic SNMP connector is only useful for single parameters. It cannot retrieve full SNMP tables from a device.

- **Parsing**: The Generic SNMP connector simply retrieves a value from the device and parses it either as a string or a numeric value, nothing more. In a lot of cases, raw data that is retrieved from the device needs to be parsed in a specific format (which is not possible with the Generic SNMP connector):

    - Sometimes, datetime values are read as a number (milliseconds since epoch time) and need to be converted into a human-readable format.
    - Sometimes, alarms are retrieved in hexadecimal format and need to be displayed as different status parameters in a connector.
    - Sometimes, table parameter have to be converted to single parameters or vice versa (e.g. in case the device mib is not logically built).
    - Sometimes, a value needs to be divided or multiplied by 100 or whatever other value.
    - etc.

- **Visio files**: On each element, you can define a custom Visual Overview. If a Visio file is linked to an element with a specific custom protocol, all elements with that same protocol will show the same Visual Overview. In case you would use only Generic SNMP, all devices independent from the type of device will have the same Visual Overview and will look the same.

- **Sets**: Via the Generic SNMP connector, you can only retrieve info. You cannot change/set any value on the device.

- **Units**: The generic SNMP connector only retrieves the raw data from the device. No units are added to the parameter. Without unit, values do not say much. When operators who notice an alarm in the Alarm Console only see a value, they will not be able to figure out what is going on.

Summarized, the Generic SNMP connector is to be used for really simple devices that only have a few straightforward parameters, and even then a dedicated connector is to be preferred.

For example, below you can find 2 elements that monitor a laptop computer ("System Uptime" is highlighted). The first one uses the Generic SNMP connector while the second one uses the Microsoft Platform SNMP connector.

![Generic SNMP connector](~/dataminer-overview/images/FAQ_Generic_SNMP_connector.png)<br>
*Generic SNMP connector*

![Dedicated connector/connector](~/dataminer-overview/images/FAQ_Dedicated_connector.png)<br>
*Dedicated connector*
