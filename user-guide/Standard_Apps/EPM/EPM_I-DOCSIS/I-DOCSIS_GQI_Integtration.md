---
uid: I-DOCSIS_GQI_Integration
---

# I-DOCSIS GQI Integration

Due the to aggregative nature of EPM, many of the tables in the Frontend element have no. To query the information using GQI, you need query where the data resides. Below is a table showing where all of the data levels information reside.

| EPM Level | Frontend (Skyline EPM Platform) | Backend (Skyline EPM Platform DOCSIS) |
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
> When querying data from the EPM drivers, the tables will show as duplicated. The first entry will be the source table and the second entry is the view table. It is recommended to use the first entry.

### Cable Modem KPI's
The Cable Modem information is seperated between the CCAP Collectors and the Generic DOCSIS CM Collector Elements.

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


