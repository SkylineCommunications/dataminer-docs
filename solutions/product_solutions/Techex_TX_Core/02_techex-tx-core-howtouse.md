---
uid: techex-tx-core-howtouse
---

# Using the Techex TX Core App

The Techex TX Core DataMiner solution offers end-to-end monitoring and orchestration of the tx core platform and tx edges from a single pane of glass. Although this network orchestration solution package is still a first version and may not yet cover the full feature set of the tx core and tx edge products, it enables off-the-shelf monitoring and orchestration of the Techex tx core platform.

## Infrastructure

On the landing page of the app, you can see the total number of tx core and tx edge instances, along with the health status of each instance. You can select a tx core instance to filter the displayed tx edges. From this page, you can monitor the cluster infrastructure, verify system uptime, and ensure proper connectivity between DataMiner and tx core.

![Infrastructure](~/user-guide/images/techex-txcore-infrastructure.png)

### Services

On the Services page, you can find more details about each service across all tx edge instances. This includes a summary of alarms across different layers, such as those related to the transport stream and IP layer. In the lower right corner, the DataMiner node edge component has been used for a visual representation of the connectivity.

![Services](~/user-guide/images/techex-txcore-services.png)

## Source and Output Summary
By double-clicking any source or destination, you will be redirected to the Node Summary page, which displays key parameters and metrics for source or output streams.

![Source Summary](~/user-guide/images/techex-txcore-source.png)

## End to end view
What sets this app apart is the end-to-end view. DataMiner automatically calculates the connectivity of each service across multiple tx edge instances, making it incredibly convenient to track your streams from their source all the way to their final destination. Additionally, we've incorporated controls to stop and resume streams or trigger failovers.

![End to end view](~/user-guide/images/techex-txcore-e2e.png)

## Monitoring
The Monitoring page provides a comprehensive overview of all existing alarms, including those from the past 24 hours for ETR290, sources, and outputs.

![Monitoring](~/user-guide/images/techex-txcore-monitoring.png)
