---
uid: Regarding_antivirus_software
---

# Regarding antivirus software

It is possible to install antivirus software on a DMA. However, you need to keep in mind that this is going to consume resources of the server. As such, we recommend that you do not install such software if the server is in a well-protected environment.

If you do install antivirus software on the **server**, you must:

- Exclude the following directories:

  - `C:\Skyline DataMiner`
  - `C:\Program Files\Skyline Communications`
  - In case you are using self-hosted data storage instead of [Storage as a Service](xref:STaaS), the data directories of the databases (e.g. `C:\ProgramData\Cassandra`)

- Exclude the following processes:

  - All DataMiner processes (process names starting with "SL" or "DataMiner").
  - The NATS processes *nats-account-server.exe* and *nats-streaming-server.exe*.
  - In case you are using self-hosted data storage instead of [Storage as a Service](xref:STaaS), the process(es) of the database application(s) you are using with DataMiner (e.g. Cassandra).

- Avoid scheduled virus scans affecting the available resources for the DataMiner software at certain moments in time.

If you install antivirus software on **client** machines, exclude the DataMiner Cube directories `%LocalAppData%\Skyline\DataMiner\DataMinerCube`.

> [!NOTE]
>
> - These restrictions do not apply for Windows Defender.
> - Deploying antivirus software on Cassandra, OpenSearch, or Elasticsearch nodes may affect performance. If this is the case, we recommend excluding the data and logs directories from the antivirus scans.

> [!CAUTION]
> Failing to make these adjustments when using antivirus software may cause undesired operational problems with your DataMiner System, which are not covered under warranty or support. See [Exclusions](xref:Support_services_terms#exclusions) and [Supported products](xref:Support_services_terms#supported-products) in the *Support services terms*.
