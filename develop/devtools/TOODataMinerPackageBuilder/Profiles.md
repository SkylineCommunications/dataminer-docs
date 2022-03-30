---
uid: Profiles
---

# Profiles

The configuration of a package can be stored into a profile, so that you can easily re-create packages without having to configure them manually again. However note, that building packages with a profile is supported for **legacy packages only**.

Via the *Profile* menu, you can respectively save and load a profile.

Below you can find an example profile.

```xml
<?xml version="1.0" encoding ="ISO-8859-1"?>
<Profile>
  <Description/>
  <Locations>
     <BaseDirectory>C:\SkylineDataMiner\</BaseDirectory>
     <Files>
        <File source="Elements\Cisco Manager_01\Elements.xml">Elements\Cisco Manager_01\Elements.xml</File>
        <File source="Protocols\CISCO Manager\5.1.2.12\Protocol.xml">Protocols\CISCO Manager\5.1.2.12\Protocol.xml</File>
        <File source="Protocols\CISCO Manager\Production\Protocol.xml.lnk">Protocols\CISCO Manager\Production\Protocol.xml.lnk</File>
     </Files>
  </Locations>
  <ElementsInfo/>
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
  <StartupActions/>
  <UpdateContent>
     <Content>Lock</Content>
     <Content>SetOption ExtractAll</Content>
     <Content>Disable</Content>
     <Content>Kill</Content>
     <Content>Delete</Content>
     <Content>Update Protocols</Content>
     <Content>Update Elements</Content>
     <Content>Enable</Content>
     <Content>Unlock</Content>
     <Content>Start</Content>
  </UpdateContent>
</Profile>
```
