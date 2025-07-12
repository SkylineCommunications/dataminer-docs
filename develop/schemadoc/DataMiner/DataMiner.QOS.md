---
uid: DataMiner.QOS
---

# QOS element

Configures the DiffServ marker on network traffic from SLPort to polled devices.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***Union*** |  |  |
| &#160;&#160;***string restriction*** |  |  |
| &#160;&#160;&#160;&#160;Enumeration | Background |  |
| &#160;&#160;&#160;&#160;Enumeration | BestEffort |  |
| &#160;&#160;&#160;&#160;Enumeration | ExcellentEffort |  |
| &#160;&#160;&#160;&#160;Enumeration | AudioVideo |  |
| &#160;&#160;&#160;&#160;Enumeration | Voice |  |
| &#160;&#160;&#160;&#160;Enumeration | Control |  |
| &#160;&#160;***integer restriction*** |  |  |

## Parents

[DataMiner](xref:DataMiner)

## Remarks

This can be done in two ways:

- By specifying one of the following predefined QoS traffic types (in ascending order of priority):

  - Background
  - BestEffort (default DiffServ marker)
  - ExcellentEffort
  - AudioVideo
  - Voice
  - Control

  Example:

  ```xml
  <DataMiner>
    ...
    <QOS diffServ="ExcellentEffort" />
    ...
  </DataMiner>
  ```

  For more information on these traffic types, see <https://msdn.microsoft.com/en-us/library/windows/desktop/aa374102(v=vs.85).aspx>.

- By specifying a custom DSCP marker referred to by a decimal value.

  Example:

  ```xml
  <DataMiner>
    ...
    <QOS diffServ="16" />
    ...
  </DataMiner>
  ```

  For more information, see:

  - <https://en.wikipedia.org/wiki/Differentiated_services#Class_Selector>
  - <https://tools.ietf.org/html/rfc2474>

  > [!NOTE]
  > - This QoS DiffServ packet marking feature makes use of the Windows qWave library, which is loaded dynamically. For more information, see <https://technet.microsoft.com/en-us/library/hh831592(v=ws.11).aspx>.
  > - The current implementation is limited to non-adaptive flows and protocols that make use of base sockets. Web-socket traffic and smart-serial traffic is not supported.
