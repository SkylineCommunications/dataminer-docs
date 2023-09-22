---
uid: EPM_1.0.5_VSAT
---

# EPM 1.0.5 VSAT - preview

## New features

#### Intelsat Flex Platform VSAT added [ID_37326]

The EPM VSAT Solution now includes the Intelsat Flex Platform VSAT connector, which is a virtual connector designed to streamline the presentation of critical data sourced from Intelsat terminals.

## Changes

### Enhancements

#### New Expiration Date column in PLM Overview table [ID_37327]

<!-- See fixes for other part of RN -->

A new *Expiration Date* column has been added to the PLM Overview table. This will allow users to easily see when recurrent PLM activities are set to expire.

### Fixes

#### Generic Trap Processor: Security issue related to BinaryFormatter [ID_37310]

A security issue related to the use of the BinaryFormatter type has been addressed in the *Generic Trap Processor* connector.

#### PLM date stuck in the past [ID_37327]

<!-- See enhancements for other part of RN -->

When an element was stopped, and a recurrent PLM activity was missed, it could occur that the system failed to calculate the next run date, causing the PLM date to become stuck in the past.
