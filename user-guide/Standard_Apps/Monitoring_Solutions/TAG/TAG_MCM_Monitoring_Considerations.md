---
uid: TAG_MCM_Monitoring_Considerations
---

# TAG MCM Considerations

When utilizing the TAG Management application with either MCS or MCM (depending on your configuration), it's important to note potential discrepancies in KPIs when exclusively using TAG MCM in your DataMiner agent.

This discrepancy may arise due to several reasons:

1. **API Limitations**: The TAG MCM API might not encompass all the data available in the TAG MCS API, leading to missing information.
   
2. **Connector Constraints**: The DataMiner Connector for TAG MCM might lack certain functionalities necessary for displaying complete information within the application.

3. **Data Collection Issues**: In some cases, the Low Code App may not be collecting all the required data through GQI (Generic Query Interface).

If you suspect missing information falls under the latter two categories, we recommend contacting your Technical Account Manager to ensure that any necessary updates are implemented in the application.

## Current Limitations

- **Overview Page**: Missing data includes Temperature, Recorders, and Outputs Limit.
  
- **Channel Status**: Bitrate, CPU Usage, Memory Allocation, and Profile data are absent.
  
- **Channels Configuration**: Recording information is not available.
