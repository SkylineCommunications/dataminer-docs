---
uid: PingMonitoring
---

# DataMiner Ping Monitoring tool

The DataMiner Ping Monitoring tool is a web application designed to simplify the monitoring of your network infrastructure and services, while identifying potential network outages.

Ping Monitoring automates the process of verifying whether an internet destination, such as an IP address or host name, responds to ping commands. This is achieved by sending automated ICMP echo requests to the specified destination at a user-defined frequency and waiting for the expected response.

> [!NOTE]
> The Ping Monitoring tool serves as an HTML5 front end that exclusively monitors elements using the [*Generic Ping* connector](xref:Installing_Ping_Monitoring#prerequisites).

You can customize the monitoring frequency to meet your specific requirements, ranging from intervals of a few seconds to several minutes. Each monitored destination is expected to provide a response to every packet sent. In the event of no reply within a predefined period, the tool identifies a network issue and can trigger alarms and notifications.

> [!TIP]
> See also:
>
> - [Ping Monitoring use case](https://community.dataminer.services/use-case/ping-monitoring/) for several use cases and application highlights
> - [Ping Monitoring - DataMiner Use Case Demo](https://www.youtube.com/watch?v=LpYbxc0jIro) for a visual guide ![Video](~/dataminer/images/video_Duo.png)
