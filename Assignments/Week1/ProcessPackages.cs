using System;
using System.Collections.Generic;
using System.Linq;
using Assignments.Common;

namespace Assignments.Week1
{
    internal class Request
    {
        public readonly int ArrivalTime;
        public readonly int ProcessTime;

        public Request(int arrivalTime, int processTime)
        {
            ArrivalTime = arrivalTime;
            ProcessTime = processTime;
        }
    }

    internal class Response
    {
        public bool Dropped;
        public int StartTime;

        public static Response DroppedResponse => new Response
        {
            Dropped = true,
            StartTime = -1
        };
    }

    internal class Buffer
    {
        private readonly int _size;
        private LinkedList<int> _queue = new LinkedList<int>();

        public Buffer(int size)
        {
            _size = size;
        }

        public Response Process(Request request)
        {
            if (_size == 0)
            {
                return Response.DroppedResponse;
            }
            var response = new Response
            {
                Dropped = false,
                StartTime = request.ArrivalTime
            };
            if (_queue.Count == _size)
            {
                var minCompleteTime = _queue.First.Value;
                if (response.StartTime >= minCompleteTime)
                {
                    _queue.RemoveFirst();
                }
                else
                {
                    return Response.DroppedResponse;
                }
            }
            if (_queue.Count > 0)
            {
                response.StartTime = Math.Max(response.StartTime, _queue.Last.Value);
            }
            _queue.AddLast(response.StartTime + request.ProcessTime);
            return response;
        }
    }

    /// <summary>
    /// Task. You are given a series of incoming network packets, and your task is to simulate their processing.
    /// Packets arrive in some order. For each packet number 𝑖, you know the time when it arrived 𝐴𝑖 and the
    /// time it takes the processor to process it 𝑃𝑖 (both in milliseconds). There is only one processor, and it
    /// processes the incoming packets in the order of their arrival. If the processor started to process some
    /// packet, it doesn’t interrupt or stop until it finishes the processing of this packet, and the processing of
    /// packet 𝑖 takes exactly 𝑃𝑖 milliseconds.
    /// 
    /// The computer processing the packets has a network buffer of fixed size 𝑆. When packets arrive,
    /// they are stored in the buffer before being processed. However, if the buffer is full when a packet
    /// arrives (there are 𝑆 packets which have arrived before this packet, and the computer hasn’t finished
    /// processing any of them), it is dropped and won’t be processed at all. If several packets arrive at the
    /// same time, they are first all stored in the buffer (some of them may be dropped because of that —
    /// those which are described later in the input). The computer processes the packets in the order of
    /// their arrival, and it starts processing the next available packet from the buffer as soon as it finishes
    /// processing the previous one. If at some point the computer is not busy, and there are no packets in
    /// the buffer, the computer just waits for the next packet to arrive. Note that a packet leaves the buffer
    /// and frees the space in the buffer as soon as the computer finishes processing it.
    /// Input Format. The first line of the input contains the size 𝑆 of the buffer and the number 𝑛 of incoming
    /// network packets. Each of the next 𝑛 lines contains two numbers. 𝑖-th line contains the time of arrival
    /// 𝐴𝑖 and the processing time 𝑃𝑖 (both in milliseconds) of the 𝑖-th packet. It is guaranteed that the
    /// sequence of arrival times is non-decreasing (however, it can contain the exact same times of arrival in
    /// milliseconds — in this case the packet which is earlier in the input is considered to have arrived earlier).
    /// 
    /// Constraints. All the numbers in the input are integers. 1 ≤ 𝑆 ≤ 105
    /// ; 1 ≤ 𝑛 ≤ 10^5; 0 ≤ 𝐴𝑖 ≤ 10^6; 0 ≤ 𝑃𝑖 ≤ 10^3; 𝐴𝑖 ≤ 𝐴𝑖+1 for 1 ≤ 𝑖 ≤ 𝑛 − 1.
    /// 
    /// Output Format. For each packet output either the moment of time (in milliseconds) when the processor
    /// began processing it or −1 if the packet was dropped (output the answers for the packets in the same
    /// order as the packets are given in the input).
    /// </summary>
    public class ProcessPackages : IAssignment
    {
        private const string NewLine = "\r\n";

        private static List<Response> ProcessRequests(IEnumerable<Request> requests, Buffer buffer)
        {
            var responses = new List<Response>();
            foreach (var request in requests)
            {
                responses.Add(buffer.Process(request));
            }
            return responses;
        }

        private static string FormatResponses(IEnumerable<Response> responses)
        {
            var res = responses.Select(response =>
            {
                if (response.Dropped)
                {
                    return -1;
                }
                return response.StartTime;
            });
            return string.Join(NewLine, res);
        }

        public string Execute(string[] args)
        {
            var scanner = new Scanner(args);
            var bufferMaxSize = scanner.NextInt();
            var buffer = new Buffer(bufferMaxSize);
            var requestsCount = scanner.NextInt();
            scanner.NextLine();
            var requests = new List<Request>();
            for (var i = 0; i < requestsCount; i++)
            {
                requests.Add(new Request(
                    arrivalTime: scanner.NextInt(),
                    processTime: scanner.NextInt()
                ));
                scanner.NextLine();
            }

            var responses = ProcessRequests(requests, buffer);
            return FormatResponses(responses);
        }
    }
}