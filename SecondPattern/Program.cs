using System;
using System.Collections.Generic;


interface IObserver
{
    void Update(string message);
}


class GaiPost : IObserver
{
    public string Name { get; private set; }

    public GaiPost(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"Пост ГАИ {Name} получил сообщение: {message}");
    }
}


class MessagePublisher
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void PublishMessage(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        GaiPost post1 = new GaiPost("Пост 1");
        GaiPost post2 = new GaiPost("Пост 2");
        GaiPost post3 = new GaiPost("Пост 3");

   
        MessagePublisher publisher = new MessagePublisher();


        publisher.AddObserver(post1);
        publisher.AddObserver(post2);
        publisher.AddObserver(post3);


        publisher.PublishMessage("Внимание! Новое сообщение!");

       
        publisher.RemoveObserver(post2);

     
        publisher.PublishMessage("Еще одно сообщение!");

        Console.ReadKey();
    }
}
