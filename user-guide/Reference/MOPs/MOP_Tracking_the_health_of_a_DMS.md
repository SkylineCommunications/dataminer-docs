---
uid: MOP_Tracking_the_health_of_a_DMS
---

# Tracking the health of a DataMiner System

The procedure below details how you can configure elements in DataMiner that can be used to track the health of each DMA in the DataMiner System.

## Requirements

- Access to the DataMiner System and permission to create elements and configure alarm and trend templates.
- The Microsoft Platform protocol must be available in the DataMiner System.

## Procedure

Follow the steps below for each DMA in the DataMiner System.

1. Create a new element representing the DMA, using the *Microsoft Platform* protocol.

   For more information on how to create elements, see [Adding elements](xref:Adding_elements).

1. Make sure the *Poll Task Manager* parameter is enabled in the element and all parameters are polled.
1. Make sure the *Auto Clear Task Manager* parameter is enabled.
1. Assign an alarm template to the element to make sure alarm monitoring is enabled for the *Poll Task Manager* parameter.

   For more information on alarm templates, see [Alarm templates](xref:About_alarm_templates).

1. Assign a trend template to the element with average trending enabled for the parameters listed below. Create the trend template if it does not exist yet. Two standard templates are available for this, which can be downloaded [below](#standard-trend-templates).

   For more information on trend templates, see [Trend templates](xref:About_trend_templates).

   Average trending must be enabled for the following parameters:

   - In the *Performance* section:

     - *Available Physical Memory*
     - *Commit Charge Available*
     - *Commit Charge Total*
     - *Page File Usage*
     - *Pages per Second*
     - *Physical Memory Usage*
     - *Total Handles*
     - *Total Processor Load*
     - *Total Threads*

   - In the *Task Manager* section:

     - *CPU DataMinerCube* or *CPU PresentationHost* (depending on whether the Cube desktop app or browser app is used)
     - *CPU SL\**
     - *CPU Prunsrv*, *CPU mysql*, *CPU mssqlserver* or *CPU elasticsearch* (depending on which database or databases are used by the DMA)
     - *CPU DataMiner*
     - *CPU NATS*
     - *Handles SL\**
     - *Threads SL\**
     - *VM Size DataMinerCube* or *VM Size PresentationHost* (depending on whether the Cube desktop app or browser app is used)
     - *VM Size Prunsrv*, *VM Size mysql*, *VM Size mssqlserver* or *VM Size elasticsearch* (depending on which database or databases are used by the DMA)
     - *VM Size SL\**
     - *VM Size DataMiner*
     - *VM Size NATS*

   - In the *Network Interface* section:

     - *Total Speed [Network Adapter Table]*

   - In the *Disk Info* section:

     - *Avg. Disc sec/Transfer*
     - *Free Space*
     - *Percentage Busy Time*

## Time estimate

This procedure is estimated to take about 5 to 10 minutes per DMA.

It will take slightly longer for the first DMA, as the trend template will only need to be configured for one DMA. Afterwards, the same trend template can be assigned to the elements representing the other DMAs.

## Standard trend templates

- [Standard trend template for DMS health tracking (HW)](https://community.dataminer.services/download/standard-trend-template-for-dms-health-tracking-hw/)
- [Standard trend template for DMS health tracking (VM)](https://community.dataminer.services/download/standard-trend-template-for-dms-health-tracking-vm/)
