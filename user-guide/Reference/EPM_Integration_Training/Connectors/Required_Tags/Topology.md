---
uid: connectorsRequiredTagsTopology
---

# Topology

In the EPM Manager connector, you will find the `<Topologies>` tag, where each distinct topology is defined.
Inside each `<Topology>` tag, you'll find the `<Cell>` tags, these representing the cells in the EPM topology. Basically, these cells allow you to define the levels visible in a topology and connections between them.

## Topology Example

```xml
<Topologies>
	<Topology>
		<Cell name="Network" table="9500"></Cell>
		<Cell name="Region" table="8500">
			<Link source="1" dest="9501"/>
		</Cell>
		<Cell name="Sub-Region" table="7500">
			<Link source="1" dest="8501"/>
		</Cell>
		<Cell name="Hub" table="6500">
			<Link source="1" dest="7501"/>
		</Cell>
		<Cell name="Station" table="5500">
			<Link source="1" dest="6501"/>
		</Cell>
		<Cell name="Device" table="2500">
			<Link source="1" dest="5501"/>
		</Cell>
	</Topology>
</Topologies>
```

## Cell

The `<Cell>` tag is used to define the levels present in the topologies and to associate each level with a specific entity table.

| Attribute | Description                                                    |
|-----------|----------------------------------------------------------------|
| `name`    | Defines the name of the level.                                 |
| `table`   | Defines the table linked to the level. The tables should be the respective View Tables. |

## Link

The `<Link>` tag is used to define the connections of each `<Cell>` (topology level).

| Attribute | Description                                                    |
|-----------|----------------------------------------------------------------|
| `source`  | An ID used to identify the source.                             |
| `dest`    | Parameter ID used to define the connection. Must be the index of the View Table. |