﻿using System;

namespace Nest.CommonAbstractions.Reactive
{
	internal static class CoordinatedRequestDefaults
	{
		public static int BulkAllMaxDegreeOfParallelismDefault = 20;
		public static TimeSpan BulkAllBackOffTimeDefault = TimeSpan.FromMinutes(1);
		public static int BulkAllBackOffRetriesDefault = 0;
		public static int BulkAllSizeDefault = 1000;
	}

	public abstract class CoordinatedRequestObserverBase<T> : IObserver<T>
	{
		private readonly Action<T> _onNext;
		private readonly Action<Exception> _onError;
		private readonly Action _completed;

		protected CoordinatedRequestObserverBase(Action<T> onNext = null, Action<Exception> onError = null, System.Action completed = null)
		{
			_onNext = onNext;
			_onError = onError;
			_completed = completed;
		}

		public void OnNext(T value)
		{
			this._onNext?.Invoke(value);
		}

		public void OnError(Exception error)
		{
			this._onError?.Invoke(error);
		}

		public void OnCompleted()
		{
			this._completed?.Invoke();
		}
	}
}
