---
uid: EPM_6.1.7_I-DOCSIS
---

# EPM 6.1.7 I-DOCSIS - Preview

## New features

\-

## Changes

### Enhancements

\-

### Fixes

#### EPM front-end element threw 'process cannot access the file because it is being used by another process' exceptions [ID_34658]

In some cases, logging for the EPM front-end element could contain exceptions like the following example:

```txt
2022/04/16 00:32:09.380|SLManagedScripting.exe|ManagedInterop|ERR|0|18|QA29|WriteCsvFile|Error writing csv file:System.IO.IOException: The process cannot access the file 'C:\DataMiner EPM\DOCSIS\Passive Relation\EP\26446_7_PASSIVERELATION_EP.csv' because it is being used by another process.
   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.StreamWriter.CreateFile(String path, Boolean append, Boolean checkHost)
   at System.IO.StreamWriter..ctor(String path, Boolean append, Encoding encoding, Int32 bufferSize, Boolean checkHost)
   at System.IO.StreamWriter..ctor(String path)
   at Skyline.Protocol.Generic.ProvisioningHelp.WriteCsvFile(SLProtocolExt protocol, List`1 lines, String path)
```

To prevent this, the Skyline EPM Platform connector will now retry three times to edit a CSV file, with a 1-second delay.

#### Arris E6000 CCAP Platform: Incorrect US QAM Ch Utilization values [ID_34660]

In the US QAM Channel table for the Arris E6000 CCAP Platform, it could occur that the US QAM Ch Utilization showed incorrect values.

#### Arris E6000 CCAP platform: Exception because file is being used by another process [ID_34780]

After an Arris E6000 CCAP platform element started up, it could occur that an exception similar to the following was thrown:

```txt
2022/09/19 05:28:24.499|SLManagedScripting.exe|ManagedInterop|ERR|0|211|QA213|DecompressTopicFile|Not able to perform decompression on file. Error: System.IO.IOException: The process cannot access the file 'C:\Skyline DataMiner\Documents\DOCSIS\ActiveQAMChannels\114404_10_DSQAM_CH.gz' because it is being used by another process.
```

Retry logic has now been added to prevent this issue.
