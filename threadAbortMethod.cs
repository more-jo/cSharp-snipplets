using System;  
using System.Threading;  
using System.Diagnostics; 

namespace workingofabort {  
    class akshay {  
        static Thread th;  
        static void ChildThread() {  
            try {  
                throw new Exception();  
            } catch (Exception) {  
                try {  
                    Console.WriteLine("thread are going to sleep mode");  
                    Thread.Sleep(5000);  
                    Console.WriteLine("now thread is out of sleep");  
                } catch (ThreadAbortException e) {  
                    Console.WriteLine(e.ToString());  
                }  
            }  
        }  

        static void Console_CancelKeyPress(Object sender, ConsoleCancelEventArgs e) {  
            Console.WriteLine("aborting");  
            if (th != null) 
            {  
                th.Abort();  
                th.Join();  
            }
        }  

        static void Main(string[] args) {  
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);  
            th = new Thread(ChildThread);  
            th.Start();  
            th.Join();  
            Console.Read();  
        }  
    }  
} 