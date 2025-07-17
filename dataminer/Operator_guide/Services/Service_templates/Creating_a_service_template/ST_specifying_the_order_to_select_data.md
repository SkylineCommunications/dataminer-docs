---
uid: ST_specifying_the_order_to_select_data
---

# Specifying the order to select data in a service template

In some cases, it may be necessary to explicitly specify the order in which child elements and input data will be selected when the service is generated.

When no custom order is configured, the following order is taken automatically:

- Input data without references to child elements

- Child elements

- Input data with references to child elements

To configure a custom order:

1. Go to the *Advanced* tab of the service template.

1. In the *Input order* box, enter the elements and input data, in the format *element:\[child element ID\]* and *data:\[input data name\]*, separated by a “\|” sign.

   Example:

   ```txt
   data:svc|element:1|data:tsid|element:2
   ```
