﻿using ApiServer.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Extensions
{
    public static class HostExtension
    {
        public static IHost ConsumeMessage(this IHost host)
        {
            /*ServiceProvider service = host.Services as ServiceProvider;
            service.Get*/
            ConsumerKafka consumer = host.Services.GetService<ConsumerKafka>();
            consumer.ConsumeMessage();
            return host;
        }
    }
}
