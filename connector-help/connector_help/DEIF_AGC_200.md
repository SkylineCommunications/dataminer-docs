---
uid: Connector_help_DEIF_AGC_200
---

# DEIF AGC 200

This serial connector can be used to monitor the DEIF Advanced Genset Controller 200 series, a power generator interface controller.

## About

The advanced controller series integrates all necessary functions for genset protection and control, and stands out for its reliability and operator-friendliness. The AGC 200 applies asymmetric load sharing to ensure optimal load on the genset, in order to cut operation costs and reduce harmful emissions. It arrests cooling at pre-programmed cooldown temperatures and features automatic priority selection, setting the optimum combination of gensets for optimized fuel consumption.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.59                        |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *502*.

## Usage

### General

General overview of the generator, including power, alarms, RPM and start attempts.

### Generator

Detailed information and statistics related to the running time, energy generated, Cos-Phi and breakers.

### Phase Values

Information about the generator phases, voltages, currents, frequencies, phase angles, power generated, apparent power and reactive power.

### Busbar Info

Information about the busbar phases, voltage, frequency, angle and phase angle.

### Engine

Detailed information about the monitored generator engine works and wears.

### Cooling System

Detailed information about the cooling system.

### Fuel System

Detailed information about the fuel system.

### Lubrication System

Detailed information about the lubrication system.

### Air Intake System

Detailed information about the engine air intake system.

### Exhaust System

Detailed information about the engine exhaust system.

### After Treatment

Detailed information about the fuel after treatment.

### Environment

Detailed information about the engine environment.

### Turbo Charger

Detailed information about the engine turbo charger system.

### Alarms

Monitored status of the engine operation and environment.
