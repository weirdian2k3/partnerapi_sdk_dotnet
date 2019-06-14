﻿/**
Copyright (c) 2018-present, Walmart Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using Walmart.Sdk.Base.Http;
using Walmart.Sdk.Base.Http.Retry;

namespace Walmart.Sdk.Base.Primitive
{
	public abstract class BaseApiClient : IApiClient, IEndpointClient
	{
		protected IHttpFactory httpFactory = new HttpFactory();

		protected IHandler httpHandler;
		public IEndpointHttpHandler GetHttpHandler()
		{
			return httpHandler;
		}

		protected Config.IEndpointConfig config;
		public Config.IEndpointConfig GetEndpointConfig()
		{
			return config;
		}

		public BaseApiClient(Config.IApiClientConfig cfg)
		{
			config = cfg;
			httpHandler = httpFactory.GetHttpHandler(cfg);
		}

		public bool SimulationEnabled
		{
			get => httpHandler.SimulationEnabled;
			set => httpHandler.SimulationEnabled = value;
		}

		public IRetryPolicy RetryPolicy
		{
			get => httpHandler.RetryPolicy;
			set => httpHandler.RetryPolicy = value;
		}

		public ILoggerAdapter Logger
		{
			get => LoggerContainer.Logger;
			set => LoggerContainer.Logger = value;
		}
	}
}
