---
uid: SchemaPackageManifest
---

# Package manifest schema

XML schema for defining the contents of an application package. For more information, refer to [Application packages](xref:TOOApplicationPackages) and [Pipeline stages for install packages](xref:Pipeline_stages_for_install_packages).

## Root element

[Manifest](xref:Manifest)

## Example

```xml
<?xml version="1.0" encoding="utf-8"?>
<Manifest xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/packageManifest">
	<Name>ExamplePackage</Name>
	<Version>1.0.1-CU0</Version>
	<Content>
		<Protocols>
			<Protocol>
				<RepoPath>Protocols\Microsoft\Platform</RepoPath>
				<Version>
					<Selection>
						<Range rangeSelection="latestRelease">1.1.2.X</Range>
					</Selection>
					<SetAsProduction>false</SetAsProduction>
				</Version>
				<SignDevelopmentVersion>true</SignDevelopmentVersion>
			</Protocol>
			<Protocol>
				<RepoPath>Protocols\Apache\Cassandra Cluster Monitor</RepoPath>
				<Version>
					<Selection>
						<Range rangeSelection="latestRelease">1.0.0.X</Range>
					</Selection>
					<SetAsProduction copyTemplates="true">true</SetAsProduction>
				</Version>
				<Templates>
					<AlarmTemplates>
						<Template replaceExisting="true">Template_Default</Template>
					</AlarmTemplates>
					<TrendTemplates>
						<Template replaceExisting="true">Trending_Default</Template>
					</TrendTemplates>
				</Templates>
				<SignDevelopmentVersion>true</SignDevelopmentVersion>
			</Protocol>
			<Protocol>
				<RepoPath>Protocols\Elastic\ElasticSearch Cluster Monitor</RepoPath>
				<Version>
					<Selection>
						<Range rangeSelection="latestRelease">1.0.0.X</Range>
					</Selection>
					<SetAsProduction>true</SetAsProduction>
				</Version>
				<SignDevelopmentVersion>true</SignDevelopmentVersion>
			</Protocol>
		</Protocols>
	</Content>
	<VersionHistory>
		<Branches>
			<Branch id="1">
				<MajorVersions>
					<MajorVersion id="0">
						<MinorVersions>
							<MinorVersion id="1">
								<CUVersions>
									<CU id="0">
										<Changes>
											<NewFeature>Initial Version</NewFeature>
										</Changes>
										<Date>2022-02-10</Date>
										<Provider>
											<Company>Skyline Communications</Company>
											<Author>TBE</Author>
										</Provider>
									</CU>
								</CUVersions>
							</MinorVersion>
						</MinorVersions>
					</MajorVersion>
				</MajorVersions>
			</Branch>
		</Branches>
	</VersionHistory>
</Manifest>
```
