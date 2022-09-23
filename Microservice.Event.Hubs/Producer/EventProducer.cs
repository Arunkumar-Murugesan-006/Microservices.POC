using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Event.Hubs.Producer
{
    public class EventProducer
    {
        string ConnectionString = "Endpoint=sb://akmeventhubdemo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=quvwM65M2jhlIfHLS4Knx1Xonqk71es7nw1PO4zemAo=";
        string EventHubName = "testeventhub";
        public async Task Produce_Event(string comments)
        {
            var producer = new EventHubBufferedProducerClient(ConnectionString, EventHubName);

            producer.SendEventBatchFailedAsync += args =>
            {
                Debug.WriteLine($"Publishing failed for {args.EventBatch.Count} events.  Error: '{args.Exception.Message}'");
                return Task.CompletedTask;
            };

            producer.SendEventBatchSucceededAsync += args =>
            {
                Debug.WriteLine($"{args.EventBatch.Count} events were published to partition: '{args.PartitionId}.");
                return Task.CompletedTask;
            };
            try
            {
                var eventData = new EventData(comments);

                await producer.EnqueueEventAsync(eventData);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error occruied {0}. Try again later", exp.Message);
            }
            finally
            {
                await producer.CloseAsync();
            }
        }
    }
}
