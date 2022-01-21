---
uid: Configuring_SNMP_agent_community_strings
---

## Configuring SNMP agent community strings

By default, if no overrides are configured, the SNMP agent of a DMA will use “public” as the get community string and “private” as the set community string. You can override this on DMA level and on element level. Settings on element level override settings on DMA level.

To override this on DMA level:

1. Stop the DataMiner software.

2. Open *C:\\Skyline DataMiner\\DataMiner.xml*.

3. Specify the community strings in the SNMP tag:

    ```xml
    <SNMP writeCommunity="set" readCommunity="get"/>
    ```

4. Save the file.

5. Restart the DataMiner software.

To override this on element level:

1. Right-click the element in the Surveyor and click *Edit*.

2. In the *Advanced element settings* section, select *Enable SNMP agent*.

3. Specify the virtual IP address and subnet mask for the SNMP agent.

4. Select *Override defaults* and specify the custom get and set community string.

    > [!NOTE]
    > In the *Element.xml* file corresponding to the element, the community strings can be found in the *SNMPAgent* tag. For example: \<SNMPAgent readCommunity="get" writeCommunity="set">1\</SNMPAgent>. See [Element.xml](../../part_7/SkylineDataminerFolder/Elements1.md#elementxml).
    >
