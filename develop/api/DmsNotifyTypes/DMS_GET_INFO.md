---
uid: DMS_GET_INFO
---

# DMS_GET_INFO (8)

> [!IMPORTANT]
> The use of DMS Notify types has been deprecated. Use types from the [DataMinerSystem library](xref:ClassLibraryIntroduction) instead.

Gets information about all elements of the DataMiner System.

```csharp
Interop.SLDms.DMSClass dms = new Interop.SLDms.DMSClass();
object x = new object();
dms.GetInfo(8/*DMS_GET_INFO*/, 0, ref x);
object[] retrievedElements = (object[])x;

foreach (object element in retrievedElements)
{
    object[] singleElementInfo = (object[])element;
    if (singleElementInfo.Length < 2) // Generic element info and properties should always be present.
    {
        continue;
    }

    string[] genericElementInfo = (string[])singleElementInfo[0];

    string dmaId = genericElementInfo[0];
    string elementId = genericElementInfo[1];
    string simulation = genericElementInfo[2]; // Empty string if not simulated, otherwise the simulation name.
    string elementName = genericElementInfo[3];
    string state = genericElementInfo[4];
    string description = genericElementInfo[5];
    string type = genericElementInfo[6];
    string data = genericElementInfo[7]; // Unused.
    string unique = genericElementInfo[8]; // Unused.
    string ipAddress = genericElementInfo[9];
    string ipMask = genericElementInfo[10];
    string telnet = genericElementInfo[11];
    string snmpAgent = genericElementInfo[12];
    string elementTimeout = genericElementInfo[13];
    string protocolName = genericElementInfo[14];
    string protocolVersion = genericElementInfo[15];
    string alarmTemplate = genericElementInfo[16];

    // If element is for example a DVE, the following mainPort settings all contain an empty string.
    string mainPortType = genericElementInfo[17];
    string mainPortNr = genericElementInfo[18];
    string mainPortBaudrate = genericElementInfo[19];
    string mainPortParity = genericElementInfo[20]; // If SNMPv3 port, this contains the SNMPv3 auth protocol.
    string mainPortDatabits = genericElementInfo[21]; // If SNMPv3 port, this contains the SNMPv3 user name.
    string mainPortStopbits = genericElementInfo[22]; // If SNMPv3 port, this contains the SNMPv3 security level.
    string mainPortFlowCtrl = genericElementInfo[23]; // If SNMPv3 port, this contains the SNMPv3 privacy protocol.
    string mainPortBusAddress = genericElementInfo[24];
    string mainPortRetries = genericElementInfo[25];
    string mainPortSlowPoll = genericElementInfo[26];
    string mainPortSlowPollBase = genericElementInfo[27];
    string mainPortTimeoutTime = genericElementInfo[28];
    string mainPortPollingIp = genericElementInfo[29];
    string mainPortPollingPort = genericElementInfo[30];
    string mainPortPingInterval = genericElementInfo[31];
    string mainPortGetCommunity = genericElementInfo[32]; // If SNMPv3 port, this contains the SNMPv3 auth password.
    string mainPortSetCommunity = genericElementInfo[33]; // If SNMPv3 port, this contains the SNMPv3 privacy password.

    string debugLogLevel = genericElementInfo[34];
    string errorLogLevel = genericElementInfo[35];
    string infoLogLevel = genericElementInfo[36];
    string trendTemplate = genericElementInfo[37];
    string isHidden = genericElementInfo[38]; // "True" or "False".
    string derived = genericElementInfo[39];
    string descriptionXmlCookie = genericElementInfo[40];
    string mainPortLocalIpPort = genericElementInfo[41];
    string readOnly = genericElementInfo[42]; // "True" or "False".
    string replicationActive = genericElementInfo[43]; // "True" or "False".
    string replicationOptions = genericElementInfo[44]; // Empty string if not replicated.
    string replicationRemoteElement = genericElementInfo[45]; // Empty string if not replicated.
    string replicationDataMinerIp = genericElementInfo[46]; // Empty string if not replicated.
    string replicationUserName = genericElementInfo[47]; // Empty string if not replicated.
    string replicationPassword = genericElementInfo[48]; // Empty string if not replicated.
    string replicationDomain = genericElementInfo[49]; // Empty string if not replicated.
    string keepOnline = genericElementInfo[50]; // "True" or "False".
    string forceAgent = genericElementInfo[51]; // "True" or "False".
    string isOnlineOnBackupAgent = genericElementInfo[52]; // "True" or "False".
    string replicationHasExternalEngine = genericElementInfo[53]; // "True" or "False".
    string dveParentDmaElementId = genericElementInfo[54]; // Empty string if not a DVE.
    string snmpAgentReadCommunity = genericElementInfo[55];
    string snmpAgentWriteCommunity = genericElementInfo[56];
    string serviceElementDmaElementId = genericElementInfo[57]; // Empty string if not a service element.
    string trendWindow = genericElementInfo[58];
    string realtimeTrendWindowUnit = genericElementInfo[59];
    string baseProtocolName = genericElementInfo[60];
    string dveCreationFlag = genericElementInfo[61]; // "True" or "False".
    string hostingDmaId = genericElementInfo[62];
    string timespanFiveMinuteWindow = genericElementInfo[63];
    string timespanFiveMinuteWindowUnit = genericElementInfo[64];
    string timespanOneHourWindow = genericElementInfo[65];
    string timespanOneHourWindowUnit = genericElementInfo[66];
    string timespaneOneDayWindow = genericElementInfo[67];
    string timespanOneDayWindowUnit = genericElementInfo[68];
    string protocolType = genericElementInfo[69];
    string credentialGuid = genericElementInfo[70];
    string isSslTlsEnabled = genericElementInfo[71]; // "True" or "False".
    string allowedIpAddresses = genericElementInfo[72]; // Semicolon-separated list of allowed IP addresses for this element.
    string visio = genericElementInfo[73];
    string config = genericElementInfo[74];
    string connectTimeoutTime = genericElementInfo[75];

    string[] genericElementProperties = (string[])singleElementInfo[1];
    if (genericElementProperties.Length > 0)
    {
        // [0] = Property name [1] = Property type [2] = Property value; [3] = Property name [4] = Property type; etc.
        int propCount = genericElementProperties.Length / 3;
        for (int i = 0; i < genericElementProperties.Length; i++)
        {
            // ...
        }
    }

    if (singleElementInfo.Length < 3) // If no additional connections are present, the third item in the singleElementInfo array is not present.
    {
        continue;
    }

    // Port settings of additional connections (if any).
    // This is a single list of all port settings of all additional connections,
    // so the list needs to be split into chunks of 25 items (one chunk per additional connection).
    string[] additionalPortSettings = (string[])singleElementInfo[2];
    for (int i = 0; i < additionalPortSettings.Length; i++)
    {
        // First additional connection port settings.
        string secondConnectionPortType = additionalPortSettings[0];
        string secondConnectionPortNumber = additionalPortSettings[1];
        string secondConnectionPortBaudrate = additionalPortSettings[2];
        string secondConnectionPortParity = additionalPortSettings[3]; // If SNMPv3 port, this contains the SNMPv3 auth protocol.
        string secondConnectionPortDatabits = additionalPortSettings[4]; // If SNMPv3 port, this contains the SNMPv3 user name.
        string secondConnectionPortStopbits = additionalPortSettings[5]; // If SNMPv3 port, this contains the SNMPv3 security level.
        string secondConnectionPortFlowCtrl = additionalPortSettings[6]; // If SNMPv3 port, this contains the SNMPv3 privacy protocol.
        string secondConnectionPortBusAddress = additionalPortSettings[7];
        string secondConnectionPortRetries = additionalPortSettings[8];
        string secondConnectionPortSlowPoll = additionalPortSettings[9];
        string secondConnectionPortSlowPollBase = additionalPortSettings[10];
        string secondConnectionPortTimeoutTime = additionalPortSettings[11];
        string secondConnectionPortPollingIp = additionalPortSettings[12];
        string secondConnectionPortPollingPort = additionalPortSettings[13];
        string secondConnectionPortPingInterval = additionalPortSettings[14];
        string secondConnectionPortGetCommunity = additionalPortSettings[15]; // If SNMPv3 port, this contains the SNMPv3 auth password.
        string secondConnectionPortSetCommunity = additionalPortSettings[16]; // If SNMPv3 port, this contains the SNMPv3 privacy password.
        string secondConnectionPortLocalPort = additionalPortSettings[17];
        string secondConnectionPortId = additionalPortSettings[18];
        string secondConnectionPortElementTimeoutTime = additionalPortSettings[19];
        string secondConnectionPortProtocolType = additionalPortSettings[20];
        string secondConnectionPortCredentialsGuid = additionalPortSettings[21];
        string secondConnectionPortSslTlsEnabled = additionalPortSettings[22]; // "True" or "False".
        string secondConnectionPortAllowedIpAddresses = additionalPortSettings[23]; // Semicolon-separated list of allowed IP addresses for this port.
        string secondConnectionPortConnectTimeoutTime = additionalPortSettings[24];
        // Second additional connection port settings (if present).
        string thirdConnectionPortType = additionalPortSettings[25];
        // ...
    }
}
```

## Parameters

- type (int): Specifies the notify type. To perform a DMS_GET_INFO call, set this to 8.
- subType (int): Specifies the sub type. Not applicable for DMS_GET_INFO calls. Set this to 0.
- retrievedElements (object): Holds the element information.
