---
uid: FAQ_Limitations_generic_SNMP_connector
---

# What are the limitations when using Generic SNMP driver as opposed to a dedicated driver?

The Generic SNMP driver is mainly a table with entries for each SNMP parameter you want to poll from a device. By means of the OID, this driver queries the data from the device and displays it either as a string or numeric value.

Major points to highlight when comparing the Generic SNMP driver with any other dedicated driver:

- Tables: The Generic SNMP driver is only useful for single parameters. It cannot retrieve full SNMP tables from a device.

- Parsing: The Generic SNMP driver simply retrieves a value from the device and parses it either as a string or a numeric value, nothing more. In a lot of cases, raw data that is retrieved from the device needs to be parsed in a specific format (which is not possible with the Generic SNMP driver):

    - E.g. date-times are sometimes read as a number (milliseconds since epoch time) and need to be converted into a human readable format.
    - Or sometimes, alarms are retrieved in HEX code and they have to be displayed as different status parameters in a driver.
    - Sometimes a conversion has to be done from table to single parameters or vice versa (e.g. in case the device mib is not logically built).
    - It’s possible that a value needs to be divided/multiplied by 100 or whatever other value.
    - …

- Visio: On each element you can define a custom Visual Overview. If a Visio is set on an element of a specific custom protocol, all elements with that same protocol show the same Visual Overview. In case you’d use only Generic SNMP, all devices independently from the type of device will have the same Visual Overview and will look the same.

- Sets: Via the Generic SNMP driver, you can only retrieve info. You cannot change/set any value into the device.

- Units: The generic SNMP driver just retrieves the raw data from the device. No units are added to the parameter. Without unit, this value doesn’t say much. For an operator that notices an alarm in the alarm console and he/she sees just a value, he/she won’t know what’s going on.

Summarized, the Generic SNMP Driver is more for really simple devices that only have a few straight forward parameters available, and even then it’s preferable to use a dedicated driver.

As an example, below are 2 elements to monitor a laptop (where we highlighted the “System Uptime”): the first one via Generic SNMP driver, the second one via Microsoft Platform SNMP driver:

![Generic SNMP Driver](~/dataminer-overview/images/FAQ_Generic_SNMP_connector.png)<br>
*Generic SNMP connector*

![Dedicated driver/connector](~/dataminer-overview/images/FAQ_Dedicated_connector.png)<br>
*Dedicated connector*
