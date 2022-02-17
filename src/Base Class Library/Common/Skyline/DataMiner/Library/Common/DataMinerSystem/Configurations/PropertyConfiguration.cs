namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Library.Common.Properties;

    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// Represents a property configuration.
    /// </summary>
    public class PropertyConfiguration : INotifyPropertyChanged
    {
        private readonly IDmsPropertyDefinition definition;
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyConfiguration"/> class.
        /// </summary>
        /// <param name="config">The configuration of the element.</param>
        /// <param name="definition">The definition of the property.</param>
        /// <param name="value">The value that should be assigned to the property.</param>
        /// <exception cref="ArgumentNullException"><paramref name="definition"/> or <paramref name="config"/> is <see langword="null"/>.</exception>
        internal PropertyConfiguration(ElementConfiguration config, IDmsPropertyDefinition definition, string value)
        {
            if (definition == null)
            {
                throw new ArgumentNullException("definition");
            }

            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            this.value = value;
            this.definition = definition;

            PropertyChanged += config.PropertyChanged;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyConfiguration"/> class.
		/// </summary>
		/// <param name="config">The configuration of the service.</param>
		/// <param name="definition">The definition of the property.</param>
		/// <param name="value">The value that should be assigned to the property.</param>
		/// <exception cref="ArgumentNullException"><paramref name="definition"/> or <paramref name="config"/> is <see langword="null"/>.</exception>
		internal PropertyConfiguration(ServiceConfiguration config, IDmsPropertyDefinition definition, string value)
		{
			if (definition == null)
			{
				throw new ArgumentNullException("definition");
			}

			if (config == null)
			{
				throw new ArgumentNullException("config");
			}

			this.value = value;
			this.definition = definition;

			PropertyChanged += config.PropertyChanged;
		}

		/// <summary>
		/// Occurs when the value of a property changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the property definition.
        /// </summary>
        public IDmsPropertyDefinition Definition
        {
            get
            {
                return definition;
            }
        }

        /// <summary>
        /// Gets or sets the property value.
        /// </summary>
        /// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The value of a set operation is invalid.</exception>
        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                if (!definition.IsValidInput(value))
                {
                    throw new ArgumentException("value", String.Format(CultureInfo.InvariantCulture, "The value:'{0}' cannot be assigned to the property.", value));
                }

                this.value = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Notifies when a property was changed.
        /// </summary>
        private void NotifyPropertyChanged()
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(definition.Name));
            }
        }
    }
}