---
uid: I-DOCSIS_GQI_Integration
keywords: I-DOCSIS GQI integration
---

# Integrated DOCSIS GQI integration

Because of the aggregative nature of EPM, many of the tables in the front-end element have no data of their own. To query the information using GQI, you need to query the actual location where the data resides. Below is a table showing where the information of the different data levels resides.

| EPM Level | Front end (Skyline EPM Platform) | Back end (Skyline EPM Platform DOCSIS) |
| :---: | :---: | :---: |
| Network | X | - |
| Market | X | - |
| Hub | X | - |
| CCAP Core | - | X |
| DS Linecard | - | X |
| US Linecard | - | X |
| DS Port | - | X |
| US Port | - | X |
| Node Segment | - | X |
| Service Group [Fiber Node] | - | X |
| DS Service Group | - | X |
| US Service Group | - | X |

> [!NOTE]
> When you query data from the EPM connectors, the tables will show as duplicated. The first entry will be the source table and the second entry is the view table. The first entry is what you should use for queries.

> [!IMPORTANT]
> Be careful when performing multiple GQI operations (especially the Join operation) on the Skyline EPM Platform DOCSIS connectors. Because of the large amount of data in EPM, the queries can time out and take too long to resolve.

## Cable modem KPIs

The cable modem information is spread over the CCAP collectors and the Generic DOCSIS CM Collector elements.

| CM KPI | CCAP Collector | Generic DOCSIS CM Collector |
| :--- | ---: | ---: |
| MAC | X | X |
| IP | X | X |
| Last Registration Time | X | - |
| Cable Interface | X | - |
| Status | X | - |
| DOCSIS Version | - | X |
| Vendor | - | X |
| Model Number | - | X |
| Software Version | - | X |
| Uptime | - | X |
| Memory Size | - | X |
| Processor Utilization | - | X |
| Reflection Distance | - | X |
| RTT | - | X |
| Jitter | - | X |
| Latency | - | X |
| Packet Loss | - | X |
| DS SNR Status | - | X |
| DS Post FEC Status | - | X |
| DS Rx Power Status | - | X |
| US Tx Power Status | - | X |
| US SNR Status | X | - |
| US Time Offset Status | X | - |
| US Rx Power Status | X | - |
| US Post FEC Status | X | - |
| Reflection Distance | - | X |
| Group Delay Status | - | X |
| Reflection Status | - | X |
