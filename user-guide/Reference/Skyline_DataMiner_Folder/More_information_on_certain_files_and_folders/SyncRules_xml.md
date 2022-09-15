---
uid: SyncRules_xml
---

# SyncRules.xml

From DataMiner version 8.5.5 onwards, the *SyncRules.xml* file is used to prevent file synchronization between DataMiner Agents running different versions of the DataMiner software.

These rules can for instance help prevent issues that might occur when not all DMAs in a DMS have been updated yet, or when you first upgrade the backup of a Failover pair and then upgrade the main agent after switching.

When there is a version difference between DMAs for which synchronization is not allowed, the following types of synchronization will be skipped:

- File synchronization

- Midnight synchronization

- Full synchronization (which occurs when a new DMA is added to the DMS)

> [!NOTE]
>
> - Security changes (e.g. added users and groups, password changes, etc.) are also ignored as long as the version difference exists.
> - It is possible to check which Sync rules are in use on a DMA by means of the SLClientTest tool. However, note that this is an advanced system administration tool that should be used with extreme care. See [Verifying Sync rules](xref:SLNetClientTest_verifying_sync_rules).
> - Changes to the *SyncRules.xml* file only take effect after a DataMiner restart.

## Example of a SyncRules.xml file:

```xml
<SyncRules xmlns="http://www.skyline.be/config/syncrules">
  <VersionRestrictions allowMajorVersions="false">
    <Rule allow="false" old="8.5.6" new="8.5.7" />
  </VersionRestrictions>
</SyncRules>
```

## Syntax

- Within the *\<VersionRestrictions>* tag, multiple rules can be specified.

- The “allowMajorVersions” attribute is set to “false” by default (if no rule has been specified, or if no *SyncRules.xml* file can be found), so that file synchronization is denied between major versions (e.g. 8.5 to 9.0).

  > [!NOTE]
  > If you want to override the default “deny sync between major versions” behavior, add specific rules for specific versions (e.g. a rule that specifically allows synchronizations from v8.5 to v9.0).

- Each rule specifies an old and a new version, with the “old” and “new” attributes, respectively. Versions can be specified using the following formats: "8", "8.5", "8.5.3", or "8.5.4.7". It is not possible to specify build IDs.

  A rule will apply if one DMA has a version older or equal to the one specified in the “old” attribute, and the other DMA has a version newer or equal to the one specified in the “new” attribute. If multiple rules match, the last one in the list will apply.     If no four-part version number is specified in the “old” attribute, the rule will apply to all subversions. If, for example, “old” is set to "8.5.6", then the rule will also apply to DMAs running v8.5.6.7.
