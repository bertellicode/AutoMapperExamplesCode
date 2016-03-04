

using AutoMapper;
using ExamplesAutoMapper.Model.ListAndArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Source = ExamplesAutoMapper.Model.ConfigurationValidation.Source;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Configuration Validation
    /// </summary>
    [TestClass]
    public class ConfigurationValidationTest
    {

        [TestMethod]
        public void AutoMapperConfigurationValidationSuccessMethod()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Source, DestinationDto>()
                                                        .ForMember(dest => dest.SomeValuefff, opt => opt.Ignore())
                                                 );

            config.AssertConfigurationIsValid();

        }

        [TestMethod]
        public void AutoMapperConfigurationValidationFailMethod()
        {

            var config = new MapperConfiguration(cfg =>cfg.CreateMap<Source, DestinationDto>());

            config.AssertConfigurationIsValid();

        }

    }
}
