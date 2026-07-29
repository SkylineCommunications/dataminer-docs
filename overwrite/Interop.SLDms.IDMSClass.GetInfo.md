---
uid: Interop.SLDms.IDMS.GetInfo(System.Int32,System.Int32,System.Object@)
remarks: *content
---

> [!WARNING]
> This method has been deprecated. Use types from the [DataMinerSystem library](xref:ClassLibraryIntroduction) instead.

##### Response

```csharp
DMSClass dms = new DMSClass();
Object x = new Object();
dms.GetInfo(8/*DMS_GET_INFO*/, 0, ref x);
Object[] retrievedElements = (Object[])x;

foreach (Object element in retrievedElements)
{
	Object[] singleElementInfo = (Object[])element;
	if (singleElementInfo.Length > 0)
	{
		String[] genericElementInfo = (String[])singleElementInfo[0];

		// ElementDetails.DmaId = genericElementInfo[0];
		// ElementDetails.ElementId = genericElementInfo[1];
		// ElementDetails.Simulation = genericElementInfo[2];
		// ElementDetails.ConfigElement.ElementName = genericElementInfo[3];
		// ElementDetails.ConfigElement.State = genericElementInfo[4];
		// ElementDetails.ConfigElement.Description = genericElementInfo[5];
		// ElementDetails.ConfigElement.Type = genericElementInfo[6];
		// ElementDetails.ConfigElement.Data = genericElementInfo[7];
		// ElementDetails.ConfigElement.Unique = genericElementInfo[8];
		// ElementDetails.ConfigElement.IpAddress = genericElementInfo[9];
		// ElementDetails.ConfigElement.IpMask = genericElementInfo[10];
		// ElementDetails.ConfigElement.Telnet = genericElementInfo[11];
		// ElementDetails.ConfigElement.SnmpAgent = genericElementInfo[12];
		// ElementDetails.ConfigElement.ElementTimeout = genericElementInfo[13];
		// ElementDetails.ConfigElement.ProtocolName = genericElementInfo[14];
		// ElementDetails.ConfigElement.Version = genericElementInfo[15];
		// ElementDetails.ConfigElement.Template = genericElementInfo[16];
		// MainElementConnection.PortType = genericElementInfo[17];
		// MainElementConnection.PortNr = genericElementInfo[18];
		// MainElementConnection.Baudrate = genericElementInfo[19];
		// MainElementConnection.Parity = genericElementInfo[20];
		// MainElementConnection.Databits = genericElementInfo[21];
		// MainElementConnection.Stopbits = genericElementInfo[22];
		// MainElementConnection.FlowCtrl = genericElementInfo[23];
		// MainElementConnection.BusAddress = genericElementInfo[24];
		// MainElementConnection.Retries = genericElementInfo[25];
		// MainElementConnection.SlowPoll = genericElementInfo[26];
		// MainElementConnection.SlowPollBase = genericElementInfo[27];
		// MainElementConnection.TimeoutTime = genericElementInfo[28];
		// MainElementConnection.PollingIp = genericElementInfo[29];
		// MainElementConnection.PollingPort = genericElementInfo[30];
		// MainElementConnection.PingInterval = genericElementInfo[31];
		// MainElementConnection.GetComm = genericElementInfo[32];
		// MainElementConnection.SetComm = genericElementInfo[33];
		// ElementDetails.LoggingDebug = genericElementInfo[34];
		// ElementDetails.LoggingError = genericElementInfo[35];
		// ElementDetails.LoggingInfo = genericElementInfo[36];
		// ElementDetails.ConfigElement.TrendingTemplate = genericElementInfo[37];
		// ElementDetails.ConfigElement.Hidden = genericElementInfo[38];
		// ElementDetails.Derived = genericElementInfo[39];
		// ElementDetails.DescriptionXMLCookie = genericElementInfo[40];
		// MainElementConnection.LocalIpPort = genericElementInfo[41];
		// ElementDetails.ConfigElement.ReadOnly = genericElementInfo[42];
		// ElementDetails.ConfigElement.Replication.Active = genericElementInfo[43];
		// ElementDetails.ConfigElement.Replication.Options = genericElementInfo[44];
		// ElementDetails.ConfigElement.Replication.RemoteElement = genericElementInfo[45];
		// ElementDetails.ConfigElement.Replication.DataMinerIp = genericElementInfo[46];
		// ElementDetails.ConfigElement.Replication.UserName = genericElementInfo[47];
		// ElementDetails.ConfigElement.Replication.Password = genericElementInfo[48];
		// ElementDetails.ConfigElement.Replication.Domain = genericElementInfo[49];
		// ElementDetails.ConfigElement.KeepOnline = genericElementInfo[50];
		// ElementDetails.ConfigElement.ForceAgent = genericElementInfo[51];
		// ElementDetails.OnlineOnBackupAgent = genericElementInfo[52];
		// ElementDetails.ConfigElement.Replication.DmpManager = genericElementInfo[53];
		// ElementDetails.DveParentDmaElementId = genericElementInfo[54];
		// ElementDetails.ReadCommunity = genericElementInfo[55];
		// ElementDetails.WriteCommunity = genericElementInfo[56];
		for (int i = 57; i < genericElementInfo.Length; i++)
		{
			// ElementDetails.ExtraPortInfo.Add(genericElementInfo[i]);
		}

		String[] genericElementProperties = (String[])singleElementInfo[1];
		if (genericElementProperties.Length > 0)
		{
			// [0] = Prop Name [1] = Type [2] = Value; [3] = Prop Name [4] = Type ...
			int propCount = genericElementProperties.Length / 3;
			for (int i = 0; i < genericElementProperties.Length; i++)
			{
				// ElementDetails.Properties.Add(new ElementProperty(genericElementProperties[i++], genericElementProperties[i++], genericElementProperties[i]));
			}
		}

		// Extra items are extra connection settings: (String[])singleElementInfo[2], (String[])singleElementInfo[3], etc                   
		for (int iConn = 2; iConn < singleElementInfo.Length; iConn++)
		{
			// ExtraElementConnection.PortType = ((String[])singleElementInfo[iConn])[0];
			// ExtraElementConnection.PortNr = ((String[])singleElementInfo[iConn])[1];
			// ExtraElementConnection.Baudrate = ((String[])singleElementInfo[iConn])[2];
			// ExtraElementConnection.Parity = ((String[])singleElementInfo[iConn])[3];
			// ExtraElementConnection.Databits = ((String[])singleElementInfo[iConn])[4];
			// ExtraElementConnection.Stopbits = ((String[])singleElementInfo[iConn])[5];
			// ExtraElementConnection.FlowCtrl = ((String[])singleElementInfo[iConn])[6];
			// ExtraElementConnection.BusAddress = ((String[])singleElementInfo[iConn])[7];
			// ExtraElementConnection.Retries = ((String[])singleElementInfo[iConn])[8];
			// ExtraElementConnection.SlowPoll = ((String[])singleElementInfo[iConn])[9];
			// ExtraElementConnection.SlowPollBase = ((String[])singleElementInfo[iConn])[10];
			// ExtraElementConnection.TimeoutTime = ((String[])singleElementInfo[iConn])[11];
			// ExtraElementConnection.PollingIp = ((String[])singleElementInfo[iConn])[12];
			// ExtraElementConnection.PollingPort = ((String[])singleElementInfo[iConn])[13];
			// ExtraElementConnection.PingInterval = ((String[])singleElementInfo[iConn])[14];
			// ExtraElementConnection.GetComm = ((String[])singleElementInfo[iConn])[15];
			// ExtraElementConnection.SetComm = ((String[])singleElementInfo[iConn])[16];
			// Unkown = ((String[])singleElementInfo[iConn])[17]
			// ExtraElementConnection.LocalIpPort = ((String[])singleElementInfo[iConn])[18];
		}
	}
}
```