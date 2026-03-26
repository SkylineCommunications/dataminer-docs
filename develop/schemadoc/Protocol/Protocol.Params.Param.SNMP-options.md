---
uid: Protocol.Params.Param.SNMP-options
---

# options attribute

Specifies a dynamic get or set community string or a context name or ID for a particular connection.

## Content Type

string

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Remarks

- In the Param tag of the parameter that will contain the **GetCommunity** string to be used whenever an SNMP Get command has to be performed on connection 0 (i.e., the first connection), specify the following SNMP tag:

  ```xml
  <SNMP options="GetCommunity:0">
  ```

  In the Param tag of the parameter that will contain the **SetCommunity** string to be used whenever an SNMP Set command has to be performed on connection 0 (i.e., the first connection), specify the following SNMP tag:

  ```xml
  <SNMP options="SetCommunity:0">
  ```

  > [!NOTE]
  > If a parameter configured to contain a GetCommunity or SetCommunity string is either not initialized or empty, the default GetCommunity or SetCommunity string (as specified in the Element Wizard) will be used instead. The community string is only changed at runtime. So, after a restart of the element, the parameters configured to contain the community strings will be flushed.

- From DataMiner 10.5.6/10.6.0 onwards<!--RN 42676-->, in an SNMPv3 connector, you can use the value of a parameter as the **context name or context ID** for a connection.

  To use the parameter value as the context name for connection 0, specify the following SNMP tag:

  ```xml
  <SNMP options="ContextName:0">
  ```

  To use the parameter value as the context ID for connection 0, specify the following SNMP tag:

  ```xml
  <SNMP options="ContextID:0">
  ```

  > [!NOTE]
  >
  > - If the parameter is not initialized or contains an empty string, the default context name or context ID (i.e., an empty string) will be used.
  > - The context name and context ID can be changed at runtime. However, unless the `save` attribute is set to "true" on the parameter (e.g., `<Param id="1" save="true">`), the values will not persist after an element restart.
