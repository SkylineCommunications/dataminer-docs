---
uid: SLNetClientTest_modifying_engine_id
---

# Modifying the engine ID of a DMA

The engine ID that is used by a DMA for northbound SNMP traffic is determined in the file *SNMP Managers.xml*. In SNMPv3 traps sent by the DMA, this engine ID is indicated.

With the SLNetClientTest tool, you can modify this engine ID:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select *SNMPManagersConfigurationRequestMessage*.

1. Click the field next to the *Agents* argument and then click the *...* button to open the *ObjectEditorForm* window.

1. In the *ObjectEditorForm* window, configure the following variables:

   - *DataMinerID*: The DataMinerID indicated in the file *SNMP managers.xml* for the DMA in question.

   - *EngineBoots*: The number of times the SNMP engine restarted. Usually, this is set to 0.

   - *Text*: The "text" for the EngineID. Depending on the *Type* variable, this text can be an IPv4 address, an IPv6 address, a MAC address, regular text or octets (bytes).

   - *Type*: Determines the type of info entered in the *Text* variable. The following types can be selected:

     - *IPv4*: IPv4 address, e.g. "10.11.12.13".

     - *IPv6*: IPv6 address, e.g. "fd7a:e0de:acc2::".

     - *MAC*: MAC address, e.g. "1234567890ABCDEF".

     - *Text*: regular text, e.g. "MyID".

     - *Octets*: bytes, e.g. "12:34:56:78:90:AB:CD:EF".

     - *LocalEngine*, *Reserved* or *EnterpriseSpecific*: these types function in the same manner as *Octets* and are included for the sake of completeness. However, these should not be used in normal circumstances.

   - All other variables in this window are for viewing purposes only and should not be modified.

1. Click *OK* to close the *ObjectEditorForm* window.

1. Enter the following values for the arguments in the *Build Message* window:

   - *DataMinerID* and *HostingDataMinerID*: The DMA to which the message should be sent, which should be the same as the DataMinerID in the *ObjectEditorForm* window.

   - *Get*: False.

   - *Set*: True.

1. Click *Send Message*.

> [!TIP]
> See also: [SNMP Managers.xml](xref:SNMP_Managers_xml#snmp-managersxml)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
