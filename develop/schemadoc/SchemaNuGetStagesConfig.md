---
uid: SchemaNuGetStagesConfig
---

# NuGet stages config schema

XML schema for configuring NuGet-related stages of the [custom solution CI/CD pipeline](xref:Pipeline_stages_for_custom_solutions).

## Root element

[NuGetStages](xref:NuGetStages)

## Example

```xml
<?xml version="1.0" encoding="utf-8" ?>
<NuGetStages xmlns="http://www.skyline.be/nuGetStagesConfig">
	<Configurations>
		<Configuration scope="development">
			<PackageCreation>
				<Enabled>true</Enabled>
			</PackageCreation>
			<PackageSigning>
				<Enabled>false</Enabled>
			</PackageSigning>
			<PackagePublishing>
				<Enabled>true</Enabled>
				<Destinations>
					<Destination>
						<Server>privateSkylineNuGetStore</Server>
					</Destination>
				</Destinations>
			</PackagePublishing>
		</Configuration>
		<Configuration scope="release">
			<PackageCreation>
				<Enabled>true</Enabled>
			</PackageCreation>
			<PackageSigning>
				<Enabled>true</Enabled>
			</PackageSigning>
			<PackagePublishing>
				<Enabled>true</Enabled>
				<Destinations>
					<Destination>
						<Server>privateSkylineNuGetStore</Server>
					</Destination>
				</Destinations>
			</PackagePublishing>
		</Configuration>
	</Configurations>
</NuGetStages>
```
