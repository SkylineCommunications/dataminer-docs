---
uid: Connector_help_Eutelsat_Probe_Service
---

# Eutelsat Probe Service

This is an enhanced service protocol that allows more efficient alarm monitoring of the parameters included in the service.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

It is possible to create alarms based on parameter values or based on alarm states. In that case, you need to configure the inputs, outputs and thresholds on the **Compare Values** page.

It is also possible to create alarms based on alarm states. In that case, you need to configure the input and output on the **Compare Alarms** page.

For more information on how the alarms are generated, refer to the section below.

## How to Use

When the **Compare Values** option is used, you can configure two input (**A** and **B**) and two output (**X** and **Y**) parameters.

Alarms will be generated based on the following conditions: - if (max(**A**, **B**) - min(**A**, **B**)) / max(**A**, **B**) \> threshold **a** - if (max(**X**, **Y**) - min(**X**, **Y**)) / max(**X**, **Y**) \> threshold **a** - if (max(**A**, **X**) - min(**A**, **X**)) / max(**A**, **X**) \> threshold **b** or (max(**A**, **Y**) - min(**A**, **Y**)) / max(**A**, **Y**) \> threshold **c** - if (max(**B**, **X**) - min(**B**, **X**)) / max(**B**, **X**) \> threshold **b** or (max(**B**, **Y**) - min(**B**, **Y**)) / max(**B**, **Y**) \> threshold **c**

Alarms will be generated based on the following conditions for two inputs (**A**, **B**) and one output (**X**): - if (max(**A**, **B**) - min(**A**, **B**)) / max(**A**, **B**) \> threshold **a** - if (max(**A**, **X**) - min(**A**, **X**)) / max(**A**, **X**) \> threshold **b** - if (max(**B**, **X**) - min(**B**, **X**)) / max(**B**, **X**) \> threshold **c**

When the **Compare Alarms** option is used, you will receive alarms based on the following table:

| **Output 1** | **Output 2** | **Input 1** | **Input 2** | **Alarm Severity** | **Alarm Description**        |
|--------------|--------------|-------------|-------------|--------------------|------------------------------|
| Critical     | Critical     | Critical    | Critical    | Critical           | Loss of outputs and inputs   |
| Critical     | Critical     | Critical    | Normal      | Critical           | Loss of outputs and input 1  |
| Critical     | Critical     | Normal      | Critical    | Critical           | Loss of outputs and input 2  |
| Critical     | Critical     | Normal      | Normal      | Critical           | Loss of outputs              |
| Critical     | Normal       | Critical    | Critical    | Critical           | Loss of output 1 and inputs  |
| Critical     | Normal       | Critical    | Normal      | Major              | Loss of output 1 and input 1 |
| Critical     | Normal       | Normal      | Critical    | Major              | Loss of output 1 and input 2 |
| Critical     | Normal       | Normal      | Normal      | Major              | Loss of output 1             |
| Normal       | Critical     | Critical    | Critical    | Critical           | Loss of output 2 and inputs  |
| Normal       | Critical     | Critical    | Normal      | Major              | Loss of output 2 and input 1 |
| Normal       | Critical     | Normal      | Critical    | Major              | Loss of output 2 and input 2 |
| Normal       | Critical     | Normal      | Normal      | Major              | Loss of output 2             |
| Normal       | Normal       | Critical    | Critical    | Critical           | Loss of inputs               |
| Normal       | Normal       | Critical    | Normal      | Major              | Loss of input 1              |
| Normal       | Normal       | Normal      | Critical    | Major              | Loss of input 2              |

## Notes

This connector was created specifically for Eutelsat.
