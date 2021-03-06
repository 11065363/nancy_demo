﻿using Nancy;

namespace NancyDemo1
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override IRootPathProvider RootPathProvider
          {
              get
              {
                  return new CustomRootPathProvider();
              }
          }
    }
}