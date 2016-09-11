using AutoMapper;
using iAsset.App.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iAsset.App.Web.Models;
namespace iAsset.App.Web
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}
