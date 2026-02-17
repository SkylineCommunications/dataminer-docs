---
uid: Regarding_antivirus_software
description: While installing antivirus software on a DMA is possible, this will consume server resources and is not recommended in a well-protected environment.
---

# Regarding antivirus software

It is possible to install antivirus software on a DMA. However, you need to keep in mind that this is going to consume resources of the server. As such, we recommend that you do not install such software if the server is in a well-protected environment.

If you do install antivirus software on the **server**, you must:

- **Avoid scheduled virus scans** affecting the available resources for the DataMiner software at certain moments in time.

- Exclude the following **directories**:

  - `C:\Skyline DataMiner`
  - `C:\Program Files\Skyline Communications`
  - In case you are using self-managed storage instead of [Storage as a Service](xref:STaaS), the data directories of the databases (e.g., `C:\ProgramData\Cassandra`)

- Exclude the following **processes**:

  - All DataMiner processes (process names starting with "SL" or "DataMiner").
  - The NATS processes *nats-account-server.exe* and *nats-streaming-server.exe*.
  - In case you are using self-managed storage instead of [Storage as a Service](xref:STaaS), the process(es) of the database application(s) you are using with DataMiner (e.g., Cassandra).

  Below you can find a list of the main processes used by DataMiner and their paths. However, note that this list is not exhaustive, and other processes also may need to be excluded depending on your specific setup. Note also that, depending on your setup and DataMiner version, some of these may not be present in your system.

  | Name                                   | Path                                                                                                                                         |
  |----------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------|
  | DataMiner APIGateway                   | C:\Program Files\Skyline Communications\DataMiner APIGateway\DataMiner APIGateway.exe                                                     |
  | DataMiner ArtifactDeployer            | C:\Program Files\Skyline Communications\DataMiner ArtifactDeployer\DataMiner ArtifactDeployer.exe                                         |
  | DataMiner Assistant                   | C:\Program Files\Skyline Communications\DataMiner Assistant\DataMiner Assistant.exe                                                       |
  | DataMiner BrokerGateway               | C:\Program Files\Skyline Communications\DataMiner BrokerGateway\DataMiner BrokerGateway.exe                                               |
  | DataMiner CloudFeed                   | C:\Program Files\Skyline Communications\DataMiner CloudFeed\DataMiner CloudFeed.exe                                                       |
  | DataMiner CloudGateway                | C:\Program Files\Skyline Communications\DataMiner CloudGateway\DataMiner CloudGateway.exe                                                 |
  | DataMiner CommunicationGateway        | C:\Program Files\Skyline Communications\DataMiner CommunicationGateway\DataMiner CommunicationGateway.exe                                |
  | DataMiner Copilot                     | C:\Program Files\Skyline Communications\DataMiner Copilot\DataMiner Copilot.exe                                                           |
  | DataMiner CoreGateway                 | C:\Program Files\Skyline Communications\DataMiner CoreGateway\DataMiner CoreGateway.exe                                                   |
  | DataMiner DataAggregator              | C:\Program Files\Skyline Communications\DataMiner DataAggregator\DataMiner DataAggregator.exe                                             |
  | DataMiner DataAPI                     | C:\Program Files\Skyline Communications\DataMiner DataAPI\DataMiner DataAPI.exe                                                           |
  | DataMiner FieldControl                | C:\Program Files\Skyline Communications\DataMiner FieldControl\DataMiner FieldControl.exe                                                 |
  | DataMiner GQI                         | C:\Program Files\Skyline Communications\DataMiner GQI\DataMiner GQI.exe                                                                   |
  | DataMiner ModelHost                   | C:\Program Files\Skyline Communications\DataMiner ModelHost\DataMiner ModelHost.exe                                                       |
  | DataMiner Orchestrator                | C:\Program Files\Skyline Communications\DataMiner Orchestrator\DataMiner Orchestrator.exe                                                 |
  | DataMiner StorageModule               | C:\Program Files\Skyline Communications\DataMiner StorageModule\DataMiner StorageModule.exe                                               |
  | DataMiner SupportAssistant            | C:\Program Files\Skyline Communications\DataMiner SupportAssistant\DataMiner SupportAssistant.exe                                         |
  | DataMiner UserDefinableApiEndpoint    | C:\Program Files\Skyline Communications\DataMiner UserDefinableApiEndpoint\DataMiner UserDefinableApiEndpoint.exe                         |
  | NAS                                   | C:\Skyline DataMiner\NATS\nats-account-server\nssm.exe                                                                                      |
  | NATS                                  | C:\Skyline DataMiner\NATS\nats-streaming-server\nats-streaming-server.exe <br>C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config |
  | SLAnalytics                           | C:\Skyline DataMiner\Files\x64\SLAnalytics.exe                                                                                            |
  | SLASPConnection                       | C:\Skyline DataMiner\Files\x64\SLASPConnection.exe                                                                                        |
  | SLAutomation                          | C:\Skyline DataMiner\Files\SLAutomation.exe                                                                                               |
  | SLDataGateway                         | C:\Skyline DataMiner\Files\x64\SLDataGateway.exe                                                                                          |
  | SLDataMiner                           | C:\Skyline DataMiner\Files\SLDataMiner.exe                                                                                                |
  | SLDMS                                 | C:\Skyline DataMiner\Files\SLDMS.exe                                                                                                      |
  | SLElement                             | C:\Skyline DataMiner\Files\x64\SLElement.exe                                                                                              |
  | SLGSMGateway                          | C:\Skyline DataMiner\Files\SLGSMGateway.exe                                                                                               |
  | SLLog                                 | C:\Skyline DataMiner\Files\SLLog.exe                                                                                                      |
  | SLNet                                 | C:\Skyline DataMiner\Files\SLNet.exe                                                                                                      |
  | SLNetCOMService                       | C:\Skyline DataMiner\Files\SLNetCOMService.exe                                                                                            |
  | SLScheduler                           | C:\Skyline DataMiner\Files\SLScheduler.exe                                                                                                |
  | SLSNMPAgent                           | C:\Skyline DataMiner\Files\SLSNMPAgent.exe                                                                                                |
  | SLSpectrum                            | C:\Skyline DataMiner\Files\SLSpectrum.exe                                                                                                 |
  | SLWatchDog                            | C:\Skyline DataMiner\Files\x64\SLWatchDog.exe                                                                                             |
  | SLXml                                 | C:\Skyline DataMiner\Files\SLXml.exe                                                                                                      |

If you install antivirus software on **client** machines, exclude the DataMiner Cube directories `%LocalAppData%\Skyline\DataMiner\DataMinerCube`.

> [!NOTE]
>
> - These restrictions do not apply for Windows Defender.
> - Deploying antivirus software on Cassandra, OpenSearch, or Elasticsearch nodes may affect performance. If this is the case, we recommend excluding the data and logs directories from the antivirus scans.

> [!CAUTION]
> Failing to make these adjustments when using antivirus software may cause undesired operational problems with your DataMiner System, which are not covered under warranty or support. See [Exclusions](xref:Support_Terms_On_Premises#exclusions) and [Supported products](xref:Support_Terms_On_Premises#supported-products) in the *Support services terms*.
