namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Globalization;
	using System.Text;

	/// <summary>
	/// Represents a view configuration.
	/// </summary>
	public class ViewConfiguration
    {
        private IDmsView parent;
        private string name;

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewConfiguration"/> class.
		/// </summary>
		/// <param name="name">The name of the view.</param>
		/// <param name="parent">The parent view.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="parent"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> is empty or white space.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> exceeds 200 characters.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> contains a forbidden character. Forbidden characters: '|'.</exception>
		/// <exception cref="ArgumentException"><paramref name="name"/> contains more than one '%' character.</exception>
		public ViewConfiguration(string name, IDmsView parent)
        {
            Name = name;
            Parent = parent;
        }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The value of a set operation is empty or white space.</exception>
		/// <exception cref="ArgumentException">The value of a set operation exceeds 200 characters.</exception>
		/// <exception cref="ArgumentException">The value of a set operation contains a forbidden character. Forbidden characters: '|'.</exception>
		/// <exception cref="ArgumentException">The value of a set operation contains more than one '%' character.</exception>
		public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = InputValidator.ValidateViewName(value, "value");
			}
        }

		/// <summary>
		/// Gets or sets the parent view.
		/// </summary>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		public IDmsView Parent
        {
            get
            {
                return parent;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                parent = value;
            }
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(CultureInfo.InvariantCulture, "Name: {0}{1}", Name, Environment.NewLine);
			sb.AppendFormat(CultureInfo.InvariantCulture, "Parent: {0}{1}", Parent, Environment.NewLine);

			return sb.ToString();
		}
	}
}