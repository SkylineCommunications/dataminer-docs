---
uid: DMS_protocol
---

# DMS protocol

In order to implement Ember+ in a DMS protocol, a smart-serial connection is needed, containing 1 general response to parse incoming data and 1 general command structure to send requests following the S101 frame structure.

Command format:

```xml
<Command id="50">
   <Name>SendS101Frame</Name>
   <Content>
      <Param>50</Param> <!--S101 BOF -->
      <Param>52</Param> <!--S101 Request Data -->
      <Param>51</Param> <!--S101 EOF -->
   </Content>
</Command>
```

Response format:

```xml
<Response id="50">
   <Name>SendS101Frame</Name>
   <Content>
      <Param>50</Param> <!--S101 BOF -->
      <Param>53</Param> <!--S101 Response Data -->
      <Param>51</Param> <!--S101 EOF -->
   </Content>
</Response>
```

```xml
<Pair id="50">
   <Name>SendChassisEmberPacket</Name>
   <Content>
      <Command>50</Command> <!--SendS101Frame -->
   </Content>
</Pair>
```

Below you can find the structure of the referenced parameters:

```xml
<Param id="50" trending="false">
   <Name>S101BOF</Name>
   <Description>S101 BOF</Description>
   <Type options="headerTrailerLink=1">header</Type>
   <Interprete>
      <RawType>unsigned number</RawType>
      <LengthType>fixed</LengthType>
      <Type>double</Type>
      <Value>0xFE</Value>
      <Length>1</Length>
   </Interprete>
</Param>
```

```xml
<Param id="51" trending="false">
   <Name>S101EOF</Name>
   <Description>S101 EOF</Description>
   <Type options="headerTrailerLink=1">trailer</Type>
   <Interprete>
      <RawType>unsigned number</RawType>
      <LengthType>fixed</LengthType>
      <Type>double</Type>
      <Value>0xFF</Value>
      <Length>1</Length>
   </Interprete>
</Param>
```

```xml
<Param id="52" trending="false">
   <Name>S101RequestData</Name>
   <Description>S101 Request Data</Description>
   <Type>read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
</Param>
```

```xml
<Param id="53" trending="false">
   <Name>S101ResponseData</Name>
   <Description>S101 Reponse Data</Description>
   <Type>read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
</Param>
```

## Handling Responses

Responses can be processed by a QAction that triggers on change of the "Response Data" parameter in the response.

Processing is done by assigning actions to different glowReader handlers, then parsing the incoming data using the glowReader that will trigger the right event.

```cs
public class QAction
{
  private GlowReader glowReader;
  public void Run(SLProtocol protocol)
  {
    if (glowReader == null)
    {
      glowReader = new GlowReader((_, e) => GlowReceived(protocol, e.Root), (_, e) => KeepAliveRequestReceived(protocol, e));
      glowReader.PackageReceived += (_, e) => PackageReceived(protocol, e);
      glowReader.FramingError += (_, e) => GlowFramingError(protocol, e.Message);
      glowReader.Error += (_, e) => GlowError(protocol, e.Message);
    }

    HandleResponse(protocol);
  }

  private void HandleResponse(SLProtocol protocol)
  {
    object receivedData = protocol.GetData("PARAMETER", HdCoreRavenna.ResponseDataPid);

    if (receivedData == null)
    {
      protocol.Log("QA" + protocol.QActionID + "|HandleResponse|ERR: Received data is invalid!", LogType.Error, LogLevel.NoLogging);
      return;
    }

    object[] objectArray = (object[])receivedData;
    if (objectArray.Length == 0)
    {
      protocol.Log("QA" + protocol.QActionID + "|HandleResponse|ERR: Received data is invalid! Content:\n" + String.Join(".", objectArray.Select(x => Convert.ToString(x))), LogType.Error, LogLevel.NoLogging);
      return;
    }

    try
    {
      byte[] data = objectArray.Select(Convert.ToByte).ToArray();

      byte[] framedData = new byte[data.Length + 2];
      framedData[0] = 0xFE;
      Array.Copy(data, 0, framedData, 1, data.Length);
      framedData[framedData.Length - 1] = 0xFF;

      glowReader.ReadBytes(framedData);
    }
    catch (Exception e)
    {
      protocol.Log("QA" + protocol.QActionID + "|HandleResponse|Error" + Environment.NewLine + e, LogType.Error, LogLevel.NoLogging);
    }
  }
}
```

## Sending commands

This works by first selecting the right node in the tree of data and then performing a specific command on that location. To then have the API create the frame, you perform encoding and finishing. To then grab that encoded frame and set it on the protocol, you can assign an action to the handler: PackageReady. The action can then be e.g. GlowPackageReady that will set the data on the "Request Data" parameter and perform a checktrigger to initiate the sending of a command.

```cs
internal static void SendGetDirectoryRequest(SLProtocol protocol, int[][] path)
{
  GlowRootElementCollection root = GlowRootElementCollection.CreateRoot();
  GlowCommand command = new GlowCommand(GlowCommandType.GetDirectory);

  if (path == null || (path.Length == 1 && path[0] == null))
  {
    root.Insert(command);
  }
  else
  {
    foreach (int[] subPath in path)
    {
       GlowQualifiedNode qnode1 = new GlowQualifiedNode(subPath);
       qnode1.Children = new GlowElementCollection(GlowTags.QualifiedNode.Children);
       qnode1.Children.Insert(command);
       root.Insert(qnode1);
    }
  }

  SendGlow(protocol, root);
}

internal static void SendGlow(SLProtocol protocol, GlowContainer glow)
{
  var glowOutPut = new GlowOutput(true, 1024, 0x00, (_, e) => GlowPackageReady(protocol, e.FramedPackage));
  using (glowOutPut)
  {
    glow.Encode(glowOutPut);
    glowOutPut.Finish();
  }
}

internal static void GlowPackageReady(SLProtocol protocol, byte[] framedPackage)
{
  protocol.SetParameterBinary(HdCoreRavenna.RequestDataPid, framedPackage);
  protocol.CheckTrigger(HdCoreRavenna.SendRequestTrigger);
}
```

## See also

- [Logic](xref:Logic)
- [Smart serial](xref:ConnectionsSmartSerial)
