namespace CachingDecorator
{
    public static class Decorators
    {
        public static Func<TResult> Caching<TResult>(Func<TResult> func)
        {
            var cached = false;

            TResult cache = default(TResult);

            return () =>
            {
                if (cached)
                {
                    return cache;
                }

                var result = func();

                cached = true;
                cache = result;

                return result;
            };
        }

        public static Func<TArg1, TResult> Caching<TArg1, TResult>(Func<TArg1, TResult> func)
        {
            var cache = new Dictionary<string, TResult>();

            return arg1 =>
            {
                var key = arg1.ToString();

                if (cache.ContainsKey(key))
                {
                    return cache[key];
                }

                var result = func(arg1);

                cache[key] = result;

                return result;
            };
        }

        public static Func<TArg1, TArg2, TResult> Caching<TArg1, TArg2,TResult>(Func<TArg1, TArg2, TResult> func)
        {
            var cache = new Dictionary<string, TResult>();

            return (arg1, arg2) =>
            {
                var key = arg1.ToString() + arg2.ToString();

                if (cache.ContainsKey(key))
                {
                    return cache[key];
                }

                var result = func(arg1, arg2);

                cache[key] = result;

                return result;
            };
        }

        public static Func<TArg1, TArg2, TArg3, TResult> Caching<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, TResult> func)
        {
            var cache = new Dictionary<string, TResult>();

            return (arg1, arg2, arg3) =>
            {
                var key = arg1.ToString() + arg2.ToString() + arg3.ToString();

                if (cache.ContainsKey(key))
                {
                    return cache[key];
                }

                var result = func(arg1, arg2, arg3);

                cache[key] = result;

                return result;
            };
        }
    }
}
