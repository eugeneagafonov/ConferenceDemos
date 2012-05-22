using System.Threading;

namespace AsyncMVCOld
{
	/// <summary>Extension methods for CancellationToken.</summary>
	public static class CancellationTokenExtensions
	{
		/// <summary>Cancels a CancellationTokenSource and throws a corresponding OperationCanceledException.</summary>
		/// <param name="source">The source to be canceled.</param>
		public static void CancelAndThrow(this CancellationTokenSource source)
		{
			source.Cancel();
			source.Token.ThrowIfCancellationRequested();
		}
	}
}