---
uid: About_trend_templates
---

# About trend templates

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Curious to see trend templates in action? Watch <a href="xref:Adding_and_deleting_trend_templates" style="color: #657AB7;">this short video</a>.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

Trend templates allow to define exactly for which parameters trending information has to be logged in the trending database, and which kind of trending information has to be included.

In a trend template, you can define both the scope and the type of the trend information to be stored in the trending database:

- Scope: You can determine exactly for which parameters of an element trending information has to be stored. Different selections can be made for different elements.

- Type: You can choose between real-time or average trending, or a combination of both.

  - **Real-time trending**: Continuous logging of all measurements, in a sliding window of maximum 1000 hours.

  - **Average trending**: Logs average trending per time slot. The time slot depends on the size of the window.

    > [!NOTE]
    >
    > - In case of average trending, the DMS not only stores the average value for a particular time slot, but also the minimum and maximum value detected in that same time slot.
    > - Average trend values and values of parameters with average type “sum” are only calculated for the current runtime of the element. Values measured during the same trend interval, but in a previous runtime of the element (e.g., after an element or DataMiner restart) are not taken into account.

> [!TIP]
> See also: [Trending](xref:trending)