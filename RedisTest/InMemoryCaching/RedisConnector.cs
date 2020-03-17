using StackExchange.Redis;

namespace RedisWPF_CRUD.RedisDBOperations
{
    public class RedisConnector
    {
        public static IDatabase GetRedisInstance()
        {
            return
                ConnectionMultiplexer
                .Connect("localhost")
                .GetDatabase();
        }


        public static ISubscriber GetRedisSubscriber()
        {
            return
                ConnectionMultiplexer
                .Connect("localhost")
                .GetSubscriber();
        }

    }
}
