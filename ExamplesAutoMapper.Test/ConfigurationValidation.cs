

using System;
using System.Diagnostics;
using AutoMapper;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Model.ConfigurationValidation;
using ExamplesAutoMapper.Model.Dto;
using ExamplesAutoMapper.Model.Projection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Configuration Validation
    /// </summary>
    [TestClass]
    public class ConfigurationValidation
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
