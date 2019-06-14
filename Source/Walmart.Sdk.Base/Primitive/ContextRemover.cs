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

namespace Walmart.Sdk.Base.Primitive
{
	using System;
	using System.Runtime.CompilerServices;
	using System.Threading;

	public struct ContextRemover : INotifyCompletion
	{
		public bool IsCompleted => SynchronizationContext.Current == null;

		public void OnCompleted(Action continuation)
		{
			SynchronizationContext prevContext = SynchronizationContext.Current;
			if (prevContext == null)
			{
				continuation();
				return;
			}
			try
			{
				SynchronizationContext.SetSynchronizationContext(null);
				continuation();
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(prevContext);
			}
		}

		public ContextRemover GetAwaiter()
		{
			return this;
		}

		public void GetResult()
		{
			// no need to return any value here
			// the purpose is to remove context
		}
	}
}
