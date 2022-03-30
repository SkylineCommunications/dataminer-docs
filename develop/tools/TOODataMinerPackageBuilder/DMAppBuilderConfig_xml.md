---
uid: DMAppBuilderConfig_xml
---

# DMAppBuilderConfig.xml

The file *DMAppBuilderConfig.xml* is a configuration file that is read by the Package Builder application during startup. This XML file allows you to specify the base directory (by default *C:\\Skyline DataMiner\\*), excluded files, included paths, files to preserve, files to remove and updated content.

The base directory may reference any location as long as it is a DataMiner folder and the application has access to it. In case you want to e.g. connect to a shared DataMiner folder on another PC, that folder must be properly shared and the application must have access to it.

 The default *DMAppBuilderConfig.xml* file has the following content:

```xml
<?xml version="1.0" encoding ="ISO-8859-1"?>
<DMAppBuilderConfig>
  <BaseDirectory>C:\SkylineDataMiner\</BaseDirectory>
  <ExcludedFiles>
     <ExcludedFile>*.txf</ExcludedFile>
     <ExcludedFile>*.lic</ExcludedFile>
     <ExcludedFile>*.QAction.*.dll</ExcludedFile>
  </ExcludedFiles>
  <IncludedPaths>
     <IncludedPath>Aggregation</IncludedPath>
     <IncludedPath>Correlation</IncludedPath>
     <IncludedPath>Documents</IncludedPath>
     <IncludedPath>Elements</IncludedPath>
     <IncludedPath>Protocols</IncludedPath>
     <IncludedPath>ProtocolScripts</IncludedPath>
     <IncludedPath>Scripts</IncludedPath>
     <IncludedPath>Views</IncludedPath>
     <IncludedPath>Webpages\favicon.ico</IncludedPath>
     <IncludedPath>Webpages\Maps</IncludedPath>
     <IncludedPath>Webpages\Tools</IncludedPath>
     <IncludedPath>Webpages\Reports\Templates</IncludedPath>
     <IncludedPath>Webpages\Dashboards</IncludedPath>
     <IncludedPath>Webpages\Reports</IncludedPath>
  </IncludedPaths>
  <FilesToLeave>
     <FileToLeave>Info.xml</FileToLeave>
     <FileToLeave>Views.xml</FileToLeave>
     <FileToLeave>MaintenanceSettings.xml</FileToLeave>
  </FilesToLeave>
  <FilesToDelete>
     <FileToDelete>Elements\*\*.txf</FileToDelete>
     <FileToDelete>Services\*\*.txf</FileToDelete>
     <FileToDelete>Protocols\*\*.txf</FileToDelete>
     <FileToDelete>ProtocolScripts\*qaction.*.dll</FileToDelete>
     <FileToDelete>ProtocolScripts\*qaction.helper.txt</FileToDelete>
     <FileToDelete>Scripts\*.txf</FileToDelete>
     <FileToDelete>Webpages\Reports\bin\*.*</FileToDelete>
     <FileToDelete>Webpages\Dashboards\Common\EditTools*.tmp</FileToDelete>
     <FileToDelete>Webpages\Dashboards\bin\*.pdb</FileToDelete>
     <FileToDelete>Webpages\HealthCheck\bin\*.*</FileToDelete>
     <FileToDelete>System Cache\slnet\*.bin</FileToDelete>
     <FileToDelete>System Cache\slnet\*.txf</FileToDelete>
  </FilesToDelete>
  <UpdateContent>
     <Content>Lock</Content>
     <Content>SetOption ExtractAll</Content>
     <Content>Disable</Content>
     <Content ifIncluded="Webpages">IIS Stop</Content>
     <Content>Kill</Content>
     <Content>Delete</Content>
     <Content>[CustomActions]</Content>
     <Content>Enable</Content>
     <Content>Unlock</Content>
     <Content ifIncluded="Webpages">IIS Start</Content>
     <Content>Start</Content>
  </UpdateContent>
</DMAppBuilderConfig>
```
