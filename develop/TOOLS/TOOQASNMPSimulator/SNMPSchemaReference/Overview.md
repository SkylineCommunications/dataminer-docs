---
uid: DeviceSimulator_SNMP_Schema_Reference_Overview
---

# SNMP simulation schema reference

The latest simulator will create a file marked as AutoBuildVersion="1.3", which looks like the empty XML overview below. Earlier versions do not support some of the tags and expect different OID ordering. 

* \<[Simulation](xref:DeviceSimulator_SNMP_Schema_Simulation)>

  * \<[Agents](xref:DeviceSimulator_SNMP_Schema_Simulation_Agents)>

      * \<[Agent](xref:DeviceSimulator_SNMP_Schema_Simulation_Agents_Agent)
      ip=""
      MacAddress=""
      Name=""
      Port=""
      AutoBuildVersion=""
      engineID=""
      userName=""
      authenticationAlgorithm=""
      encryptionAlgorithm=""
      authenticationPassword=""
      encryptionPassword=""
      />

  * \</Agents>

  * \<[ProxyAgents](xref:DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents)>

    * \<[ProxyAgent](xref:DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents_ProxyAgent)
    ip=""
    MacAddress=""
    Name=""
    Port=""
    AutoBuildVersion=""
    engineID=""
    userName=""
    authenticationAlgorithm=""
    encryptionAlgorithm=""
    authenticationPassword=""
    encryptionPassword=""
    deviceIP=""
    devicePort=""
    maxFileSize=""
    maxDuration=""
    />

  * \</ProxyAgents>

  * \<[DatabaseAgents](xref:DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents)>

    * \<[DatabaseAgent](xref:DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents_DatabaseAgent)
    ip=""
    MacAddress=""
    Name=""
    Port=""
    AutoBuildVersion=""
    engineID=""
    userName=""
    authenticationAlgorithm=""
    encryptionAlgorithm=""
    authenticationPassword=""
    encryptionPassword=""
    databaseType=""
    databaseServer=""
    databaseName=""
    databaseTable=""
    user=""
    password=""
    />

  * \</DatabaseAgents>

  * \<[Options](xref:DeviceSimulator_SNMP_Schema_Simulation_Options)>

    * \<[MaxResponseWeight](xref:DeviceSimulator_SNMP_Schema_Simulation_Options_MaxResponseWeight)>\</MaxResponseWeight>

  * \</Options>

  * \<[DefaultDefinitionAttributes](xref:DeviceSimulator_SNMP_Schema_Simulation_DefaultDefinitionAttributes)
  LogOutput=""
  Comment=""
  Delay=""
  Save=""
  SkipOID=""
  Weight=""
  SameResponse=""
  />

  * \<[Definitions](xref:DeviceSimulator_SNMP_Schema_Simulation_Definitions)>

    * \<[Definition](xref:DeviceSimulator_SNMP_Schema_Simulation_Definitions_Definition)
    OID=""
    Type=""
    ReturnValue=""
    LogOutput=""
    Comment=""
    Delay=""
    Save=""
    SkipOID=""
    Weight=""
    SameResponse=""
    />

  * \</Definitions>

* \</Simulation>