---
uid: Layer_groups
---

# Layer groups

In the `<ToggleGroups>` tag of a map configuration file, add a `<Group>` tag for every layer group you want to define.

## Defining layer groups

A `<Group>` tag can have the following two attributes:

- **name**: The name of the layer group.

- **height**: The height of the dropdown list (in pixels).

  - If you do not specify a height, the dropdown list will be automatically adjusted to the number of items in the list.
  - If you do specify a height, a scroll bar will automatically be added if the dropdown list is too small to list all items.

After you have defined all necessary layer groups, add a *toggleGroup* attribute to the `<Layer>` tag of every layer that you want to put in those groups. If you want to put a layer into a group called e.g. "MyGroup", then add a *toggleGroup* attribute to the `<Layer>` tag of that layer and set its value to "MyGroup".

The following code sample shows how to define a layer group called "My Layer Group" and how to add a layer called "My Layer" to that group:

```xml
<ToggleGroups>
  <Group name="My Layer Group" />
</ToggleGroups>
<Layers>
  <Layer sourceType="overlay" name="My Layer" visible="true" allowToggle="true" toggleGroup="My Layer Group"/>
</Layers>
```

On the map, the above-mentioned code will be rendered in the following way. Notice that, as we did not specify a height attribute in the `<Group>` tag, the dropdown list of the group is automatically adjusted to the number of items in the list.

![](~/dataminer/images/layergroups1.png)

> [!NOTE]
>
> - All layers of which the `<Layer>` tag does not contain a *toggleGroup* attribute will be put into a default layer group called "Layers".
> - If you put multiple layers with the same name into the same layer group, then those layers will be merged and represented by one single layer in that layer group. This means that when you activate that single layer, all layers that were merged into it will become visible.

## Separators in layer groups

In a layer group, you can insert separators by defining dummy layers of sourceType "separator". Layers of this type do not have any function other than displaying a kind of "section title" in a layer group.

The following code sample shows how the layers in a layer group have been subdivided into two types by inserting two separators:

```xml
<ToggleGroups>
  <Group name="My Layer Group"/>
</ToggleGroups>
<Layers>
  <Layer sourceType="separator" name="One type of layers" visible="true" allowToggle="true" textcolor="white" backgroundcolor="blue" toggleGroup="My Layer Group"/>
  <Layer sourceType="overlay" name="Layer 1" visible="true" allowToggle="true" toggleGroup="My Layer Group"/>
  <Layer sourceType="overlay" name="Layer 2" visible="true" allowToggle="true"  toggleGroup="My Layer Group"/>
  <Layer sourceType="separator" name="Another type of layers" visible="true" allowToggle="true" textcolor="white" backgroundcolor="green"  toggleGroup="My Layer Group"/>
  <Layer sourceType="overlay" name="Layer 3" visible="true" allowToggle="true"  toggleGroup="My Layer Group"/>
  <Layer sourceType="overlay" name="Layer 4" visible="true" allowToggle="true"  toggleGroup="My Layer Group"/>
</Layers>
```

On the map, the above-mentioned code will be rendered in the following way.

![](~/dataminer/images/layergroups2.png)

## Text color and background color of layer group items

It is possible to change both the text color and the background color of any item in a layer group, whatever its sourceType.

Colors can be specified by either a color keyword (red, green, yellow, etc.) or an RGB value (#CCCCCC, #00AEEF, #EEEEEE, etc.).

The following code sample shows how both the text color and the background color of layer group items can be changed:

```xml
<Layers>
  <Layer sourceType="overlay" name="Layer 1" visible="true" allowToggle="true" textcolor="#00AEEF" toggleGroup="My Layer Group"/>
  <Layer sourceType="overlay" name="Layer 2" visible="true" allowToggle="true" textcolor="white" backgroundcolor="gray" toggleGroup="My Layer Group"/>
</Layers>
```

On the map, the above-mentioned code will be rendered in the following way.

![](~/dataminer/images/layergroups3.png)
