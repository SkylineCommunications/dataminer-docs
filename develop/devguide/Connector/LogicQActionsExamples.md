---
uid: LogicQActionsExamples
---

# QAction examples

The following QActions implement some functionality that is often required when developing a protocol.

- [Reading from files](#reading-from-files)
- [Reading from a (protected) Shared Folder](#reading-from-a-protected-shared-folder)
- [Processing JSON](#processing-json)
- [Processing MIME](#processing-mime)
- [Processing gzip-compressed data](#processing-gzip-compressed-data)
- [Creating an alarm in a QAction](#creating-an-alarm-in-a-qaction)

> [!TIP]
> See also: [Use case: Internal flow – QActions](xref:LogicUseCase3)

## Reading from files

Reading data from files can be done using an instance of the *StreamReader* class (System.IO). Always specify the default encoding (System.Text) so content with special characters will be interpreted correctly. By also using a *FileStream* instance (System.IO), it is possible to read files that are already in use.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Skyline.DataMiner.Scripting;

public class Utility
{
   public static List<string> GetFileData(string file)
   {
      List<string> lines = new List<string>();

      if (File.Exists(file))
      {

         using (FileStream logReader = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
         {
            using (StreamReader sr = new StreamReader(logReader, Encoding.Default))
            {
               while (!sr.EndOfStream)
               {
                  lines.Add(sr.ReadLine());
               }
            }
         }
      }

      return lines;
   }
}
```

## Reading from a (protected) shared folder

The following C# code fragment illustrates how to read from a shared folder, assuming the protocol defines the following parameters:

| ID | Description |
|----|-------------|
| 1  | Username    |
| 3  | Password    |
| 6  | Share       |
| 8  | Domain name |
| 10 | File name   |

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Skyline.DataMiner.Scripting;

using DWORD = System.UInt32;
using LPWSTR = System.String;
using NET_API_STATUS = System.UInt32;

public static class QAction
{
   /// <summary>
   /// Quick Action example.
   /// </summary>
   /// <param name="protocol">Link with SLProtocol process.</param>
   public static void Run(SLProtocol protocol)
   {
      uint[] ids = new uint[] { 1, 8, 3, 6, 10 };
      object[] parameters = (object[]) protocol.GetParameters(ids);

      object userName = parameters[0];
      object domainName = parameters[1];
      object password = parameters[2];
      object share = parameters[3];
      object filename= parameters[4];

      List<string> lines = SharedFile.ReadFromSharedFile(protocol, userName, domainName, password, share, filename);
   }

   public class SharedFile
   {
      [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
      internal static extern NET_API_STATUS NetUseAdd(
      LPWSTR UncServerName,
      DWORD Level,
      ref USE_INFO_2 Buf,
      out DWORD ParmError);

      [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
      internal static extern NET_API_STATUS NetUseDel(
      LPWSTR UncServerName,
      LPWSTR UseName,
      DWORD ForceCond);

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
      internal struct USE_INFO_2
      {
         internal LPWSTR ui2_local;
         internal LPWSTR ui2_remote;
         internal LPWSTR ui2_password;
         internal DWORD ui2_status;
         internal DWORD ui2_asg_type;
         internal DWORD ui2_refcount;
         internal DWORD ui2_usecount;
         internal LPWSTR ui2_username;
         internal LPWSTR ui2_domainname;
      }

      public static List<string> ReadFromSharedFile(SLProtocol protocol, object userName, object domainName, object password, object share, object filename)
      {
         List<string> lines = new List<string>();

         USE_INFO_2 useInfo = new USE_INFO_2();
         useInfo.ui2_remote = Convert.ToString(share);
         useInfo.ui2_password = Convert.ToString(password);
         useInfo.ui2_username = Convert.ToString(userName);
         useInfo.ui2_domainname = Convert.ToString(domainName);
         useInfo.ui2_asg_type = 0xFFFFFFFF;
         useInfo.ui2_usecount = 1;
         uint paramErrorIndex;
         uint returnCode = NetUseAdd(null, 2, ref useInfo, out paramErrorIndex);

         if (returnCode != 0)
         {
         protocol.Log(8, -1, "NetUseAdd failed " + Convert.ToString(returnCode) +  ".");
         }
         else
         {
            protocol.Log(8, -1, "NetUseAdd succeeded.");

            using (StreamReader sr = new StreamReader(Convert.ToString(share) + "\\" + Convert.ToString(filename), System.Text.Encoding.Default))
            {
               string line = sr.ReadLine();

               while (line != null)
               {
                  lines.Add(line);
                  line = sr.ReadLine();
               }
            }
         }

         returnCode = NetUseDel(null, Convert.ToString(share), 2);

         if (returnCode != 0)
         {
            protocol.Log(8, -1, "NetUseDel failed " + Convert.ToString(returnCode));
         }
         else
         {
            protocol.Log(8, -1, "NetUseDel Succeeded.");
         }

         return lines;
      }
   }
}
```

## Processing JSON

While in the past the *Json* class (System.Web.Helpers) was used to process JSON (JavaScript Object Notation) data, now the *JavaScriptSerializer* class (System.Web.Script.Serialization) is preferred (available since .NET Framework v3.5).

It is not necessary to load additional DLLs into DataMiner when using this approach. However, the QAction does need a reference to "System.Web.Extensions.dll" (using the *dllimport* attribute).

The following code will create a dictionary of all the items in the JSON data:

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

using Skyline.DataMiner.Scripting;

public static class QAction
{
   public static void Run(SLProtocol protocol)
   {
      var serializer = new JavaScriptSerializer();
      try
      {
         string data = Convert.ToString(protocol.GetParameter(10));
         var deserializedResult = serializer.Deserialize((string)data, typeof(object)) as Dictionary<string, object>;

         if (deserializedResult != null)
         {
            string portNumber = Convert.ToString(deserializedResult["port_number"]);
         }
      }
      catch (Exception e)
      {
         protocol.Log("QA" + protocol.QActionID + "|Run|An unexpected error occurred during deserialization of JSON data: " + e.ToString(), LogType.Error, LogLevel.NoLogging);
      }
   }
}
```

> [!NOTE]
>
> - When an instance of the JavaScriptSerializer is created, it has a maximum length of JSON strings that are accepted. In case a device can return large JSON responses, this default size can be too small. If this is the case, be sure to set the maximum length property of the JavaScriptSerializer instance before using the instance to deserialize the response.
> - A useful JSON editor can be found at <https://jsoneditoronline.org>.
> - The online generator available at <http://json2csharp.com/> can be used to convert JSON to C# classes.

> [!TIP]
> See also:
>
> - <https://www.json.org>
> - <http://msdn.microsoft.com/enus/library/system.web.helpers.json(v=vs.99).aspx>
> - <http://msdn.microsoft.com/enus/library/system.web.script.serialization.javascriptserializer(v=vs.110).aspx>

## Processing MIME

Information on MIME (multipart content type) can be found at <http://www.w3.org/Protocols/rfc1341/7_2_Multipart.html>. It is important to know that the boundary string should start with at least "-", otherwise the multipart will not be recognized.

```csharp
string filePath = Convert.ToString(protocol.GetParameter(10));

try
{
   XmlDocument document = new XmlDocument();

   document.Load(filePath);

   string content = document.InnerXml;
   string boundary = "------------Ij5KM7KM7Ij5gL6Ij5GI3GI3Ef1ae0\r\n";
   string multipartl = "Content-Disposition: form-data; name=\"Filename\"\r\n\r\n'";
   string[] datal = filePath.Split(Convert.ToChar("\\"));
   string dataFile = datal[datal.Length - 1];
   string multipart2 = "Content-Disposition: form-data; name=\"" + dataFile +
   "\"3 filename=\"" + dataFile + "\" \r\nContent-Type: application/octet-stream\r\n\r\n";
   string multipart3 = "Content-Disposition: form-data; name=\"Upload\"\r\n\r\n";
   string data3 = "Submit Query";
   string endBoundary = "\r\n------------Ij5KM7KM7Ij5gL6Ij5GI3GI3Ef1ae0-- ";

   content = boundary + multipartl + dataFile + "\r\n" + boundary + multipart2 + content + "\r\n" + boundary + multipart3 + data3 + endBoundary;

   protocol.SetParameters(new int[] { 3100, 3103 }, new object[] { content, "Import Started" });
}
catch (Exception e)
{
   protocol.Log(protocol.QActionID + "|ProcessMime|Load configuration XML-file failed (Check the correct format of the XML-file):" + Environment.NewLine + filePath + Environment.NewLine + e.ToString(),LogType.Error, LogLevel.NoLogging);
}
```

## Processing gzip-compressed data

It is possible that an HTTP response contains gzip-compressed data in the response. Processing gzip-compressed data can be done as illustrated in the example below. The content is received in the parameter with ID 307.

> [!TIP]
> See also: <https://www.gnu.org/software/gzip/>

```csharp
using System;
using System.IO;
using System.IO.Compression;
using System.Text;

using Skyline.DataMiner.Scripting;

/// <summary>
/// Processing gzip compressed data.
/// </summary>
public static class QAction
{
   /// <summary>
   /// QAction entry point.
   /// </summary>
   /// <param name="protocol">Link with SLProtocol process.</param>
   public static void Run(SLProtocol protocol)
   {
      Array bytes = (Array)protocol.GetData("PARAMETER", 307);
      byte[] bytesToParse = new byte[bytes.Length];

      for (int i = 0; i < bytes.Length; i++)
      {
         bytesToParse[i] = Convert.ToByte(bytes.GetValue(i));
      }

      byte[] decompressedBytes = Decompress(bytesToParse, protocol);

      if (decompressedBytes.Length > 1)
      {
         UTF8Encoding encoding = new UTF8Encoding();
         string xmlDocument = encoding.GetString(decompressedBytes);

         //// Code processing the XML document...
      }
   }

   /// <summary>
   /// Decompresses gzip compressed data.
   /// </summary>
   /// <param name="compressedData">The compressed data.</param>
   /// <param name="protocol">Link with SLProtocol process.</param>
   /// <returns>The decompressed data.</returns>
   public static byte[] Decompress(byte[] compressedData, SLProtocol protocol)
   {
      try
      {
         using (GZipStream stream = new GZipStream(new MemoryStream(compressedData), CompressionMode.Decompress))
         {
            const int Size = 4096;
            byte[] buffer = new byte[Size];

            using (MemoryStream memory = new MemoryStream())
            {
               int count = 0;
               
               do
               {
                  count = stream.Read(buffer, 0, Size);
                  
                  if (count > 0)
                  {
                     memory.Write(buffer, 0, count);
                  }
               }
               while (count > 0);

               return memory.ToArray();
            }
         }
      }
      catch (Exception e)
      {
         protocol.Log("QA" + protocol.QActionID + "|Decompress|An unexpected error occurred: " + e.ToString(), LogType.Error, LogLevel.NoLogging);

         return new byte[] { 0 };
      }
   }
}
```

## Creating an alarm in a QAction

To create an alarm from a QAction, the SLProtocolScripts.dll DLL needs to be imported (Skyline.DataMiner.ProtocolScripts).

```csharp
int elementID = 214;
int parameterID = 100;
string information = "Text to set in Information event/alarm";

Alarm alarm = new Alarm();

string[] alarmData = alarm.NewAlarm(elementID, parameterID, information, "Major");

protocol.NotifyDataMiner(106, 0, alarmData);   // NT_MAKE_ALARM call.
```

```xml
<Param id="20" trending="false">
   <Name>a1armReceiver</Name>
   <Description>Alarm Receiver</Description>
   <Type options="linkAlarmValue=..">read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
   <Display>
      <RTDisplay>true</RTDisplay>
   </Display>
   <Alarm>
      <Monitored>true</Monitored>
   </Alarm>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
```

Alarm linking can be done with:

- linkAlarmValue=true

  This option allows the linking of externally generated alarms based on the alarm value. When there is an exact value match, the alarms are linked whether or not a root key has been specified.

- linkAlarmValue=[xx]

  This option allows the linking of alarms based on the value between the two specified characters.

In case you want alarms to be linked if the values between two brackets match:

- options="LinkAlarmValue=()"

In case you want alarms to be linked if the values between two dots match:

- options="LinkAlarmValue=.."

With these options, you can link alarms to each other. Note that the linking will only work if you set alarm monitoring to true.
