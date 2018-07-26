

public interface IPath<T>
{
	T DerivativeAt(T _arg, float _value);
	T ValueAt(T _arg, float _value);
	float approximate(T _arg);
	float locate(T _arg);
	float approxLength(int _value);

}
