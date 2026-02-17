---
uid: EPMConfig_xml
---

# EPMConfig.xml

From DataMiner 10.2.0/10.1.7 onwards, it is possible to override the names of EPM topology cells, chains and search chains specified in a protocol with aliases specified in a separate file.

To create system-wide overrides, in the folder `C:\Skyline DataMiner`, create an *EPMConfig.xml* file that contains a *\<Topologies>* and/or *\<Chains>* configuration identical to the one in the protocol, and specify the necessary aliases in override attributes.

From DataMiner 10.2.2/10.3.0 onwards, you can also add *EPMConfig.xml* files on element level to apply overrides to specific elements only, overriding the system-level *EPMConfig.xml* file if there is any. To add such an element-level *EPMConfig.xml* file, place it in the folder of the relevant element (e.g., `C:\Skyline DataMiner\Elements\<ElementName>\`).

This is an example of the *EPMConfig.xml* configuration:

```xml
<Protocol>
  <Topologies>
    <Topology name="" override="CustomChainName">
      <Cell name="CM" override="Cable Modem"/>
      <Cell name="OLT" override="Hub"/>
      <Cell name="Street" override="CustomStreet"/>
    </Topology>
    ...
  </Topologies>
  <Chains>
    <Chain name="OLT (Limited)" override="Full OLT">
      <Field name="Network" override="Mesh"/>
    </Chain>
    ...
    <SearchChain name="search">
      <Tabs>
        <Tab name="STB" override="Box">
          <Field name="Customer ID" override="User ID"/>
        </Tab>
      </Tabs>
    </SearchChain>
    ...
  </Chains>
</Protocol>
```

> [!NOTE]
>
> - *EPMConfig.xml* is not synchronized automatically. It is also only read at DataMiner startup.
> - For systems where some of the cell names and field names are identical, we recommend using identical overrides to avoid creating a confusing user interface.
