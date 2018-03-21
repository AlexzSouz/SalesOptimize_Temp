using FluentAssertions;
using Moq;
using SalesOptimize.OneToManyMapper.Composite;
using SalesOptimize.OneToManyMapper.Composite.Abstractions;
using SalesOptimize.OneToManyMapper.Exceptions;
using SalesOptimize.OneToManyMapper.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SalesOptimize.OneToManyMapper.Tests
{
	public class MapperDecoratorTests
	{
		[Theory]
		[InlineData(1, 1)]
		public void MapperDecorator_ShouldHaveMethodAdd_CalledWithExpectedArguments(int parent, int child)
		{
			// Arrange
			bool isValidCall = false;
			int p = 1;
			int c = 1;

			var mapperStub = new Mock<IOneToManyMapper>();
			mapperStub
				.Setup(a => a.Add(p, c))
				.Callback(() =>
				{
					isValidCall = true;
				});

			// Act
			mapperStub.Object.Add(parent, child);

			// Assert
			isValidCall.Should().BeTrue();
		}

		[Theory]
		[InlineData(1, 1)]
		public void CompositeMapperProvider_ShouldThrow_ExistingParentIdentifierException(int p, int c)
		{
			// Arrange
			var mapper = new CompositeMapperProvider();

			// Act
			mapper.Add(p, c);

			// Assert
			mapper
				.Invoking(a => a.Add(p, c))
				.Should()
				.Throw<ExistingParentIdentifierException>();
		}

		[Fact]
		public void StructValueUnderlineValue1_ShouldBeEqualWithEqualOperator_IntValue1()
		{
			// Arrange
			var sValue = new Value(1);
			int iValue = 1;

			// Act
			bool areEqual = sValue == iValue;
			
			// Assert
			areEqual.Should().BeTrue();
		}

		[Fact]
		public void StructValueUnderlineValue1_ShouldBeEqualWithEqualsMethod_IntValue1()
		{
			// Arrange
			var sValue = new Value(1);
			int iValue = 1;

			// Act
			bool areEqual = sValue.Equals(iValue);

			// Assert
			areEqual.Should().BeTrue();
		}

		[Fact]
		public void StructValueUnderlineValue1_ShouldBeNotEqual_IntValue2()
		{
			// Arrange
			var sValue = new Value(1);
			int iValue = 2;

			// Act
			bool notEqual = sValue != iValue;

			// Assert
			notEqual.Should().BeTrue();
		}
	}
}