using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TTAPI_Init_Worker_XT;


namespace TTAPIMVVMU.Model
{
    public class ServerTTapi :IConnection
    {
        public void Connect()
        {
            {
                // Dictates whether TT API will be started on its own thread
                bool startOnSeparateThread = true;

                if (startOnSeparateThread)
                {
                    // Start TT API on a separate thread
                    TTAPIFunctions tf = new TTAPIFunctions();
                    Thread workerThread = new Thread(tf.Start);
                    workerThread.Name = "TT API Thread";
                    workerThread.Start();

                    // Insert other code here that will run on this thread
                }
                else
                {
                    // Start the TT API on the same thread
                    using (TTAPIFunctions tf = new TTAPIFunctions())
                    {
                        tf.Start();
                    }
                }
            }
        }
    }
}
