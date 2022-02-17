using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Net.Jobs;
using Skyline.DataMiner.Net.Sections;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Defines extension methods on <see cref="ISectionContainer"/> and <see cref="Section"/>.
	/// </summary>
	public static class SectionUtils
    {
		/// <summary>
		/// Adds or updates the specified field of the specified section in the specified container to the specified value.
		/// </summary>
		/// <typeparam name="T">The type of the value.</typeparam>
		/// <param name="container">The section container.</param>
		/// <param name="sectionDefinition">The section definition.</param>
		/// <param name="fieldDescriptor">The field descriptor.</param>
		/// <param name="value">The value.</param>
		/// <exception cref="ArgumentNullException"><paramref name="container"/>, <paramref name="sectionDefinition"/> or <paramref name="fieldDescriptor"/> is <see langword="null"/>.</exception>
		/// <remarks>The first <see cref="Section"/> found for the given <paramref name="sectionDefinition"/> gets <paramref name="value"/> as its value for <paramref name="fieldDescriptor"/>. If no <see cref="Section"/> is found, a new one is created and added.</remarks>
		public static void AddOrUpdateFieldValue<T>(
            this ISectionContainer container, 
            SectionDefinition sectionDefinition,
            FieldDescriptor fieldDescriptor,
            T value)
        {
        }

		/// <summary>
		/// Adds or updates the value of the specified field of the specified section.
		/// </summary>
		/// <typeparam name="T">The type of the value.</typeparam>
		/// <param name="section">The section that holds the field.</param>
		/// <param name="fieldDescriptor">The field descriptor ID of the field to add or update.</param>
		/// <param name="value">The value.</param>
		/// <exception cref="ArgumentNullException"><paramref name="section"/> or <paramref name="fieldDescriptor"/> is <see langword="null"/>.</exception>
		/// <remarks>Adds or updates the specified <see cref="Section"/> with a <see cref="FieldValue"/> that points to the given <paramref name="fieldDescriptor"/> and contains a <see cref="ValueWrapper{T}"/> with value <paramref name="value"/>.</remarks>
		public static void AddOrUpdateValue<T>(
            this Section section,
            FieldDescriptor fieldDescriptor,
            T value)
        {
        }

		/// <summary>
		/// Retrieves the field value of the specified field in the specified section in the specified container.
		/// </summary>
		/// <typeparam name="T">The type to use for the returned <see cref="ValueWrapper{T}"/> instance.</typeparam>
		/// <param name="container">The section container.</param>
		/// <param name="sectionDefinition">The section definition.</param>
		/// <param name="fieldDescriptor">The field descriptor.</param>
		/// <returns>The value or <see langword="null" /> if the field was not found.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="container"/>, <paramref name="sectionDefinition"/> or <paramref name="fieldDescriptor"/> is <see langword="null"/>.</exception>
		/// <remarks>Returns the value of the first <see cref="Section"/> for the given <paramref name="sectionDefinition"/>.</remarks>
		public static ValueWrapper<T> GetFieldValue<T>(
            this ISectionContainer container,
            SectionDefinition sectionDefinition,
            FieldDescriptor fieldDescriptor)
        {
			return null;
		}

		/// <summary>
		/// Returns the <see cref="ValueWrapper{T}"/> for the specified <paramref name="fieldDescriptorID"/>.
		/// </summary>
		/// <typeparam name="T">The type to use for the returned <see cref="ValueWrapper{T}"/> instance.</typeparam>
		/// <param name="section">The section that holds the field.</param>
		/// <param name="fieldDescriptorID">The field descriptor ID of the field to retrieve.</param>
		/// <returns>The value or <see langword="null" /> if the field was not found.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="section"/> or <paramref name="fieldDescriptorID"/> is <see langword="null"/>.</exception>
		public static ValueWrapper<T> GetValue<T>(
            this Section section,
            FieldDescriptorID fieldDescriptorID)
        {
			return null;
		}
    }
}