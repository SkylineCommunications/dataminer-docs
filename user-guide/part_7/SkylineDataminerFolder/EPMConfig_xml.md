## EPMConfig.xml

From DataMiner 10.2.0/10.1.7 onwards, it is possible to override the names of EPM topology cells, chains and search chains specified in a protocol with aliases specified in a separate file.

For this purpose, in the folder *C:\\Skyline DataMiner*, create an *EPMConfig.xml* file that contains a *\<Topologies>* and/or *\<Chains>* configuration identical to the one in the protocol, and specify the necessary aliases in override attributes.

For example:

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
> -  This file is not synchronized automatically. It is also only read at DataMiner startup.
> -  When you update the *EPMConfig.xml* file on a particular DMA, delete the \*.txf files on that DMA and restart DataMiner.
>
