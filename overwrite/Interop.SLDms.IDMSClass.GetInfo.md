---
uid: Interop.SLDms.IDMS.GetInfo(System.Int32,System.Int32,System.Object@)
remarks: *content
---

> [!WARNING]
> This method has been deprecated. Use types from the [DataMinerSystem library](xref:ClassLibraryIntroduction) instead.

##### Response

```csharp
List<ElementDetails> allElementDetails = new List<ElementDetails>();

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

		ElementDetails elementDetails = new DmaElement.ElementDetails();
		List<DMAElementConnection> elementConnections = new List<DMAElementConnection>();
		elementDetails.ConfigElement = new ConfigDMAElement(elementConnections);
		DMAElementConnection mainConnection = new DMAElementConnection();
		
		elementDetails.DmaId = genericElementInfo[0];
		elementDetails.ElementId = genericElementInfo[1];
		elementDetails.Simulation = genericElementInfo[2];
		elementDetails.ConfigElement.ElementName = genericElementInfo[3];
		elementDetails.ConfigElement.State = genericElementInfo[4];
		elementDetails.ConfigElement.Description = genericElementInfo[5];
		elementDetails.ConfigElement.Type = genericElementInfo[6];
		elementDetails.ConfigElement.Data = genericElementInfo[7];
		elementDetails.ConfigElement.Unique = genericElementInfo[8];
		elementDetails.ConfigElement.IpAddress = genericElementInfo[9];
		elementDetails.ConfigElement.IpMask = genericElementInfo[10];
		elementDetails.ConfigElement.Telnet = genericElementInfo[11];
		elementDetails.ConfigElement.SnmpAgent = genericElementInfo[12];
		elementDetails.ConfigElement.ElementTimeout = genericElementInfo[13];
		elementDetails.ConfigElement.ProtocolName = genericElementInfo[14];
		elementDetails.ConfigElement.Version = genericElementInfo[15];
		elementDetails.ConfigElement.Template = genericElementInfo[16];
		mainConnection.PortType = genericElementInfo[17];
		mainConnection.PortNr = genericElementInfo[18];
		mainConnection.Baudrate = genericElementInfo[19];
		mainConnection.Parity = genericElementInfo[20];
		mainConnection.Databits = genericElementInfo[21];
		mainConnection.Stopbits = genericElementInfo[22];
		mainConnection.FlowCtrl = genericElementInfo[23];
		mainConnection.BusAddress = genericElementInfo[24];
		mainConnection.Retries = genericElementInfo[25];
		mainConnection.SlowPoll = genericElementInfo[26];
		mainConnection.SlowPollBase = genericElementInfo[27];
		mainConnection.TimeoutTime = genericElementInfo[28];
		mainConnection.PollingIp = genericElementInfo[29];
		mainConnection.PollingPort = genericElementInfo[30];
		mainConnection.PingInterval = genericElementInfo[31];
		mainConnection.GetComm = genericElementInfo[32];
		mainConnection.SetComm = genericElementInfo[33];
		elementDetails.LoggingDebug = genericElementInfo[34];
		elementDetails.LoggingError = genericElementInfo[35];
		elementDetails.LoggingInfo = genericElementInfo[36];
		elementDetails.ConfigElement.TrendingTemplate = genericElementInfo[37];
		elementDetails.ConfigElement.Hidden = genericElementInfo[38];
		elementDetails.Derived = genericElementInfo[39];
		elementDetails.DescriptionXMLCookie = genericElementInfo[40];
		mainConnection.LocalIpPort = genericElementInfo[41];
		elementDetails.ConfigElement.ReadOnly = genericElementInfo[42];
		elementDetails.ConfigElement.Replication.Active = genericElementInfo[43];
		elementDetails.ConfigElement.Replication.Options = genericElementInfo[44];
		elementDetails.ConfigElement.Replication.RemoteElement = genericElementInfo[45];
		elementDetails.ConfigElement.Replication.DataMinerIp = genericElementInfo[46];
		elementDetails.ConfigElement.Replication.UserName = genericElementInfo[47];
		elementDetails.ConfigElement.Replication.Password = genericElementInfo[48];
		elementDetails.ConfigElement.Replication.Domain = genericElementInfo[49];
		elementDetails.ConfigElement.KeepOnline = genericElementInfo[50];
		elementDetails.ConfigElement.ForceAgent = genericElementInfo[51];
		elementDetails.OnlineOnBackupAgent = genericElementInfo[52];
		elementDetails.ConfigElement.Replication.DmpManager = genericElementInfo[53];
		elementDetails.DveParentDmaElementId = genericElementInfo[54];
		elementDetails.ReadCommunity = genericElementInfo[55];
		elementDetails.WriteCommunity = genericElementInfo[56];
		for (int i = 57; i < genericElementInfo.Length; i++)
		{
			elementDetails.ExtraPortInfo.Add(genericElementInfo[i]);
		}
		
		elementConnections.Add(mainConnection);

		String[] genericElementProperties = (String[])singleElementInfo[1];
		if (genericElementProperties.Length > 0)
		{
			//[0] = prop Name [1] type [2]=value; [3] = prop Name [4] =type ...
			int propCount = genericElementProperties.Length / 3;

			for (int i = 0; i < genericElementProperties.Length; i++)
			{
				elementDetails.Properties.Add(new ElementProperty(genericElementProperties[i++], genericElementProperties[i++], genericElementProperties[i]));
			}
		}

		// Extra items are extra connection settings: (String[])singleElementInfo[2], (String[])singleElementInfo[3], etc                   
		for (int iConn = 2; iConn < singleElementInfo.Length; iConn++)
		{
			DMAElementConnection extraConnection = new DMAElementConnection();
			extraConnection.PortType = ((String[])singleElementInfo[iConn])[0];
			extraConnection.PortNr = ((String[])singleElementInfo[iConn])[1];
			extraConnection.Baudrate = ((String[])singleElementInfo[iConn])[2];
			extraConnection.Parity = ((String[])singleElementInfo[iConn])[3];
			extraConnection.Databits = ((String[])singleElementInfo[iConn])[4];
			extraConnection.Stopbits = ((String[])singleElementInfo[iConn])[5];
			extraConnection.FlowCtrl = ((String[])singleElementInfo[iConn])[6];
			extraConnection.BusAddress = ((String[])singleElementInfo[iConn])[7];
			extraConnection.Retries = ((String[])singleElementInfo[iConn])[8];
			extraConnection.SlowPoll = ((String[])singleElementInfo[iConn])[9];
			extraConnection.SlowPollBase = ((String[])singleElementInfo[iConn])[10];
			extraConnection.TimeoutTime = ((String[])singleElementInfo[iConn])[11];
			extraConnection.PollingIp = ((String[])singleElementInfo[iConn])[12];
			extraConnection.PollingPort = ((String[])singleElementInfo[iConn])[13];
			extraConnection.PingInterval = ((String[])singleElementInfo[iConn])[14];
			extraConnection.GetComm = ((String[])singleElementInfo[iConn])[15];
			extraConnection.SetComm = ((String[])singleElementInfo[iConn])[16];
			// Unkown = ((String[])singleElementInfo[iConn])[17]
			extraConnection.LocalIpPort = ((String[])singleElementInfo[iConn])[18];
			elementConnections.Add(extraConnection);
		}
		
		allElementDetails.Add(elementDetails);
	}
}
```