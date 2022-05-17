namespace BigCalculator.UnitTests.Service
{
    using System.Collections.Generic;
    using System.Xml.Linq;
    using BigCalculator.Core;
    using BigCalculator.Service;
    using Core;
    using Xunit;

    public class ConvertorUnitTests
    {
        private readonly IConvertor convertor;

        public ConvertorUnitTests()
        {
            convertor = new Convertor();
        }

        [Fact]
        public void Given_FromStringToIntArray_When_StringNumberIsCorrect_Then_ConversionIsSuccessfully()
        {
            // Arrange
            string number = "2519782156712612756126137613421375";
            int[] expected = new[]
            {
                2, 5, 1, 9, 7, 8, 2, 1, 5, 6, 7, 1, 2, 6, 1, 2, 7, 5, 6, 1, 2, 6, 1, 3, 7, 6, 1, 3, 4, 2, 1, 3, 7, 5
            };

            //Act
            var result = convertor.FromStringToIntArray(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromStringToIntArray_When_StringNumberIsEmpty_Then_ConversionReturnZero()
        {
            // Arrange
            string number = "";
            int[] expected = new[] { 0 };

            //Act
            var result = convertor.FromStringToIntArray(number);

            //Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Given_FromStringToIntArray_When_NumberIsNull_Then_ConversionReturnZero()
        {
            // Arrange
            string number = null;
            int[] expected = new[] { 0 };

            //Act
            var result = convertor.FromStringToIntArray(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromIntArrayToString_When_ArrayIsACorrectNumber_Then_ConversionIsSuccessfully()
        {
            // Arrange
            int[] number = new[]
            {
                5, 6, 9, 8, 7, 4, 5, 6, 1, 2, 3, 6, 5, 9, 8, 7, 9, 9, 6, 3, 5, 6, 4, 8, 9, 6, 5, 3, 2, 1, 5, 9, 8, 7, 4,
                5
            };
            string expected = "569874561236598799635648965321598745";

            //Act
            var result = convertor.FromIntArrayToString(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromIntArrayToString_When_ArrayIsEmpty_Then_ResultIsEmptyString()
        {
            // Arrange
            int[] number = new int[] { };
            string expected = "";

            //Act
            var result = convertor.FromIntArrayToString(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_FromIntArrayToString_When_ArrayIsNull_Then_ResultIsEmptyString()
        {
            // Arrange
            int[] number = null;
            string expected = "-1";

            //Act
            var result = convertor.FromIntArrayToString(number);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Given_XmlToData_When_XMLIsCorrect_Then_ResultIsConvertedSuccessfully()
        {
        // Arrange
            string xmlData = "<?xml version=" + '\u0022' + "1.0" + '\u0022' + " encoding=" + '\u0022' + "UTF - 8" + '\u0022' + @"?>
                          <data> 
                            <expression>
                                <operand>a</operand>
                                <operator>+</operator>
                                <operand>b</operand>
                                <operator>*</operator>
                                <parenthesis>
                                    <operand>c</operand>
                                    <operator>+</operator>
                                    <operand>d</operand>
                                </parenthesis>
                                <operator>+</operator>
                                <operand>e</operand>
                            </expression>

                            <terms>
                                <term>
                                    <name>a</name>
                                    <value>100</value>
                                </term>
                                <term>
                                    <name>b</name>
                                    <value>101</value>
                                </term>
                                <term>
                                    <name>c</name>
                                    <value>102</value>
                                </term>
                                <term>
                                    <name>d</name>
                                    <value>103</value>
                                </term>
                                <term>
                                    <name>e</name>
                                    <value>104</value>
                                </term>
                            </terms>
                        </data>";
            XElement xml = XElement.Parse(xmlData);
            Data expected = new()
            {
                Expression = "a+b*(c+d)+e",
                Terms = new List<Term>
                {
                    new Term { Name = "a", Value = "100" },
                    new Term { Name = "b", Value = "101" },
                    new Term { Name = "c", Value = "102" },
                    new Term { Name = "d", Value = "103" },
                    new Term { Name = "e", Value = "104" }
                }
            };

            //Act
            var result = convertor.XmlToData(xml);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
