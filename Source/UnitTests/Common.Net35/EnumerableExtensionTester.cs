using System;
using System.Collections.Generic;
using System.Linq;

using Junior.Common.Net35;

using NUnit.Framework;

namespace Junior.Common.UnitTests.Common.Net35
{
	public static class EnumerableExtensionTester
	{
		[TestFixture]
		public class When_calling_EnsureNotEmpty_on_empty_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				IEnumerable<object> value = new object[0];

				var exception = Assert.Throws<ArgumentException>(() => value.EnsureNotEmpty("value", "message"));

				Assert.That(exception.Message, Is.EqualTo(String.Format("message{0}Parameter name: value", Environment.NewLine)));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotEmpty_on_valid_parameter
		{
			[Test]
			public void Must_return_value()
			{
				IEnumerable<object> value = new object[] { 0 };

				Assert.That(value.EnsureNotEmpty("value"), Is.SameAs(value));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrEmpty_on_empty_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				IEnumerable<object> value = new object[0];

				var exception = Assert.Throws<ArgumentException>(() => value.EnsureNotNullOrEmpty("value", null, "message"));

				Assert.That(exception.Message, Is.EqualTo(String.Format("message{0}Parameter name: value", Environment.NewLine)));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrEmpty_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				IEnumerable<object> value = null;

				// ReSharper disable once ExpressionIsAlwaysNull
				var exception = Assert.Throws<ArgumentNullException>(() => value.EnsureNotNullOrEmpty("value", "message"));

				Assert.That(exception.Message, Is.EqualTo(String.Format("message{0}Parameter name: value", Environment.NewLine)));
			}
		}

		[TestFixture]
		public class When_calling_EnsureNotNullOrEmpty_on_valid_parameter
		{
			[Test]
			public void Must_return_value()
			{
				IEnumerable<object> value = new object[] { 0 };

				Assert.That(value.EnsureNotNullOrEmpty("value"), Is.SameAs(value));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrEmpty_on_empty_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				IEnumerable<object> value = new object[0];

				var exception = Assert.Throws<ArgumentException>(() => value.ThrowIfNullOrEmpty("value", null, "message"));

				Assert.That(exception.Message, Is.EqualTo(String.Format("message{0}Parameter name: value", Environment.NewLine)));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrEmpty_on_null_parameter
		{
			[Test]
			public void Must_throw_exception()
			{
				IEnumerable<object> value = null;

				// ReSharper disable once ExpressionIsAlwaysNull
				var exception = Assert.Throws<ArgumentNullException>(() => value.ThrowIfNullOrEmpty("value", "message"));

				Assert.That(exception.Message, Is.EqualTo(String.Format("message{0}Parameter name: value", Environment.NewLine)));
			}
		}

		[TestFixture]
		public class When_calling_ThrowIfNullOrEmpty_on_valid_parameter
		{
			[Test]
			public void Must_not_throw_exception()
			{
				IEnumerable<object> value = new object[] { 0 };

				Assert.DoesNotThrow(() => value.ThrowIfNullOrEmpty("value"));
			}
		}

		[TestFixture]
		public class When_converting_empty_enumerable_to_empty
		{
			[Test]
			public void Must_convert_to_empty()
			{
				Assert.That(Enumerable.Empty<object>().NullToEmpty(), Is.Empty);
			}
		}

		[TestFixture]
		public class When_converting_empty_enumerable_to_null
		{
			[Test]
			public void Must_convert_to_null()
			{
				Assert.That(Enumerable.Empty<object>().EmptyToNull(), Is.Null);
			}
		}

		[TestFixture]
		public class When_converting_non_empty_enumerable_to_empty
		{
			[Test]
			public void Must_return_enumerable()
			{
				var value = new[] { "" };

				Assert.That(value.NullToEmpty(), Is.SameAs(value));
			}
		}

		[TestFixture]
		public class When_converting_non_empty_enumerable_to_null
		{
			[Test]
			public void Must_return_enumerable()
			{
				var value = new[] { "" };

				Assert.That(value.EmptyToNull(), Is.SameAs(value));
			}
		}

		[TestFixture]
		public class When_converting_null_enumerable_to_empty
		{
			[Test]
			public void Must_convert_to_empty()
			{
				Assert.That(((IEnumerable<object>)null).NullToEmpty(), Is.Empty);
			}
		}

		[TestFixture]
		public class When_converting_null_enumerable_to_null
		{
			[Test]
			public void Must_convert_to_null()
			{
				Assert.That(((IEnumerable<object>)null).EmptyToNull(), Is.Null);
			}
		}

		[TestFixture]
		public class When_enumerable_has_equal_count_of_objects_than_a_countequal_comparison
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(new[] { 1, 2 }.CountEqual(2), Is.True);
			}
		}

		[TestFixture]
		public class When_enumerable_has_equal_count_of_objects_than_a_countgreaterthan_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountGreaterThan(2), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_equal_count_of_objects_than_a_countgreaterthanorequal_comparison
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(new[] { 1, 2 }.CountGreaterThanOrEqual(2), Is.True);
			}
		}

		[TestFixture]
		public class When_enumerable_has_equal_count_of_objects_than_a_countlessthan_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountLessThan(2), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_equal_count_of_objects_than_a_countlessthanorequal_comparison
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(new[] { 1, 2 }.CountLessThanOrEqual(2), Is.True);
			}
		}

		[TestFixture]
		public class When_enumerable_has_greater_count_of_objects_than_a_countequal_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountEqual(1), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_greater_count_of_objects_than_a_countgreaterthan_comparison
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(new[] { 1, 2 }.CountGreaterThan(1), Is.True);
			}
		}

		[TestFixture]
		public class When_enumerable_has_greater_count_of_objects_than_a_countgreaterthanorequal_comparison
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(new[] { 1, 2 }.CountGreaterThanOrEqual(1), Is.True);
			}
		}

		[TestFixture]
		public class When_enumerable_has_greater_count_of_objects_than_a_countlessthan_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountLessThan(1), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_greater_count_of_objects_than_a_countlessthanorequal_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountLessThanOrEqual(1), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_smaller_count_of_objects_than_a_countequal_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountEqual(3), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_smaller_count_of_objects_than_a_countgreaterthan_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountGreaterThan(3), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_smaller_count_of_objects_than_a_countgreaterthanorequal_comparison
		{
			[Test]
			public void Must_return_false()
			{
				Assert.That(new[] { 1, 2 }.CountGreaterThanOrEqual(3), Is.False);
			}
		}

		[TestFixture]
		public class When_enumerable_has_smaller_count_of_objects_than_a_countlessthan_comparison
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(new[] { 1, 2 }.CountLessThan(3), Is.True);
			}
		}

		[TestFixture]
		public class When_enumerable_has_smaller_count_of_objects_than_a_countlessthanorequal_comparison
		{
			[Test]
			public void Must_return_true()
			{
				Assert.That(new[] { 1, 2 }.CountLessThanOrEqual(3), Is.True);
			}
		}

		[TestFixture]
		public class When_retrieving_object_by_a_maximum_value
		{
			[Test]
			public void Must_retrieve_correct_object()
			{
				var systemUnderTest = new[]
				{
					"Test",
					"Test1",
					"Test2",
					"Test10",
					"Six",
					"Four"
				};

				Assert.That(systemUnderTest.MaxBy(arg => arg.Length), Is.EqualTo("Test10"));
			}
		}

		[TestFixture]
		public class When_retrieving_object_by_a_minimum_value
		{
			[Test]
			public void Must_retrieve_correct_object()
			{
				var systemUnderTest = new[]
				{
					"Test",
					"Test1",
					"Test2",
					"Test10",
					"Six",
					"Four"
				};

				Assert.That(systemUnderTest.MinBy(arg => arg.Length), Is.EqualTo("Six"));
			}
		}
	}
}