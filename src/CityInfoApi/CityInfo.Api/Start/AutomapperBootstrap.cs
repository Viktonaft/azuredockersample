using AutoMapper;
using CityInfo.API.Models;
using CityInfo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Api.Start
{
	public static class AutoMapperBootstrap
	{
		public static void Configure()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<City, CityDto>();
				cfg.CreateMap<City, CityWithoutPointsOfInterestDto>();
				cfg.CreateMap<CityForCreationDto, City>();
				cfg.CreateMap<CityForUpdateDto, City>();
				cfg.CreateMap<PointOfInterest, PointOfInterestDto>();
				cfg.CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
				cfg.CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();
			});

		}
	}
}
