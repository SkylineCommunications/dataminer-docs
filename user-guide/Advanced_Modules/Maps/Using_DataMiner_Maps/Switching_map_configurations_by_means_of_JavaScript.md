---
uid: Switching_map_configurations_by_means_of_JavaScript
---

# Switching map configurations by means of JavaScript

You can switch from one DataMiner Maps configuration to another by means of JavaScript.

This can be useful in scenarios where the maps component is an iframe inside a parent page that allows you to view multiple map configurations. Instead of switching the URL of the iframe, the parent frame can ask the maps frame to load a different configuration.

#### Example

Suppose you have a parent HTML file that contains an iframe.

To select a map configuration, use the selectConfig(name, vars) method:

| Parameter | Description                                                                                                                        |
|-----------|------------------------------------------------------------------------------------------------------------------------------------|
| name      | The name of the configuration.                                                                                                     |
| vars      | An array of {Name: XXX, Value: YYY} pairs to be used for input in case the configuration has dynamic elements (i.e. placeholders). |

If the parent page contains the following script ...

```xml
<script type="text/javascript">
  function doOpenConfig(name, vars)
  {
    var e = document.getElementById('mapFrame');
    if (!e || !e.contentWindow)
    return false; // frame contents not found
    if (!e.contentWindow.selectConfig)
    return false; // frame is not a maps app
    try
    {
    e.contentWindow.selectConfig(name, vars);
    }
    catch (e)
    {
    alert('Error switching map: ' + e.message);
    }
    return false;
  }
</script>
```

... and the iframe has the ID "mapFrame" ...

```xml
<iframe width="800" height="600" id="mapFrame" src="/maps/map.aspx?config=mechelen"></iframe>
```

... then a configuration could be opened as follows:

```xml
<a href=""
  onclick="return doOpenConfig('mechelen.dynamic',
      [{ Name: 'numValue', Value: '200'},
      { Name: 'manager', Value: '7/46840' }]);">Config (dynamic 2)</a>
```

This would be identical to opening the following URL:

```txt
maps/map.aspx?config=mechelen.dynamic&dmanager=7/46840&dnumValue=200
```

> [!NOTE]
> When custom scripts are included in a map configuration, there can be side effects when you switch to another configuration. If you notice any side effects, then the custom scripts should be rewritten so that those side effects are dealt with.
