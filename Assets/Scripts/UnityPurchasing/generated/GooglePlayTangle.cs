// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("7R0Hm10zAA9pD7IfltbyTOC8E8Q1mIoPuT9v8B0JZwYhn3HKZ0Twb51zQrHD85rP9eu8gYZWfvRoCwAQUgkUgy1Fb6nGMVUBYTW68oxa6TO538HmPaKOLoWW1eNanGE5v9wEGvpLv1hzxqbo15dt+Oykw0jJGl17a5QBAqDHPZi1ESTZpVVGeqqPi9cmzTOjK+GsZHxdDSNSTbLwPgp5msNATkFxw0BLQ8NAQEHPpZeheXesccNAY3FMR0hrxwnHtkxAQEBEQUJ/CXsVlqMX5k4vbcVEfVr0+gvU8XB4/n/ntcv2OIdR/Da8LjRnFuxjPwRQGeP3J3shxf1IyJXVZGMzBedsrnt5X+K8IyN0qfJbe1hERokBI1xIhnRUv1ElKENCQEFA");
        private static int[] order = new int[] { 9,10,2,13,8,8,11,8,10,9,13,12,12,13,14 };
        private static int key = 65;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
