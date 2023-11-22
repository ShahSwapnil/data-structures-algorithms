namespace algorithms;

public interface IAlgoLogger
{
    void Info(string message);

    void Info(string format, params object[] args);
    void Warn(string message);

    void Warn(string format, params object[] args);
    void Error(string message);

    void Error(string format, params object[] args);
}
