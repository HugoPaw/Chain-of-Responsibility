public interface IHandler
{
    IHandler SetNext(IHandler handler);
    string Handle(string request);
}

// Basisklasse für gemeinsame Logik
abstract class Handler : IHandler
{
    private IHandler _next;

    public IHandler SetNext(IHandler handler)
    {
        _next = handler;
        return handler;
    }

    public virtual string Handle(string request)
    {
        return _next?.Handle(request);
    }
}

class InternetSupport : Handler
{
    public override string Handle(string request)
    {
        if (request == "Router Problem")
            return "Support: Bitte Router neustarten.";
        return base.Handle(request);
    }
}

class TechnikSupport : Handler
{
    public override string Handle(string request)
    {
        if (request == "Leitung kaputt")
            return "Technik: Wir schicken einen Techniker vorbei.";
        return base.Handle(request);
    }
}

// Benutzung
var level1 = new InternetSupport();
var level2 = new TechnikSupport();
level1.SetNext(level2);

Console.WriteLine(level1.Handle("Leitung kaputt"));
