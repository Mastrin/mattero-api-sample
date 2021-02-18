using System;

namespace Integration.Sample.Common
{
	public class Disposable : IDisposable
	{
		protected bool IsDisposed { get; private set; }

		private string _objectName;

		private string ObjectName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_objectName))
					_objectName = this.GetType().Name;

				return _objectName;
			}
		}

		~Disposable()
			=> Dispose(false);

		public void CheckDisposed()
		{
			if (IsDisposed)
				throw new ObjectDisposedException(ObjectName);
		}

		public void Dispose()
			=> Dispose(true);

		public void Dispose(bool isDisposing)
		{
			if (isDisposing)
				this.DisposeManaged();

			IsDisposed = true;
			GC.SuppressFinalize(this);
		}

		public virtual void DisposeManaged() { }
	}
}