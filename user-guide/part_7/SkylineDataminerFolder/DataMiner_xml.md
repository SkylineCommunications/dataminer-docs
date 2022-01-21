---
uid: DataMiner_xml
---

## DataMiner.xml

In the file *DataMiner.xml*, you can specify a number of general system settings.

- This file is located in the following folder:

    *C:\\Skyline DataMiner\\*

- Before you make changes to this file, always stop DataMiner. Restart DataMiner when your changes have been saved.

### Example

This is an example of a *DataMiner.xml* file:

```xml
<DataMiner id="7" disableElementIP="false">
  <AlarmSocket port=”5024”/>
  <PollSocket port=”5025”/>
  <SMTP>...</SMTP>
  <Colors>...</Colors>
  <LDAP nonDomainLDAP="true"
      host="dc.gtc.be" port="389"
      username="" password=""
      auth=""
      namingContext="DC=gtc,DC=local">
    ...
  </LDAP>
  <ProcessOptions protocolProcesses="5"/>
  <Logging>
    <Debug>0</Debug>
    <Error>0</Error>
    <Info>1</Info>
  </Logging>
</DataMiner>
```

### Alphabetical overview of settings

Below you can find an alphabetical overview of settings that can be specified in the *DataMiner.xml* file.

- **DataMiner**:

    This tag can have the following attributes:

    | Attribute       | Description                                                                                                                                                                                                         |
    |-------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | disableElementIP= | Optional attribute. See [Forcing a DataMiner Agent to work without virtual IP addresses](../../part_3/DataminerAgents/General_DMA_configuration.md#forcing-a-dataminer-agent-to-work-without-virtual-ip-addresses). |
    | elementid=        | The ID of the most recently added element.                                                                                                                                                                          |
    | id=               | The DMA ID. See [Changing the DataMiner ID of a DMA](../../part_3/DataminerAgents/General_DMA_configuration.md#changing-the-dataminer-id-of-a-dma).                                                                 |
    | licenseNotice=    | Automatically generated attribute. Contains information about which license notices have been generated for this agent.                                                                                             |
    | protocolVisioLnk= | When set to “1”, this tag indicates that DataMiner has attempted to create all the Visio.lnk files which indicate the current Visio file for a protocol. This is used for troubleshooting purposes.                 |
    | readProperties=   | Automatically generated attribute, indicating that existing properties that were previously saved in the info database table are now saved in *Element.xml*.                         |
    | readElementData=  | Automatically generated attribute, indicating that previously configured element data that was saved in *DataMiner.xml* has been moved to the element data database tables.          |
    | safeMode=         | Optional attribute. If set to “true”, elements will not be started using multiple threads.                                                                                                                          |

- **DataMiner.AlarmSocket**:

    See [Configuring the TCP-IP socket settings](../../part_3/TCPIPSockets/Configuring_the_TCP-IP_socket_settings.md#configuring-the-tcp-ip-socket-settings).

- **DataMiner.ClearableAlarmStormProtection**

    Supported from DataMiner 10.2.0/10.1.6 onwards. The attributes of this tag allow you to configure alarm storm protection for clearable alarms.

    | Attribute | Description                                                                                                                                                                                                              |
    |-------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | max         | The maximum threshold for the alarm storm mode. If this threshold is crossed, newly generated clearable alarms will be closed instead of clearable. Default value: 1000.                                                 |
    | min         | The minimum threshold for the alarm storm mode: If the number of clearable alarm trees drops below this number, the alarm storm protection is lifted and newly generated alarms are clearable again. Default value: 100. |

    > [!NOTE]
    > If you change this configuration, you must do so on every DMA in a cluster, as this setting is not automatically synchronized.

    > [!TIP]
    > See also:
    > [Clearing alarms](../../part_2/alarms/Clearing_alarms.md)

- **DataMiner.Colors**:

    See [Changing the default alarm colors](../../part_2/alarms/Changing_the_default_alarm_colors.md).

- **DataMiner.DMA**:

    This tag can have several subtags:

    | Subtag                          | Description                                                                                                                                                                                                                                 |
    |-----------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | DMAName                           | See [Changing the name of a DMA](../../part_3/DataminerAgents/General_DMA_configuration.md#changing-the-name-of-a-dma).                                                                                                                     |
    | Location1 / Location2 / Location3 | Location information of the DataMiner Agent. This information can also be found and modified in DataMiner Cube. See [Specifying your company data](../../part_3/DataminerAgents/General_DMA_configuration.md#specifying-your-company-data). |

    In addition, the tag can have one optional attribute, *publicDNS*. When a DNS name is specified for this attribute, it will be used instead of the DataMiner IP address for links to the DataMiner user interface in notification emails.

- **DataMiner.ID**:

    Information about the ID ranges to be used for e.g. view creation. This information allows multiple DataMiner agents to create views at the same time, without creating conflicts.     Example:

    ```xml
    <DataMiner>
    ...
      <ID>
        <Views current="20004" currentOwn="2320001"/>
      </ID>
    </DataMiner>
    ```

- **DataMiner.IP**:

    This tag can have one optional attribute, *skipMAC*, which tells DataMiner to ignore certain network adapters, so that these will not be considered as a local network interface. Multiple addresses can be specified by using a ”;” separator.     This can be necessary in case special VPN connections end up in front of the normal adapters in the order of the network adapters, and changing the order of the adapters does not work. In this case, DataMiner could see the primary IP address as 127.0.0.1, and the secondary IP address would then have the value from the actual first NIC.     Example:

    ```xml
    <DataMiner>
      <IP skipMAC="12-34-56-78-90-AB;F1-F2-F3-F4-F5-F6">
      ...
      </IP>
    </DataMiner>
    ```

    In addition, the tag has three subtags: *VirtualIPFrom*, *VirtualIPTo*, and *VirtualIPMask*. These indicate the IP address range for virtual IP addresses that may be assigned to elements.

- **DataMiner.LDAP**

    Contains the LDAP configuration, as explained in [Configuring LDAP settings](../../part_3/security/Configuring_LDAP_settings.md).     This tag can have the following attributes:

    | Attribute        | Description                                                                                                                                                                                                                                                                                                                             |
    |--------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | nonDomainLDAP      | Should be set to “true” to make sure that DMAs that are not connected to a domain can use Active Directory or open LDAP. If this is specified on a DMA that is in a domain, this attribute is not used.                                                                                                                                 |
    | host               | The name or IP of the LDAP server. Alternatively, the hostname can be specified in the *namingContext* attribute, in which case it should precede the actual naming context data and be separated from it by a forward slash.                                                                            |
    | port               | The port to connect to the LDAP server.                                                                                                                                                                                                                                                                                                 |
    | username           | The user name to connect to the LDAP server, in case it requires authentication.                                                                                                                                                                                                                                                        |
    | password           | The password to connect to the LDAP server, in case it requires authentication.                                                                                                                                                                                                                                                         |
    | auth               | The authentication method to access the LDAP server. Possible methods: *ANONYMOUS*, *MAX*, *MEMBER_SYSTEM*, *PASSWORD*, *SASL*, and *SIMPLE*. |
    | namingContext      | A suffix that identifies the top entry of the LDAP hierarchy. If no naming context is specified when Active Directory is used, it will be auto-discovered. When OpenLDAP is used, a naming context must be specified.                                                                                                                   |
    | notifications      | When Active Directory is used, by default DataMiner also automatically receives updates whenever changes occur in the domain. Set this attribute to false to disable these automatic updates.                                                                                                                                           |
    | referralConfigured | If referrals are not configured, this attribute should be set to false in order to make a connection with the other Domain Controller and query it directly.<br> See [Remarks regarding LDAP settings](../../part_3/security/Configuring_LDAP_settings.md#remarks-regarding-ldap-settings).                                             |
    | useForFullName     | Determines whether the full user names will be retrieved by means of LDAP (“true”) or NetAPI (“false”).                                                                                                                                                                                                                                 |
    | useSSL             | To connect to the LDAP server with SSL, set this attribute to “true”. (Supported from DataMiner 9.5.6 onwards.)                                                                                                                                                                                                                         |

    In addition, it can have the following subtags:

    - DataMiner.LDAP.Group:

        | Tag              | Description                                                                                              |
        |--------------------|----------------------------------------------------------------------------------------------------------|
        | Filter             | The LDAP search filters to find all groups.                                                              |
        | Classname          | The object class(es) that identify groups. Multiple values can be separated with pipe characters (“\|”). |
        | NameField          | The name of the group.                                                                                   |
        | DistinguishedField | The alias of the group.                                                                                  |
        | DescriptionField   | The description of the group.                                                                            |

    - DataMiner.LDAP.QueryTimeout:

        Contains the number of seconds after which an individual LDAP request will time out (by default 300). Supported from DataMiner 10.0.6 onwards.

        > [!NOTE]
        > This timeout applies to every individual LDAP query. As a result, a request to refresh all groups (which consists of multiple requests) could have a total timeout that is much larger than the configured value.

    - DataMiner.LDAP.User

        | Tag            | Description                                                                                             |
        |------------------|---------------------------------------------------------------------------------------------------------|
        | Filter           | The LDAP search filters to find all users.                                                              |
        | Classname        | The object class(es) that identify users. Multiple values can be separated with pipe characters (“\|”). |
        | AccountNameField | The user’s account name.                                                                                |
        | DisplayNameField | The user name that will be displayed.                                                                   |
        | DescriptionField | The user’s description.                                                                                 |
        | EmailField       | The user’s email address.                                                                               |
        | PhoneField       | The user’s fixed phone number.                                                                          |
        | MobileField      | The users mobile phone number                                                                           |
        | PagerField       | The user’s pager number.                                                                                |

    For more information, refer to [Configuring LDAP settings](../../part_3/security/Configuring_LDAP_settings.md).

- **DataMiner.Logging**

    This tag has three subtags indicating the logging level for Info logging, Debug logging and Error logging. See [Consulting the DataMiner logs in DataMiner Cube](../../part_6/logging/Consulting_the_DataMiner_logs_in_DataMiner_Cube.md).
    From DataMiner 9.6.5 onwards, an additional *\<DaysToKeep>* subtag can be specified, which determines for how many days log files are kept in the folder *C:\\Skyline DataMiner\\Logging*. If this tag is not specified or if its value is 0, log files will be kept for 100 days.     Example:

    ```xml
    <DataMiner>
      ...
      <Logging>
      ...
      <DaysToKeep>30</DaysToKeep>
      </Logging>
      ...
    </DataMiner>
    ```

- **DataMiner.MobileGateway**

    This tag has the following two subtags.

    | Tag    | Description                                                                    |
    |----------|--------------------------------------------------------------------------------|
    | IP       | IP address of the DataMiner Agent that has the mobile gateway device attached. |
    | UserName | Currently not used.                                                            |

- **DataMiner.NetworkAdapters**

    From DataMiner 9.0.0 CU20/9.5.0 CU3/9.5.7 onwards, you can use this tag to override the order of the network adapters on a DataMiner Agent. This can be useful to prevent issues in case the order in Windows changes for some reason (e.g. because there is a new network adapter).
    To do so, specify a number of *\<MAC>* subtags, each containing a MAC address.
    To determine its primary IP address, the DataMiner Agent will place the adapters with matching MAC addresses first in its list. In other words, the primary IP address of the DataMiner Agent will be the one for which the first valid MAC address is found in this tag.     For example:

    ```xml
    <NetworkAdapters>
      <MAC>B0-83-FE-B3-F8-0B</MAC>
      <MAC>E8-EE-7A-CA-97-B0</MAC>
    </NetworkAdapters>
    ```

- **DataMiner.PollSocket**

    See [Configuring the TCP-IP socket settings](../../part_3/TCPIPSockets/Configuring_the_TCP-IP_socket_settings.md#configuring-the-tcp-ip-socket-settings).

- **DataMiner.ProcessOptions**

    See:

    - [Setting the number of simultaneously running SLPort processes](../../part_3/DataminerAgents/Configuration_of_DataMiner_processes.md#setting-the-number-of-simultaneously-running-slport-processes)

    - [Setting the number of simultaneously running SLProtocol processes](../../part_3/DataminerAgents/Configuration_of_DataMiner_processes.md#setting-the-number-of-simultaneously-running-slprotocol-processes)

    - [Having separate SLScripting processes created for every protocol being used](../../part_3/DataminerAgents/Configuration_of_DataMiner_processes.md#having-separate-slscripting-processes-created-for-every-protocol-being-used)

    - [Having replicated elements handled by one SLProtocol process](../../part_3/DataminerAgents/Configuration_of_DataMiner_processes.md#having-replicated-elements-handled-by-one-slprotocol-process)

    - [Running SLScripting as a service](../../part_3/DataminerAgents/Configuration_of_DataMiner_processes.md#running-slscripting-as-a-service)

- **DataMiner.QOS**

    Available from DataMiner 9.5.7 onwards. This tag can be used to customize the DiffServ marker on network traffic from SLPort to polled devices.     This can be done in two ways:

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

        For more information on these traffic types, see:

        - https://msdn.microsoft.com/en-us/library/windows/desktop/aa374102(v=vs.85).aspx

    - By specifying a custom DSCP marker (on systems running Windows 7 or a later version) referred to by a decimal value.

        Example:

        ```xml
        <DataMiner>
          ...
          <QOS diffServ="16" />
          ...
        </DataMiner>
        ```

        For more information, see:

        - https://en.wikipedia.org/wiki/Differentiated_services#Class_Selector

        - https://tools.ietf.org/html/rfc2474

        > [!NOTE]
        > - This QoS DiffServ packet marking feature makes use of the Windows qWave library, which is loaded dynamically. For more information, see: https://technet.microsoft.com/en-us/library/hh831592(v=ws.11).aspx
        > - The current implementation is limited to non-adaptive flows and protocols that make use of base sockets. Web-socket traffic and smart-serial traffic is not supported.

- **DataMiner.SMTP**

    See [Configuring outgoing email](../../part_3/DataminerAgents/General_DMA_configuration.md#configuring-outgoing-email).

- **DataMiner.SNMP**

    See:

    - [Changing SNMP agent ports](../../part_3/SNMP/Changing_SNMP_agent_ports.md)

    - [Configuring SNMP agent community strings](../../part_3/SNMP/Configuring_SNMP_agent_community_strings.md)

    - [Disabling element SNMP agent functionality](../../part_3/SNMP/Disabling_element_SNMP_agent_functionality.md)

    - [Enabling DataMiner SNMP agent functionality](../../part_3/SNMP/Enabling_DataMiner_SNMP_agent_functionality.md)

    - [Adjusting the SNMP inform message cache size](../../part_3/SNMP/Adjusting_the_SNMP_inform_message_cache_size.md)

- **DataMiner.SNMPv3**

    See:

    - [Customizing the trap reception ports of a DMA](../../part_3/SNMP/Changing_SNMP_agent_ports.md#customizing-the-trap-reception-ports-of-a-dma)

    - [Enabling notifications in case SNMPv3 traps cannot be processed](../../part_3/SNMP/Enabling_notifications_in_case_SNMPv3_traps_cannot_be_processed.md)

- **DataMiner.SnmpTrapDistribution**

    Available from DataMiner 9.6.5 onwards. If set to false, SNMP trap distribution will be disabled within the DMS.     Example:

    ```xml
    <DataMiner>
      ...
      <SnmpTrapDistribution>false</SnmpTrapDistribution>
      ...
    </DataMiner>
    ```

- **DataMiner.Telnet**

    Available from DataMiner 9.5.6 onwards. Can be used to activate or deactivate the Telnet interface for a DMA using the attribute active=”true” or active=”false”, respectively.     Up to DataMiner 9.6.4, by default, this tag is not present and the Telnet interface is activated. From DataMiner 9.6.5 onwards, for security reasons, the Telnet interface is deactivated by default.     Example:

    ```xml
    <DataMiner>
      <Telnet active="true"/>
      ...
    </DataMiner>
    ```

- **DataMiner.WarningThreshold**

    When a DMA is approaching the limit of its element license, by default warning messages are generated. From DataMiner 9.6.4 onwards, it is possible to customize when these messages are generated using the *WarningThreshold* tag     The following values can be configured in this tag:

    - A value lower than or equal to 0: The option will have no effect.

    - A value between 0 and 1: The value represents the percentage of active elements compared to the total allowed elements. Once this percentage is reached, warnings will be generated. However, license limit warnings are never generated if the DMA is below 80% of its total capacity, even if a value lower than 0.8 is configured here.

    - A value higher than 1: No warnings will be generated.

    For example, if you specify the following, warnings will only be generated once the DMA is at 99% of its capacity: *\<WarningThreshold>0.99\</WarningThreshold>*
