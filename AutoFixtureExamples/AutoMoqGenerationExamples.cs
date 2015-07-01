using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace AutoFixtureExamples
{
    [TestFixture]
    public class AutoMoqGenerationExamples
    {
        [Test]
        public void AutoMoqConstructorInterfacesWithoutAutoConfigure()
        {
            IFixture fixture = new Fixture().Customize(new AutoMoqCustomization());

            SutWithConstructorDependencies sut = fixture.Create<SutWithConstructorDependencies>();

            // Assert
            sut.Dependency1.Should().NotBeNull();
            sut.Dependency1.SomeStringProperty.Should().BeNullOrEmpty();
        }


        [Test]
        public void AutoMoqConstructorInterfacesWithAutoConfigure()
        {
            IFixture fixture = new Fixture();
            fixture.Customize(new AutoConfiguredMoqCustomization());

            string expectedStringProperty = "BlahBlah";
            fixture.Inject<string>(expectedStringProperty);
            SutWithConstructorDependencies sut = fixture.Create<SutWithConstructorDependencies>();

            // Assert
            sut.Dependency1.SomeStringProperty.Should().NotBeNullOrEmpty();
            sut.Dependency1.SomeStringProperty.Should().Be(expectedStringProperty);
        }

    }

    public class SutWithConstructorDependencies
    {
        public string StringProperty { get; set; }

        public SutWithConstructorDependencies(IDependency1 dependency1)
        {
            Dependency1 = dependency1;
        }

        public IDependency1 Dependency1 { get; set; }
    }

    public interface IDependency1
    {
        string SomeStringProperty { get; set; }
    }

    public interface IDependency2
    {
        void DoLotsOfStuff();
    }
}
