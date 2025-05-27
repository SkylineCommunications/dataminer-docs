---
uid: Configuring_SNMP_agent_community_strings
---

# Configuring SNMP agent community strings

By default, if no overrides are configured, the SNMP agent of a DMA will use “public” as the get community string and “private” as the set community string. You can override this on DMA level and on element level. Settings on element level override settings on DMA level.

To override this on DMA level:

1. Stop the DataMiner software.

1. Open `C:\Skyline Dataminer\DataMiner.xml`.

1. Specify the community strings in the SNMP tag:

   ```xml
   <SNMP writeCommunity="set" readCommunity="get"/>
   ```

1. Save the file.

1. Restart the DataMiner software.

To override this on element level:

1. Right-click the element in the Surveyor and click *Edit*.

1. In the *Advanced element settings* section, select *Enable SNMP agent*.

1. Specify the virtual IP address and subnet mask for the SNMP agent.

1. Select *Override defaults* and specify the custom get and set community string.
