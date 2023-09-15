---
uid: Connector_help_Eutelsat_TAOS_Calculation
---

# Eutelsat TAOS Calculation

This connector allows to make calculation from the other elements that use the Eutelsat TAOS Manager protocol.

## About

The connector calculates the average, minimum and maximum values from a selected *Table* of an *Element* created with the Eutelsat TAOS Manager.

The user can select the following Tables from the related Element:

- **ALC Input Power**
- **FGM Output Power**
- **Anode Voltage**
- **Helix Current**
- **Bus Current**

Also, the connector calculates the average, minimum and maximum **OBO** *(Output Back-Off)* values. These calculations are done using the average, minimum and maximum values from the **TAOS Manager** Table mentioned previously. The formula for these **OBO** value calculations is given by the user.

Ranges of the connector

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

General
In this page the connector displays the following parameters:

- **Element:** Allows the user to select the element where is going to take the values.
- **Parameter:** Allows the user to select the table from the element.
- **TAOS Manager Values:** Displays the values taken from the selected table and it allows the user to include or not a specific value on the calculation.
- **Maximum Value:** The maximum value from the TAOS Manager table.
- **Minimum Value:** The minimum value from the TAOS Manager table.
- **Average Value:** The average value from the TAOS Manager table.
- **Formula:** Allows the user to write the formula that will be used to do the calculations. The formula must have the following format: *(VOL\[n\]\*x^N + VOL\[n-1\]\*x^(n-1) + ... + VOL\[1\]\*x^1 + VOL\[0\]\*x^0).*
- **VOL (Volume):** Allows the user to add values that would be used on the formula.
- **Maximum OBO Value:** The maximum OBO *(Output Back-Off)* value calculated with the formula.
- **Minimum OBO Value:** The minimum OBO *(Output Back-Off)* value calculated with the formula.
- **Average OBO Value:** The average OBO *(Output Back-Off)* value calculated with the formula.
