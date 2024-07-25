namespace Extension
{
    public static class Extension
    {
        public static List<T> Filter<T>(this List<T> records,Func<T,bool> func)
        {
            var list  = new List<T>();
            foreach (var record in records)
            {
                if (func(record))
                    list.Add(record);
            }
            return list;
        }

    }
}
