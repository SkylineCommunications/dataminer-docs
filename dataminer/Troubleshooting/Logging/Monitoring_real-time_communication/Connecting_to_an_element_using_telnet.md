---
uid: Connecting_to_an_element_using_telnet
---

# Connecting to an element using telnet

1. In Windows, open the *Run* window (e.g., by pressing Windows key + R).

1. Enter *telnet*, followed by a space and then the virtual IP address of the element.

> [!NOTE]
> You can only open a telnet session to monitor an element if the following is configured:
>
> - In *DataMiner.xml*, the `active` attribute of the `Telnet` tag must be set to "true". Note that this is an **obsolete** option that has been disabled by default for security reasons. Modifying this file requires a restart of the DataMiner Agent.
> - In the *Element.xml* of the element, the `Telnet` tag must be set to "1". Modifying this file requires a restart of the DataMiner Agent.
> - The element must have a virtual IP address.
> - The firewall must allow connections to TCP port 23.
