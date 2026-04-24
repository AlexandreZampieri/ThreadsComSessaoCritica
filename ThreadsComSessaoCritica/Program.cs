using System;
using System.IO;
using System.Threading;

class Program
{
    static int qtdeThreads = 20;
    static int linhasPorThread = 500;

    static StreamWriter writer;
    static object trava = new object();

    static void Escrever()
    {
        for (int i = 0; i < linhasPorThread; i++)
        {
            string linha = $"Thread {Thread.CurrentThread.ManagedThreadId} escreveu linha {i}";

            lock (trava)
            {
                writer.WriteLine(linha);
            }

            Thread.Sleep(1);
        }
    }

    static void Main()
    {
        writer = new StreamWriter("log_com_trava.txt");

        Thread[] threads = new Thread[qtdeThreads];

        for (int i = 0; i < qtdeThreads; i++)
        {
            threads[i] = new Thread(Escrever);
            threads[i].Start();
        }

        foreach (Thread t in threads)
            t.Join();

        writer.Close();

        Console.WriteLine("Execução finalizada COM trava.");
        Console.WriteLine("Esperado: 10000 linhas.");
    }
}