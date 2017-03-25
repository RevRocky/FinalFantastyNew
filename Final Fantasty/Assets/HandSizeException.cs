public class HandSizeException : System.Exception
{
	public HandSizeException() : base() { }
	public HandSizeException(string message) : base(message) { }
	public HandSizeException(string message, System.Exception inner) : base(message, inner) { }

	// A constructor is needed for serialization when an
	// exception propagates from a remoting server to the client. 
	protected HandSizeException(System.Runtime.Serialization.SerializationInfo info,
		System.Runtime.Serialization.StreamingContext context) { }
}