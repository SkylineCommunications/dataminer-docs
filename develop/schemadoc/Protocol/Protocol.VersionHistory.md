---
uid: Protocol.VersionHistory
---

# VersionHistory element

<!-- RN 17697, RN 18360 -->

Contains an overview of the version history of this protocol.

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Branches](xref:Protocol.VersionHistory.Branches)||Contains the different branches of this protocol.|

## Examples

```xml
<VersionHistory>
  <Branches>
    <Branch id="1">
      <Comment>Initial branch.</Comment>
      <SystemVersions>
        <SystemVersion id="0">
          <MajorVersions>
            <MajorVersion id="0">
              <MinorVersions>
                <MinorVersion id="1">
                  <Date>2012-10-22</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <NewFeature>Initial version.</NewFeature>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="2">
                  <Date>2015-05-28</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <Fix>Added a check to make sure a Nimbra element is fully loaded in SLElement before doing a get on it (QAction 5/5299/5399) to prevent exceptions.</Fix>
                    <Fix>Buffered the elements creation to avoid RTEs.</Fix>
                    <NewFeature>Added an "Element Creation Progress" parameter.</NewFeature>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="3">
                  <Date>2015-11-09</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <NewFeature>Support Hitless Services.</NewFeature>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="4">
                  <Date>2015-11-24</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <Change>Made the code more robust and dynamic to allow changing the Nimbra connector columns without having to adapt the manager every time.</Change>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="5">
                  <Date>2016-04-11</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <Fix>Some InterApp calls (ex: 'Delete Service' IAS) were throwing exceptions.</Fix>
                    <NewFeature>Support fully deleting hitless services in one go.</NewFeature>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="6">
                  <Date>2016-05-26</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <Fix>Discovered Element Creation was not working properly.</Fix>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="7">
                  <Date>2016-08-03</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <NewFeature>Added some columns to the DTM Overview Table (coming from the DTM Interfaces Table).</NewFeature>
                    <NewFeature>Added the Ethernet Forwarding Functions Table.</NewFeature>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="8">
                  <Date>2016-10-10</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <Fix>Deleting a service was not nicely showing feedback in case of removing the last TTP of a node.</Fix>
                    <Fix>Corrected a few spelling mistakes in the connector.</Fix>
                  </Changes>
                </MinorVersion>
                <MinorVersion id="9">
                  <Date>2016-10-24</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                  <Changes>
                    <Fix>When a node is removed from the Nodes Table, the related rows are now also deleted from "DTM Interfaces Table", "Trunk Link Details", "Trunk Link".</Fix>
                    <Fix>"Eth Forwarding Functions Table" has been made volatile.</Fix>
                  </Changes>
                </MinorVersion>
              </MinorVersions>
            </MajorVersion>
              <MajorVersion id="1">
                <MinorVersions>
                  <MinorVersion id="1" basedOn="1.0.0.9">
                  <Changes>
                    <Change>Used Mbps instead of kbps for all bit rate values.</Change>
                  </Changes>
                  <Date>2016-10-24</Date>
                  <Provider>
                    <Company>Skyline</Company>
                    <Author>SVD</Author>
                  </Provider>
                </MinorVersion>
              </MinorVersions>
            </MajorVersion>
          </MajorVersions>
        </SystemVersion>
      </SystemVersions>
    </Branch>
  </Branches>
</VersionHistory>
```
