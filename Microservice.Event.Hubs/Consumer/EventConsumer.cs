using Azure.Messaging.EventHubs.Consumer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Hubs.Consumer
{
    public class EventConsumer
    {
        string ConnectionString = "Endpoint=sb://akmeventhubdemo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=quvwM65M2jhlIfHLS4Knx1Xonqk71es7nw1PO4zemAo=";
        string EventHubName = "testeventhub";
        string Consumergroup = "$Default";

        public async Task Consume_Event()
        {
            EventHubConsumerClient eventConsumer = new EventHubConsumerClient(Consumergroup, ConnectionString, EventHubName);
            try
            {
                int loopTicks = 0;
                int maximumTicks = 10;
                var options = new ReadEventOptions
                {
                    MaximumWaitTime = TimeSpan.FromSeconds(1)
                };

                await foreach (PartitionEvent partitionEvent in eventConsumer.ReadEventsAsync(options))
                {
                    if (partitionEvent.Data != null)
                    {
                        string readFromPartition = partitionEvent.Partition.PartitionId;
                        byte[] eventBodyBytes = partitionEvent.Data.EventBody.ToArray();

                        Debug.WriteLine($"Read event of length {eventBodyBytes.Length} from {readFromPartition}");
                    }
                    else
                    {
                        Debug.WriteLine("Wait time elapsed; no event was available.");
                    }
                    loopTicks++;
                    if (loopTicks >= maximumTicks)
                    {
                        break;
                    }
                }
                await Task.CompletedTask;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error occruied {0}. Try again later", exp.Message);
            }
            finally
            {
                await eventConsumer.CloseAsync();
            }
        }
    }
}
